using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Drawing;
using System.Windows.Input;

namespace Poker_App
{
    class Game
    {
        Hand curr;
        public Button CC = new Button();
        public Button[] buttons = new Button[3];
        private TextBox RaiseSum = new TextBox();
        private int cnt = 0;//number of the games
        private int dcnt = 0;
        private const int blind = 50;
        private bool first = false, finished = false,nxt=false;
        private int table_dim = 0;
        private bool[] butt = new bool[4];
        private int last_act;
        /// <summary>
        /// 1 call
        /// 2 check
        /// 3 raise
        /// </summary>
        private Label cpu_balance = new Label(),user_balance=new Label();
        private Label cpu_currbet = new Label(),user_currbet=new Label();
        private Label pot_label = new Label(), currhand_label = new Label(), chance_label = new Label();
        private PictureBox pbox1 = new PictureBox(), pbox2 = new PictureBox();
        private PictureBox[] TablePic = new PictureBox[5];
        private PictureBox[] CpuPic = new PictureBox[2];
        private int[] sel=new int[52],csel=new int[52],curr_hand=new int[7];
        private int[] deck=new int[52];
        private int[] player=new int[2], cpu=new int[2], table=new int[5];
        class play
        {
            public int balance,currbet;
            public double[,] rc = new double[52, 52];
            public double[] tc = new double[52];
            public double chance;
            public play()
            {
                balance = 1500;
            }
        };
        private play user=new play(), john=new play();
        private int pot;
        /// <summary>
        /// chance-the chance to win the pot after the flop is known
        /// rc[x][y]-the chance to win the pot after x and y card are on the turn and river
        /// tc[x]-the chance to win the pot after x card is on the turn
        /// player - user's cards
        /// cpu - cpu's cards
        /// table - contains the flop,the turn and the river
        /// </summary>
        int i, j, aux, cmp;
        Random random = new Random();
        /// <summary>
        /// deck shuffle
        /// </summary>
        public Game(Label l1,Label l2,Label l3,Label l4,Label l5,Label l6,Label l7)
        {
            cpu_balance = l1; cpu_currbet=l2;
            user_balance = l3;user_currbet = l4;
            pot_label = l5;currhand_label = l6;
            chance_label = l7;
            Shuffle();
        }
        private void Shuffle()
        {/**/
            for (i = 0; i < 52; ++i)
            {
                deck[i] = i;
                sel[i] = 0;
            }
            for (i = 0; i < 52; ++i)
            {
                for (j = 0; j < 52; ++j)
                {
                    cmp = random.Next(2);
                    if (cmp > 0)
                    {
                        aux = deck[i];
                        deck[i] = deck[j];
                        deck[j] = aux;
                    }
                }
            }/**/
            /*/deck[0] = 12;deck[1] = 1;deck[2] = 19;deck[3] = 9;    //SPECIFIED HAND TESTING5 
            deck[5] = 3;deck[7] = 30; deck[9] = 18;
            deck[11] = 2; deck[15] = 26;/**/
        }
        public void Init( PictureBox box1,PictureBox box2,PictureBox[] v,PictureBox[] c,Button call_check,Button[] B,TextBox text)
        {
            int i,payed;
            bool d = false;
            if (cnt < 1)
                for (i = 0; i < 4; ++i) butt[i] = true;
            for (i = 0; i < 5; ++i)
            TablePic[i] = v[i];
            for (i = 0; i < 2; ++i)
            CpuPic[i] = c[i];
            CC = call_check;
            for (i = 0; i < 3; ++i)
                buttons[i] = B[i];
            CC.Text = "Call"; buttons[1].Text = "Raise";
            RaiseSum = text;
            ResetTable();finished = false;
            dcnt = 0;first = false;nxt = false;
            table_dim = 0;
            pot = 0;
            pot_label.Text = " ";
            cnt++;
            last_act = 0;
            for (i = 0; i < 52; ++i)
            {
                csel[i] = 0;
                sel[i] = 0;
            }
            pbox1 = box1;
            pbox2 = box2;
            player[0] = deck[0];
            sel[deck[0]] = 1;
            player[1] = deck[1];
            sel[deck[1]] = 1;
            cpu[0] = deck[2];
            sel[deck[2]] = 1;
            cpu[1] = deck[3];
            sel[deck[3]] = 1;
            Card a, b;
            a = new Card(player[0]);
            b = new Card(player[1]);
            a.ShowCard(box1);
            b.ShowCard(box2);
            GetChance(user, 0, player);
            GetChance(john, 0, cpu);
            chance_label.Text = user.chance.ToString(".00");
            if (player[0] % 13 == player[1] % 13) currhand_label.Text = "Pair";
            else currhand_label.Text = "High Card";
            curr_hand[0] = player[0]; curr_hand[1] = player[1];
            for (i = 2; i < 7; ++i) curr_hand[i] = -1;
            if (cnt%2==0)
            {///cpu begins
                payed = min(blind/2, john.balance);
                payed = min(payed, user.balance);
                john.currbet = payed;
                john.balance -= payed;
                payed = min(john.currbet + john.balance, blind);
                payed = min(payed, user.balance);
                user.balance -= payed;
                user.currbet = payed;
                cpu_balance.Text = john.balance.ToString();
                cpu_currbet.Text = john.currbet.ToString();
                user_balance.Text = user.balance.ToString();
                user_currbet.Text = user.currbet.ToString();
                if (user.balance < blind * 2) butt[1] = false;
                LockButtons();
                Thread.Sleep(200);
                if (user.currbet != john.currbet) {  d = true; Decision(); }
            }
            else
            {///the user begins
                payed = min(blind/2, user.balance);
                payed = min(payed, john.balance);
                user.balance -= payed;
                user.currbet = payed;
                payed = min(blind , user.balance + user.currbet);
                payed = min(payed, john.balance);
                john.currbet = payed;
                john.balance -= payed;
                cpu_balance.Text = john.balance.ToString();
                cpu_currbet.Text = john.currbet.ToString();
                user_balance.Text = user.balance.ToString();
                user_currbet.Text = user.currbet.ToString();
                Thread.Sleep(200);
                if (user.balance < blind * 2) butt[1] = false;
                if (user.currbet != john.currbet) UnlockButtons();
            }
            
            if (user.currbet == john.currbet && d==false)SkipToEnd();
        }
        private int min(int a,int b)
        {
            if (a < b) return a;
            return b;
        }
        private int max(int a, int b)
        {
            if (a > b) return a;
            return b;
        }
        private void NewGame()
        {
            Thread.Sleep(2000);
            Shuffle();
            ResetTable();
            Init(pbox1, pbox2,TablePic,CpuPic,CC,buttons,RaiseSum);
        }
        private void CH()
        {
            GetChance(user, 3, player);
            GetChance(john, 3, cpu);
        }
        private void ResetTable()
        {
            for (int i = 0; i < 5; ++i) { TablePic[i].Image = TablePic[i].BackgroundImage; TablePic[i].SizeMode = PictureBoxSizeMode.StretchImage; }
            for (int i = 0; i < 2; ++i) { CpuPic[i].Image = CpuPic[i].BackgroundImage; CpuPic[i].SizeMode = PictureBoxSizeMode.StretchImage; }
        }
        private void SwapButton()
        {
            if (CC.Text == "Call")
                CC.Text = "Check";
            else
                CC.Text = "Call";
            if (buttons[1].Text == "Raise")
                buttons[1].Text = "Bet";
            else
                buttons[1].Text = "Raise";
        }
        private void LockButtons()
        {
            CC.Enabled = false;
            for (int i = 0; i < 3; ++i)
                buttons[i].Enabled = false;
        }
        private void UnlockButtons()
        {
            if(butt[3] || CC.Text=="Check")CC.Enabled = true;
            for (int i = 0; i < 3; ++i)
                if (butt[i])buttons[i].Enabled = true;
        }
        public void Fold(int x)
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            if (x==1)
            {
                MessageBox.Show("You won the pot, but the almighty CPU is still not beaten yet!\nKeep your concentration and take down that CPU!");
                voice.SpeakAsync("You won the pot, but the almighty CPU is still not beaten yet!\nKeep your concentration and take down that CPU!");
                pot += user.currbet + john.currbet;
                user.currbet = 0; john.currbet = 0;
                user.balance += pot;
                pot = 0;
                user_balance.Text = user.balance.ToString();
                user_currbet.Text = user.currbet.ToString();
                ResetTable();
                NewGame();
            }
            else
            {
                MessageBox.Show("You have lost the pot, but you are not defeated yet!\n Keep trying!");
                voice.SpeakAsync("You have lost the pot, but you are not defeated yet!\n Keep trying!");
                pot += user.currbet + john.currbet;
                user.currbet = 0;john.currbet = 0;
                john.balance += pot;
                pot = 0;
                cpu_balance.Text = john.balance.ToString();
                cpu_currbet.Text = john.currbet.ToString();
                ResetTable();
                NewGame();
            }
        }
        /// <summary>
        /// shows the next card(s) on the table
        /// </summary>
        /// <param name="dim"></param>
        private async void Next(int x)
        {
            LockButtons();dcnt = 0;
            if (table_dim < 1)
            {
                Card a;
                table_dim = 3;
                table[0] = deck[5];
                sel[deck[5]] = 1; csel[deck[5]] = 1;
                table[1] = deck[7];
                sel[deck[7]] = 1; csel[deck[7]] = 1;
                table[2] = deck[9];
                sel[deck[9]] = 1; csel[deck[9]] = 1;
                curr_hand[2] = table[0]; curr_hand[3] = table[1]; curr_hand[4] = table[2];
                Thread Chance = new Thread(new ThreadStart(CH));
                Chance.Start();
                await Task.Delay(1500);
                a = new Card(deck[5]);
                a.ShowCard(TablePic[0]);
                await Task.Delay(1500);
                a = new Card(deck[7]);
                a.ShowCard(TablePic[1]);
                await Task.Delay(1500);
                a = new Card(deck[9]);
                a.ShowCard(TablePic[2]);
                chance_label.Text = user.chance.ToString(".00");
                curr= new Hand(curr_hand);
                currhand_label.Text = curr.Name();
            }
            else
            {
                if (table_dim < 4)
                {
                    Card a;
                    table_dim++;
                    table[3] = deck[11];
                    sel[deck[11]] = 1; csel[deck[11]] = 1;
                    curr_hand[5] = deck[11];
                    await Task.Delay(2000);
                    a = new Card(deck[11]);
                    a.ShowCard(TablePic[3]);
                    chance_label.Text = user.tc[deck[11]].ToString(".00");
                    curr = new Hand(curr_hand);
                    currhand_label.Text = curr.Name();
                }
                else
                {
                    Card a;
                    table_dim++;
                    table[4] = deck[15];
                    sel[deck[15]] = 1; csel[deck[15]] = 1;
                    curr_hand[6] = deck[15];
                    await Task.Delay(2500);
                    a = new Card(deck[15]);
                    a.ShowCard(TablePic[4]);
                    chance_label.Text = user.rc[deck[11],deck[15]].ToString(".00");
                    curr = new Hand(curr_hand);
                    currhand_label.Text = curr.Name();
                }
            }
            await Task.Delay(2000);
            if (x == 1) Decision();
            nxt = false;
            UnlockButtons();
        }
        public void Call(int x)
        {
            if(last_act<2 || last_act>2)///call
            {
                int payed;
                if (x == 1)///cpu action
                {
                    payed = min(user.currbet, john.currbet + john.balance);
                    john.balance -= payed - john.currbet;
                    john.currbet = payed;
                    user.balance += user.currbet - payed;
                    user.currbet = payed;
                    user_balance.Text = user.balance.ToString();
                    user_currbet.Text = user.currbet.ToString();
                    cpu_balance.Text = john.balance.ToString();
                    cpu_currbet.Text = john.currbet.ToString();
                    if (john.balance < blind * 2) butt[1] = false;
                    if (last_act == 1 || last_act==3)
                    {
                        dcnt++;
                        if ((dcnt % 2 == 0 && last_act==1)||(dcnt%2==1 && last_act==3 && john.currbet>0 &&user.currbet>0) )
                        {
                            pot += user.currbet + john.currbet;
                            pot_label.Text = pot.ToString();
                            john.currbet = 0;
                            user.currbet = 0;
                            cpu_currbet.Text = john.currbet.ToString();
                            user_currbet.Text = user.currbet.ToString();
                            if (john.balance > 0 && user.balance > 0)
                            {
                                if (table_dim > 4)
                                {
                                    Finish();
                                    finished = true;
                                }
                                else
                                { if (CC.Text == "Call") SwapButton(); Next(2); nxt = true; }
                            }
                            else SkipToEnd();
                        }
                    }
                    else
                    {
                        UnlockButtons();
                        dcnt = 1;
                    }
                    if (finished == false)
                    {
                        last_act = 1;
                        if (first == false)
                        {
                            first = true;
                            last_act = 2;
                            SwapButton();
                        }
                    }
                    //else finished = false;
                }
                else///user action
                {
                    payed = min(john.currbet, user.currbet + user.balance);
                    user.balance -= payed - user.currbet;
                    user.currbet = payed;
                    john.balance += john.currbet - payed;
                    john.currbet = payed;
                    user_balance.Text = user.balance.ToString();
                    user_currbet.Text = user.currbet.ToString();
                    cpu_balance.Text = john.balance.ToString();
                    cpu_currbet.Text = john.currbet.ToString();
                    if (user.balance < blind * 2 ) butt[1] = false;
                    if (last_act == 1|| last_act==3 )
                    {
                        dcnt++;
                        if ((dcnt % 2 == 0 && last_act == 1) || (dcnt % 2 == 1 && last_act == 3 && john.currbet > 0 && user.currbet > 0) )
                        {
                            if (john.balance > 0 && user.balance > 0)
                            {
                                pot += john.currbet + user.currbet;
                                john.currbet = 0;
                                user.currbet = 0;
                                pot_label.Text = pot.ToString();
                                cpu_currbet.Text = john.currbet.ToString();
                                user_currbet.Text = user.currbet.ToString();
                                if (table_dim > 4)
                                {
                                    Finish();
                                    finished = true;
                                }
                                else
                                {
                                    { if(CC.Text=="Call")SwapButton(); Next(1); nxt = true; }
                                }
                            }
                            else SkipToEnd();
                        }
                    }
                    else dcnt = 1;
                    if (finished == false)
                    {
                        last_act = 1;
                        if (first == false)
                        {
                            first = true;
                            last_act = 2;
                            SwapButton();
                        }
                        LockButtons();
                        if (nxt == false) Decision();
                        else nxt = false;
                    }
                    //else finished = false;
                }
            }
            else///check
            {
                if(x == 1)///cpu action
                {
                    if (last_act == 2)
                    {
                        dcnt++;
                        if (dcnt % 2 == 0)
                        {
                            if (john.balance > 0 && user.balance > 0)
                            {
                                pot += john.currbet + user.currbet;
                                pot_label.Text = pot.ToString();
                                john.currbet = 0;
                                user.currbet = 0;
                                cpu_currbet.Text = john.currbet.ToString();
                                user_currbet.Text = user.currbet.ToString();
                                if (table_dim > 4)
                                {
                                    Finish();
                                    finished = true;
                                }
                                else
                                Next(2);
                            }
                            else SkipToEnd();
                        }
                    }
                    else
                    {
                        UnlockButtons();
                        dcnt = 1;
                    }
                    if (finished == false) last_act = 2;
                    //else finished = false;
                }
                else///user action
                {
                    if (last_act == 2)
                    {
                        dcnt++;
                        if (dcnt % 2 == 0)
                        {
                            pot += john.currbet + user.currbet;
                            pot_label.Text = pot.ToString();
                            john.currbet = 0;
                            user.currbet = 0;
                            cpu_currbet.Text = john.currbet.ToString();
                            user_currbet.Text = user.currbet.ToString();
                            if (table_dim > 4)
                            {
                                Finish();
                                finished = true;
                            }
                            else
                            {
                                Next(1);nxt = true;
                            }
                        }
                    }
                    else dcnt = 1;
                    if (finished == false)
                    {
                        last_act = 2;
                        LockButtons();
                        if (nxt == false) Decision();
                        else nxt = false;
                    }
                    //else finished = false;
                }
            }
        }
        private int UnselectedCard(int k)
        {
            if (csel[k] < 1) return k;
            if(50-k>k)
            {
                while (csel[k] > 0) ++k;
                return k;
            }
            while (csel[k] < 1) --k;
            return k;
        }
        private void GetChance(play a,int dim,int[] hand)
        {
            Random r = new Random();
            int i, j;
            double ans, win = 0, lost = 0/*,matches=0*/;
            int[] v = new int[7],w=new int[7];
            ///v-mana lui a
            ///w- mana adversarului
            v[0] = hand[0]; csel[v[0]] = 1;
            v[1] = hand[1]; csel[v[1]] = 1;
            if (dim<1)
            {
                for(i=0;i<100000;++i)
                {
                    for(j=0;j<2;++j)
                    {
                        w[j] = UnselectedCard(r.Next(52));
                        csel[w[j]] = 1;
                    }
                    for (j = 2; j < 7; ++j)
                    {
                        w[j] = UnselectedCard(r.Next(52));
                        csel[w[j]] = 1;
                        v[j] = w[j];
                    }
                    Hand h1 = new Hand(v);
                    Hand h2 = new Hand(w);
                    if(h1.k!=h2.k)
                    {
                        if (h1 < h2)
                            ++lost;
                        else
                            ++win;
                    }
                    for (j = 0; j < 7; ++j)
                        csel[w[j]] = 0;
                }
                ans = win *100/ (win+lost);
                a.chance = ans;
            }
            else
            {
                if(dim<4)
                {
                    double t_win,r_win,t_lost,r_lost;
                    int it1, it2;
                    Hand h1, h2;
                    for(i=2;i<5;++i)
                    {
                        w[i] = table[i - 2];
                        v[i] = w[i];
                    }
                    for(i=51;i>-1;--i)
                    {
                        if (csel[i] > 0) continue;
                        csel[i] = 1;
                        t_win = 0;t_lost = 0;
                        for(j=50;j>-1;--j)
                        {
                            if (csel[j] > 0) continue;
                            csel[j] = 1;
                            r_win = 0; r_lost = 0;
                            for (it1=51;it1>-1;--it1)
                            {
                                if (csel[it1] > 0) continue;
                                csel[it1] = 1;
                                for(it2=it1-1;it2>-1;--it2)
                                {
                                    if (csel[it2] > 0) continue;
                                    w[0] = it1;w[1] = it2;
                                    v[5] = i;v[6] = j;
                                    w[5] = v[5];w[6] = v[6];
                                    h1 = new Hand(v);h2 = new Hand(w);
                                    //if(h1.k!=h2.k)
                                    //{
                                        if (h1 < h2)
                                            ++r_lost;
                                        else
                                            ++r_win;
                                    //}
                                }
                                csel[it1] = 0;
                            }
                            csel[j] = 0;
                            a.rc[i,j] = r_win * 100 / (r_lost+r_win);
                            a.rc[j, i] = a.rc[i, j];
                            t_win += r_win;
                            t_lost += r_lost;
                        }
                        csel[i] = 0;
                        a.tc[i] = t_win * 100 / (t_win+t_lost);
                        win += t_win;
                        lost += t_lost;
                    }
                    a.chance = win * 100 / (win + lost);
                    win += lost;
                }
            }
            csel[v[0]] = 0; csel[v[1]] = 0;
        }
        private void Finish()
        {
            Card C;
            C = new Card(cpu[0]);
            C.ShowCard(CpuPic[0]);
            C = new Card(cpu[1]);
            C.ShowCard(CpuPic[1]);
            Hand a, b;
            SpeechSynthesizer voice = new SpeechSynthesizer();
            int i;
            int[] v = new int[7];
            for (i = 0; i < 5; ++i) v[i] = table[i];
            v[5] = cpu[0];v[6] = cpu[1];
            a = new Hand(v);
            v[5] = player[0];v[6] = player[1];
            b = new Hand(v);
            if (b>a)
            {
                if (john.balance == 0)
                {
                    voice.SpeakAsync("Congratulations! You have defeated the almighty CPU!" +
                            "If you want to try beating him again click New Game in the Options button from the top left!  ");
                    MessageBox.Show("Congratulations! You have defeated the almighty CPU!" +
                            "If you want to try beating him again click New Game in the Options button from the top left!  ");
                    user.balance += pot;
                    pot = 0;
                    pot_label.Text = pot.ToString();
                    user_balance.Text = user.balance.ToString();
                    LockButtons();
                }
                else
                {
                    voice.SpeakAsync("You have won the pot, but the CPU is not beaten yet!");
                    MessageBox.Show("You have won the pot, but the CPU is not beaten yet!");
                    user.balance+= pot;
                    pot = 0;
                    pot_label.Text = pot.ToString();
                    user_balance.Text = user.balance.ToString();
                    if (user.balance >= blind * 2) butt[1] = true;
                    NewGame();
                }
            }
            else
            {
                if(b<a)
                {
                    if (user.balance == 0)
                    {
                        voice.SpeakAsync("Oh no! You have been defeated by the CPU!\n" +
                            "But you can try again by clicking New Game in the Options button from the top left! ");
                        MessageBox.Show("Oh no! You have been defeated by the CPU!\n" +
                            "But you can try again by clicking New Game in the Options button from the top left! ");
                        john.balance += pot;
                        pot = 0;
                        pot_label.Text = pot.ToString();
                        cpu_balance.Text = john.balance.ToString();
                        LockButtons();
                    }
                    else
                    {
                        voice.SpeakAsync("You have lost the pot, but you can still beat the almighty CPU!\n");
                        MessageBox.Show("You have lost the pot, but you can still beat the almighty CPU!\n");
                        john.balance += pot;
                        pot = 0;
                        pot_label.Text = pot.ToString();
                        cpu_balance.Text = john.balance.ToString();
                        NewGame();
                    }
                }
                else
                {
                    voice.SpeakAsync("I can't believe it! It's a tie between you and the CPU, but you have to do better than that!");
                    MessageBox.Show("I can't believe it! It's a tie between you and the CPU,\n but you have to do better than that!");
                    john.balance += pot / 2;
                    user.balance += pot / 2;
                    pot = 0;
                    pot_label.Text = pot.ToString();
                    cpu_balance.Text = john.balance.ToString();
                    user_balance.Text = user.balance.ToString();
                    if (user.balance >= blind * 2) butt[1] = true;
                    NewGame();
                }
            }
        }
        private void Decision()
        {
            /**/SpeechSynthesizer voice = new SpeechSynthesizer();
            Random r = new Random();LockButtons();
            Thread.Sleep(r.Next(3000) + 2000);
            if (john.chance<40)
            {
                if (last_act == 2 || user.currbet<1) { voice.SpeakAsync("Check!"); Call(1); }
                else
                {
                    voice.SpeakAsync("Fold!");
                    Fold(1);
                }
            }
            else
            {
                if(john.chance<70)
                {
                    if (last_act == 2)
                    {
                        if (john.currbet == 0 && user.currbet == 0)
                            voice.SpeakAsync("Bet");
                        else
                            voice.SpeakAsync("Raise");
                        Raise(50);
                    }
                    else
                        if (user.currbet - john.currbet > 300)
                    { voice.SpeakAsync("Fold!"); Fold(1); }
                        else
                    { voice.SpeakAsync(CC.Text); Call(1); }
                }
                else
                {
                    if (r.Next(100) < 40 ||john.balance<=blind)
                    { voice.SpeakAsync("All In!"); AllIn(1); }
                    else
                    {
                        int payed = user.currbet-john.currbet+ (john.balance-user.currbet +john.currbet) * (r.Next(40) + 60) / 100;
                        if (john.currbet == 0 && user.currbet == 0)
                            voice.SpeakAsync("Bet");
                        else
                            voice.SpeakAsync("Raise");
                        payed = max(payed, blind);
                        Raise(payed);
                    }
                }
            }
            UnlockButtons();
        }
        private async void SkipToEnd()
        {
            Card a;
            finished = true;
            LockButtons();
            pot += user.currbet + john.currbet;
            john.currbet = 0;user.currbet = 0;
            cpu_currbet.Text = john.currbet.ToString();
            user_currbet.Text = user.currbet.ToString();
            pot_label.Text = pot.ToString();
            curr_hand[0] = player[0]; curr_hand[1] = player[1];
            if (table_dim < 1)
            {
                table_dim = 5;
                table[0] = deck[5]; table[1] = deck[7]; table[2] = deck[9];
                await Task.Delay(1000); a = new Card(deck[5]); a.ShowCard(TablePic[0]);
                await Task.Delay(1000); a = new Card(deck[7]); a.ShowCard(TablePic[1]);
                await Task.Delay(1000); a = new Card(deck[9]); a.ShowCard(TablePic[2]);
                curr_hand[2] = table[0]; curr_hand[3] = table[1]; curr_hand[4] = table[2];
                table[3] = deck[11];
                await Task.Delay(1000);
                a = new Card(deck[11]); a.ShowCard(TablePic[3]);
                curr_hand[5] = table[3];
                table[4] = deck[15];
                await Task.Delay(1000);
                a = new Card(deck[15]); a.ShowCard(TablePic[4]);
                curr_hand[6] = table[4];
            }
            else
            {
                if (table_dim < 4)
                {
                    table_dim+=2;
                    table[3] = deck[11];
                    await Task.Delay(1000);
                    a = new Card(deck[11]); a.ShowCard(TablePic[3]);
                    curr_hand[5] = table[3];
                    table[4] = deck[15];
                    await Task.Delay(1000);
                    a = new Card(deck[15]); a.ShowCard(TablePic[4]);
                    curr_hand[6] = table[4];
                }
                else
                {
                    if (table_dim < 5)
                    {
                        table_dim++;
                        table[4] = deck[15];
                        await Task.Delay(1000);
                        a = new Card(deck[15]); a.ShowCard(TablePic[4]);
                        curr_hand[6] = table[4];
                    }
                }

            }
            curr = new Hand(curr_hand);
            currhand_label.Text = curr.Name();
            await Task.Delay(1000);
            Finish();
        }
        public void AllIn(int x)
        {
            int payed;
            last_act = 3;dcnt = 0;
            if (x==1)///cpu action
            {
                payed = min(user.currbet + user.balance, john.currbet + john.balance);
                john.balance -= payed - john.currbet;
                john.currbet += payed - john.currbet;
                cpu_currbet.Text = john.currbet.ToString();
                cpu_balance.Text = john.balance.ToString();
                if (CC.Text == "Check") SwapButton();
                if (user.currbet == john.currbet && (user.balance < 1 || john.balance < 1) && !finished)
                {
                    SkipToEnd();
                    finished = true;
                }
            }
            else///user action
            {
                payed = min(user.currbet + user.balance, john.currbet + john.balance);
                user.balance -= payed - user.currbet;
                user.currbet += payed - user.currbet;
                user_currbet.Text = user.currbet.ToString();
                user_balance.Text = user.balance.ToString();
                LockButtons();
                if (user.currbet == john.currbet && (user.balance < 1 || john.balance < 1) && !finished)
                {
                    SkipToEnd();
                    finished = true;
                }
                else Decision();
            }
        }
        public void Raise(int x)
        {
            last_act = 3;dcnt = 0;
            int payed=0,D=0;
            if(x==2)///user action
            {
                D = Valid(RaiseSum.Text);
                if ( D > 0 )
                {
                    if (buttons[1].Text == "Bet") SwapButton();
                    if (D == 1)
                    {
                        if (john.balance >= blind)
                        {
                            user.balance -= john.currbet - user.currbet + blind;
                            user.currbet += john.currbet - user.currbet + blind;
                            user_balance.Text = user.balance.ToString();
                            user_currbet.Text = user.currbet.ToString();
                            Decision();
                        }
                        else AllIn(2);
                    }
                    else
                    {
                        payed = int.Parse(RaiseSum.Text);
                        if (payed < blind) MessageBox.Show("You have to type a raise value at least as big as the blind");
                        else
                        {
                            if (payed > user.balance || payed > john.balance) MessageBox.Show("You can't bet more than what you or the cpu have");
                            else
                            {
                                user.balance -= john.currbet - user.currbet + payed;
                                user.currbet += john.currbet - user.currbet + payed;
                                user_balance.Text = user.balance.ToString();
                                user_currbet.Text = user.currbet.ToString();
                                Decision();
                            }
                        }
                    }
                }
                else MessageBox.Show("You have to type a valid sum");
            }
            else///cpu action
            {
                john.currbet += x;
                john.balance -= x;
                cpu_currbet.Text = john.currbet.ToString();
                cpu_balance.Text = john.balance.ToString();
                UnlockButtons();
                if(CC.Text=="Check")SwapButton();
            }
        }
        private int Valid(string a)
        {
            int dim = a.Length, nr = 0 ,val;
            for (int i = 0; i < dim; ++i)
            {
                if ((a[i] < '0' || a[i] > '9') && a[i] != ' ') return 0;
                else if (a[i] >= '0' && a[i] <= '9') ++nr;
                if (nr > 0 && (a[i] < '0' || a[i] > '9')) return 0;
            }
            if(nr<1)
            { val = 0;return 1; }
            val = int.Parse(a);
            return val;
        }
        /*end of class*/
    }
}
