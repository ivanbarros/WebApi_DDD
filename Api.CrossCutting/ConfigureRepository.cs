using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeniesRepository (IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql("Server=127.0.0.1,Port =3306;Database=Api_Project;Uid=root;Pwd=pophets3003"));
            //serviceCollection.AddDbContext<MyContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Api_Project;Uid=Ivan;Pwd=pophets3003"));
        }

    }
}
