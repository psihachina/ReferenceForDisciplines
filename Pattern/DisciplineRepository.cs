using System.Collections.ObjectModel;
using System.Linq;
using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.Pattern
{
    internal class DisciplineRepository : IRepository<Discipline>
    {
        private readonly ObservableCollection<Discipline> context;

        public DisciplineRepository(ObservableCollection<Discipline> db)
        {
            context = db;
        }

        public void Add(Discipline value)
        {
            context.Add(value);
        }

        public ObservableCollection<Discipline> Get()
        {
            return context;
        }

        public void Remove(Discipline value)
        {
            context.Remove(value);
        }

        public void Update(Discipline value, Discipline newValue)
        {
            //Так работает
            //var i = context.IndexOf(value);
            //context.Remove(value);
            //context.Insert(i, newValue);

            var item = context.FirstOrDefault(x => x == value);
            item.Name = newValue.Name;
        }
    }
}