using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Client10.Service;
using System.ServiceModel;
using System.Drawing;

namespace Client10
{
    public partial class Chat : Form, IServerCallback
    {
        Dictionary<int, Abonent> allAbonents;
        ServerClient client = null;
        Abonent abonentCurrent = new Abonent();
        //Status status = Status.Offline;
        //string userName = "";
        public Chat()
        {
            InitializeComponent();
            this.ActiveControl = InputName;
            abonentCurrent = new Abonent();
            abonentCurrent.status = Status.Offline;
        }
        public void cbSendMessage(string senderName, string message)
        {
            OutputMessage.Text += senderName + ": " + message + "\r";
        }
        public void cbShowAbonent(Abonent abonent)
        {
            allAbonents[abonent.id] = abonent;
            DrawAbonentList();
        }
        private void ConnectMethod()
        {            

            if (InputName.Text.Trim() == "")
            {
                MessageBox.Show("Incorrect data!!! Try again");
                return;
            }
            else
            {

                InstanceContext i = new InstanceContext(this);
                client = new ServerClient(i);
                abonentCurrent.name = InputName.Text.Trim();
                abonentCurrent.id = client.Connect(abonentCurrent.name);

                if (abonentCurrent.id == -1)
                {
                    MessageBox.Show("Error. Current user already online");
                    return;
                }

                abonentCurrent.status = Status.Online;
                allAbonents = client.ShowAbonents(abonentCurrent.id);

                OutputMessage.ReadOnly  = false;
                SendButton.Enabled      = true;
                InputMessage.ReadOnly   = false;
                AbonentList.Enabled     = true;
                ConnDisconnButton.Text  = "Disconnect";
                InputName.ReadOnly      = true;
                ShowButton.Enabled      = true;
                ForAllCheck.Enabled     = true;
                this.Text               = abonentCurrent.name + ": "+ abonentCurrent.status;

               // allAbonents.Remove(abonentCurrent.id);
                DrawAbonentList();
                var h = client.ProvideMessage(abonentCurrent.id);

                foreach (var index in h)
                {
                    string recipient = allAbonents[index.SenderId].name;

                    OutputMessage.Text += recipient + ": " + index.TextOfMessage + "\r";
                }

                this.ActiveControl = InputMessage;                
            }
        }
        private void DisconnectMethod()
        {
            client.Disconnect(abonentCurrent.id);
            client = null;
            abonentCurrent.status = Status.Offline;
            AbonentList.Items.Clear();
            OutputMessage.ReadOnly  = true;
            OutputMessage.Clear();
            SendButton.Enabled      = false;
            InputMessage.ReadOnly   = true;
            AbonentList.Enabled     = false;
            ConnDisconnButton.Text  = "Connect";
            InputName.ReadOnly      = false;
            ShowButton.Enabled      = false;
            ForAllCheck.Enabled     = false;
            this.Text               = "Login";
        }
        private int GetId(string name)
        {
            int id = 0;
            foreach(int ID in allAbonents.Keys)
            {
                if (allAbonents[ID].name == name)
                {
                    id = ID;
                    break;
                }
                    
            }

            return id;
        }
        private void SendMethod()
        {
            InputMessage.Text = InputMessage.Text.Trim();

            if (InputMessage.Text == "")
            {
                return;
            }
            else
            {
                if (ForAllCheck.Text == "Remove")
                {
                    client.SendMessage(abonentCurrent.id, null, InputMessage.Text); 
                }
                else 
                {
                    List<int> destination = new List<int>();

                    foreach(var index in AbonentList.CheckedIndices)
                    {
                        int tmpUserIndex = Convert.ToInt32(index.ToString());
                        string selectedUser = AbonentList.Items[tmpUserIndex].ToString();
                        string tmpName = selectedUser.Substring(0, selectedUser.IndexOf(":"));

                        destination.Add(GetId(tmpName));
                        
                    }
                    if (destination.Count == 0)
                    {
                        MessageBox.Show("Select a user to send a message");
                        return;
                    }
                    else 
                    {
                        if (destination.Count == AbonentList.Items.Count)
                        {
                            client.SendMessage(abonentCurrent.id, null, InputMessage.Text);
                        }
                        else
                        {
                            client.SendMessage(abonentCurrent.id, destination.ToArray(), InputMessage.Text);
                        }
                    }
                }

                InputMessage.Clear();
                                               
                this.ActiveControl = InputMessage;
                ForAllCheck.Text = "All";
            }

            foreach (var index in AbonentList.CheckedIndices)
            {
                int tmpUserIndex = Convert.ToInt32(index.ToString());
                AbonentList.SetItemCheckState(tmpUserIndex, CheckState.Unchecked);
            }
        } 
        private void ExitMethod()
        {
            if (abonentCurrent.status == Status.Online)
            {
                try
                {
                    DisconnectMethod();
                }
                catch
                {

                }

                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
        private int In_List(string userName)
        {
            int index = -1;
            for (int i = 0; i < AbonentList.Items.Count; ++i)
            {
                string tmp = AbonentList.Items[i].ToString();
                tmp = tmp.Substring(0, tmp.IndexOf(':'));
                if (tmp == userName)
                    index = i;
            }

            return index;
        }
        private void DrawAbonentList()
        {
            int tmpUserIndex;
            //int i = 0;

            foreach (int index in allAbonents.Keys)
            {

                tmpUserIndex = In_List(allAbonents[index].name);

                if (tmpUserIndex == -1)
                {
                    AbonentList.Items.Add(allAbonents[index].name + ": " + allAbonents[index].status); //добавляем в список чекбоксов
                    //allAbonents[abonent.id] = abonent;
                }
                else
                {
                    AbonentList.Items[tmpUserIndex] = allAbonents[index].name + ": " + allAbonents[index].status;// обновляем в списке чекбоксов
                }

                //++i;
            }

            //tmpUserIndex = In_List(abonent.name);

            //if (tmpUserIndex == -1)
            //    AbonentList.Items.Add(abonent.name + ": " + abonent.status);
            //else
            //    AbonentList.Items[tmpUserIndex] = abonent.name + ": " + abonent.status;


            AbonentList.Items.Remove(abonentCurrent.name + ": " + abonentCurrent.status);
        }
        private void ConnDisconnButton_Click(object sender, EventArgs e)
        {
            if (abonentCurrent.status == Status.Online)
            {
                try
                {
                    DisconnectMethod();          
                }
                catch
                {
                    MessageBox.Show("Server doesn't work now. The app will be closed");
                    Application.Exit();
                }

            }
            else
            {
                try
                {
                    ConnectMethod();
                }
                catch
                {
                    MessageBox.Show("Sorry, chat is unavailable now. Try later");
                }
            }
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMethod();
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitMethod();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitMethod();
        }
        private void InputName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ConnectMethod();
                }
                catch
                {
                    MessageBox.Show("Sorry, chat is unavailable now. Try later");
                }
            }
        }
        private void InputMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputMessage.Multiline = false;
                SendMethod();
                InputMessage.Multiline = true;
            }
        }
        private void ShowButton_Click(object sender, EventArgs e)
        {
            allAbonents = client.ShowAbonents(abonentCurrent.id);
            DrawAbonentList();
        }
        private void ForAllCheck_Click(object sender, EventArgs e)
        {
            if (ForAllCheck.Text == "All")
            {
                for (int i = 0; i < AbonentList.Items.Count; ++i)
                {
                    AbonentList.SetItemCheckState(i, CheckState.Checked);
                }
                ForAllCheck.Text = "Remove";
            }
            else
            {
                for (int i = 0; i < AbonentList.Items.Count; ++i)
                {
                    AbonentList.SetItemCheckState(i, CheckState.Unchecked);
                }
                ForAllCheck.Text = "All";
            }
        }
        private void ChatThemesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ChatThemesList.SelectedIndex)
            {
                case 0:
                    ChatThemesList.Text = "Dark theme";
                    this.BackColor = Color.FromArgb(57, 58, 58);
                    this.ForeColor = Color.FromArgb(252, 247, 247);

                    AbonentListPanel.ForeColor = Color.FromArgb(252, 247, 247);
                    AbonentListPanel.BackColor = Color.FromArgb(57, 58, 58);
                    ShowButton.BackColor = Color.FromArgb(52, 54, 54);
                    ShowButton.ForeColor = Color.FromArgb(252, 247, 247);
                    ForAllCheck.ForeColor = Color.FromArgb(252, 247, 247);
                    ForAllCheck.BackColor = Color.FromArgb(52, 54, 54);

                    AbonentList.BackColor = Color.FromArgb(37, 38, 38);
                    AbonentList.ForeColor = Color.FromArgb(252, 247, 247);

                    LoginPanel.BackColor = Color.FromArgb(52, 54, 54);
                    LoginPanel.ForeColor = Color.FromArgb(252, 247, 247);
                    InputName.BackColor = Color.FromArgb(77, 78, 78);
                    InputName.ForeColor = Color.FromArgb(252, 247, 247);
                    ConnDisconnButton.BackColor = Color.FromArgb(52, 54, 54);
                    ConnDisconnButton.ForeColor = Color.FromArgb(252, 247, 247);
                    ExitButton.BackColor = Color.FromArgb(52, 54, 54);
                    ExitButton.ForeColor = Color.FromArgb(222, 60, 60);

                    Customization.BackColor = Color.FromArgb(57, 58, 58);
                    Customization.ForeColor = Color.FromArgb(252, 247, 247);
                    ChatThemesList.BackColor = Color.FromArgb(77, 78, 78);
                    ChatThemesList.ForeColor = Color.FromArgb(252, 247, 247);

                    OutputMessage.BackColor = Color.FromArgb(37, 38, 38);
                    OutputMessage.ForeColor = Color.FromArgb(252, 247, 247);

                    InputMessage.BackColor = Color.FromArgb(37, 38, 38);
                    InputMessage.ForeColor = Color.FromArgb(252, 247, 247);

                    SendButton.BackColor = Color.FromArgb(52, 54, 54);
                    SendButton.ForeColor = Color.FromArgb(252, 247, 247);

                    this.ActiveControl = InputMessage;

                    break;
                case 1:
                    ChatThemesList.Text = "LightTheme";
                    this.BackColor = Color.FromArgb(252, 252, 252);
                    this.ForeColor = Color.Black;

                    AbonentListPanel.ForeColor = Color.Black;
                    AbonentListPanel.BackColor = Color.FromArgb(252, 252, 252);
                    ShowButton.BackColor = Color.FromArgb(252, 247, 247);
                    ShowButton.ForeColor = Color.Black;
                    ForAllCheck.ForeColor = Color.Black;
                    ForAllCheck.BackColor = Color.FromArgb(252, 247, 247);

                    AbonentList.BackColor = Color.FromArgb(245, 245, 245);
                    AbonentList.ForeColor = Color.Black;

                    LoginPanel.BackColor = Color.FromArgb(252, 252, 252);
                    LoginPanel.ForeColor = Color.Black;
                    InputName.BackColor = Color.FromArgb(245, 245, 245);
                    InputName.ForeColor = Color.Black;
                    ConnDisconnButton.BackColor = Color.FromArgb(252, 247, 247);
                    ConnDisconnButton.ForeColor = Color.Black;
                    ExitButton.BackColor = Color.FromArgb(252, 247, 247);
                    ExitButton.ForeColor = Color.FromArgb(222, 60, 60);

                    Customization.BackColor = Color.FromArgb(252, 252, 252);
                    Customization.ForeColor = Color.Black;
                    ChatThemesList.BackColor = Color.FromArgb(245, 245, 245);
                    ChatThemesList.ForeColor = Color.Black;

                    OutputMessage.BackColor = Color.FromArgb(245, 245, 245);
                    OutputMessage.ForeColor = Color.Black;

                    InputMessage.BackColor = Color.FromArgb(245, 245, 245);
                    InputMessage.ForeColor = Color.Black;

                    SendButton.BackColor = Color.FromArgb(252, 247, 247);
                    SendButton.ForeColor = Color.Black;

                    this.ActiveControl = InputMessage;

                    break;
            }
        }
    }
}
