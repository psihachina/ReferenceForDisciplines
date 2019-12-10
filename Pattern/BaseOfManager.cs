using ReferenceForDisciplines.Model;

namespace ReferenceForDisciplines.Pattern
{
    internal class BaseOfManager
    {
        private static BaseOfManager _instance;

        public UnitOfWork unitOfWork = new UnitOfWork();

        private BaseOfManager()
        {
        }

        public static BaseOfManager GetInstance()
        {
            if (_instance == null) _instance = new BaseOfManager();
            return _instance;
        }
    }
}