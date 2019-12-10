using System.Collections.ObjectModel;
using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines
{
    internal class LocalStorage
    {
        public LocalStorage()
        {
            Disciplines = new ObservableCollection<Discipline>
            {
                new Discipline {Name = "Структуры данных"},
                new Discipline {Name = "Архитектура информационных систем"},
                new Discipline {Name = "Управление данными"},
                new Discipline {Name = "Дискретная математика"},
                new Discipline {Name = "Математическая логика"},
                new Discipline {Name = "Общая теория систем и системный анализ"},
                new Discipline {Name = "Основы теории управления"}
            };

            References = new ObservableCollection<Reference>
            {
                new Reference
                {
                    Name = "Массив",
                    Document = "D:\\Project\\ReferenceForDisciplines\\ReferenceForDisciplines\\Content\\Массив.xps",
                    Disciplines = Disciplines[0].Name
                },
                new Reference
                {
                    Name = "Список",
                    Document = "D:\\Project\\ReferenceForDisciplines\\ReferenceForDisciplines\\Content\\Список.xps",
                    Disciplines = Disciplines[0].Name
                },
                new Reference
                {
                    Name = "В-дерево",
                    Document = "D:\\Project\\ReferenceForDisciplines\\ReferenceForDisciplines\\Content\\Массив.xps",
                    Disciplines = Disciplines[0].Name
                }
            };
        }

        public ObservableCollection<Discipline> Disciplines { get; set; }
        public ObservableCollection<Reference> References { get; set; }
    }
}