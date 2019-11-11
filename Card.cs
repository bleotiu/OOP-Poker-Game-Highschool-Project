using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Poker_App
{
    
    class Card
    {
        private int x;
        //private string CurrentAdress;
        private string Picture;
        public const string imagePath = @"Cards/";
        public Card(int a)
        {
            this.x = a;
            //this.picture = new PictureBox();
            //this.picture.Width = 75;
            //this.picture.Height = 100;
            //this.picture.Image = Image.FromFile(imagePath + GetStringValue() + "_of_" + GetStringSymbol() + ".png");
            //this.picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture = imagePath + GetStringValue() + "_of_" + GetStringSymbol() + ".png";
        }
        private string GetStringValue()
        {
            int v = this.x % 13 +2;
            switch (v)
            {
                case 14: return "ace";
                case 13: return "king";
                case 12: return "queen";
                case 11: return "jack";
                default: return v.ToString();
            }
        }
        private string GetStringSymbol()
        {
            int v = this.x / 13;
            switch (v)
            {
                case 0: return "clubs";
                case 1: return "diamonds";
                case 2: return "hearts";
                default: return "spades";
            }
        }
        public void ShowCard(PictureBox p)
        {
            p.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Image=Image.FromFile(this.Picture);
        }
    }
}
