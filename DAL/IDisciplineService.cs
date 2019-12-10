using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.DAL
{
    internal interface IDisciplineService
    {
        DisciplineContext GetDiscipline();
        void UpdateDiscipline(DisciplineContext t);
    }
}