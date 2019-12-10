using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.DAL
{
    internal interface IReferenceService
    {
        ReferenceContext GetReference();
        void UpdateReference(ReferenceContext t);
    }
}