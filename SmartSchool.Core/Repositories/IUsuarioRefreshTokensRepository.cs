using SmartSchool.Core.BusinessEntities;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories
{
    public interface IUsuarioRefreshTokensRepository
    {
        Task<UsuarioRefreshTokens> FindByUsernameAndTokenAsync(string username, string refreshToken);
        Task InsertAsync(UsuarioRefreshTokens token);
        Task RevokeAsync(UsuarioRefreshTokens token);
    }
}