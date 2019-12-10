using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("ReferenceContext")]
    public class ReferenceContext
    {
        [XmlElement("Reference")] public ObservableCollection<Reference> References { get; set; }
    }
}