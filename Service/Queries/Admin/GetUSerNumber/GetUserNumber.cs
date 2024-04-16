using Microsoft.EntityFrameworkCore;
using soundcloud_.Models.Countexts;

namespace soundcloud_.Service.Queries.Admin.GetUSerNumber
{
    public class GetUserNumber:IGetUserNumber
    {

        DataBaseContext _DatabaseContext;
        public GetUserNumber(DataBaseContext databaseContext)
        {
            _DatabaseContext = databaseContext;
        }

        public async Task<int> getUserNumber()
        {
           var UserNumber= await _DatabaseContext.Users.Where(i=>i.Roleid==1).CountAsync();
            return UserNumber;
        }
    }
}
