
using soundcloud_.Models.Utilitis;
using soundcloud_.Models;
namespace soundcloud_.Service.Commands.UserRegister
{
    public interface IUserRegister
    {
        Task<ServiseResponse> AddUser(User user);

    }
}
