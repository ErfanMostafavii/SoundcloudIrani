using soundcloud_.Models.Countexts;
using soundcloud_.Models.Utilitis;
using soundcloud_.Models;
using Microsoft.EntityFrameworkCore;

namespace soundcloud_.Service.Commands.Admin.AcceptMusic
{
    public class AcceptMusic:IAcceptMusic
    {
        DataBaseContext _DatabaseContext;
        public AcceptMusic(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        public async Task<ServiseResponse> acceptMusic(int MusicId)
        {
            try
            {
                var music=  _DatabaseContext.Musics.Where(m => m.id == MusicId).Single();
                music.Status = "موفق";
                 _DatabaseContext.SaveChanges();
                var res = new ServiseResponse()
                {
                    code = 200,
                    status = "success",
                    message = "تایید اهنگ انجام شد"


                };
                return res;



            }
            catch (Exception ex)
            {

                var res = new ServiseResponse()
                {
                    code = 300,
                    status = "Error",
                    message = "تایید اهنگ انجام نشد"


                };
                return res;

            }
        }

       
    }
}
