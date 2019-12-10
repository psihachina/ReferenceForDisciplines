using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class BrowsingVM
    {
        private Browsing _browsingtUC;
        private FixedDocumentSequence _document;
        private Reference _selectedReference;
        private SeeAlso _selectedReferenceEdge;
        private readonly DefaultVM defaultVM;
        private readonly MainVM mainVM;

        public BrowsingVM(Browsing model, Reference reference, MainVM mainVM, DefaultVM defaultVM)
        {
            this.defaultVM = defaultVM;
            _browsingtUC = model;
            SelectedReference = reference;
            this.mainVM = mainVM;
        }

        public Reference SelectedReference
        {
            get => _selectedReference;
            set
            {
                if (Set(ref _selectedReference, value))
                    Document = new XpsDocument(SelectedReference.Document, FileAccess.Read).GetFixedDocumentSequence();
            }
        }

        public SeeAlso SelectedReferenceEdge
        {
            get => _selectedReferenceEdge;
            set
            {
                if (value != null)
                    if (Set(ref _selectedReferenceEdge, value))
                    {
                        defaultVM.SelectedReference = BaseOfManager.GetInstance().unitOfWork
                            .FindTopic(_selectedReferenceEdge.ConnectedTopic);
                        defaultVM.OpenBrowsing();
                    }
            }
        }

        public FixedDocumentSequence Document
        {
            get => _document;
            set => Set(ref _document, value);
        }

        public ICommand Back =>
            new UserCommand(async () =>
                {
                    var defaultUC = new Default();
                    var defaultUCVM = new DefaultVM(defaultUC, mainVM);
                    defaultUCVM.ReferencesList = mainVM.ReferencesList;
                    defaultUCVM.ReferencesList = new ObservableCollection<Reference>(BaseOfManager.GetInstance()
                        .unitOfWork.References.Get().Where(x => x.Disciplines == mainVM.SelectedDiscipline.Name));
                    defaultUC.DataContext = defaultUCVM;
                    mainVM.ContentWindow = defaultUC;
                }
            );

        public ICommand OpenAddSeeAlso =>
            new UserCommand(() =>
                {
                    var viewModel = new AddSeeAlsoVM(new AddSeeAlso(), SelectedReference);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

        public ICommand OpenEditSeeAlso =>
            new UserCommand(() =>
                {
                    var viewModel = new EditSeeAlsoVM(new EditSeeAlso(), SelectedReference, SelectedReferenceEdge);
                    object dialogResult = DialogHost.Show(viewModel.View,
                        new DialogOpenedEventHandler((sender, args) => { viewModel.DialogSession = args.Session; }));
                }
            );

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

        public void SetEgdeReference()
        {
            SelectedReference = BaseOfManager.GetInstance().unitOfWork.FindTopic(SelectedReferenceEdge.ConnectedTopic);
        }
    }
}