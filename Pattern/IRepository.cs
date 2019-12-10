using System.Collections.ObjectModel;

namespace ReferenceForDisciplines.Pattern
{
    public interface IRepository<T>
    {
        void Add(T value);
        void Remove(T value);
        void Update(T value, T newValue);

        ObservableCollection<T> Get();
    }
}