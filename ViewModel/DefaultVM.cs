using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ReferenceForDisciplines.ViewModel
{
    public class DefaultVM : ViewModelBase
    {
        private ObservableCollection<Reference> _referencesList = new ObservableCollection<Reference>();
        private Reference _selectedReference;
        public MainVm mainVM;

        public DefaultVM(IView view, MainVm mainVM) : base(view)
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
                    var viewModel = new EditTopicVm(new EditTopic(), SelectedReference);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenDeleteTopic =>
            new UserCommand(() =>
                {
                    var viewModel = new DeleteTopicVm(new DeleteTopic(), SelectedReference, ReferencesList);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public void OpenBrowsing()
        {
            var browsing = new Browsing();
            new BrowsingVM(new Browsing(), SelectedReference, mainVM, this)
            {
                SelectedReference = _selectedReference
            };
            mainVM.ContentWindow = browsing;
        }
    }
}