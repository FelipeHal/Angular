using SmartSchool.Core.BusinessEntities;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> FindByUsernameAsync(string username);
    }
}