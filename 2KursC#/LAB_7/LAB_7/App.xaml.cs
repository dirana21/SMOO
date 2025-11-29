using System.IO;
using System.Windows;
using LAB_7.Services;
using LAB_7.ViewModels;

namespace LAB_7
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "Students.xml");
            var repository = new XmlStudentRepository(xmlPath);
            var dialogService = new DialogService();

            var vm = new MainViewModel(repository, dialogService);

            var mainWindow = new MainWindow
            {
                DataContext = vm
            };

            mainWindow.Show();
        }
    }
}
