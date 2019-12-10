using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("DisciplineContext")]
    public class Discipline : BaseModelClass
    {
        private string name;

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Discipline;
            if (item == null) return false;

            return item.Name == Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}