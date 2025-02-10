using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Numerics;
using Org.BouncyCastle.Crypto;
using static BoomWords.Game;
using System.Data.SqlTypes;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;


namespace BoomWords
{
    

    public partial class Game : Form
    {
        
        public class Player
        {
            public string Name;
            public int x, y;
            public int currentLives = 0;
            public Form game;
            
            public Label playerNameLabel;
            public PictureBox playerIcon;
            public List<PictureBox> livesIcons = new List<PictureBox>();
            public Label wordLabel;

            int playerSize = 75;
            int liveSize = 15;
            int spaceBetweenLives = 2;
            public Player(string name, int x, int y, Image playerAvatar, Form form)
            {
                this.Name = name;
                this.x = x;
                this.y = y;
                this.game = form;

                
                playerIcon = new PictureBox
                {
                    Image = playerAvatar,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(playerSize, playerSize),
                    BackColor = Color.RoyalBlue,
                    BorderStyle = BorderStyle.None,
                    Location = new Point(x - Convert.ToInt32(playerSize / 2), y - Convert.ToInt32(playerSize / 2))
                };

                //  etiqueta del usuario
                playerNameLabel = new Label
                {
                    Text = name,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Rockwell", 10), // Fuente de la etiqueta (nombre del usuario
                    ForeColor = Color.White,
                    BackColor = Color.Black,
                    AutoSize = false,
                    Size = new Size(playerIcon.Width, 20)
                };
                playerNameLabel.Location = new Point(x - Convert.ToInt32(playerIcon.Width / 2), y - Convert.ToInt32(playerIcon.Height / 2 + playerNameLabel.Height));

                wordLabel = new Label
                {
                    Text = "",
                    TextAlign = ContentAlignment.TopCenter,
                    Font = new Font("Rockwell", 10), // Fuente de la etiqueta (nombre del usuario
                    AutoSize = false,
                    Size = new Size(playerIcon.Width*2, 20),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Black
                };
                wordLabel.Location = new Point(x - Convert.ToInt32(playerIcon.Width), y + Convert.ToInt32(playerIcon.Height / 2 + liveSize*4/5));
                
                game.Controls.Add(playerNameLabel);
                game.Controls.Add(playerIcon);
                game.Controls.Add(wordLabel);
            }

            public void SetLives(int totalLives)
            {
                livesIcons = new List<PictureBox>();
                currentLives = totalLives;
                for (int l=0; l<totalLives; l++)
                {
                    PictureBox liveIcon = new PictureBox
                    {
                        Image = Properties.Resources.LiveON, // Accede al recurso con el nombre de la foto
                        BackColor = Color.Transparent,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(liveSize, liveSize),
                        Location = new Point(x - Convert.ToInt32((liveSize*totalLives+ spaceBetweenLives * (totalLives-1))/2)+l*(liveSize+ spaceBetweenLives), y + Convert.ToInt32(playerIcon.Height / 2 - liveSize/3))
                    };
                    livesIcons.Add(liveIcon);
                    game.Controls.Add(liveIcon);
                    liveIcon.BringToFront(); 
                }
            }

            public int LoseLive()
            {
                currentLives--;
                livesIcons[currentLives].Image = Properties.Resources.LiveOFF;
                playerIcon.BackColor = Color.Red;
                playerIcon.Refresh();
                if (currentLives == 0) { return 0; }
                return 1;
            }

        }

        string gamename;
        
        string username;
        bool host = false;
        public List<PictureBox> userLives = new List<PictureBox>();
        int userCurrentLives = 0;
        Point userLocation;
        bool leavingGame = false;
        
        Socket userSocket;
        List<Player> currentPlayers = new List<Player>();
        
        public bool end = false;
        string TurnPlayer = "";
        Random rnd = new Random();
        System.Media.SoundPlayer FirstTikTakSound = new System.Media.SoundPlayer(Properties.Resources.TikTakSound);
        System.Media.SoundPlayer SecondTikTakSound = new System.Media.SoundPlayer(Properties.Resources.FastTikTakSound);

        public Game(string user_name, string game_name, Socket userSocket)
        {
            InitializeComponent();

            this.username = user_name;
            this.gamename = game_name;
            this.userSocket = userSocket;
            this.currentPlayers = new List<Player>();
            userLocation = AvatarBox.Location;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.UsernameLabel.Text = this.username;
            this.GamenameLabel.Text = this.gamename;
            if (host)
            {
                InviteButton.Visible = true;    
            }
                
            string mensaje = $"Game/{gamename}/Join";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            userSocket.Send(msg);
            SyllableLabel.Text = "";
        }
        private void TurnFocus()
        {
            foreach (Player player in currentPlayers)
            {
                player.playerIcon.Padding = new Padding(all: 0);
                player.wordLabel.Text = ""; 
                if (player.Name == this.TurnPlayer)
                {
                    player.playerIcon.BackColor = Color.RoyalBlue;
                    player.playerIcon.Padding = new Padding(all: 5);
                }
                player.playerIcon.Refresh();
            }
            if (TurnPlayer == this.username)
            {
                UsernameLabel.Visible = false;

                AvatarBox.Size = new Size(AvatarBox.Bottom - WordBox.Bottom - 2  , AvatarBox.Bottom - WordBox.Bottom - 2);
                AvatarBox.Location = new Point(WordBox.Location.X + (int)(WordBox.Width/2 - AvatarBox.Width/2), WordBox.Bottom + 2);
                AvatarBox.Padding = new Padding(all: 5);
                AvatarBox.Refresh();

                WordBox.Enabled = true;
                WordBox.Focus();
            }
            else if (AvatarBox.Location.X != WordBox.Location.X || AvatarBox.BackColor.Equals(Color.Red))
            {
                UsernameLabel.Visible = true;

                AvatarBox.Size = new Size(WordBox.Width, WordBox.Width);
                AvatarBox.Location = new Point(WordBox.Location.X, UsernameLabel.Bottom);
                AvatarBox.Padding = new Padding(all: 0);
                AvatarBox.BackColor = Color.RoyalBlue;
                AvatarBox.Refresh();

                WordBox.Enabled = false;
                WordBox.Text = "";
            }
            

        }

        private void GuessingWord(string word, int type)
        {
            foreach (Player player in currentPlayers)
            {
                player.wordLabel.Text = "";

                if (player.Name == this.TurnPlayer)
                {
                    player.wordLabel.Text = word.ToUpper();
                }
            }
            WordBox.BackColor = Color.White;
            if (TurnPlayer == this.username)
            {
                WordBox.Enabled = true;
                WordBox.Text = word;
                if (type == 1)
                    WordBox.BackColor = Color.Green;
                else if (type == 0)
                    WordBox.BackColor = Color.Red;
            }
        }

       
        

        private void CleanPlayers()
        {
            // Elimina las etiquetas de usuario previamente creadas
            foreach (Player player in currentPlayers)
            {
                this.Controls.Remove(player.playerNameLabel);
                this.Controls.Remove(player.playerIcon);
                foreach (PictureBox heart in player.livesIcons)
                    this.Controls.Remove(heart);
                this.Controls.Remove(player.wordLabel);
            }
            currentPlayers.Clear();
        }


        private int[] UserPoistion(int position, int totalPlayers)
        {
            int centerX = SyllableLabel.Location.X + Convert.ToInt32(this.SyllableLabel.Width / 2);
            int centerY = SyllableLabel.Location.Y + Convert.ToInt32(this.SyllableLabel.Height / 2);
            int b = (int)(AvatarBox.Location.Y+AvatarBox.Height/2)- centerY;
            double a = (int)(b * (1.4+(int)(totalPlayers/4)/10+(int)(totalPlayers/3)/5));
            // Calculamos la posición del jugador en el elipse
            double angle = (360.0 / totalPlayers) * position + 90;
            int x = (int)(centerX + a * Math.Cos(angle * Math.PI / 180));
            int y = (int)(centerY + b * Math.Sin(angle * Math.PI / 180)); 
            return new[] { x, y };
        }

        private Image GetAvatarImage(int iAvatar)
        {
            Image playerAvatar = null;
            switch (iAvatar)
            {
                case 1:
                    playerAvatar = Properties.Resources.Av_1;
                    break;
                case 2:
                    playerAvatar = Properties.Resources.Av_2;
                    break;
                case 3:
                    playerAvatar = Properties.Resources.Av_3;
                    break;
                case 4:
                    playerAvatar = Properties.Resources.Av_4;
                    break;
                case 5:
                    playerAvatar = Properties.Resources.Av_5;
                    break;
                case 6:
                    playerAvatar = Properties.Resources.Av_6;
                    break;
                case 7:
                    playerAvatar = Properties.Resources.Av_7;
                    break;
                case 8:
                    playerAvatar = Properties.Resources.Av_8;
                    break;
            }
            return playerAvatar;

        }


        public void GameResponses(string userResponse)
        {
            string[] gameResponse = userResponse.Split('/');
            this.Invoke(new Action(() =>
            {
                switch (gameResponse[0])
                {
                    case "Start":
                        
                        this.StartButton.Visible = false;
                        this.InviteButton.Visible = false;
                        this.LeaveButton.Visible = false;
                        userCurrentLives = Convert.ToInt32(gameResponse[1]);
                        foreach (Player player in currentPlayers)
                        {
                            player.SetLives(userCurrentLives);
                        }
                        userLives = new List<PictureBox>();
                        int liveSize = 25;
                        for (int l = 0; l < userCurrentLives; l++)
                        {
                            PictureBox liveIcon = new PictureBox
                            {
                                Image = Properties.Resources.LiveON, // Accede al recurso con el nombre de la foto
                                BackColor = Color.Transparent,
                                SizeMode = PictureBoxSizeMode.StretchImage,
                                Size = new Size(25, 25),
                                Location = new Point(AvatarBox.Left + (int)AvatarBox.Size.Width/2 - Convert.ToInt32((liveSize * userCurrentLives + 3 * (userCurrentLives - 1)) / 2) + l * (liveSize + 3), AvatarBox.Bottom - Convert.ToInt32(liveSize / 3))
                            };
                            userLives.Add(liveIcon);
                            this.Controls.Add(liveIcon);
                            liveIcon.BringToFront();
                        }
                        BombBox.Image = Properties.Resources.BombOFF;
                        BombBox.Visible = true;
                        RunDelay.Start();

                        break;

                    case "Turn":
                        TurnPlayer = gameResponse[1];
                        string syllable = gameResponse[2];

                        this.SyllableLabel.Text = syllable.ToUpper();
                        
                        WordBox.Text = "";
                        WordBox.BackColor = Color.White;
                        WordBox.ForeColor = Color.Black;
                       
                        TurnFocus();
                        break;

                    case "Word":
                        string word = gameResponse[1];
                        int type = Convert.ToInt32(gameResponse[2]);
                        GuessingWord(word, type);
                        
                        break;

                    case "Boom":
                        WordBox.Enabled = false;
                        foreach (Player p in currentPlayers)
                        {
                            if (p.Name == gameResponse[1])
                            {
                                p.LoseLive();
                                break;
                            }
                        }
                        
                        if (username == gameResponse[1])
                        {
                            userCurrentLives--;
                            userLives[userCurrentLives].Image = Properties.Resources.LiveOFF;
                            UsernameLabel.Visible = true;

                            AvatarBox.Size = new Size(WordBox.Width, WordBox.Width);
                            AvatarBox.Location = new Point(WordBox.Location.X, UsernameLabel.Bottom);
                            AvatarBox.BackColor = Color.Red;
                            AvatarBox.Refresh();
                        }
                        FirstTikTakSound.Stop();
                        SecondTikTakSound.Stop();
                        RunDelay.Start();
                        BombBox.Visible = false;
                        SyllableLabel.Text = "";
                        SyllableLabel.Visible = false;
                        ExplosionPictureBox.Visible = true;
                        ImageAnimator.Animate(ExplosionPictureBox.Image, OnFrameChanged);
                        System.Media.SoundPlayer ExplosionSound = new System.Media.SoundPlayer(Properties.Resources.Explosion_Sound);
                        ExplosionSound.Play();
                       

                        break;

                    case "MiddleBoom":
                        SecondTikTakSound.Play();
                        BombBox.Image = Properties.Resources.BombON_2;

                        break;

                    case "Win":
                        BoomTimer.Stop();
                        MiddleBomb.Stop();
                        FirstTikTakSound.Stop();
                        SecondTikTakSound.Stop();
                        BombBox.Image = Properties.Resources.BombOFF;
                        string winPlayer = gameResponse[1];
                        foreach (Player player in currentPlayers)
                        {
                            player.playerIcon.Padding = new Padding(all: 0);
                            player.wordLabel.Text = "";
                            if (player.Name == winPlayer)
                            {
                                player.playerIcon.BackColor = Color.Green;
                                player.playerIcon.Padding = new Padding(all: 5);
                                player.wordLabel.Text = "WINNER!";
                            }
                            player.playerIcon.Refresh();
                        }
                        AvatarBox.Padding = new Padding(all: 0);
                        AvatarBox.BackColor = Color.RoyalBlue;
                        if (winPlayer == this.username)
                        {
                            UsernameLabel.Visible = true;

                            AvatarBox.Size = new Size(WordBox.Width, WordBox.Width);
                            AvatarBox.Location = new Point(WordBox.Location.X, UsernameLabel.Bottom);
                            AvatarBox.Padding = new Padding(all: 5);
                            AvatarBox.BackColor = Color.Green;
                            SyllableLabel.Text = "WIN!";

                            WordBox.Enabled = false;
                            WordBox.Text = "";
                        }
                        AvatarBox.Refresh();
                        WinTimer.Start();
                        break;
                        

                    case "Load":
                        FirstTikTakSound.Stop();
                        SecondTikTakSound.Stop();
                        BombBox.Image = Properties.Resources.BombOFF;
                        CleanPlayers();
                        int iYou = 0;
                        int i = 0;
                        var Players = gameResponse[1].Split('|')
                            .Select(t => t.Trim())
                            .Select(t =>
                            {
                                var part = t.Split(',');

                                if (part[0] == this.username)
                                    iYou = i;
                                    
                                i++;
                                
                                return new { name = part[0], iAvatar = int.Parse(part[1]) };     
                            })
                            .ToList(); 
                        int totalPlayers = Players.Count;

                        for (i = 0; i < totalPlayers; i++)
                        {
                            Image avatarImage = GetAvatarImage(Players[i].iAvatar);
                            if (i != iYou)
                            {
                                int[] xy = new int[2];
                                if (i < iYou)
                                    xy = UserPoistion(i + totalPlayers - iYou, totalPlayers);
                                else
                                    xy = UserPoistion(i - iYou, totalPlayers);
                                
                                Player p = new Player(Players[i].name, xy[0], xy[1], avatarImage, this);

                                this.currentPlayers.Add(p);

                            }
                            else
                                AvatarBox.Image = avatarImage;
                        }

                        LeaveButton.Visible = true;
                        if (host)
                        {
                            InviteButton.Enabled = true;
                            if (totalPlayers >= 2)
                                StartButton.Visible = true;
                            else
                                StartButton.Visible = false;
                        }

                        break;

                    case "Invite":

                        var InviteBoard = gameResponse[1].Split('|')
                            .Select(t => t.Trim())
                            .Select(t =>
                            {
                                return new { name = t };
                            })
                            .Where(user => user != null)
                            .ToList();

                        foreach (var user in InviteBoard)
                        {
                            InviteGrid.Rows.Add(user.name);
                        }


                        InviteGrid.ClearSelection();
                        break;

                    case "End":
                        end = true;
                        leavingGame = true;
                        Close();
                        break;

                }
            }));
        }

        public void DeclareHost()
        {
            this.host = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string mensaje = $"Game/{gamename}/Start";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
        }

        private void RunDelay_Tick(object sender, EventArgs e)
        {
            RunDelay.Stop();
            BombBox.Image = Properties.Resources.BombOFF;
            SyllableLabel.Visible = true;
            BombBox.Visible = true;
            RunDelay.Interval = 1000;
            ExplosionPictureBox.Visible = false;
            List<string> startCountDown = new List<string> { "3", "2", "1", "GO!" };
            int position = startCountDown.IndexOf(SyllableLabel.Text);
            
            if (position == 3)
            {
                RunDelay.Interval = 3000;
                SyllableLabel.Text = "";

                BombBox.Image = Properties.Resources.BombON_1;
                FirstTikTakSound.Play();
                if (host)
                {
                    string mensaje = $"Game/{gamename}/Run";
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    userSocket.Send(msg);
                    int boomTime = rnd.Next(17000, 23001); //entre 17 y 23 segundos
                    int boomMiddleTime = Convert.ToInt32(boomTime / 2);
                 
                    BoomTimer.Interval = boomTime;
                    MiddleBomb.Interval = boomMiddleTime;
                    BoomTimer.Start();
                    MiddleBomb.Start();
                }
            }
            else
            {
                BombBox.Image = Properties.Resources.BombOFF;
                BombBox.Visible = true;
      
                SyllableLabel.Text = startCountDown[position + 1];
                RunDelay.Start();
            }
        }

        private void BoomTimer_Tick(object sender, EventArgs e)
        {
            BoomTimer.Stop();
            string mensaje = $"Game/{gamename}/Boom";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            userSocket.Send(msg);
        }
        private void MiddleBomb_Tick(object sender, EventArgs e)
        {
            MiddleBomb.Stop();
            string mensaje = $"Game/{gamename}/MiddleBoom";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            userSocket.Send(msg);
        }

        private void CheckWord(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && WordBox.Text.Length>0)
            {
                WordBox.Enabled = false;
                e.SuppressKeyPress = true;
                string mensaje = $"Game/{gamename}/Word/{WordBox.Text.ToLower()}";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                userSocket.Send(msg);
            }
        }

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            leavingGame = true;
            this.Close();
        }

        private void InviteButton_Click(object sender, EventArgs e)
        {
            InviteButton.Visible = false;
            string mensaje = $"Game/{gamename}/Invite";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
            InviteGrid.ClearSelection();
            InviteGrid.Rows.Clear();
            InviteGrid.Visible = true;
            BackInvitationButton.Visible = true;
        }

        private void InviteGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            SendInvitationButton.Visible = true;
        }

        private void BackInvitationButton_Click(object sender, EventArgs e)
        {
            InviteButton.Visible = true;
            InviteGrid.Visible = false;
            SendInvitationButton.Visible = false;
            BackInvitationButton.Visible = false;
        }

        private void SendInvitationButton_Click(object sender, EventArgs e)
        {
            string invitedUser = InviteGrid.SelectedRows[0].Cells["InvitedUsers"].Value.ToString();
            string mensaje = $"Game/{gamename}/Invite/{invitedUser}";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
            InviteGrid.ClearSelection();
            SendInvitationButton.Visible = false;
        }

        private void WinTimer_Tick(object sender, EventArgs e)
        {
            WinTimer.Stop();
            foreach (Player player in currentPlayers)
            {
                player.playerIcon.Padding = new Padding(all: 0);
                player.playerIcon.BackColor = Color.RoyalBlue;
                player.wordLabel.Text = "";
                player.playerIcon.Refresh();

                player.currentLives = 0;
                foreach (PictureBox heart in player.livesIcons)
                    this.Controls.Remove(heart);
            }
            AvatarBox.Padding = new Padding(all: 0);
            AvatarBox.BackColor = Color.RoyalBlue;
            AvatarBox.Refresh();
            WordBox.Text = "";

            userCurrentLives = 0;
            foreach (PictureBox heart in userLives)
                this.Controls.Remove(heart);

            if (host)
            {
                StartButton.Visible = true;
                InviteButton.Visible = true;
            }
            LeaveButton.Visible = true;

            TurnPlayer = "";
            SyllableLabel.Text = "";

        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!leavingGame)
                e.Cancel = true;
        }

        private void OnFrameChanged(object sender, EventArgs e)
        {
            // Refresca el PictureBox para mostrar el siguiente frame del GIF
            ExplosionPictureBox.Invalidate();
        }

        private void BlockKeys(object sender, KeyPressEventArgs e)
        {
            char[] forbiddenChars = { ' ', ',', '/', '|' };

            // Si el carácter está en la lista, cancela el evento
            if (forbiddenChars.Contains(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }
    }
}


