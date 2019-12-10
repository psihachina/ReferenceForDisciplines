using CurrencyConverter.Patterns;
using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.DAL
{
    internal class DisciplineService : IDisciplineService
    {
        public DisciplineContext GetDiscipline()
        {
            var path = "D:/Project/ReferenceForDisciplines/ReferenceForDisciplines/Content/Disciplines.xml";
            return Xml.LoadObjectFromFile<DisciplineContext>(path);
        }

        public void UpdateDiscipline(DisciplineContext t)
        {
            var path = "D:/Project/ReferenceForDisciplines/ReferenceForDisciplines/Content/Disciplines.xml";
            Xml.Serelialize(t).Save(path);
        }
    }
}