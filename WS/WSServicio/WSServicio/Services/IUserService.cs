using WSServicio.Models.Request;
using WSServicio.Models.Response;

namespace WSServicio.Services
{
    public interface IUserService
    {
        USerResponse Auth(AuthRequest model);
    }
}
