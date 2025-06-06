namespace TiaTeresa.Models
{
    public class Geschichte
    {
        public int Id { get; set; }
        
        public string TitelSpanisch { get; set; }
        public string TitelDeutsch { get; set; }
        public string Spanisch { get; set; }
        public string Deutsch { get; set; }
        public string Niveau { get; set; }
        public string? Bild { get; set; }
        public string? Audio { get; set; }


    }
}
