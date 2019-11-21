using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Client10.Service;
using System.ServiceModel;
using System.Drawing;

namespace Client10
{
    public partial class Chat : Form, IServerCallback
    {
        int id;
        ServerClient client = null;
        Dictionary<int, Abonent> allAbonents;          
        string userName = "";
        Status status = Status.Offline;
        public Chat()
        {
            InitializeComponent();
            this.ActiveControl = InputName;
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

                userName = InputName.Text.Trim();
                id = client.Connect(userName);
                status = Status.Online;
                allAbonents = client.ShowAbonents(id);


                OutputMessage.ReadOnly  = false;
                SendButton.Enabled      = true;
                InputMessage.ReadOnly   = false;
                AbonentList.Enabled     = true;
                ConnDisconnButton.Text  = "Disconnect";
                InputName.ReadOnly      = true;
                ShowButton.Enabled      = true;
                ForAllCheck.Enabled     = true;
                this.Text               = userName+": "+status;

                DrawAbonentList(userName, status,allAbonents);

                var h = client.ProvideMessage(id);
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
            client.Disconnect(id);
            client = null;
            status = Status.Offline;

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

        private int GetId(string name, Dictionary<int, Abonent> allUsers)
        {
            int id = 0;
            foreach(int ID in allUsers.Keys)
            {
                if (allUsers[ID].name == name)
                    id = ID;
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
                    client.SendMessage(id, null, InputMessage.Text); 
                }
                else 
                {
                    List<int> destination = new List<int>();

                    foreach(var index in AbonentList.CheckedIndices)
                    {
                        int tmpUserIndex = Convert.ToInt32(index.ToString());
                        string selectedUser = AbonentList.Items[tmpUserIndex].ToString();
                        string tmpName = selectedUser.Substring(0, selectedUser.IndexOf(":"));

                        destination.Add(GetId(tmpName,allAbonents));
                        
                    }
                    if (destination.Count == 0)
                    {
                        MessageBox.Show("Выберите кому отправить сообщение");
                        return;
                    }
                    else 
                    {
                        client.SendMessage(id, destination.ToArray(), InputMessage.Text);
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
            if (status == Status.Online)
            {
                DisconnectMethod();
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }

        private int in_List(string userName)
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

        //private string MakeName(string name, Status status, Abonent longestUser)
        //{
        //    string resultName = name + ": ";
        //    string tmpName = resultName + status;

        //    string longestName = longestUser.name+": "+longestUser.status;

        //    while (tmpName.Length < longestName.Length)
        //    {
        //        resultName += ' ';
        //        tmpName = resultName + status;
        //    }

        //    return resultName+status;

        //}

        //private Abonent MaxNameInAbonents(Dictionary<int, Abonent> allUsers)
        //{
        //    Abonent maxName = new Abonent();
        //    maxName.name = "";
        //    maxName.status = Status.Online;
            
        //    foreach(int index in allUsers.Keys)
        //    {
        //        if (maxName.name.Length < allUsers[index].name.Length)
        //        {
        //            maxName.name   = allUsers[index].name;
        //            maxName.status = allUsers[index].status;
        //        }
        //    }

        //    return maxName;
        //}

        private void DrawAbonentList(string tmpUserName = "<default>", Status tmpUserStatus = Status.Offline, Dictionary<int, Abonent> allUsers = null)
        {
            int tmpUserIndex = -1;

            //Abonent maxSizeName = MaxNameInAbonents(allUsers);

            foreach (int index in allUsers.Keys)
            {
                tmpUserIndex = in_List(allUsers[index].name);

                if (tmpUserIndex == -1)
                {
                    AbonentList.Items.Add(allUsers[index].name + ": "+ allUsers[index].status);
                    //AbonentList.Items.Add(MakeName(allUsers[index].name, allUsers[index].status, maxSizeName));
                }
                else
                {
                    AbonentList.Items[tmpUserIndex] = allUsers[index].name + ": "+ allUsers[index].status;
                    //AbonentList.Items[tmpUserIndex] = MakeName(allUsers[index].name, allUsers[index].status, maxSizeName);
                }
            }

            tmpUserIndex = in_List(tmpUserName);

            if (tmpUserIndex == -1)
                AbonentList.Items.Add(tmpUserName + ": " + tmpUserStatus);
            else
                AbonentList.Items[tmpUserIndex] = tmpUserName + ": " + tmpUserStatus;
            //AbonentList.Items.Add(MakeName(tmpUserName, tmpUserStatus, maxSizeName));


            AbonentList.Items.Remove(userName + ": " + status);
            //AbonentList.Items.Remove(MakeName(userName, status, maxSizeName));
        }

        public void cbSendMessage(string senderName, string message)
        {
            OutputMessage.Text += senderName + ": " + message+"\r";
        }
        public void cbShowAbonent(Abonent abonent)
        {
            //int index = in_List(abonent.name);
            //AbonentList.Items[index] = abonent.name + ": " + abonent.status;
            DrawAbonentList(abonent.name, abonent.status, allAbonents);
        }

        private void ConnDisconnButton_Click(object sender, EventArgs e)
        {
            if (status == Status.Online)
            {
                DisconnectMethod();            
            }
            else
            {
                ConnectMethod();
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
                ConnectMethod();
            }
        }

        private void InputMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMethod();
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            allAbonents = client.ShowAbonents(id);

            //DrawAbonentList(userName, status, allAbonents);
            DrawAbonentList(userName, status,allAbonents);
            //MessageBox.Show("Отрисовал, проверяй");
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
                    this.BackColor = Color.FromArgb(27, 28, 28);
                    this.ForeColor = Color.White;

                    AbonentListPanel.ForeColor = Color.White;
                    ShowButton.BackColor = Color.FromArgb(37, 38, 38);
                    ShowButton.ForeColor = Color.White;
                    ForAllCheck.ForeColor = Color.White;
                    ForAllCheck.BackColor = Color.FromArgb(37, 38, 38);

                    AbonentList.BackColor = Color.FromArgb(37, 38, 38);
                    AbonentList.ForeColor = Color.FromArgb(252, 247, 247);

                    LoginPanel.BackColor = Color.FromArgb(37, 38, 38);
                    LoginPanel.ForeColor = Color.FromArgb(252, 247, 247);
                    InputName.BackColor = Color.FromArgb(37, 38, 38);
                    InputName.ForeColor = Color.FromArgb(252, 247, 247);
                    ConnDisconnButton.BackColor = Color.FromArgb(37, 38, 38);
                    ConnDisconnButton.ForeColor = Color.FromArgb(252, 247, 247);
                    ExitButton.BackColor = Color.FromArgb(37, 38, 38);
                    ExitButton.ForeColor = Color.FromArgb(222, 60, 60);

                    Customization.BackColor = Color.FromArgb(37, 38, 38);
                    Customization.ForeColor = Color.FromArgb(252, 247, 247);
                    ChatThemesList.BackColor = Color.FromArgb(37, 38, 38);
                    ChatThemesList.ForeColor = Color.FromArgb(252, 247, 247);

                    OutputMessage.BackColor = Color.FromArgb(37, 38, 38);
                    OutputMessage.ForeColor = Color.FromArgb(252, 247, 247);

                    InputMessage.BackColor = Color.FromArgb(37, 38, 38);
                    InputMessage.ForeColor = Color.FromArgb(252, 247, 247);

                    SendButton.BackColor = Color.FromArgb(37, 38, 38);
                    SendButton.ForeColor = Color.White;
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
                    break;
            }
        }

     
    }
}
