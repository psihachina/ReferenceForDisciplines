using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    public interface IViewModel
    {
        IView View { get; set; }
    }
}