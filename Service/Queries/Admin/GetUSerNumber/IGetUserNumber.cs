using soundcloud_.Models.ViewModels;

namespace soundcloud_.Service.Queries.Admin.GetUSerNumber
{
    public interface IGetUserNumber
    {
        Task<int> getUserNumber();

    }
}
