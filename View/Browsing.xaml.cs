using System;
using System.Windows.Controls;
using ReferenceForDisciplines.ViewModel;

namespace ReferenceForDisciplines.View
{
    /// <summary>
    ///     Логика взаимодействия для BrowsingUC.xaml
    /// </summary>
    public partial class Browsing : UserControl, IView
    {
        public Browsing()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get => DataContext as IViewModel;
            set => DataContext = value;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public ListView GetListView()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}