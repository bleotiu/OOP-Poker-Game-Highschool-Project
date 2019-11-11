using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Poker_App
{
    public partial class Form2 : Form
    {
        private Game G;
        public Form2()
        {
            InitializeComponent();
        }
        public void StartGame()
        {
            G = new Game(CpuBalance, CpuBet, UserBalance, UserBet, Pot, HandName, WinChance);
            PictureBox[] Table=new PictureBox[5];
            PictureBox[] CPU = new PictureBox[2];
            Button[] B = new Button[3];
            B[0] = FoldButton;
            B[1] = RaiseButton;
            B[2] = AllInButton;
            Table[0] = flop1;
            Table[1] = flop2;
            Table[2] = flop3;
            Table[3] = turncard;
            Table[4] = rivercard;
            CPU[0] = cpu1;
            CPU[1] = cpu2;
            G.Init(usercard1, usercard2,Table,CPU,CallButton,B,RaiseValue);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void epicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print("This Application!");
        }


        private void Print(string a)
        {
            MessageBox.Show(a);
        }

        private void awesomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print("You!");
        }

        private void boringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print("Other Applications!");
        }

        private void awfulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print("Other people who are not using this awesome application!");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void FoldButton_Click(object sender, EventArgs e)
        {
            G.Fold(2);
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            G.Call(2);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void AllInButton_Click(object sender, EventArgs e)
        {
            G.AllIn(2);
        }

        private void RaiseButton_Click(object sender, EventArgs e)
        {
            G.Raise(2);
        }

        private void pokerHandRankingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread T = new Thread(new ThreadStart(Rank));
            T.Start();
        }
        private void Rank()
        {
            Image R = Image.FromFile(@"rankings.jpg");
            PictureBox ranking = new PictureBox();
            ranking.Image = R;
            ranking.Size = R.Size;
            ranking.SizeMode = PictureBoxSizeMode.StretchImage;
            Form F = new Form();
            F.Text = "Poker Hand Rankings";
            F.StartPosition = FormStartPosition.CenterScreen;
            F.Size = R.Size;
            F.Icon = this.Icon;
            F.Controls.Add(ranking);
            ranking.Anchor = AnchorStyles.None;
            F.ShowDialog();
        }
    }
}
