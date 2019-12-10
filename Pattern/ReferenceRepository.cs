using System.Collections.ObjectModel;
using System.Linq;
using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.Pattern
{
    internal class ReferenceRepository : IRepository<Reference>
    {
        private readonly ObservableCollection<Reference> context;

        public ReferenceRepository(ObservableCollection<Reference> db)
        {
            context = db;
        }

        public void Add(Reference value)
        {
            context.Add(value);
        }

        public ObservableCollection<Reference> Get()
        {
            return context;
        }

        public void Remove(Reference value)
        {
            context.Remove(value);
        }


        public void Update(Reference value, Reference newValue)
        {
            var item = context.FirstOrDefault(x => x == value);
            item.Name = newValue.Name;
            item.Document = newValue.Document;
            item.Disciplines = newValue.Disciplines;
            item.Edges = newValue.Edges;
            item = newValue;
        }
    }
}