using ReferenceForDisciplines.Model;
using ReferenceForDisciplines.Pattern;

namespace ReferenceForDisciplines.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Reference> References { get; set; }
        IRepository<Discipline> Disciplines { get; set; }
        void SaveChange();
        Reference FindTopic(string topicName);
    }
}