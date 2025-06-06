using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace TiaTeresa.Models
{
    public class Sprichwort
    {
        public int ID { get; set; }
        public string Spanisch { get; set; }
        public string Deutsch {  get; set; }
        [Display(Name = "Bedeutung Spanisch")]
        public string BedeutungSpanisch { get; set; }
        [Display(Name = "Bedeutung Deutsch")]
        public string BedeutungDeutsch { get; set; }
        public string Bilddatei { get; set; }
    }
}
