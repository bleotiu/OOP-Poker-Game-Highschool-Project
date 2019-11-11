namespace Poker_App
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.somethingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.epicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.awesomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.awfulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cpu1 = new System.Windows.Forms.PictureBox();
            this.cpu2 = new System.Windows.Forms.PictureBox();
            this.usercard1 = new System.Windows.Forms.PictureBox();
            this.usercard2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.flop1 = new System.Windows.Forms.PictureBox();
            this.flop2 = new System.Windows.Forms.PictureBox();
            this.flop3 = new System.Windows.Forms.PictureBox();
            this.turncard = new System.Windows.Forms.PictureBox();
            this.rivercard = new System.Windows.Forms.PictureBox();
            this.FoldButton = new System.Windows.Forms.Button();
            this.RaiseValue = new System.Windows.Forms.TextBox();
            this.CallButton = new System.Windows.Forms.Button();
            this.RaiseButton = new System.Windows.Forms.Button();
            this.AllInButton = new System.Windows.Forms.Button();
            this.UserBet = new System.Windows.Forms.Label();
            this.CpuBet = new System.Windows.Forms.Label();
            this.Pot = new System.Windows.Forms.Label();
            this.UserBalance = new System.Windows.Forms.Label();
            this.CpuBalance = new System.Windows.Forms.Label();
            this.WinChance = new System.Windows.Forms.Label();
            this.HandName = new System.Windows.Forms.Label();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pokerHandRankingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usercard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usercard2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turncard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rivercard)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(787, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.somethingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.viewToolStripMenuItem.Text = "See also";
            // 
            // somethingToolStripMenuItem
            // 
            this.somethingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.epicToolStripMenuItem,
            this.awesomeToolStripMenuItem,
            this.boringToolStripMenuItem,
            this.awfulToolStripMenuItem});
            this.somethingToolStripMenuItem.Name = "somethingToolStripMenuItem";
            this.somethingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.somethingToolStripMenuItem.Text = "Something";
            // 
            // epicToolStripMenuItem
            // 
            this.epicToolStripMenuItem.Name = "epicToolStripMenuItem";
            this.epicToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.epicToolStripMenuItem.Text = "Epic";
            this.epicToolStripMenuItem.Click += new System.EventHandler(this.epicToolStripMenuItem_Click);
            // 
            // awesomeToolStripMenuItem
            // 
            this.awesomeToolStripMenuItem.Name = "awesomeToolStripMenuItem";
            this.awesomeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.awesomeToolStripMenuItem.Text = "Awesome";
            this.awesomeToolStripMenuItem.Click += new System.EventHandler(this.awesomeToolStripMenuItem_Click);
            // 
            // boringToolStripMenuItem
            // 
            this.boringToolStripMenuItem.Name = "boringToolStripMenuItem";
            this.boringToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.boringToolStripMenuItem.Text = "Boring";
            this.boringToolStripMenuItem.Click += new System.EventHandler(this.boringToolStripMenuItem_Click);
            // 
            // awfulToolStripMenuItem
            // 
            this.awfulToolStripMenuItem.Name = "awfulToolStripMenuItem";
            this.awfulToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.awfulToolStripMenuItem.Text = "Awful";
            this.awfulToolStripMenuItem.Click += new System.EventHandler(this.awfulToolStripMenuItem_Click);
            // 
            // cpu1
            // 
            this.cpu1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cpu1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cpu1.BackgroundImage")));
            this.cpu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpu1.Location = new System.Drawing.Point(341, 27);
            this.cpu1.Name = "cpu1";
            this.cpu1.Size = new System.Drawing.Size(51, 65);
            this.cpu1.TabIndex = 1;
            this.cpu1.TabStop = false;
            // 
            // cpu2
            // 
            this.cpu2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cpu2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cpu2.BackgroundImage")));
            this.cpu2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cpu2.Location = new System.Drawing.Point(398, 27);
            this.cpu2.Name = "cpu2";
            this.cpu2.Size = new System.Drawing.Size(51, 65);
            this.cpu2.TabIndex = 2;
            this.cpu2.TabStop = false;
            // 
            // usercard1
            // 
            this.usercard1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.usercard1.BackColor = System.Drawing.Color.Transparent;
            this.usercard1.Location = new System.Drawing.Point(341, 318);
            this.usercard1.Name = "usercard1";
            this.usercard1.Size = new System.Drawing.Size(51, 65);
            this.usercard1.TabIndex = 3;
            this.usercard1.TabStop = false;
            // 
            // usercard2
            // 
            this.usercard2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.usercard2.BackColor = System.Drawing.Color.Transparent;
            this.usercard2.Location = new System.Drawing.Point(398, 318);
            this.usercard2.Name = "usercard2";
            this.usercard2.Size = new System.Drawing.Size(51, 65);
            this.usercard2.TabIndex = 4;
            this.usercard2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(153, 162);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(51, 65);
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // flop1
            // 
            this.flop1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flop1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flop1.BackgroundImage")));
            this.flop1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flop1.Location = new System.Drawing.Point(234, 162);
            this.flop1.Name = "flop1";
            this.flop1.Size = new System.Drawing.Size(51, 65);
            this.flop1.TabIndex = 6;
            this.flop1.TabStop = false;
            // 
            // flop2
            // 
            this.flop2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flop2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flop2.BackgroundImage")));
            this.flop2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flop2.Location = new System.Drawing.Point(291, 162);
            this.flop2.Name = "flop2";
            this.flop2.Size = new System.Drawing.Size(51, 65);
            this.flop2.TabIndex = 7;
            this.flop2.TabStop = false;
            // 
            // flop3
            // 
            this.flop3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flop3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("flop3.BackgroundImage")));
            this.flop3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flop3.Location = new System.Drawing.Point(348, 162);
            this.flop3.Name = "flop3";
            this.flop3.Size = new System.Drawing.Size(51, 65);
            this.flop3.TabIndex = 8;
            this.flop3.TabStop = false;
            // 
            // turncard
            // 
            this.turncard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.turncard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("turncard.BackgroundImage")));
            this.turncard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.turncard.Location = new System.Drawing.Point(416, 162);
            this.turncard.Name = "turncard";
            this.turncard.Size = new System.Drawing.Size(51, 65);
            this.turncard.TabIndex = 9;
            this.turncard.TabStop = false;
            // 
            // rivercard
            // 
            this.rivercard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rivercard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rivercard.BackgroundImage")));
            this.rivercard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rivercard.Location = new System.Drawing.Point(487, 162);
            this.rivercard.Name = "rivercard";
            this.rivercard.Size = new System.Drawing.Size(51, 65);
            this.rivercard.TabIndex = 10;
            this.rivercard.TabStop = false;
            // 
            // FoldButton
            // 
            this.FoldButton.BackColor = System.Drawing.Color.Maroon;
            this.FoldButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FoldButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FoldButton.Location = new System.Drawing.Point(29, 414);
            this.FoldButton.Name = "FoldButton";
            this.FoldButton.Size = new System.Drawing.Size(150, 45);
            this.FoldButton.TabIndex = 11;
            this.FoldButton.Text = "Fold";
            this.FoldButton.UseVisualStyleBackColor = false;
            this.FoldButton.Click += new System.EventHandler(this.FoldButton_Click);
            // 
            // RaiseValue
            // 
            this.RaiseValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RaiseValue.ForeColor = System.Drawing.Color.Black;
            this.RaiseValue.Location = new System.Drawing.Point(497, 429);
            this.RaiseValue.Name = "RaiseValue";
            this.RaiseValue.Size = new System.Drawing.Size(100, 20);
            this.RaiseValue.TabIndex = 15;
            // 
            // CallButton
            // 
            this.CallButton.BackColor = System.Drawing.Color.Maroon;
            this.CallButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CallButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CallButton.Location = new System.Drawing.Point(185, 414);
            this.CallButton.Name = "CallButton";
            this.CallButton.Size = new System.Drawing.Size(150, 45);
            this.CallButton.TabIndex = 19;
            this.CallButton.Text = "Call";
            this.CallButton.UseVisualStyleBackColor = false;
            this.CallButton.Click += new System.EventHandler(this.CallButton_Click);
            // 
            // RaiseButton
            // 
            this.RaiseButton.BackColor = System.Drawing.Color.Maroon;
            this.RaiseButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaiseButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RaiseButton.Location = new System.Drawing.Point(341, 416);
            this.RaiseButton.Name = "RaiseButton";
            this.RaiseButton.Size = new System.Drawing.Size(150, 45);
            this.RaiseButton.TabIndex = 20;
            this.RaiseButton.Text = "Raise";
            this.RaiseButton.UseVisualStyleBackColor = false;
            this.RaiseButton.Click += new System.EventHandler(this.RaiseButton_Click);
            // 
            // AllInButton
            // 
            this.AllInButton.BackColor = System.Drawing.Color.Maroon;
            this.AllInButton.Font = new System.Drawing.Font("Modern No. 20", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllInButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.AllInButton.Location = new System.Drawing.Point(603, 416);
            this.AllInButton.Name = "AllInButton";
            this.AllInButton.Size = new System.Drawing.Size(150, 45);
            this.AllInButton.TabIndex = 21;
            this.AllInButton.Text = "All In";
            this.AllInButton.UseVisualStyleBackColor = false;
            this.AllInButton.Click += new System.EventHandler(this.AllInButton_Click);
            // 
            // UserBet
            // 
            this.UserBet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UserBet.AutoSize = true;
            this.UserBet.Location = new System.Drawing.Point(300, 300);
            this.UserBet.Name = "UserBet";
            this.UserBet.Size = new System.Drawing.Size(35, 13);
            this.UserBet.TabIndex = 22;
            this.UserBet.Text = "label1";
            // 
            // CpuBet
            // 
            this.CpuBet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CpuBet.AutoSize = true;
            this.CpuBet.Location = new System.Drawing.Point(456, 95);
            this.CpuBet.Name = "CpuBet";
            this.CpuBet.Size = new System.Drawing.Size(35, 13);
            this.CpuBet.TabIndex = 23;
            this.CpuBet.Text = "label2";
            // 
            // Pot
            // 
            this.Pot.AutoSize = true;
            this.Pot.Location = new System.Drawing.Point(357, 230);
            this.Pot.Name = "Pot";
            this.Pot.Size = new System.Drawing.Size(35, 13);
            this.Pot.TabIndex = 24;
            this.Pot.Text = "label1";
            // 
            // UserBalance
            // 
            this.UserBalance.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UserBalance.AutoSize = true;
            this.UserBalance.Location = new System.Drawing.Point(250, 381);
            this.UserBalance.Name = "UserBalance";
            this.UserBalance.Size = new System.Drawing.Size(35, 13);
            this.UserBalance.TabIndex = 25;
            this.UserBalance.Text = "label1";
            // 
            // CpuBalance
            // 
            this.CpuBalance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CpuBalance.AutoSize = true;
            this.CpuBalance.Location = new System.Drawing.Point(494, 42);
            this.CpuBalance.Name = "CpuBalance";
            this.CpuBalance.Size = new System.Drawing.Size(35, 13);
            this.CpuBalance.TabIndex = 26;
            this.CpuBalance.Text = "label1";
            // 
            // WinChance
            // 
            this.WinChance.AutoSize = true;
            this.WinChance.Location = new System.Drawing.Point(515, 318);
            this.WinChance.Name = "WinChance";
            this.WinChance.Size = new System.Drawing.Size(35, 13);
            this.WinChance.TabIndex = 27;
            this.WinChance.Text = "label1";
            // 
            // HandName
            // 
            this.HandName.AutoSize = true;
            this.HandName.Location = new System.Drawing.Point(515, 348);
            this.HandName.Name = "HandName";
            this.HandName.Size = new System.Drawing.Size(35, 13);
            this.HandName.TabIndex = 28;
            this.HandName.Text = "label1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pokerHandRankingsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // pokerHandRankingsToolStripMenuItem
            // 
            this.pokerHandRankingsToolStripMenuItem.Name = "pokerHandRankingsToolStripMenuItem";
            this.pokerHandRankingsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.pokerHandRankingsToolStripMenuItem.Text = "Poker Hand Rankings";
            this.pokerHandRankingsToolStripMenuItem.Click += new System.EventHandler(this.pokerHandRankingsToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(787, 488);
            this.Controls.Add(this.HandName);
            this.Controls.Add(this.WinChance);
            this.Controls.Add(this.CpuBalance);
            this.Controls.Add(this.UserBalance);
            this.Controls.Add(this.Pot);
            this.Controls.Add(this.CpuBet);
            this.Controls.Add(this.UserBet);
            this.Controls.Add(this.AllInButton);
            this.Controls.Add(this.RaiseButton);
            this.Controls.Add(this.CallButton);
            this.Controls.Add(this.RaiseValue);
            this.Controls.Add(this.FoldButton);
            this.Controls.Add(this.rivercard);
            this.Controls.Add(this.turncard);
            this.Controls.Add(this.flop3);
            this.Controls.Add(this.flop2);
            this.Controls.Add(this.flop1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.usercard2);
            this.Controls.Add(this.usercard1);
            this.Controls.Add(this.cpu2);
            this.Controls.Add(this.cpu1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usercard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usercard2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turncard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rivercard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem somethingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem epicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem awesomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem awfulToolStripMenuItem;
        private System.Windows.Forms.PictureBox cpu1;
        private System.Windows.Forms.PictureBox cpu2;
        private System.Windows.Forms.PictureBox usercard1;
        private System.Windows.Forms.PictureBox usercard2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox flop1;
        private System.Windows.Forms.PictureBox flop2;
        private System.Windows.Forms.PictureBox flop3;
        private System.Windows.Forms.PictureBox turncard;
        private System.Windows.Forms.PictureBox rivercard;
        private System.Windows.Forms.Button FoldButton;
        private System.Windows.Forms.TextBox RaiseValue;
        private System.Windows.Forms.Button CallButton;
        private System.Windows.Forms.Button RaiseButton;
        private System.Windows.Forms.Button AllInButton;
        private System.Windows.Forms.Label UserBet;
        private System.Windows.Forms.Label CpuBet;
        private System.Windows.Forms.Label Pot;
        private System.Windows.Forms.Label UserBalance;
        private System.Windows.Forms.Label CpuBalance;
        private System.Windows.Forms.Label WinChance;
        private System.Windows.Forms.Label HandName;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pokerHandRankingsToolStripMenuItem;
    }
}