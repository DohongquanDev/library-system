using Libarary.GUI;
using Libarary.Models;

namespace Libarary
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using(var db = new LibararyContext())
            {
                db.Copies.ToList();
            }
            Application.Run(new LoginGUI());
        }
    }
}