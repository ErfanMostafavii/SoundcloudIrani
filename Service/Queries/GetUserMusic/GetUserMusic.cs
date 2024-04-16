using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetUserMusic
{
    public class GetUserMusic:IGetUserMusic
    {
        DataBaseContext _DatabaseContext;
        public GetUserMusic(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        public List<MusicViewModel> getUserMusic(int UserId)
        {
            List<MusicViewModel>lst= new List<MusicViewModel>();
            var music = _DatabaseContext.Musics.Where(i => i.USerId == UserId).ToList();
            foreach (var i in music)
            {
                MusicViewModel mv = new MusicViewModel();
                mv.title = i.title;
                mv.id = i.id;
                mv.MusicTime = i.MusicIime;
                mv.status = i.Status;
                mv.Date = i.Date;
                lst.Add(mv);

            }
            return lst;
        }
    }
}
