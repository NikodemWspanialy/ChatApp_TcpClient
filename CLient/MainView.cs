using Client.Model;
using Client.Network.IO;
using CLient.Network;
using CLient.Network.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CLient
{
    public partial class MainView : Form
    {

        public ServerClient ServerClient { get; set; } = null!;

        private ObservableCollection<User> users = new ObservableCollection<User>();
        private ObservableCollection<string> messages = new ObservableCollection<string>();
        public MainView()
        {
            InitializeComponent();

            UserListBoxDataSource();
            ConverstionListBoxDataSource();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameInput.Text;
            if (!string.IsNullOrEmpty(username) && ServerClient is null)
            {
                ServerClient = new ServerClient(username);

                //events
                ServerClient.connectedEvent += UserConnected;
                ServerClient.allChatMessageEvent += AllChatMessage;
                ServerClient.disconnectedEvent += UserDisconnected;

                ServerClient.ConnectToServer();

                SendData(1, username);
            }
        }

        private void UserDisconnected()
        {
            var uID = ServerClient.Read();
            var dcUser = users.FirstOrDefault(x => x.UID == uID);
            if(dcUser is null)
            {
                return;
            }
            users.Remove(dcUser);
            messages.Add($"[{DateTime.Now}] {dcUser.Username} left the chat");
            ConversationListBoxInvoke();
        }

        private void AllChatMessage()
        {
            var message = ServerClient.Read();
            messages.Add(message);
            ConversationListBoxInvoke();
        }

        private void UserConnected()
        {
            var user = new User()
            {
                Username = ServerClient.Read(),
                UID = ServerClient.Read(),
            };
            if (!users.Where(x => x.UID == user.UID).Any())
            {
                users.Add(user);
                if (UserListBox.InvokeRequired)
                {
                    UserListBox.Invoke(new MethodInvoker(delegate
                    {
                        UserListBoxDataSource();
                    }));
                }
                else
                {
                    UserListBoxDataSource();
                }
                messages.Add($"[{DateTime.Now}] {user.Username} join the chat");
                ConversationListBoxInvoke();
            }
        }

        private void SendData(byte func, string data)
        {
            var pb = new PacketBuilder();
            pb.WriteFuncCode(func);
            pb.WriteData(data);
            this.ServerClient.Send(pb.GetStream());
        }
        public void UserListBoxDataSource()
        {
            UserListBox.DataSource = null;
            UserListBox.DataSource = users;
            UserListBox.DisplayMember = "Username";
        }
        private void ConversationListBoxInvoke()
        {
            if (ConversationListBox.InvokeRequired)
            {
                UserListBox.Invoke(new MethodInvoker(delegate
                {
                    ConverstionListBoxDataSource();
                }));
            }
            else
            {
                ConverstionListBoxDataSource();
            }
        }
        private void ConverstionListBoxDataSource()
        {
            ConversationListBox.DataSource = null;
            ConversationListBox.DataSource = messages;
        }

        private void SentBtn_Click(object sender, EventArgs e)
        {
            var message = MessegeInput.Text;
            if (ServerClient is not null && !String.IsNullOrEmpty(message))
            {
                SendData(3, message);
            }
        }
    }
}
