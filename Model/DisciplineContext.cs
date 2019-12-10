using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("DisciplineContext")]
    public class DisciplineContext : INotifyPropertyChanged
    {
        public DisciplineContext()
        {
            Disciplines = new ObservableCollection<Discipline>();
            Disciplines.CollectionChanged += Disciplines_CollectionChanged;
        }

        [XmlElement("Discipline")] public ObservableCollection<Discipline> Disciplines { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Disciplines_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Disciplines");
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}