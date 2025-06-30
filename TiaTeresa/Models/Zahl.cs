using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TiaTeresa.Models
{
    public class Zahl
    {
        public int Id { get; set; }

        public string Wert { get; set; }
        public string Spanisch { get; set; }
        public string? Audio { get; set; }


    }
}
