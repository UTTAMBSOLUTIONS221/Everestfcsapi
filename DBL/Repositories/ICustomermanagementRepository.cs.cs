using DBL.Models;

namespace DBL.Repositories
{
    public interface ICustomermanagementRepository
    {
        IEnumerable<Systemtenantcustomers> Getsystemtenantcustomersdata();
        Genericmodel Registersystemccustomerdata(string jsonObjectdata);
    }
}
