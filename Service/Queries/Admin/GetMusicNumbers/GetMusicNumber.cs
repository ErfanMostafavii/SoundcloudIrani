using Microsoft.EntityFrameworkCore;
using soundcloud_.Models.Countexts;

namespace soundcloud_.Service.Queries.Admin.GetMusicNumbers
{
    public class GetMusicNumber:IGetMusicNumber
    {
        DataBaseContext _DatabaseContext;
        public GetMusicNumber(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        public async Task<int> getMusicNumber()
        {
            var MusicNumber = await _DatabaseContext.Musics.Where(i => i.Status == "موفق").CountAsync();
            return MusicNumber;
        }
    }
}
