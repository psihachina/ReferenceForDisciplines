using System.Windows;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines
{
    /// <summary>
    ///     Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            new MainVM(new MainWindow());
        }
    }
}