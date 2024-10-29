namespace MyChat
{
    partial class Form1
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
            loadChatButton = new Button();
            chatBox = new RichTextBox();
            sendButton = new Button();
            semaphoreTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // loadChatButton
            // 
            loadChatButton.Location = new Point(15, 17);
            loadChatButton.Name = "loadChatButton";
            loadChatButton.Size = new Size(150, 46);
            loadChatButton.TabIndex = 0;
            loadChatButton.Text = "Load Chat";
            loadChatButton.UseVisualStyleBackColor = true;
            loadChatButton.Click += loadChatButton_Click;
            // 
            // chatBox
            // 
            chatBox.Location = new Point(17, 77);
            chatBox.Name = "chatBox";
            chatBox.Size = new Size(775, 615);
            chatBox.TabIndex = 1;
            chatBox.Text = "";
            // 
            // sendButton
            // 
            sendButton.Location = new Point(678, 625);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(97, 46);
            sendButton.TabIndex = 2;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // semaphoreTimer
            // 
            semaphoreTimer.Interval = 1000;
            semaphoreTimer.Tick += semaphoreTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 755);
            Controls.Add(sendButton);
            Controls.Add(chatBox);
            Controls.Add(loadChatButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button loadChatButton;
        private RichTextBox chatBox;
        private Button sendButton;
        private System.Windows.Forms.Timer semaphoreTimer;
    }
}
