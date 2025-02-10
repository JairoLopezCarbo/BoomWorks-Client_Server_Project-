namespace BoomWords
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GameLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.GamenameLabel = new System.Windows.Forms.Label();
            this.SyllableLabel = new System.Windows.Forms.Label();
            this.WordBox = new System.Windows.Forms.TextBox();
            this.BoomTimer = new System.Windows.Forms.Timer(this.components);
            this.RunDelay = new System.Windows.Forms.Timer(this.components);
            this.BombBox = new System.Windows.Forms.PictureBox();
            this.ExplosionPictureBox = new System.Windows.Forms.PictureBox();
            this.ExplosionTimer = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.LeaveButton = new System.Windows.Forms.Button();
            this.InviteButton = new System.Windows.Forms.Button();
            this.InviteGrid = new System.Windows.Forms.DataGridView();
            this.InvitedUsers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SendInvitationButton = new System.Windows.Forms.Button();
            this.BackInvitationButton = new System.Windows.Forms.Button();
            this.AvatarBox = new System.Windows.Forms.PictureBox();
            this.WinTimer = new System.Windows.Forms.Timer(this.components);
            this.MiddleBomb = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BombBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplosionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InviteGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLabel
            // 
            this.GameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameLabel.Font = new System.Drawing.Font("Rockwell", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLabel.Location = new System.Drawing.Point(15, -1);
            this.GameLabel.Name = "GameLabel";
            this.GameLabel.Size = new System.Drawing.Size(840, 57);
            this.GameLabel.TabIndex = 0;
            this.GameLabel.Text = "BOOMWORDS";
            this.GameLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.BackColor = System.Drawing.Color.Black;
            this.UsernameLabel.Font = new System.Drawing.Font("Rockwell", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(363, 394);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(140, 31);
            this.UsernameLabel.TabIndex = 24;
            this.UsernameLabel.Text = "User";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GamenameLabel
            // 
            this.GamenameLabel.BackColor = System.Drawing.Color.Transparent;
            this.GamenameLabel.Font = new System.Drawing.Font("Rockwell", 15F);
            this.GamenameLabel.Location = new System.Drawing.Point(667, 30);
            this.GamenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GamenameLabel.Name = "GamenameLabel";
            this.GamenameLabel.Size = new System.Drawing.Size(195, 30);
            this.GamenameLabel.TabIndex = 25;
            this.GamenameLabel.Text = "GameName";
            this.GamenameLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // SyllableLabel
            // 
            this.SyllableLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.SyllableLabel.Font = new System.Drawing.Font("Rockwell", 15F, System.Drawing.FontStyle.Bold);
            this.SyllableLabel.ForeColor = System.Drawing.Color.White;
            this.SyllableLabel.Location = new System.Drawing.Point(388, 286);
            this.SyllableLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SyllableLabel.Name = "SyllableLabel";
            this.SyllableLabel.Size = new System.Drawing.Size(93, 41);
            this.SyllableLabel.TabIndex = 27;
            this.SyllableLabel.Text = "SYL";
            this.SyllableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WordBox
            // 
            this.WordBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.WordBox.Enabled = false;
            this.WordBox.Font = new System.Drawing.Font("Rockwell", 12F);
            this.WordBox.ForeColor = System.Drawing.Color.Black;
            this.WordBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.WordBox.Location = new System.Drawing.Point(363, 443);
            this.WordBox.Margin = new System.Windows.Forms.Padding(5);
            this.WordBox.Name = "WordBox";
            this.WordBox.Size = new System.Drawing.Size(139, 31);
            this.WordBox.TabIndex = 33;
            this.WordBox.TabStop = false;
            this.WordBox.Text = "WORD";
            this.WordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckWord);
            this.WordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BlockKeys);
            // 
            // BoomTimer
            // 
            this.BoomTimer.Interval = 20000;
            this.BoomTimer.Tick += new System.EventHandler(this.BoomTimer_Tick);
            // 
            // RunDelay
            // 
            this.RunDelay.Interval = 3000;
            this.RunDelay.Tick += new System.EventHandler(this.RunDelay_Tick);
            // 
            // BombBox
            // 
            this.BombBox.BackColor = System.Drawing.Color.Transparent;
            this.BombBox.Image = global::BoomWords.Properties.Resources.BombOFF;
            this.BombBox.Location = new System.Drawing.Point(373, 222);
            this.BombBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BombBox.Name = "BombBox";
            this.BombBox.Size = new System.Drawing.Size(133, 139);
            this.BombBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BombBox.TabIndex = 34;
            this.BombBox.TabStop = false;
            // 
            // ExplosionPictureBox
            // 
            this.ExplosionPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.ExplosionPictureBox.BackgroundImage = global::BoomWords.Properties.Resources.Explosion_Animation;
            this.ExplosionPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExplosionPictureBox.Location = new System.Drawing.Point(373, 240);
            this.ExplosionPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExplosionPictureBox.Name = "ExplosionPictureBox";
            this.ExplosionPictureBox.Size = new System.Drawing.Size(133, 121);
            this.ExplosionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExplosionPictureBox.TabIndex = 39;
            this.ExplosionPictureBox.TabStop = false;
            this.ExplosionPictureBox.Visible = false;
            // 
            // ExplosionTimer
            // 
            this.ExplosionTimer.Interval = 1000;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Black;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Rockwell", 16F, System.Drawing.FontStyle.Bold);
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(37, 481);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(167, 39);
            this.StartButton.TabIndex = 59;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Visible = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LeaveButton
            // 
            this.LeaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LeaveButton.BackColor = System.Drawing.Color.Maroon;
            this.LeaveButton.FlatAppearance.BorderSize = 0;
            this.LeaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.LeaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.LeaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaveButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.LeaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LeaveButton.Location = new System.Drawing.Point(719, 540);
            this.LeaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(136, 38);
            this.LeaveButton.TabIndex = 60;
            this.LeaveButton.Text = "Leave";
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // InviteButton
            // 
            this.InviteButton.BackColor = System.Drawing.Color.Black;
            this.InviteButton.FlatAppearance.BorderSize = 0;
            this.InviteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InviteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InviteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InviteButton.Font = new System.Drawing.Font("Rockwell", 16F, System.Drawing.FontStyle.Bold);
            this.InviteButton.ForeColor = System.Drawing.Color.White;
            this.InviteButton.Location = new System.Drawing.Point(37, 535);
            this.InviteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InviteButton.Name = "InviteButton";
            this.InviteButton.Size = new System.Drawing.Size(167, 39);
            this.InviteButton.TabIndex = 61;
            this.InviteButton.Text = "Invite";
            this.InviteButton.UseVisualStyleBackColor = false;
            this.InviteButton.Visible = false;
            this.InviteButton.Click += new System.EventHandler(this.InviteButton_Click);
            // 
            // InviteGrid
            // 
            this.InviteGrid.AllowUserToAddRows = false;
            this.InviteGrid.AllowUserToDeleteRows = false;
            this.InviteGrid.AllowUserToResizeColumns = false;
            this.InviteGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Rockwell", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InviteGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.InviteGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InviteGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.InviteGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.InviteGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InviteGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.InviteGrid.ColumnHeadersHeight = 29;
            this.InviteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.InviteGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvitedUsers});
            this.InviteGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InviteGrid.DefaultCellStyle = dataGridViewCellStyle9;
            this.InviteGrid.EnableHeadersVisualStyles = false;
            this.InviteGrid.Location = new System.Drawing.Point(37, 370);
            this.InviteGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InviteGrid.MultiSelect = false;
            this.InviteGrid.Name = "InviteGrid";
            this.InviteGrid.ReadOnly = true;
            this.InviteGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.InviteGrid.RowHeadersVisible = false;
            this.InviteGrid.RowHeadersWidth = 51;
            this.InviteGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Rockwell", 12F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.InviteGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.InviteGrid.RowTemplate.Height = 24;
            this.InviteGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InviteGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InviteGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InviteGrid.ShowCellErrors = false;
            this.InviteGrid.ShowCellToolTips = false;
            this.InviteGrid.ShowEditingIcon = false;
            this.InviteGrid.ShowRowErrors = false;
            this.InviteGrid.Size = new System.Drawing.Size(167, 190);
            this.InviteGrid.TabIndex = 63;
            this.InviteGrid.Visible = false;
            this.InviteGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InviteGrid_CellClick);
            // 
            // InvitedUsers
            // 
            this.InvitedUsers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.InvitedUsers.DefaultCellStyle = dataGridViewCellStyle8;
            this.InvitedUsers.FillWeight = 30F;
            this.InvitedUsers.HeaderText = "Invite Users";
            this.InvitedUsers.MinimumWidth = 2;
            this.InvitedUsers.Name = "InvitedUsers";
            this.InvitedUsers.ReadOnly = true;
            this.InvitedUsers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InvitedUsers.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SendInvitationButton
            // 
            this.SendInvitationButton.BackColor = System.Drawing.Color.Black;
            this.SendInvitationButton.FlatAppearance.BorderSize = 0;
            this.SendInvitationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendInvitationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendInvitationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendInvitationButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.SendInvitationButton.ForeColor = System.Drawing.Color.White;
            this.SendInvitationButton.Location = new System.Drawing.Point(116, 544);
            this.SendInvitationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendInvitationButton.Name = "SendInvitationButton";
            this.SendInvitationButton.Size = new System.Drawing.Size(80, 31);
            this.SendInvitationButton.TabIndex = 64;
            this.SendInvitationButton.Text = "Send Invitation";
            this.SendInvitationButton.UseVisualStyleBackColor = false;
            this.SendInvitationButton.Visible = false;
            this.SendInvitationButton.Click += new System.EventHandler(this.SendInvitationButton_Click);
            // 
            // BackInvitationButton
            // 
            this.BackInvitationButton.BackColor = System.Drawing.Color.Black;
            this.BackInvitationButton.FlatAppearance.BorderSize = 0;
            this.BackInvitationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackInvitationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackInvitationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackInvitationButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.BackInvitationButton.ForeColor = System.Drawing.Color.White;
            this.BackInvitationButton.Location = new System.Drawing.Point(28, 544);
            this.BackInvitationButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackInvitationButton.Name = "BackInvitationButton";
            this.BackInvitationButton.Size = new System.Drawing.Size(36, 31);
            this.BackInvitationButton.TabIndex = 65;
            this.BackInvitationButton.Text = "◀️";
            this.BackInvitationButton.UseVisualStyleBackColor = false;
            this.BackInvitationButton.Visible = false;
            this.BackInvitationButton.Click += new System.EventHandler(this.BackInvitationButton_Click);
            // 
            // AvatarBox
            // 
            this.AvatarBox.BackColor = System.Drawing.Color.RoyalBlue;
            this.AvatarBox.Image = global::BoomWords.Properties.Resources.Av_1;
            this.AvatarBox.Location = new System.Drawing.Point(363, 425);
            this.AvatarBox.Margin = new System.Windows.Forms.Padding(0);
            this.AvatarBox.Name = "AvatarBox";
            this.AvatarBox.Size = new System.Drawing.Size(140, 129);
            this.AvatarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AvatarBox.TabIndex = 66;
            this.AvatarBox.TabStop = false;
            // 
            // WinTimer
            // 
            this.WinTimer.Interval = 5000;
            this.WinTimer.Tick += new System.EventHandler(this.WinTimer_Tick);
            // 
            // MiddleBomb
            // 
            this.MiddleBomb.Interval = 20000;
            this.MiddleBomb.Tick += new System.EventHandler(this.MiddleBomb_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoomWords.Properties.Resources.BackGroundImage;
            this.ClientSize = new System.Drawing.Size(869, 592);
            this.Controls.Add(this.AvatarBox);
            this.Controls.Add(this.SyllableLabel);
            this.Controls.Add(this.BackInvitationButton);
            this.Controls.Add(this.SendInvitationButton);
            this.Controls.Add(this.InviteButton);
            this.Controls.Add(this.LeaveButton);
            this.Controls.Add(this.BombBox);
            this.Controls.Add(this.GamenameLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.InviteGrid);
            this.Controls.Add(this.ExplosionPictureBox);
            this.Controls.Add(this.GameLabel);
            this.Controls.Add(this.WordBox);
            this.Controls.Add(this.StartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Game";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BombBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplosionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InviteGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AvatarBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label GamenameLabel;
        private System.Windows.Forms.Label SyllableLabel;
        private System.Windows.Forms.TextBox WordBox;
        private System.Windows.Forms.Timer BoomTimer;
        private System.Windows.Forms.Timer RunDelay;
        private System.Windows.Forms.PictureBox BombBox;
        private System.Windows.Forms.PictureBox ExplosionPictureBox;
        private System.Windows.Forms.Timer ExplosionTimer;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.Button InviteButton;
        private System.Windows.Forms.DataGridView InviteGrid;
        private System.Windows.Forms.Button SendInvitationButton;
        private System.Windows.Forms.Button BackInvitationButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvitedUsers;
        private System.Windows.Forms.PictureBox AvatarBox;
        private System.Windows.Forms.Timer WinTimer;
        private System.Windows.Forms.Timer MiddleBomb;
    }
}