using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    public class DefaultVM : ViewModelBase
    {
        private Default _defaultUC;

        private ObservableCollection<Reference> _referencesList = new ObservableCollection<Reference>();
        private Reference _selectedReference;
        public MainVM mainVM;

        public DefaultVM(IView view, MainVM mainVM) : base(view)
        {
            View.ViewModel = this;
            this.mainVM = mainVM;
            if (mainVM.SelectedDiscipline != null)
                _referencesList = new ObservableCollection<Reference>(BaseOfManager.GetInstance().unitOfWork.References
                    .Get().Where(x => x.Disciplines == mainVM.SelectedDiscipline.Name));
        }

        public ObservableCollection<Reference> ReferencesList
        {
            get => _referencesList;
            set => Set(ref _referencesList, value);
        }

        public Reference SelectedReference
        {
            get => _selectedReference;
            set
            {
                if (Set(ref _selectedReference, value))
                    OpenBrowsing();
            }
        }

        public ICommand OpenAddTopic =>
            new UserCommand(() =>
                {
                    var viewModel = new AddTopicVM(new EditTopic(), mainVM.SelectedDiscipline, this);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenEditTopic =>
            new UserCommand(() =>
                {
                    var viewModel = new EditTopicVM(new EditTopic(), SelectedReference);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenDeleteTopic =>
            new UserCommand(() =>
                {
                    var viewModel = new DeleteTopicVM(new DeleteTopic(), SelectedReference, ReferencesList);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public void OpenBrowsing()
        {
            var browsing = new Browsing();
            var browsingUCVM = new BrowsingVM(browsing, SelectedReference, mainVM, this);
            browsingUCVM.SelectedReference = _selectedReference;
            browsing.DataContext = browsingUCVM;
            mainVM.ContentWindow = browsing;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}