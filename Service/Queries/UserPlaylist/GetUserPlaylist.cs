using Microsoft.EntityFrameworkCore;
using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.UserPlaylist
{
    public class GetUserPlaylist:IGetUserPlaylist
    {
        DataBaseContext _DatabaseContext;
        public GetUserPlaylist(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }


        
        public  List<UserMusicViewModel> getUserPlaylist(int UserId)
        {
            List<UserMusicViewModel> lst = new List<UserMusicViewModel>();
            var music = _DatabaseContext.Musics.Where(i => i.Status == "موفق"&&i.USerId== UserId).ToList();
            foreach (var i in music)
            {
                UserMusicViewModel mv = new UserMusicViewModel();
                mv.musicname = i.title;
                mv.musicadress = i.MusicAdress;
                mv.musicimage = i.MusicImage;
                mv.musictime = i.MusicIime;
                lst.Add(mv);
            }
            return lst;
         }
    }
}
