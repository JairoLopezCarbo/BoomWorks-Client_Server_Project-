using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BoomWords
{
    
    public partial class Launcher : Form
    {
        int SHIVA = 1 ; //for SHIVA SETUP set to 1, otherwise set to 0

        string localhost_ip = "192.168.56.102";
        string localhost_port = "9050";
        string shiva_ip = "10.4.119.5";
        string shiva_port = "50050";
        string port;
        string ip;

        Socket launcherSocket;
        Thread launcherThread;
        bool leavingLauncher = false;
          
        public Launcher()
        {
            InitializeComponent();
            //CheckForIllegalCrossThreadCalls = false; //Necesario para que los elementos de los formularios puedan ser
            //accedidos desde threads diferentes a los que los crearon
        }
        private void Launcher_Load(object sender, EventArgs e)
        {
            //Creamos un IPEndPoint con el ip del servidor y puerto del servidor 
            //al que deseamos conectarnos
            if (SHIVA == 1)
            {
                ip = shiva_ip;
                port = shiva_port;
            }
            else
            {
                ip = localhost_ip;
                port = localhost_port;
            }
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));


            //Creamos el socket 
            launcherSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                launcherSocket.Connect(ipep);//Intentamos conectar el socket
                ConnectionLabel.Text = "Connected " + ip + ":" + port;

                //Thread LAUNCHER
                ThreadStart ts = delegate { LauncherAttendServer(); };
                launcherThread = new Thread(ts);
                launcherThread.Start();

                string mensaje = "LeaderBoard/";
                // Enviamos al servidor el nombre tecleado
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

                launcherSocket.Send(msg);

            }
            catch
            {
                //Si hay excepcion imprimimos error y salimos del programa con return 
                MessageBox.Show("Could not connect " + ip + ":" + port);
                this.Close();
            }
        }

        private void LauncherAttendServer()
        {
            while (true)
            {
                //Recibimos mensaje del servidor
                byte[] msg = new byte[80];
                launcherSocket.Receive(msg);
                string[] server = Encoding.ASCII.GetString(msg).Split('\0')[0].Split('$');

                foreach (string sR in server)
                { 
                    string[] serverResponse = sR.Split('/');
                    switch (serverResponse[0])
                    {
                        case "LogIn":
                            switch (Convert.ToInt32(serverResponse[1]))
                            {
                                case -1:
                                    MessageBox.Show("Usuario no existente");
                                    break;
                                case 0:
                                    MessageBox.Show("Wrong Password");
                                    break;
                                case 1:
                                    string username = UsernameBox.Text;
                                    ThreadStart ts = delegate { Create_UserLobby(username); };
                                    Thread T = new Thread(ts);
                                    T.Start();
                                    this.Invoke(new Action(() =>
                                    {
                                        UsernameBox.Text = "";
                                        PasswordBox.Text = "";
                                    }));

                                    break;
                                case 2:
                                    MessageBox.Show("User already logged");
                                    break;
                                case 3:
                                    MessageBox.Show("Server is full... Try again later");
                                    break;
                            }
                            break;


                        case "SignIn":

                            switch (Convert.ToInt32(serverResponse[1]))
                            {
                                case 0:
                                    MessageBox.Show("Usuario ya existente");
                                    break;
                                case 1:
                                    MessageBox.Show("Usuario creado correctamente");
                                    string mensaje = "LeaderBoard/";
                                    msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                                    launcherSocket.Send(msg);
                                    break;

                            }
                            break;



                        case "LeaderBoard":
                            this.Invoke(new Action(() =>
                            {
                                LeaderBoardGrid.Rows.Clear();
                                var LeaderBoard = serverResponse[1].Split('|')
                                    .Select(t => t.Trim())
                                    .Select(t =>
                                    {
                                        var part = t.Split(',');


                                        if (part.Length < 2 || !int.TryParse(part[1], out int score))
                                        {

                                            return null;
                                        }
                                        return new { name = part[0], score = int.Parse(part[1]) };

                                    })
                                    .Where(player => player != null && player.name != "user")
                                    .OrderByDescending(x => x.score)
                                    .ToList();
                                int position = 1;
                                foreach (var player in LeaderBoard)
                                {
                                    LeaderBoardGrid.Rows.Add($"#{position}", player.name, player.score);
                                    position++;
                                }
                            }));

                            break;
                    }
                }
            }
        }

        private void EnterUserButton_Click(object sender, EventArgs e)
        {
            if (UsernameBox.Text == "" || PasswordBox.Text == "") return;
            
            if (EnterUserButton.Text == "Log In")
            {
                if (UsernameBox.Text == "user")
                {
                    MessageBox.Show("Usuario no existente");
                }
                else
                {
                    string mensaje = "LogIn/" + UsernameBox.Text + "," + PasswordBox.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);

                    launcherSocket.Send(msg);
                }      
            }
            else if (EnterUserButton.Text == "Sign In")
            {
                if (UsernameBox.Text == "user")
                {
                    MessageBox.Show("Usuario no permitido");
                }
                else
                {
                    string mensaje = "SignIn/" + UsernameBox.Text + "," + PasswordBox.Text;
                    // Enviamos al servidor el nombre tecleado
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    launcherSocket.Send(msg);
                }
                
            }

        }

        private void Create_UserLobby(string username)
        {
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ip), Convert.ToInt32(port));
            UserLobby userLobby = new UserLobby(ipep, username);

            userLobby.ShowDialog();
        }
        

        private void HiperTextLabel_MouseEnter(object sender, EventArgs e)
        {
            HiperTextLabel.Font = new Font(HiperTextLabel.Font, FontStyle.Italic | FontStyle.Underline);
        }

        private void HiperTextLabel_MouseLeave(object sender, EventArgs e)
        {
            HiperTextLabel.Font = new Font(HiperTextLabel.Font, FontStyle.Italic | FontStyle.Regular);
        }

        private void HiperTextLabel_Click(object sender, EventArgs e)
        {
            if (HiperTextLabel.Text == "Create Account")
            {
                UserLabel.Visible = true;
                HiperTextLabel.Text = "Log In";
                EnterUserButton.Text = "Sign In";
            }
            else if (HiperTextLabel.Text == "Log In")
            {
                UserLabel.Visible = false;
                HiperTextLabel.Text = "Create Account";
                EnterUserButton.Text = "Log In";
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            leavingLauncher = true;
            Close();
        }

        private void CloseLauncher(object sender, FormClosedEventArgs e)
        {
            string mensaje = "Exit/";
            if (launcherThread != null)
            {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                launcherSocket.Send(msg);

                // Nos desconectamos
                launcherThread.Abort();
                launcherSocket.Shutdown(SocketShutdown.Both);
                launcherSocket.Close();

            }
        }

        private void PlayersTimer_Tick(object sender, EventArgs e)
        {
            string mensaje = "LeaderBoard/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            launcherSocket.Send(msg);

            PlayersTimer.Start();
        }

        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!leavingLauncher)
                e.Cancel = true;
        }


        private void BlockWords(object sender, KeyPressEventArgs e)
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
