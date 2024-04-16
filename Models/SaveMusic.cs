﻿namespace soundcloud_.Models
{
    public class SaveMusic
    {
        public int id { get; set; }
        public string title { get; set; }
        public string? Description { get; set; }
        public string? MusicIime { get; set; }
        public string? ArticName { get; set; }
        public string Date { get; set; }
        public string? Status { get; set; }
        public int USerId { get; set; }
        public User? user { get; set; }

        public IFormFile MusicImage { get; set; }
        public IFormFile MusicAdress { get; set; }
        
    }
}