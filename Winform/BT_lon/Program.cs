using System;
using System.Windows.Forms;

namespace BT_lon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_form());
            // Application.Run(new Form1());
            //Application.Run(new Cap_nhat_MK());
            // Application.Run(new Them_NV());
            // Application.Run(new Sua_nhan_vien());
            // Application.Run(new test());

        }



    }
}
