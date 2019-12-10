using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ReferenceForDisciplines.Model
{
    public abstract class BaseModelClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            //вызываем событие, уведомляем все подписчиков об изменении свойства
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}