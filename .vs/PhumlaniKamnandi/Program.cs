using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhumlaniKamnandi.Data;
using PhumlaniKamnandi.Presentation;

namespace PhumlaniKamnandi
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HotelDB hotelDB = new HotelDB();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainDashboard(hotelDB));
        }
    }
}
