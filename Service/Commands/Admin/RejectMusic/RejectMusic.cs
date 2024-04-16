using Microsoft.EntityFrameworkCore;
using soundcloud_.Models.Countexts;
using soundcloud_.Models.Utilitis;

namespace soundcloud_.Service.Commands.Admin.RejectMusic
{
    public class RejectMusic:IRejectMusic
    {


        DataBaseContext _DatabaseContext;
        public RejectMusic(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

      

        public async Task<ServiseResponse> rejectMusic(int MusicId)
        {
            try
            {
                var music =  _DatabaseContext.Musics.Where(m => m.id == MusicId).Single();
                music.Status = "لغو";
                 _DatabaseContext.SaveChanges();
                var res = new ServiseResponse()
                {
                    code = 200,
                    status = "success",
                    message = "لغو اهنگ انجام شد"


                };
                return res;



            }
            catch (Exception ex)
            {

                var res = new ServiseResponse()
                {
                    code = 300,
                    status = "Error",
                    message = "لغو نام انجام نشد"


                };
                return res;

            }
        }
    }
}
