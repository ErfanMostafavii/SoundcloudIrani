using car_service.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using soundcloud_.Models;

namespace soundcloud_.Controllers
{
    public class MusicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult AddMusic()
        //{
        //    return View();
        //}
        public async Task<IActionResult> AddMusic(SaveMusic m)
        {
            //if (ModelState.IsValid)
            //{
              

            //}
            return View();
        //      public string title { get; set; }
        //public string? Description { get; set; }
        //public string? MusicIime { get; set; }
        //public string? ArticName { get; set; }
        //public string Date { get; set; }
        //public string Status { get; set; }
        //public int USerId { get; set; }
        //public User user { get; set; }

        //public IFormFile MusicImage { get; set; }
        //public IFormFile MusicAdress { get; set; }

    }

}
}
