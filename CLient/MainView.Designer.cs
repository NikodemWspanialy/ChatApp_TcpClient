namespace CLient
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ConnectBtn = new Button();
            UsernameInput = new TextBox();
            UserListBox = new ListBox();
            userBindingSource = new BindingSource(components);
            userBindingSource1 = new BindingSource(components);
            MessegeInput = new TextBox();
            SentBtn = new Button();
            ConversationListBox = new ListBox();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // ConnectBtn
            // 
            ConnectBtn.Location = new Point(12, 654);
            ConnectBtn.Name = "ConnectBtn";
            ConnectBtn.Size = new Size(129, 36);
            ConnectBtn.TabIndex = 0;
            ConnectBtn.Text = " Connect to server";
            ConnectBtn.UseVisualStyleBackColor = true;
            ConnectBtn.Click += ConnectBtn_Click;
            // 
            // UsernameInput
            // 
            UsernameInput.Location = new Point(12, 625);
            UsernameInput.Name = "UsernameInput";
            UsernameInput.Size = new Size(129, 23);
            UsernameInput.TabIndex = 1;
            // 
            // UserListBox
            // 
            UserListBox.FormattingEnabled = true;
            UserListBox.ItemHeight = 15;
            UserListBox.Items.AddRange(new object[] { "users" });
            UserListBox.Location = new Point(7, 45);
            UserListBox.Name = "UserListBox";
            UserListBox.Size = new Size(207, 574);
            UserListBox.TabIndex = 2;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Microsoft.VisualBasic.ApplicationServices.User);
            // 
            // userBindingSource1
            // 
            userBindingSource1.DataSource = typeof(Microsoft.VisualBasic.ApplicationServices.User);
            // 
            // MessegeInput
            // 
            MessegeInput.Location = new Point(238, 635);
            MessegeInput.Name = "MessegeInput";
            MessegeInput.Size = new Size(489, 23);
            MessegeInput.TabIndex = 3;
            // 
            // SentBtn
            // 
            SentBtn.Location = new Point(733, 635);
            SentBtn.Name = "SentBtn";
            SentBtn.Size = new Size(80, 23);
            SentBtn.TabIndex = 4;
            SentBtn.Text = "Sent";
            SentBtn.UseVisualStyleBackColor = true;
            SentBtn.Click += SentBtn_Click;
            // 
            // ConversationListBox
            // 
            ConversationListBox.FormattingEnabled = true;
            ConversationListBox.ItemHeight = 15;
            ConversationListBox.Location = new Point(238, 47);
            ConversationListBox.Name = "ConversationListBox";
            ConversationListBox.Size = new Size(573, 574);
            ConversationListBox.TabIndex = 5;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 702);
            Controls.Add(ConversationListBox);
            Controls.Add(SentBtn);
            Controls.Add(MessegeInput);
            Controls.Add(UserListBox);
            Controls.Add(UsernameInput);
            Controls.Add(ConnectBtn);
            Name = "MainView";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnectBtn;
        private TextBox UsernameInput;
        private BindingSource bindingSource1;
        private ListBox UserListBox;
        private ComboBox comboBox;
        private BindingSource userBindingSource;
        private BindingSource userBindingSource1;
        private TextBox MessegeInput;
        private Button SentBtn;
        private ListBox ConversationListBox;
    }
}
