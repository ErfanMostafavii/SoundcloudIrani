using soundcloud_.Models.Countexts;
using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.GetArtist
{
    public class GetArtists:IGetArtists
    {
        DataBaseContext _DatabaseContext;
        public GetArtists(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        public async Task<List<ArtistsModelView>> getArtists()
        {
            List<ArtistsModelView> lst = new List<ArtistsModelView>();
            var user = _DatabaseContext.Users.Where(i => i.Roleid ==1).ToList();
            foreach (var i in user)
            {
                ArtistsModelView mv = new ArtistsModelView();
                mv.id = i.id;
                mv.name = i.Name+" "+i.family;
                mv.image = i.UserPhoto;
            
                lst.Add(mv);
            }
            return lst;
        }
    }
}
