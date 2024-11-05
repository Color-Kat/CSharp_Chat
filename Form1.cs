namespace MyChat
{
    public partial class Form1 : Form
    {
        private Chat Chat = new Chat();

        public Form1()
        {
            InitializeComponent();
        }

        private void loadChatButton_Click(object sender, EventArgs e)
        {
            Chat.Load(chatBox, semaphoreTimer);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            Chat.Send(chatBox, semaphoreTimer);
        }

        private void semaphoreTimer_Tick(object sender, EventArgs e)
        {
            // Every tick update semaphore
            Chat.Load(chatBox, semaphoreTimer);
            // MessageBox.Show("123");
        }
    }
}
