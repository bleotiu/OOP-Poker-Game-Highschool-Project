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
using Poker_App;

namespace Poker_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// inchiderea aplicatiei
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program was made by Bleotiu (a.k.a. Bleo)\n It is a Poker Simulator");
        }

        private void fontDialog2_Apply(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_Game();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            New_Game();
        }
        private void New_Game()
        {
            Thread SampleThread1=new Thread(new ThreadStart( Game_Thread ) );
            SampleThread1.Start();
        }
        static void Game_Thread()
        {
            Form2 F;
            F = new Form2();
            F.StartGame();
            Application.Run(F);
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
