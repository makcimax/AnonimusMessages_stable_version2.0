using System;
using System.Windows.Forms;
using System.ServiceModel;
using Client_v1.Service;

namespace Client_v1
{

    //279,179
    public partial class Form1 : Form, IServerCallback
    {
        ServerClient client;
        int id;
        string nameInList;
        string userName;
        bool isConnected = false;

        private void SendMethod()
        {
            if (InputMessage.Text.Trim() == "")
            {
                return;
            }
            else
            {
                client.SendMessage(id, null, InputMessage.Text);
                InputMessage.Text = string.Empty;
                this.ActiveControl = InputMessage;
                //InputMessage.
            } 
        }

        private void ConnectMethod()
        {
            if (InputName.Text == "")
            {
                MessageBox.Show("Incorrect data!");
                ConnectButton.Enabled = true;
                return;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.ControlBox = true;
                this.Text = InputName.Text;
                this.AllABonents.Enabled = true;
                this.InputMessage.Enabled = true;
                this.SendButton.Enabled = true;
                this.OutputMessage.Enabled = true;
                this.ConnectButton.Text = "Disconnect";
                this.InputName.ReadOnly = true;

                client = new ServerClient(new InstanceContext(this));
                userName = InputName.Text;
                id = client.Connect(InputName.Text);
                isConnected = true;
                nameInList = userName+" — Online";
                client.ProvideMessage(id);

                //if (AllABonents.Items.Contains(InputName.Text + " — Offline"))
                //    AllABonents.Items[id] = nameInList;
                //else
                //    AllABonents.Items.Add(nameInList);
                this.ActiveControl = InputMessage;
                InputMessage.Focus();

            }
            
        }

        private void DisconnectMethod()
        {
            client.Disconnect(id);
            client = null;
            OutputMessage.Text = string.Empty;


            this.FormBorderStyle = FormBorderStyle.FixedDialog;
           // AllABonents.Items[id] = InputName.Text + " — Offline";
            this.ControlBox = false;
            InputName.ReadOnly = false;
            this.ControlBox = false;
            this.Text = "Login";
            this.AllABonents.Enabled = false;
            this.InputMessage.Enabled = false;
            this.SendButton.Enabled = false;
            this.OutputMessage.Enabled = false;
            ConnectButton.Text = "Connect";
            isConnected = false;
        }

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = InputName;
            
        }

        private string RepeatStr(string str, int num)
        {
            string result = "";

            for (int i = 0; i<num;++i)
            {
                result += str;
            }
            return result;
        }

        public void cbSendMessage(string senderName, string message)
        {
            if (InputMessage.Text == "")
            {
                return;
            }
            else
            {
                string chatString = senderName + ":\r";
                chatString += RepeatStr(" ", 2 * senderName.Length) + message + "\t\t\t" + DateTime.Now + "\r";
                OutputMessage.Text += chatString;
            }
            
        }

        public void cbShowAbonent(string abonentName, bool abonentStatus)
        {
           
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if(!isConnected)
            {
                ConnectMethod();
            }
            else
            {
                DisconnectMethod();
                //MessageBox.Show("Disconnect is done");
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMethod();
        }

        private void InputMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendMethod();
        }

        private void InputName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ConnectMethod();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if(isConnected)
                DisconnectMethod();

            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (isConnected)
                DisconnectMethod();

            Application.Exit();
        }
    }
}
