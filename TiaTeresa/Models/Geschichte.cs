using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiaTeresa.Models
{
    public class Geschichte
    {
        public int Id { get; set; }

        [Display(Name = "Titel Spanisch")]
        public string TitelSpanisch { get; set; }
        [Display(Name = "Titel Deutsch")]
        public string TitelDeutsch { get; set; }
        public string Spanisch { get; set; }
        public string Deutsch { get; set; }
        public string Niveau { get; set; }
        public string? Bild { get; set; }
        public string? Audio { get; set; }


    }
}
