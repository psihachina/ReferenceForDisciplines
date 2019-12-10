using System.Collections.ObjectModel;
using ReferenceForDisciplines.DAL;
using ReferenceForDisciplines.Pattern;

namespace ReferenceForDisciplines.Model
{
    public class UnitOfWork : IUnitOfWork
    {
        private LocalStorage context;

        public UnitOfWork()
        {
            context = new LocalStorage();
            References = new ReferenceRepository(new ReferenceService().GetReference().References);
            Disciplines = new DisciplineRepository(new DisciplineService().GetDiscipline().Disciplines);
        }

        public IRepository<Reference> References { get; set; }
        public IRepository<Discipline> Disciplines { get; set; }

        public Reference FindTopic(string topicName)
        {
            foreach (var v in References.Get())
                if (v.Name.Equals(topicName))
                    return v;

            return null;
        }

        public void SaveChange()
        {
            new DisciplineService().UpdateDiscipline(new DisciplineContext {Disciplines = Disciplines.Get()});
            new ReferenceService().UpdateReference(new ReferenceContext {References = References.Get()});
        }

        public ObservableCollection<Discipline> GetListDisciplines()
        {
            return Disciplines.Get();
        }

        public ObservableCollection<Reference> GetListReferences()
        {
            return References.Get();
        }
    }
}