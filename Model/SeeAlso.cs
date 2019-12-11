using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("ReferenceContext")]
    public class SeeAlso : BaseModelClass
    {
        private string _connectedTopic;


        public string ConnectedTopic
        {
            get => _connectedTopic;
            set => Set(ref _connectedTopic, value);
        }
    }
}