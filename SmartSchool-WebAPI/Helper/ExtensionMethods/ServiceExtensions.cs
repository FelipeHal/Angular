using Microsoft.Extensions.DependencyInjection;
using SmartSchool.WebAPI.Services;
using SmartSchool.WebAPI.Services.Handlers;

namespace SmartSchool.WebAPI.Helper.ExtensionMethods
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAlunoService, AlunoServiceDefault>();
            serviceCollection.AddScoped<IProfessorService, ProfessorServiceDefault>();
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationServiceDefault>();
        }
    }
}
