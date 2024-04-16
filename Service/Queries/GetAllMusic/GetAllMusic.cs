using soundcloud_.Models;
using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetAllMusic
{
    public class GetAllMusic : IGetAllMusic
    {
        DataBaseContext _DatabaseContext;
        public GetAllMusic(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        
        public async Task<List<UserMusicViewModel>> getAllMusic()
        {
            List<UserMusicViewModel> lst = new List<UserMusicViewModel>();
            var music = _DatabaseContext.Musics.Where(i => i.Status == "موفق").ToList();
            foreach (var i in music)
            {
                UserMusicViewModel mv = new UserMusicViewModel();
                mv.musicname = i.title;
                mv.musicadress = i.MusicAdress;
                mv.musicimage = i.MusicImage;
                mv. musictime = i.MusicIime;
                lst.Add(mv);
            }
            return lst;
        }
    }
}
