using System;
using System.IO;
using System.Windows.Forms;

namespace MyChat
{
    class Chat
    {
        private byte[] semaphoreState = new byte[1];

        /// <summary>
        /// Loads chat content if semaphore indicates availability.
        /// </summary>
        /// <param name="chatBox">RichTextBox control to display chat content</param>
        /// <param name="semaphoreTimer">Timer control to manage loading state</param>
        public void Load(RichTextBox chatBox, System.Windows.Forms.Timer semaphoreTimer)
        {
            ReadSemaphoreState();

            if (IsSemaphoreUpdated())
            {
                SetSemaphoreState(false); // Set semaphore to actual (0)
                chatBox.LoadFile("Chat.rtf");

                semaphoreTimer.Stop();
            } else
            {
                semaphoreTimer.Start();
            }
        }

        /// <summary>
        /// Saves chat content and updates semaphore to indicate file is in use.
        /// </summary>
        /// <param name="chatBox">RichTextBox control with chat content</param>
        public void Send(RichTextBox chatBox, System.Windows.Forms.Timer semaphoreTimer)
        {
            chatBox.SaveFile("Chat.rtf");
            SetSemaphoreState(true); // Set semaphore to THERE'S SOME UPDATES (1)


            semaphoreTimer.Start();
        }

        /// <summary>
        /// Reads the semaphore state from the file.
        /// </summary>
        private void ReadSemaphoreState()
        {
            using (FileStream semaphoreFile = File.OpenRead("Semaphore.txt"))
            {
                semaphoreFile.Read(semaphoreState, 0, 1);
            }
        }

        /// <summary>
        /// Sets the semaphore state to available (0) or in use (1) and writes to file.
        /// </summary>
        /// <param name="isChatUpdated">If true, sets state to in use (1); if false, sets state to available (0)</param>
        private void SetSemaphoreState(bool isChatUpdated)
        {
            semaphoreState[0] = Convert.ToByte(isChatUpdated ? '1' : '0');
            using (FileStream semaphoreFile = File.OpenWrite("Semaphore.txt"))
            {
                semaphoreFile.Write(semaphoreState, 0, 1);
            }
            //MessageBox.Show(isChatUpdated ? "1" : "0");

        }

        /// <summary>
        /// Checks if the semaphore is currently available (1).
        /// </summary>
        /// <returns>True if semaphore state is available (1); false otherwise.</returns>
        private bool IsSemaphoreUpdated()
        {
            return semaphoreState[0] == Convert.ToByte('1');
        }
    }
}
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MyChat
{
    internal class Chat
    {
        byte[] semaphoreState = new byte[1];

        // Есть стейт 0 или 1
        // 0 - изменений нет
        // 1 - изменения есть
        // Каждую секунду читаем файл, если 0, то ничего не делаем
        // Если 1, то загружаем его в поле и обновляем состояние в 0

        private void changeSemaphoreState(char state)
        {
            semaphoreState[0] = (byte) state;

            using (FileStream semaphoreFile = File.OpenWrite("Semaphore.txt"))
            {
                semaphoreFile.Write(semaphoreState, 0, 1);
            }
        }

        public void Load(RichTextBox chatBox, System.Windows.Forms.Timer semaphoreTimer)
        {
            // Load semaphore status from file
            using (FileStream semaphoreFile = File.OpenRead("Semaphore.txt"))
            {
                semaphoreFile.Read(semaphoreState, 0, 1);
            }

            // Check if semaphore is available (equals '0')
            if (semaphoreState[0] == (byte)'1') {
            //    semaphoreTimer.Enabled = true; // Enable timer to indicate active load state
            // }
            // else
            // {
                

                // And load content for chat
                chatBox.LoadFile("Chat.txt", RichTextBoxStreamType.PlainText);
                // semaphoreTimer.Enabled = false;

                // Update semaphore state to 0 (available) and write to file
                changeSemaphoreState('0');
            }
        }

        public void Send(RichTextBox chatBox)
        {
            chatBox.SaveFile("Chat.txt", RichTextBoxStreamType.PlainText);

            changeSemaphoreState('1');
        }
    }
}

        */
