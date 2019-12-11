using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    public class DefaultVm : ViewModelBase
    {
        private ObservableCollection<Reference> _referencesList = new ObservableCollection<Reference>();
        private Reference _selectedReference;
        public MainVm MainVm;

        public DefaultVm(IView view, MainVm mainVm) : base(view)
        {
            View.ViewModel = this;
            MainVm = mainVm;
            if (mainVm.SelectedDiscipline != null)
                _referencesList = new ObservableCollection<Reference>(BaseOfManager.GetInstance().unitOfWork.References
                    .Get().Where(x => x.Disciplines == mainVm.SelectedDiscipline.Name));
        }

        public ObservableCollection<Reference> ReferencesList
        {
            get => _referencesList;
            set => Set(ref _referencesList, value);
        }

        public Reference SelectedReference
        {
            get => _selectedReference;
            set => Set(ref _selectedReference, value);
        }

        public ICommand OpenAddTopic =>
            new UserCommand(() =>
                {
                    var viewModel = new AddTopicVm(new AddTopic(), MainVm.SelectedDiscipline, this);
                    DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenEditTopic =>
            new UserCommand(() =>
                {
                    var viewModel = new EditTopicVm(new EditTopic(), SelectedReference);
                    DialogHost.Show(viewModel.View,
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

        public ICommand OpenBrowsing =>
            new UserCommand(() => { OnOpenBrowsing(); }
            );

        public void OnOpenBrowsing()
        {
            var browsing = new Browsing();
            browsing.DataContext = new BrowsingVM(browsing, SelectedReference, MainVm, this)
            {
                SelectedReference = _selectedReference
            };
            MainVm.ContentWindow = browsing;
        }
    }
}