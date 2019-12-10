using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("DisciplineContext")]
    public class Discipline : BaseModelClass
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Discipline item = obj as Discipline;
            if (item == null) return false;

            return item.Name == Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}