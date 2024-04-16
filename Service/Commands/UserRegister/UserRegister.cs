using soundcloud_.Models.Countexts;
using soundcloud_.Models.Utilitis;
using soundcloud_.Models;

namespace soundcloud_.Service.Commands.UserRegister
{
    public class UserRegister : IUserRegister
    {
        DataBaseContext _DatabaseContext;
        public  UserRegister(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }
        public async Task<ServiseResponse> AddUser(User user)
        {
            string hasedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hasedPassword;

            try
            {

                _DatabaseContext.Users.Add(user);
                 _DatabaseContext.SaveChanges();
                var res = new ServiseResponse()
                {
                    code = 200,
                    status = "success",
                    message = "ثبت نام انجام شد"


                };
                return res;



            }
            catch (Exception ex)
            {

                var res = new ServiseResponse()
                {
                    code = 300,
                    status = "Error",
                    message = "ثبت نام انجام نشد"


                };
                return res;

            }

        }
    }
}
