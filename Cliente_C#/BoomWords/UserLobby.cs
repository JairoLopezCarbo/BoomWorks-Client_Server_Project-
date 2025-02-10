using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BoomWords
{
    public partial class UserLobby : Form
    {
        string username;
        Socket userSocket;
        Thread userThread;
        bool leaveUser = false;
        

        Dictionary<string, Game> gameForms = new Dictionary<string, Game>();
        Dictionary<string, string> invitedGames = new Dictionary<string, string>();

        public UserLobby(IPEndPoint ipep, string username)
        {
            InitializeComponent();
            this.username = username;

            userSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                userSocket.Connect(ipep);  //Intentamos conectar el socket

                ThreadStart ts = delegate { UserAttendServer(); };
                userThread = new Thread(ts);
                userThread.Start();
            }
            catch
            {
                MessageBox.Show("Error en User");
                this.Close();
            }

        }

        private void UserLobby_Load(object sender, EventArgs e)
        {
            UsernameLabel.Text = this.username;
            string mensaje = "ActiveGames/";
            // Enviamos al servidor el nombre tecleado
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

            userSocket.Send(msg);
        }
        private void UserAttendServer()
        {

            string mensaje = $"User/{username}";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
            
            while (true)
            {
                //Recibimos mensaje del servidor
                msg = new byte[80];
                userSocket.Receive(msg);

                string[] server = Encoding.ASCII.GetString(msg).Split('\0')[0].Split('$');
                
                string game_name;
                foreach (string sR in server)
                {
                    string[] serverResponse = sR.Split('/');
                    switch (serverResponse[0])
                    {
                        case "Create":
                            switch (Convert.ToInt32(serverResponse[1]))
                            {
                                case -1:
                                    MessageBox.Show("Juego ya existente, cambia el nombre");
                                    break;
                                case 0:
                                    MessageBox.Show("El servidor no soporta mas juegos");
                                    break;
                                case 1:
                                    Game game;
                                    game_name = GamenameBox.Text;
                                    ThreadStart ts = delegate {
                                        game = Create_GameForm(game_name);
                                        game.DeclareHost();
                                        gameForms.Add(game_name, game);
                                        gameForms[game_name].ShowDialog();
                                        gameForms.Remove(game_name);
                                        string leave = $"Game/{game_name}/Leave";
                                        byte[] leaveMsg = System.Text.Encoding.ASCII.GetBytes(leave);
                                        userSocket.Send(leaveMsg);
                                    };
                                    Thread T = new Thread(ts);
                                    T.Start();
                                    this.Invoke(new Action(() =>
                                    {
                                        GamenameBox.Text = "";
                                        PasswordBox.Text = "";
                                    }));
                                    break;
                            }
                            this.Invoke(new Action(() =>
                            {
                                EnterGameButton.Enabled = true;
                            }));
                            break;


                        case "Chat":
                            string sender = serverResponse[1];
                            string message = serverResponse[2];


                            this.Invoke(new Action(() =>
                            {
                                if (sender == username)
                                {
                                    int rowIndex = ChatGridView.Rows.Add(message);
                                    DataGridViewRow row = ChatGridView.Rows[rowIndex];
                                    row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Alinear al centro derecha
                                    row.DefaultCellStyle.BackColor = Color.LightGray; // Fondo gris
                                }
                                else
                                {
                                    message = sender + ": " + message;
                                    ChatGridView.Rows.Add(message);
                                }
                            }));
                            break;


                        case "Join":
                            switch (Convert.ToInt32(serverResponse[1]))
                            {
                                case -1:
                                    MessageBox.Show("Lobby No existente, cree uno nuevo");
                                    break;
                                case 0:
                                    MessageBox.Show("Wrong Password");
                                    break;
                                case 1:
                                    Game game;
                                    game_name = GamenameBox.Text;

                                    ThreadStart ts = delegate { 
                                        game = Create_GameForm(game_name);
                                        gameForms.Add(game_name, game);
                                        gameForms[game_name].ShowDialog();
                                        gameForms.Remove(game_name);
                                        if (!game.end)
                                        {
                                            string leave = $"Game/{game_name}/Leave";
                                            byte[] leaveMsg = System.Text.Encoding.ASCII.GetBytes(leave);
                                            userSocket.Send(leaveMsg);
                                        }                                    
                                    };
                                    Thread T = new Thread(ts);
                                    T.Start();
                                    this.Invoke(new Action(() =>
                                    {
                                        GamesGrid.ClearSelection();
                                        BackButton.Visible = false;
                                        GameEnterLabel.Text = "CREATE GAME";
                                        GamenameBox.Text = "";
                                        PasswordBox.Text = "";
                                        PasswordBox.Visible = true;
                                        PasswordLabel.Visible = true;
                                        GamenameBox.Enabled = true;
                                        EnterGameButton.Text = "Create";
                                        EnterGameButton.Visible = true;

                                        AcceptInvitationButton.Visible = false;
                                        RejectInvitationButton.Visible = false;
                                    }));

                                    break;
                            }
                            this.Invoke(new Action(() =>
                            {
                                EnterGameButton.Enabled = true;
                            }));
                            break;
                        case "DataUser":
                            string[] parts = serverResponse[1].Split(',');
                        

                            this.Invoke(new Action(() =>
                            {
                                this.ScoreLbl.Text = parts[2];
                                int playedMatches = Convert.ToInt32(parts[1]);
                                this.PlayedMarchesDataLbl.Text = playedMatches.ToString();
                                int wins = Convert.ToInt32(parts[0]);
                                try
                                {
                                    int ratio = (int)(wins * 100) / playedMatches ;
                                    this.WinRateDataLbl.Text = ratio.ToString() + "%";
                                }
                                catch
                                {
                                    int ratio = 0;
                                    this.WinRateDataLbl.Text = ratio.ToString() + "%";
                                }
                            

                                Image avatarImage = GetAvatarImage(Convert.ToInt32(parts[3]));
                                
                                UserBox.Image = avatarImage;
                                foreach (Control control in this.Controls)
                                {
                                    // Verifica si es un PictureBox y su Tag coincide
                                    if (control is PictureBox pictureBox && pictureBox.Tag != null && pictureBox.Tag.ToString() == parts[3])
                                    {
                                        pictureBox.Padding = new Padding(all: 5);
                                        pictureBox.BackColor = Color.Black;
                                        pictureBox.Refresh(); ; // Cambia el color del fondo
                                        break; // Salimos del bucle si encontramos el control
                                    }
                                }
                            }));
                            break;
                        case "RecentPlayers":
                            string[] tr = serverResponse[1].Split(',');
                            this.Invoke(new Action(() =>
                            {
                                dataGridPG.Rows.Clear();
                                dataGridPG.Columns.Clear();
                                dataGridPG.Columns.Add("Player", "Player");
                                dataGridPG.Columns.Add("Wins", "Wins");
                                dataGridPG.Columns.Add("Loses", "Loses");

                                for (int i = 0; i < tr.Length; i += 3)
                                {
                                    if (i + 2 < tr.Length)
                                    {
                                        string playerName = tr[i];
                                        string wins = tr[i + 1];
                                        string losses = tr[i + 2];
                                        dataGridPG.Rows.Add(playerName, wins, losses);
                                    }
                                }
                            }));
                            break;

                        case "RecentGames":
                            string[] tro = serverResponse[1].Split(',');
                            this.Invoke(new Action(() =>
                            {
                                dataGridPG.Rows.Clear();
                                dataGridPG.Columns.Clear();
                                dataGridPG.Columns.Add("Game", "Game");
                                dataGridPG.Columns.Add("Date", "Date");
                                dataGridPG.Columns.Add("Rest", "Rest");
                                dataGridPG.Columns["Game"].Width = 110;
                                dataGridPG.Columns["Date"].Width = 130; 
                                dataGridPG.Columns["Rest"].Width = 80; 
                                for (int i = 0; i < tro.Length; i += 3)
                                {
                                    if (i + 2 < tro.Length)
                                    {
                                        string playerName = tro[i];
                                        string wins = tro[i + 1];
                                        string losses = tro[i + 2];
                                        dataGridPG.Rows.Add(playerName, wins, losses);
                                    }
                                }
                            }));
                            break;


                        case "ActiveGames":
                            Dictionary<string, string> refreshInvitations = new Dictionary<string, string>();
                            this.Invoke(new Action(() =>
                            {
                                GamesGrid.Rows.Clear();
                                if (serverResponse[1] != "")
                                {
                                
                                    var GameBoard = serverResponse[1].Split('|')
                                    .Select(t => t.Trim())
                                    .Select(t =>
                                    {
                                        var part = t.Split(',');
                                        if (invitedGames.ContainsKey(part[0]))
                                            refreshInvitations.Add(part[0], invitedGames[part[0]]);

                                        return new { name = part[0], numPlayers = int.Parse(part[1]), state = int.Parse(part[2]) };
                                    })
                                    .Where(game => game != null)
                                    .OrderByDescending(game => gameForms.ContainsKey(game.name)) // Ordenar primero los que están en "PLAYING"
                                    .ThenByDescending(game => refreshInvitations.ContainsKey(game.name)) // Luego "INVITED"
                                    .ThenBy(game => game.state) // Luego "JOIN" y finalmente "ONGOING"
                                    .ToList();


                                    string status = "";
                                    Color backColor = Color.White;
                                    Color foreColor = Color.Black;
                                    foreach (var game in GameBoard)
                                    {
                                        if (gameForms.ContainsKey(game.name))
                                        {
                                            status = "PLAYING";
                                            backColor = Color.SkyBlue;
                                            foreColor = Color.Black;
                                        }
                                        else if (refreshInvitations.ContainsKey(game.name))
                                        {
                                            status = "INVITED";
                                            backColor = Color.MediumSpringGreen;
                                            foreColor = Color.Black;
                                        }
                                        else if (game.state == 0) 
                                        {
                                            status = "JOIN";
                                            backColor = Color.White;
                                            foreColor = Color.Black;
                                        }

                                        else if (game.state == 1) 
                                        {
                                            status = "ONGOING";
                                            backColor = Color.Maroon;
                                            foreColor = Color.White;
                                        }
                                        int rowIndex = GamesGrid.Rows.Add(game.name, game.numPlayers, status);
                                        GamesGrid.Rows[rowIndex].DefaultCellStyle.BackColor = backColor;
                                        GamesGrid.Rows[rowIndex].DefaultCellStyle.ForeColor = foreColor;
                                        if (status != "JOIN")
                                        {
                                            GamesGrid.Rows[rowIndex].DefaultCellStyle.SelectionBackColor = backColor;
                                            GamesGrid.Rows[rowIndex].DefaultCellStyle.SelectionForeColor = foreColor;
                                        }
                                    }
                                }    
                                invitedGames = refreshInvitations;
                            }));
                            GamesGrid.ClearSelection();
                            break;

                        case "Invitation":
                            if (!invitedGames.ContainsKey(serverResponse[1]))
                            {
                                invitedGames.Add(serverResponse[1], serverResponse[2]);
                                mensaje = "ActiveGames/";
                                msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                userSocket.Send(msg);
                            }
                            break;


                        case "Game":
                            game_name = serverResponse[1];
                            string game_request = string.Join("/", serverResponse.Skip(2).Take(serverResponse.Length - 2));
                            this.Invoke(new Action(() =>
                            {
                                gameForms[game_name].GameResponses(game_request);
                            }));
                            break;
                    }
                }
            }
        }


        private Game Create_GameForm(string game_name)
        {
            Game game = new Game(username, game_name, userSocket);
            return game;
        }
        
        private void EnterGameButton_Click(object sender, EventArgs e)
        {
            if (GamenameBox.Text == "" || PasswordBox.Text == "") return;

            byte[] msg = System.Text.Encoding.ASCII.GetBytes("");
            if (EnterGameButton.Text == "Create")
            {
                string mensaje = "Create/" + GamenameBox.Text + "," + PasswordBox.Text;
                // Enviamos al servidor el nombre tecleado
                msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            }
            else if (EnterGameButton.Text == "Join")
            {
                string mensaje = "Join/" + GamenameBox.Text + "," + PasswordBox.Text;
                // Enviamos al servidor el nombre tecleado
                msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            }
            EnterGameButton.Enabled = false;

            userSocket.Send(msg);
        }

        private void LogOut()
        {
            string mensaje = "LogOut/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);

            // Nos desconectamos
            userThread.Abort();
            userSocket.Shutdown(SocketShutdown.Both);
            userSocket.Close();
            this.Close();
        }
        private void UserLobby_Closed(object sender, FormClosedEventArgs e)
        {
            LogOut();
        }
        private void LogOutButton_Click_1(object sender, EventArgs e)
        {
            if (gameForms.Count == 0)
            {
                leaveUser = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("You can't log out while playing a game");
            }
        }

        private void GamesGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >=0 && GamesGrid.Rows[rowIndex].Cells["State"].Value.ToString() == "JOIN" )
            {
                BackButton.Visible = true;
                GameEnterLabel.Text = "JOIN GAME";
                GamenameBox.Text = GamesGrid.Rows[rowIndex].Cells["Game"].Value.ToString();
                PasswordBox.Text = "";
                PasswordBox.Visible = true;
                PasswordLabel.Visible = true;
                GamenameBox.Enabled = false;
                EnterGameButton.Text = "Join";
                EnterGameButton.Visible = true;

                AcceptInvitationButton.Visible = false;
                RejectInvitationButton.Visible = false;
            }
            else if (rowIndex >= 0 && GamesGrid.Rows[rowIndex].Cells["State"].Value.ToString() == "INVITED")
            {
                BackButton.Visible = true;
                GameEnterLabel.Text = "INVITATION";
                GamenameBox.Text = GamesGrid.Rows[rowIndex].Cells["Game"].Value.ToString();
                GamenameBox.Enabled = false;
                PasswordBox.Visible = false;
                PasswordLabel.Visible = false;
                PasswordBox.Text = invitedGames[GamenameBox.Text];
                EnterGameButton.Visible = false;

                AcceptInvitationButton.Visible = true;
                RejectInvitationButton.Visible = true;
            }
            else if (GameEnterLabel.Text == "JOIN GAME")
            {
                GamesGrid.ClearSelection();
                BackButton.Visible = false;
                GameEnterLabel.Text = "CREATE GAME";
                GamenameBox.Text = "";
                PasswordBox.Text = "";
                PasswordBox.Visible = true;
                PasswordLabel.Visible = true;
                GamenameBox.Enabled = true;
                EnterGameButton.Text = "Create";
                EnterGameButton.Visible = true;

                AcceptInvitationButton.Visible = false;
                RejectInvitationButton.Visible = false;
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            GamesGrid.ClearSelection();
            BackButton.Visible = false;
            GameEnterLabel.Text = "CREATE GAME";
            GamenameBox.Text = "";
            PasswordBox.Text = "";
            PasswordBox.Visible = true;
            PasswordLabel.Visible = true;
            GamenameBox.Enabled = true;
            EnterGameButton.Text = "Create";
            EnterGameButton.Visible = true;

            AcceptInvitationButton.Visible = false;
            RejectInvitationButton.Visible = false;
        }
        
        private void RejectInvitationButton_Click(object sender, EventArgs e)
        {
            AcceptInvitationButton.Visible = false;
            RejectInvitationButton.Visible = false;

            string mensaje = "ActiveGames/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
            invitedGames.Remove(GamenameBox.Text);
        }

        private void AcceptInvitationButton_Click(object sender, EventArgs e)
        {
            AcceptInvitationButton.Visible = false;
            RejectInvitationButton.Visible = false;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes("");
            string mensaje = "Join/" + GamenameBox.Text + "," + PasswordBox.Text;
            msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);

            invitedGames.Remove(GamenameBox.Text);
        }

       

        private void AvatarSelection_Click(object sender, EventArgs e)
        {
            

            foreach (Control control in this.Controls)
            {
                // Verifica si es un PictureBox y su Tag es un número en el rango
                if (control is PictureBox pictureBox && pictureBox.Tag != null)
                {
                    if (int.TryParse(pictureBox.Tag.ToString(), out int tagValue) && tagValue >= 1 && tagValue <= 8)
                    {
                        pictureBox.Padding = new Padding(all: 0);
                        pictureBox.Refresh();  // Cambia el color del fondo
                    }
                }
            }

            int selectedAvatar = Convert.ToInt32(((PictureBox)sender).Tag);
            ((PictureBox)sender).Padding = new Padding(all: 5);
            ((PictureBox)sender).BackColor = Color.Black;
            ((PictureBox)sender).Refresh();
            string mensaje = "PfpChange/"+ selectedAvatar;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
            Image avatarImage = GetAvatarImage(selectedAvatar);
            UserBox.Image = avatarImage;
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

        private void SelectAvatarButton_Click(object sender, EventArgs e)
        {
            SelectAvatarButton.Visible = false;
            BackAvatarButton.Visible = true;
            UserBox.Visible = false;
            ScoreName.Visible = false;
            PlayedMarchesDataLbl.Visible = false;
            PlayedMatchesLbl.Visible = false;
            ScoreLbl.Visible = false;
            WinRateDataLbl.Visible = false;
            WinRateLbl.Visible = false;
            Avatar1Box.Visible = true;
            Avatar2Box.Visible = true;
            Avatar3Box.Visible = true;
            Avatar4Box.Visible = true;
            Avatar5Box.Visible = true;
            Avatar6Box.Visible = true;
            Avatar7Box.Visible = true;
            Avatar8Box.Visible = true;

        }

        private void BackAvatarButton_Click(object sender, EventArgs e)
        {
            SelectAvatarButton.Visible = true;
            BackAvatarButton.Visible = false;
            ScoreName.Visible = true;
            UserBox.Visible = true;
            PlayedMarchesDataLbl.Visible = true;
            PlayedMatchesLbl.Visible = true;
            ScoreLbl.Visible = true;
            WinRateDataLbl.Visible = true;
            WinRateLbl.Visible = true;
            Avatar1Box.Visible = false;
            Avatar2Box.Visible = false;
            Avatar3Box.Visible = false;
            Avatar4Box.Visible = false;
            Avatar5Box.Visible = false;
            Avatar6Box.Visible = false;
            Avatar7Box.Visible = false;
            Avatar8Box.Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PlayerButton.BackColor = Color.DimGray;
            GameButton.BackColor = Color.DarkGray;
            LastMonth.BackColor = Color.DarkGray;
            string mensaje = "RecentPlayers/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
        }

        private void GameButton_Click(object sender, EventArgs e)
        {
            GameButton.BackColor = Color.DimGray;
            PlayerButton.BackColor = Color.DarkGray;
            LastMonth.BackColor = Color.DarkGray;
            string mensaje = "RecentGames/168";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
        }
        private void UserLobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!leaveUser)
                e.Cancel = true;
        }

        private void LastMonth_Click(object sender, EventArgs e)
        {
            LastMonth.BackColor = Color.DimGray;
            PlayerButton.BackColor = Color.DarkGray;
            GameButton.BackColor = Color.DarkGray;
            string mensaje = "RecentGames/730";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            userSocket.Send(msg);
        }

        private void HiperTextLabel_Click(object sender, EventArgs e)
        {
            if (gameForms.Count == 0)
            {
                DialogResult result = MessageBox.Show(
                "Are you sure you want to eliminate your user? This is irreversible.",
                "Confirm action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning );
                if (result == DialogResult.Yes)
                {
                    string mensaje = "DeleteUser/";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    userSocket.Send(msg);
                    MessageBox.Show("El usuario ha sido eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    leaveUser = true;
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("You can't execute this action while in a game");
            }
            
        }

        private void HiperTextLabel_MouseEnter(object sender, EventArgs e)
        {
            HiperTextLabel.Font = new Font(HiperTextLabel.Font, FontStyle.Italic | FontStyle.Underline);
        }

        private void HiperTextLabel_MouseLeave(object sender, EventArgs e)
        {
            HiperTextLabel.Font = new Font(HiperTextLabel.Font, FontStyle.Italic | FontStyle.Regular);
        }

        private void SendMessage(object sender, KeyEventArgs e)
        {
            string message = ChatInputBox.Text.Trim();
            if (e.KeyCode == Keys.Enter && !(string.IsNullOrWhiteSpace(message)))
            {
                e.SuppressKeyPress = true; // Esto elimina el beep
                string mensaje = $"Chat/{message}";
                byte[] msg = Encoding.ASCII.GetBytes(mensaje);
                userSocket.Send(msg);

                ChatInputBox.Text = "";
            }
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
