using System;
using System.Windows.Forms;

namespace Client10
{
    //class MessageCallback : IServerCallback
    //{
    //    public void cbSendMessage(string senderName, string message)
    //    {
    //       // Console.WriteLine(senderName + ":" + message);
    //    }
    //    public void cbShowAbonent(string abonentName, bool abonentStatus)
    //    {
    //        //Console.WriteLine(abonentName + " " + abonentStatus);
    //    }
    //}


    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Chat());
        }
    }
}
