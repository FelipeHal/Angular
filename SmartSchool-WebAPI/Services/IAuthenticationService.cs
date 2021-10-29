using SmartSchool.WebAPI.Models.Authentication;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Services
{
    public interface IAuthenticationService
    {
        Task<SignInResponseModel> SignInAsync(SignInRequestModel model);
    }
}