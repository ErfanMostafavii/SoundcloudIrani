namespace soundcloud_.Models
{
    public class Music
    {
        public int id { get; set; }
        public string title { get; set; }
        public string? Description { get; set; }
        public string MusicImage { get; set; }
        public string MusicAdress { get; set; }
        public string? MusicIime { get; set; }
        public string? ArticName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int USerId { get; set; }
        public User? user { get; set; }  
    }
}
