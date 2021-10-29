using Microsoft.EntityFrameworkCore;
using SmartSchool.Core.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Core.Repositories.EFCore
{
    public class UsuarioRefreshTokensRepository : IUsuarioRefreshTokensRepository
    {
        private readonly DataContext context;

        public UsuarioRefreshTokensRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task InsertAsync(UsuarioRefreshTokens token)
        {
            await context.Set<UsuarioRefreshTokens>().AddAsync(token);
        }

        public async Task RevokeAsync(UsuarioRefreshTokens token)
        {
            token.Revoked = DateTime.UtcNow;
            await Task.Run(() => { context.Set<UsuarioRefreshTokens>().Update(token); });
        }

        public async Task<UsuarioRefreshTokens> FindByUsernameAndTokenAsync(string username, string refreshToken)
        {
            return await context.Set<UsuarioRefreshTokens>().FirstOrDefaultAsync(t => t.Usuario.Usuario.ToUpper() == username.ToUpper() && t.Token == refreshToken);
        }
    }
}
