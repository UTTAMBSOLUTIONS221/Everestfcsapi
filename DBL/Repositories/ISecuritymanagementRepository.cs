using DBL.Models;

namespace DBL.Repositories
{
    public interface ISecuritymanagementRepository
    {
        Genericmodel VerifySystemStaff(string EmailOrPhone);
        long Verifystaffrefreshtoken(long Userid);
        Genericmodel Updatestaffrefreshtoken(long Userid, string RefreshToken);
        Genericmodel Registerstaffrefresftoken(long Userid, string TokenId, string RefreshToken);
        Genericmodel Getsystemtenatdata(string TetantCode);
    }
}
