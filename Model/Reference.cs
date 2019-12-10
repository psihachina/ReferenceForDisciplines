using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("ReferenceContext")]
    public class Reference : BaseModelClass
    {
        private string _name;
        private string _disciplines;
        private string _document;
        private ObservableCollection<SeeAlso> _edges = new ObservableCollection<SeeAlso>();
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Disciplines
        {
            get => _disciplines;
            set => Set(ref _disciplines, value);
        }

        public string Document
        {
            get => _document;
            set => Set(ref _document, value);
        }

        [XmlElement("SeeAlso")]
        public ObservableCollection<SeeAlso> Edges
        {
            get => _edges;
            set => Set(ref _edges, value);
        }

        public override string ToString() => Name;

        public override int GetHashCode()
        {
            return Name.GetHashCode()
                   + Document.GetHashCode()
                   + Edges.GetHashCode()
                   + Disciplines.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Reference;
            if (item == null) return false;

            return item.Name == Name
                   && item.Document == Document
                   && item.Disciplines == Disciplines
                   && item.Edges.Where((x, i) => x != Edges[i]) == null;
        }
    }
}
