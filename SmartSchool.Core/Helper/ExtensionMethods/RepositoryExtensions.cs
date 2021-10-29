using Microsoft.Extensions.DependencyInjection;
using SmartSchool.Core.Repositories;
using SmartSchool.Core.Repositories.EFCore;

namespace SmartSchool.Core.Helper.ExtensionMethods
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
            serviceCollection.AddScoped<IUsuarioRefreshTokensRepository, UsuarioRefreshTokensRepository>();

            serviceCollection.AddScoped<IAlunoRepository, AlunoRepository>();
            serviceCollection.AddScoped<IProfessorRepository, ProfessorRepository>();
        }
    }
}