using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_App
{
    class Hand
    {
        private int[] cards=new int[7] , C=new int[5] , V=new int[15] , pk=new int[52];
        /// <summary>
        /// pk[i]=1=>the i-th card from the deck
        /// C[i]=how many cards of the colour i are in this hand
        /// V[i]=how many cards with the number i are in this hand
        /// cards = the codes for the cards in this hand
        /// </summary>
        private int l;
        private int x, y;
        public int k;
        //k-nr mana//x,y datele auxiliare,exemplu full x=3,y=2;
        private int mx,mn,mxi,mni,sets,Q,S,F;
        /// <summary>
        /// Q=1=>quads
        /// F=1->flush
        /// S=1=>straight
        /// </summary>
        /// <param name="v"></param>
        public Hand(int[] v)
        {
            mx = 0; mn = 15; mxi = 0; mni = 55; Q = 0; S = 0; F = 0;
            for (l = 0; l < 15; ++l) V[l] = 0;
            for (l = 0; l < 5; ++l) C[l] = 0;
            for (l = 0; l < 52; ++l) pk[l] = 0;
            for (l = 0; l < 7; ++l)
            {
                if (v[l] >-1) 
                {
                    x = v[l]; y = number(x);
                    this.cards[l] = x;
                    ++C[symbol(x)];
                    ++V[y];
                    ++pk[x];
                    if (x > mxi) mxi = x;
                    if (x < mni) mni = x;
                    if (y > mx) mx = y;
                    if (y < mn) mn = y;
                }
            }
            ///checking for straight
            y = 0;
            for (l = mx; l >= mn && S < 1; --l)///cautarea quintei
            {
                if (V[l] > 0) ++y;
                else y = 0;
                if (y > 4)
                {
                    S = 1;
                    x = l%13 +2;
                }
            }
            if (S<1 && V[0]>0 && V[1]>0  && V[2]>0 && V[3]>0 && V[12]>0)
            {
                S = 1; x = 1;
            }
            ///checking for flush
            for (l = 0; l < 4; ++l) if (C[l] > 4) F = 1;
            srt(this.cards, 7);
            if(F>0 || S>0)
            {
                if(F>0 && S>0)
                {
                    y = 0;
                    ///searching for a random straight flush
                    for (l = mxi; l >= mni && this.k<1; --l)
                    {
                        if (pk[l]>0) ++y;
                        else y = 0;
                        if (y > 4)
                        {
                            this.k = 8;
                            this.x = l % 13+2;
                            for (int i = l - 4; i < l + 1; ++i) this.cards[i - l + 6] = i;
                        }
                        if (l % 13 < 1) y = 0;
                    }
                    ///royal flush checking
                    if (this.x > 7 && this.k == 8) this.k = 9;
                    if(this.k<1)///checking for straight flush from Ace to 5
                    {
                        if (pk[0] > 0 && pk[1] > 0 && pk[2] > 0 && pk[3] > 0 && pk[12] > 0)
                        {
                            this.k = 8;
                            this.x = 1;this.cards[2] = 12;
                            for (int i = 3; i <7 ; ++i) this.cards[i] = i-3;
                        }
                        if (pk[13]>0 && pk[14]>0 && pk[15]>0 && pk[16]>0 && pk[25]>0)
                        {
                            this.k = 8;
                            this.x = 1;this.cards[2] = 25;
                            for (int i = 3; i < 7; ++i) this.cards[i] = i + 10;
                        }
                        if (pk[26]>0 && pk[27]>0 && pk[28]>0 && pk[29]>0 && pk[38]>0)
                        {
                            this.k = 8;
                            this.x = 1; this.cards[2] = 38;
                            for (int i = 3; i < 7; ++i) this.cards[i] = i + 23;
                        }
                        if (pk[39]>0 && pk[40]>0 && pk[41]>0 && pk[42]>0 && pk[51]>0)
                        {
                            this.k = 8;
                            this.x = 1; this.cards[2] = 51;
                            for (int i = 3; i < 7; ++i) this.cards[i] = i + 36;
                        }
                    }
                    ///it's not a straight flush, so it's just a regular flush
                    if (this.k < 1)
                    {
                        flushsort(this.cards, 7); 
                        this.k = 5;
                    }
                }
                else
                {
                    if (F > 0)///flush checking;
                    {
                        this.k = 5;
                        flushsort(this.cards, 7);
                    }
                    else///straight checking;
                    {
                        this.k = 4;
                        if(this.x==1)
                        {
                            this.cards[2] = 12;this.cards[3] = 0;
                            for (int i = 4; i < 7; ++i) this.cards[i] = this.cards[i - 1] + 1;
                        }
                        else
                        {
                            this.cards[2] = this.x - 2;
                            for (int i = 3; i < 7; ++i) this.cards[i] = this.cards[i - 1] + 1;
                        }
                    }
                }
            }
            else
            {
                srt2(cards, 7);//Console.WriteLine();
                //for (int i = 0; i < 7; ++i) Console.Write("{0} ", cards[i]);Console.WriteLine();Console.Write("{0} {1}",V[0],V[2]);
                Q = 0; sets = -1; x = -1; y = -1;
                for (l = 6; l > -1; --l)
                {
                    mn = number(this.cards[l]);
                    if (V[mn] > 3) ///quads checking
                    {
                        Q = 1; this.x = mn;
                        this.k = 7;
                        l -= V[mn]-1;
                    }
                    else
                    {
                        if (V[mn] > 2 && sets<0)
                        {
                            sets = mn; ///sets checking
                            l -= V[mn] - 1;
                        }
                        else
                        {
                            if (V[mn] > 1)///pair checking
                            {
                                if (x < 0)///this is the first pair i find
                                    x = mn;
                                else
                                    if (y < 0)///this is the second pair i find
                                    y = mn; 
                                l -= V[mn] - 1;
                            }
                        }
                    }
                }
                if(Q<1)///no quads found
                {
                    if(sets>-1 && x>-1) ///fullhouse checking
                    {
                        this.k = 6;
                        this.y = x;
                        this.x = sets;
                    }
                    else
                    {
                        if(sets>-1)///sets checking
                        {
                            this.k = 3;
                            this.x = sets;
                        }
                        else
                        {
                            if (y > -1)///two pair checking
                                this.k = 2;
                            else
                            {
                                if (x > -1)///simple pair checking
                                    this.k = 1;
                                else this.k = 0;
                            }
                        }
                    }
                }
            }
        }
        private int symbol(int x)
        {
            return (x / 13);
        }
        private int number(int x)
        {
            return (x % 13);
        }
        /// <summary>
        /// sorting the cards by the number
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        private void srt(int[] a , int n) 
        {
            int i, j, aux;
            for (i = 0; i < n - 1; ++i)
            {
                for (j = i + 1; j < n; ++j)
                {
                    if (a[i] % 13 < a[j] % 13)
                    {
                        aux = a[i]; a[i] = a[j]; a[j] = aux;
                    }
                }
            }
        }
        /// <summary>
        /// sorting the cards by the number of appearences
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        private void srt2(int[] a, int n)
        {
            int i, j, aux;
            for (i = 0; i < n; ++i)
                for (j = i + 1; j < n; ++j)
                    if (V[a[i] % 13] > V[a[j] % 13])
                    {
                        aux = a[i]; a[i] = a[j]; a[j] = aux;
                    }
                    else
                        if( (V[a[i] % 13] == V[a[j] % 13]) && (a[i]%13 > a[j]%13) )
                    {
                        aux = a[i]; a[i] = a[j]; a[j] = aux;
                    }
        }
        /// <summary>
        ///this will order the hand by the card's symbol and value 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="n"></param>
        private void flushsort(int[] a,int n)
        {
            int i, j, aux;
            for (i = 0; i < n; ++i)
                for (j = i + 1; j < n; ++j)
                    if (C[ a[i]/13 ]>C[ a[j]/13 ])
                    {
                        aux = a[i]; a[i] = a[j]; a[j] = aux;
                    }
                    else
                        if (C[a[i] / 13] == C[a[j] / 13] && (a[i]%13>a[j]%13) )
                    {
                        aux = a[i]; a[i] = a[j]; a[j] = aux;
                    }
        }
        public string Name()
        {
            switch(k)
            {
                case 1: return "Pair";
                case 2: return "Double Pair";
                case 3: return "Sets";
                case 4: return "Straight";
                case 5: return "Flush";
                case 6: return "Full House";
                case 7: return "Four of a Kind";
                case 8: return "Straight Flush";
                case 9: return "Royal Flush";
                default: return "High Card";
            }
        }
        public static bool operator > (Hand a,Hand b)
        {
            if (a.k == b.k)/// same hand name
            {
                int i,x,y;
                for (i = 6; i > 1; --i)///searching for the first card that is different
                {
                    x = a.cards[i] % 13;
                    y = b.cards[i] % 13;
                    if (x  > y ) return true;///the first hand is greater 
                    if (x  < y ) return false;///the second hand is greater
                }
                return false;/// equal hands
            }
            ///different hand name
            if (a.k > b.k) return true;///the first is greater 
            return false;///the second is greater
        }
        public static bool operator < (Hand a, Hand b)
        {
            if (a.k == b.k)/// same hand name
            {
                int i, x, y;
                for (i = 6; i > 1; --i)///searching for the first card that is different
                {
                    x = a.cards[i] % 13;
                    y = b.cards[i] % 13;
                    if (x > y) return false;///the first hand is greater 
                    if (x < y) return true;///the second hand is greater
                }
                return false;/// equal hands
            }
            ///different hand name
            if (a.k > b.k) return false;///the first is greater 
            return true;///the second is greater
        }
        public static bool operator == (Hand a, Hand b)
        {
            if (a.k == b.k)/// same hand name
            {
                int i, x, y;
                for (i = 6; i > 1; --i)///searching for the first card that is different
                {
                    x = a.cards[i] % 13;
                    y = b.cards[i] % 13;
                    if (x != y) return false;
                }
                return true;/// equal hands
            }
            ///different hand name
            return false;
        }
        public static bool operator !=(Hand a, Hand b)
        {
            if (a.k == b.k)/// same hand name
            {
                int i, x, y;
                for (i = 6; i > 1; --i)///searching for the first card that is different
                {
                    x = a.cards[i] % 13;
                    y = b.cards[i] % 13;
                    if (x != y) return true;
                }
                return false;/// equal hands
            }
            ///different hand name
            return true;
        }
        public void afis()
        {
            for (int i = 0; i < 7; ++i) Console.Write("{0} ", cards[i]);
            Console.WriteLine();
        }
    }
}
