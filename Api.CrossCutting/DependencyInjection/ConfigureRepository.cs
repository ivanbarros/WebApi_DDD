using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Data.Implementation;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeniesRepository (IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=mysql5025.site4now.net,Port =3306;Database=db_a5617e_webapi;Uid=a5617e_webapi;Pwd=pophets3003"));
            //serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Api_Project;Uid=Ivan;Pwd=pophets3003"));
        }

    }
}
