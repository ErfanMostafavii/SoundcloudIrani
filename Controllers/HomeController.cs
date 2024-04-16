using Microsoft.AspNetCore.Mvc;
using soundcloud_.Models;
using System.Diagnostics;
using System.Text.Json;
using soundcloud_.Service.Queries.GetAllMusic;
using soundcloud_.Models.ViewModels;
using soundcloud_.Service.Queries.GetArtist;
using soundcloud_.Service.Queries.UserPlaylist;
using soundcloud_.Service.Queries.GetUserInfo;

namespace soundcloud_.Controllers
{
   
    public class HomeController : Controller
    {
        IGetAllMusic _GetAllMusic;
        private readonly ILogger<HomeController> _logger;
        IGetArtists _GetArtists;
        IGetUserPlaylist _GetUserPlaylist;
        IGetUserInfo _GetUserInfo;
        public HomeController(ILogger<HomeController> logger, IGetAllMusic GetAllMusic, IGetArtists GetArtists, IGetUserPlaylist GetUserPlaylist, IGetUserInfo GetUserInfo)
        {
            _logger = logger;
            _GetAllMusic = GetAllMusic;
            _GetArtists = GetArtists;
            _GetUserPlaylist = GetUserPlaylist;
            _GetUserInfo = GetUserInfo;
        }

        public async Task<IActionResult> Index()
        {
            var music = await _GetAllMusic.getAllMusic();
            var artists = await _GetArtists.getArtists();
            ViewBag.Artists = artists;
            ViewBag.music = music;
            return View();
        }
        public IActionResult UserPlaylist(int id)
        {
            var user= _GetUserInfo.GetUserinfo(id);
           var music= _GetUserPlaylist.getUserPlaylist(id);
            ViewBag.music = music;
            ViewBag.user = user;
             return View();
        }
        [HttpPost]
        public async Task<JsonResult> UserPlaylist_Json(int id)
        {

            var music = _GetUserPlaylist.getUserPlaylist(id);
            music.ToArray();
            return Json(music);
        }
        [HttpPost]
        public async Task<JsonResult> UserMusics()
        {
           
            var music =await _GetAllMusic.getAllMusic();
            music.ToArray();
            return Json(music);
        }


     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}