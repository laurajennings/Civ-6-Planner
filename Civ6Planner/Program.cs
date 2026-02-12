using Civ6Planner._Repos;
using Civ6Planner.Presenters;
using Civ6Planner.Views;
using System.Configuration;

namespace Civ6Planner
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlDb"].ConnectionString;
            var seed = new Seed(sqlConnectionString);
            seed.CheckDbExists();

            IMainView view = new MainView();
            new MainPresenter(view, sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}