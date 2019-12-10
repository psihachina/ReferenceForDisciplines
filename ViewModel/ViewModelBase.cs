using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        public ViewModelBase(IView view)
        {
            PrepareViewModel();
            View = view;
            View.ViewModel = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public IView View { get; set; }

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

        protected virtual void PrepareViewModel()
        {
        }
    }
}