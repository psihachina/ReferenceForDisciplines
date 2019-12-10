using CurrencyConverter.Patterns;
using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.DAL
{
    internal class ReferenceService : IReferenceService
    {
        public ReferenceContext GetReference()
        {
            var path = "D:/Project/ReferenceForDisciplines/ReferenceForDisciplines/Content/References.xml";
            return Xml.LoadObjectFromFile<ReferenceContext>(path);
        }

        public void UpdateReference(ReferenceContext t)
        {
            var path = "D:/Project/ReferenceForDisciplines/ReferenceForDisciplines/Content/References.xml";
            Xml.Serelialize(t).Save(path);
        }
    }
}