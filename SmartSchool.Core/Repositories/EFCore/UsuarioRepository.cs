using Microsoft.EntityFrameworkCore;
using SmartSchool.Core.BusinessEntities;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories.EFCore
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext context;

        public UsuarioRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task<Usuarios> FindByUsernameAsync(string username)
        {
            return await context.Set<Usuarios>().FirstOrDefaultAsync(x => x.Usuario == username);
        }
    }
}