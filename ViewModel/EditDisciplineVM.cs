using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MaterialDesignThemes.Wpf;
using ReferenceForDisciplines.View;

namespace ReferenceForDisciplines.ViewModel
{
    internal class EditDisciplineVM
    {
        private string _newName;
        private EditDialog editDialog;


        public EditDisciplineVM(EditDialog model)
        {
            editDialog = model;
        }

        public DialogSession DialogSession { get; set; }


        public string NewName
        {
            get => _newName;
            set => Set(ref _newName, value);
        }

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