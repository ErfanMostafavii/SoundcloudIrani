using soundcloud_.Models.Countexts;
using soundcloud_.Models.Utilitis;
using soundcloud_.Models;

namespace soundcloud_.Service.Commands.Musics
{
    public class AddMusic : IAddMusics
    {
        DataBaseContext _DatabaseContext;
        public AddMusic(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
     
        public async Task<ServiseResponse> AddNewMusic(Music m)
        {
            try
            { 

                _DatabaseContext.Musics.Add(m);
                await _DatabaseContext.SaveChangesAsync(); 
                var res = new ServiseResponse()
                {
                    code = 200,
                    status = "success",
                    message = "ثبت اهنگ انجام شد"


                };
                return res;



            }
            catch (Exception ex)
            {

                var res = new ServiseResponse()
                {
                    code = 300,
                    status = "Error",
                    message = "ثبت اهنگ انجام نشد"


                };
                return res;

            }
        }
    }
}
