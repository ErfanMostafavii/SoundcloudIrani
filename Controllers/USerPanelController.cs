using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using soundcloud_.Models;
using soundcloud_.Models.Utilitis;
using soundcloud_.Service.Commands.Musics;
using soundcloud_.Service.UpladImageMusic;
using soundcloud_.Service.UploadMusic;
using System.Diagnostics;
using System.Security.Claims;
using soundcloud_.Service.Queries.GetUserInfo;
using soundcloud_.Service.Queries.GetUserMusic;

namespace soundcloud_.Controllers
{
    public class USerPanelController : Controller
    {
        private readonly IWebHostEnvironment _webhostenviroment;
        IAddMusics _AddMusic;
        IGetUserInfo _IGetUserInfo;
        IGetUserMusic _IGetUserMusic;
        public USerPanelController(IWebHostEnvironment webhostenviroment, IAddMusics AddMusic, IGetUserInfo IGetUserInfo, IGetUserMusic IGetUserMusic)
        {
            _webhostenviroment = webhostenviroment;
            _AddMusic = AddMusic;
            _IGetUserInfo= IGetUserInfo;
            _IGetUserMusic = IGetUserMusic;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var UserMusic = _IGetUserMusic.getUserMusic(Convert.ToInt16(userId));
            ViewBag.UserMusic= UserMusic;
            return View();
        }
        public IActionResult UserInfo()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var USer= _IGetUserInfo.GetUserinfo(Convert.ToInt16( userId));
            ViewBag.USer = USer;
            return View();
        }
        //public IActionResult UserInfo()
        //{
        //    var USer _IGetUserInfo.GetUserinfo();
        //    return View();
        //}
        public IActionResult AddMusic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMusic(SaveMusic m)
        {
            
            UploadMusic uplm = new UploadMusic(_webhostenviroment);
            UpoadImageMusics uplimage = new UpoadImageMusics(_webhostenviroment);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Music Music = new Music();

            Music.title = m.title;
            Music.ArticName = m.ArticName;
            Music.Date = DateTime.Now;
            Music.Status = "برسی";
            Music.USerId =Convert.ToInt16( userId);

            Music.MusicImage = uplimage.upload(m.MusicImage);
            Music.MusicAdress = uplm.upload(m.MusicAdress);

    
        var musicFilePath = _webhostenviroment.WebRootPath + "\\Musics\\" + m.MusicAdress.FileName;
        var fileTag = TagLib.File.Create(musicFilePath);
            var duration = fileTag.Properties.Duration;
           

            var totalSeconds = (int)duration.TotalSeconds;
            var minutes = totalSeconds / 60;
            var seconds = totalSeconds % 60;
            var formattedDuration = $"{minutes:00}:{seconds:00}";

            Music.MusicIime = formattedDuration;

            var res = await _AddMusic.AddNewMusic(Music);
            ViewBag.AddCarResult = res;

            //return View("AddCar");
            return View();
        }
    }
}
