using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Interface
{
    static class Program
    {
        public static List<Thread> myThreards = new List<Thread>();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InterfaceController interfaceController = new InterfaceController();
            Thread thread = new Thread(delegate () { interfaceController.Start(); });
            myThreards.Add(thread);
            thread.Start();

            Thread thread1 = new Thread(delegate () { new Session(interfaceController); });
            myThreards.Add(thread1);
            thread1.Start();
        }
    }
}
