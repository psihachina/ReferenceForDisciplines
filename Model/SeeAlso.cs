using System.Xml.Serialization;

namespace ReferenceForDisciplines.Model
{
    [XmlRoot("ReferenceContext")]
    public class SeeAlso
    {
        /// <summary>
        ///     Связанная тема
        /// </summary>

        public string ConnectedTopic { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectedTopic">Связанная тема</param>

        //public SeeAlso(string connectedTopic)
        //{
        //    ConnectedTopic = connectedTopic;
        //}
    }
}