using System.ComponentModel.DataAnnotations;

namespace TiaTeresa.Models
{
    public class Ort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Beschreibung Spanisch")]
        public string BeschreibungSpanisch { get; set; }
        [Display(Name = "Beschreibung Deutsch")]
        public string BeschreibungDeutsch { get; set; }
        public string URL { get; set; }
        public string Bild { get; set; }
        [Display(Name = "Bild Copyright")]
        public string BildCopyright { get; set; }
        public string lon { get; set; }
        public string lat { get; set; }


    }
}
