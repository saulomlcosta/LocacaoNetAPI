using LocacaoNetAPI.Data.Context;
using LocacaoNetAPI.Data.Repositories;
using LocacaoNetAPI.Domain.Interfaces;
using LocacaoNetAPI.Application.Interfaces;
using LocacaoNetAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LocacaoNetAPI.IoC
{
    public static class NativeInjector
    {
        //public static IServiceCollection RegisterServices(this IServiceCollection services)
        //{
        //    #region Repository

        //    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        //    #endregion

        //    #region Services

        //    services.AddScoped<IClienteService, ClienteService>();
        //    services.AddScoped<IFilmeService, FilmeService>();

        //    #endregion

        //    return services;
        //}
    }
}