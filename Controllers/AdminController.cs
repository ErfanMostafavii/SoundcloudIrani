using Microsoft.AspNetCore.Mvc;
using soundcloud_.Models;
using soundcloud_.Models.ViewModels;
using soundcloud_.Service.Commands.Admin.AcceptMusic;
using soundcloud_.Service.Commands.Admin.RejectMusic;
using soundcloud_.Service.Queries.Admin.AcceptUserMusic;
using soundcloud_.Service.Queries.Admin.GetMusicNumbers;
using soundcloud_.Service.Queries.Admin.GetUSerNumber;

namespace soundcloud_.Controllers
{
    public class AdminController : Controller
    {

        IGetUsersMusic _GetUsersMusic;
        IAcceptMusic _AcceptMusic;
        IRejectMusic _RejectMusic;
        IGetUserNumber _GetUserNumber;
        IGetMusicNumber _GetMusicNumber;
        public AdminController(IGetUsersMusic GetUsersMusic, IAcceptMusic AcceptMusic, IRejectMusic RejectMusic, IGetUserNumber GetUserNumber, IGetMusicNumber GetMusicNumber) { 
        
        _GetUsersMusic = GetUsersMusic;
            _AcceptMusic = AcceptMusic;
            _RejectMusic = RejectMusic;
            _GetUserNumber = GetUserNumber;
            _GetMusicNumber = GetMusicNumber;
        }
        public async Task<IActionResult> Index()
        {

            var MusicNumber= await _GetMusicNumber.getMusicNumber();
              var UserNumber= await _GetUserNumber.getUserNumber();
            var UsersMusic = await _GetUsersMusic.getUsersMusic();
            ViewBag.UsersMusic = UsersMusic;
            ViewBag.UserNumber = UserNumber;    
            ViewBag.MusicNumber = MusicNumber;
            return View();
        }
    
       
        [HttpPost]

        public IActionResult RejectMusic(int MusicId)
        {
            var res = _RejectMusic.rejectMusic(MusicId);
            ViewBag.res = res;
            return RedirectToAction(nameof(Index), "Admin");
        }

        [HttpPost]
        public IActionResult AcceptMusic(int MusicId)
        {
            var res = _AcceptMusic.acceptMusic(MusicId);
            ViewBag.res = res;
            return RedirectToAction(nameof(Index), "Admin"); 

        }
    }
}
