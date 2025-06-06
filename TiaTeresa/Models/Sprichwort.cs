using System.Security.Policy;

namespace TiaTeresa.Models
{
    public class Sprichwort
    {
        public int ID { get; set; }
        public string Spanisch { get; set; }
        public string Deutsch {  get; set; }
        public string BedeutungSpanisch { get; set; }
        public string BedeutungDeutsch { get; set; }
        public string Bilddatei { get; set; }
    }
}
