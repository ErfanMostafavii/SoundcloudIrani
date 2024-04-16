using Microsoft.EntityFrameworkCore;
using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.Admin.AcceptUserMusic
{
    public class GetUsersMusic:IGetUsersMusic
    {

        DataBaseContext _DatabaseContext;
        public GetUsersMusic(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        public async Task<List<AdminUserMusicModelView>> getUsersMusic()
        {
            List<AdminUserMusicModelView> lst = new List<AdminUserMusicModelView>();
            var music = await _DatabaseContext.Musics.Where(i => i.Status == "برسی").ToListAsync();

            foreach (var mu in music)
            {
                AdminUserMusicModelView m = new AdminUserMusicModelView();

                m.MusicId = mu.id;
                m.UserId = mu.USerId;
                var user = await _DatabaseContext.Users.Where(i => i.id == mu.USerId).SingleAsync();
                m.UserName = user.Name + " " + user.family;
                m.MusicTitle = mu.title;
                m.MusicAdress = mu.MusicAdress;
                m.Status = mu.Status;

                lst.Add(m);
            }

            return lst;
        }

    }
}
