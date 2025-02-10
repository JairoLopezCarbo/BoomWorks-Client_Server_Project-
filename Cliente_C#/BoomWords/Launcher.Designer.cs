namespace BoomWords
{
    partial class Launcher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.LeaderBoardGrid = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoomWordsLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordBox = new System.Windows.Forms.MaskedTextBox();
            this.UsernameBox = new System.Windows.Forms.MaskedTextBox();
            this.EnterUserButton = new System.Windows.Forms.Button();
            this.GameBox = new System.Windows.Forms.PictureBox();
            this.HiperTextLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PlayersTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LeaderBoardGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.BackColor = System.Drawing.Color.Transparent;
            this.ConnectionLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.ConnectionLabel.Location = new System.Drawing.Point(13, 327);
            this.ConnectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(195, 32);
            this.ConnectionLabel.TabIndex = 29;
            this.ConnectionLabel.Text = "Connection Parameters";
            this.ConnectionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LeaderBoardGrid
            // 
            this.LeaderBoardGrid.AllowUserToAddRows = false;
            this.LeaderBoardGrid.AllowUserToDeleteRows = false;
            this.LeaderBoardGrid.AllowUserToResizeColumns = false;
            this.LeaderBoardGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Rockwell", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LeaderBoardGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LeaderBoardGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LeaderBoardGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LeaderBoardGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.LeaderBoardGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LeaderBoardGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LeaderBoardGrid.ColumnHeadersHeight = 43;
            this.LeaderBoardGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.LeaderBoardGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.Username,
            this.Score});
            this.LeaderBoardGrid.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LeaderBoardGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.LeaderBoardGrid.EnableHeadersVisualStyles = false;
            this.LeaderBoardGrid.Location = new System.Drawing.Point(409, 69);
            this.LeaderBoardGrid.MultiSelect = false;
            this.LeaderBoardGrid.Name = "LeaderBoardGrid";
            this.LeaderBoardGrid.ReadOnly = true;
            this.LeaderBoardGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.LeaderBoardGrid.RowHeadersVisible = false;
            this.LeaderBoardGrid.RowHeadersWidth = 51;
            this.LeaderBoardGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Rockwell", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.LeaderBoardGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.LeaderBoardGrid.RowTemplate.Height = 24;
            this.LeaderBoardGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LeaderBoardGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LeaderBoardGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LeaderBoardGrid.ShowCellErrors = false;
            this.LeaderBoardGrid.ShowCellToolTips = false;
            this.LeaderBoardGrid.ShowEditingIcon = false;
            this.LeaderBoardGrid.ShowRowErrors = false;
            this.LeaderBoardGrid.Size = new System.Drawing.Size(242, 230);
            this.LeaderBoardGrid.TabIndex = 30;
            // 
            // Position
            // 
            this.Position.FillWeight = 15F;
            this.Position.HeaderText = "";
            this.Position.MinimumWidth = 6;
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            this.Username.DefaultCellStyle = dataGridViewCellStyle3;
            this.Username.FillWeight = 55F;
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 2;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Username.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Score
            // 
            this.Score.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Score.DefaultCellStyle = dataGridViewCellStyle4;
            this.Score.FillWeight = 30F;
            this.Score.HeaderText = "Score";
            this.Score.MinimumWidth = 2;
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            this.Score.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Score.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BoomWordsLabel
            // 
            this.BoomWordsLabel.BackColor = System.Drawing.Color.Transparent;
            this.BoomWordsLabel.Font = new System.Drawing.Font("Rockwell", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoomWordsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BoomWordsLabel.Location = new System.Drawing.Point(155, 9);
            this.BoomWordsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BoomWordsLabel.Name = "BoomWordsLabel";
            this.BoomWordsLabel.Size = new System.Drawing.Size(397, 55);
            this.BoomWordsLabel.TabIndex = 53;
            this.BoomWordsLabel.Text = "BOOMWORDS";
            this.BoomWordsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.AutoSize = true;
            this.ExitButton.BackColor = System.Drawing.Color.Maroon;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold);
            this.ExitButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExitButton.Location = new System.Drawing.Point(541, 323);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(2);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(131, 34);
            this.ExitButton.TabIndex = 57;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.Black;
            this.PasswordLabel.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(44, 199);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(104, 24);
            this.PasswordLabel.TabIndex = 62;
            this.PasswordLabel.Text = "Password";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.BackColor = System.Drawing.Color.Black;
            this.UsernameLabel.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.White;
            this.UsernameLabel.Location = new System.Drawing.Point(43, 125);
            this.UsernameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(109, 24);
            this.UsernameLabel.TabIndex = 61;
            this.UsernameLabel.Text = "Username";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordBox
            // 
            this.PasswordBox.AsciiOnly = true;
            this.PasswordBox.BackColor = System.Drawing.Color.White;
            this.PasswordBox.Font = new System.Drawing.Font("Rockwell", 12F);
            this.PasswordBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PasswordBox.Location = new System.Drawing.Point(49, 227);
            this.PasswordBox.Margin = new System.Windows.Forms.Padding(2);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(192, 31);
            this.PasswordBox.TabIndex = 60;
            this.PasswordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BlockWords);
            // 
            // UsernameBox
            // 
            this.UsernameBox.AsciiOnly = true;
            this.UsernameBox.BackColor = System.Drawing.Color.White;
            this.UsernameBox.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.UsernameBox.Location = new System.Drawing.Point(49, 153);
            this.UsernameBox.Margin = new System.Windows.Forms.Padding(2);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(192, 31);
            this.UsernameBox.TabIndex = 59;
            this.UsernameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UsernameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BlockWords);
            // 
            // EnterUserButton
            // 
            this.EnterUserButton.BackColor = System.Drawing.Color.Black;
            this.EnterUserButton.FlatAppearance.BorderSize = 0;
            this.EnterUserButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterUserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EnterUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterUserButton.Font = new System.Drawing.Font("Rockwell", 16F, System.Drawing.FontStyle.Bold);
            this.EnterUserButton.ForeColor = System.Drawing.Color.White;
            this.EnterUserButton.Location = new System.Drawing.Point(185, 280);
            this.EnterUserButton.Margin = new System.Windows.Forms.Padding(2);
            this.EnterUserButton.Name = "EnterUserButton";
            this.EnterUserButton.Size = new System.Drawing.Size(157, 45);
            this.EnterUserButton.TabIndex = 58;
            this.EnterUserButton.Text = "Log In";
            this.EnterUserButton.UseVisualStyleBackColor = false;
            this.EnterUserButton.Click += new System.EventHandler(this.EnterUserButton_Click);
            // 
            // GameBox
            // 
            this.GameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.GameBox.Location = new System.Drawing.Point(27, 93);
            this.GameBox.Name = "GameBox";
            this.GameBox.Size = new System.Drawing.Size(329, 210);
            this.GameBox.TabIndex = 63;
            this.GameBox.TabStop = false;
            // 
            // HiperTextLabel
            // 
            this.HiperTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.HiperTextLabel.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HiperTextLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.HiperTextLabel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.HiperTextLabel.Location = new System.Drawing.Point(33, 282);
            this.HiperTextLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HiperTextLabel.Name = "HiperTextLabel";
            this.HiperTextLabel.Size = new System.Drawing.Size(133, 17);
            this.HiperTextLabel.TabIndex = 65;
            this.HiperTextLabel.Text = "Create Account";
            this.HiperTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HiperTextLabel.Click += new System.EventHandler(this.HiperTextLabel_Click);
            this.HiperTextLabel.MouseEnter += new System.EventHandler(this.HiperTextLabel_MouseEnter);
            this.HiperTextLabel.MouseLeave += new System.EventHandler(this.HiperTextLabel_MouseLeave);
            // 
            // UserLabel
            // 
            this.UserLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.UserLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserLabel.Font = new System.Drawing.Font("Rockwell", 16F, System.Drawing.FontStyle.Bold);
            this.UserLabel.ForeColor = System.Drawing.Color.Black;
            this.UserLabel.Location = new System.Drawing.Point(36, 69);
            this.UserLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(273, 43);
            this.UserLabel.TabIndex = 64;
            this.UserLabel.Text = "CREATE ACOUNT";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserLabel.Visible = false;
            // 
            // PlayersTimer
            // 
            this.PlayersTimer.Interval = 5000;
            this.PlayersTimer.Tick += new System.EventHandler(this.PlayersTimer_Tick);
            // 
            // Launcher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::BoomWords.Properties.Resources.BackGroundImage;
            this.ClientSize = new System.Drawing.Size(683, 368);
            this.Controls.Add(this.LeaderBoardGrid);
            this.Controls.Add(this.EnterUserButton);
            this.Controls.Add(this.HiperTextLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.GameBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.BoomWordsLabel);
            this.Controls.Add(this.ConnectionLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Launcher_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloseLauncher);
            this.Load += new System.EventHandler(this.Launcher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LeaderBoardGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.DataGridView LeaderBoardGrid;
        private System.Windows.Forms.Label BoomWordsLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.MaskedTextBox PasswordBox;
        private System.Windows.Forms.MaskedTextBox UsernameBox;
        private System.Windows.Forms.Button EnterUserButton;
        private System.Windows.Forms.PictureBox GameBox;
        private System.Windows.Forms.Label HiperTextLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.Timer PlayersTimer;
    }
}

