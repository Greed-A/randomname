using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lines
{
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

            Game game = new Game();
            Form2 form = new Form2();
            Form3 form3 = new Form3();
            Application.Run(new Form2());

            if (form.res >=8||form.res<=32)
            {
                Application.Run(new Form1());
            }

        }
    }
}
