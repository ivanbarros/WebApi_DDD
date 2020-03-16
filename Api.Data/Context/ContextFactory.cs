using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context {
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>

        {
            public MyContext CreateDbContext (string[] args) {

            //string server = "localhost\\SQLEXPRESS";
            //string database = "Api_Project";
            //string user = "Ivan";
            //string password = "pophets3003";

            string server = "mysql5025.site4now.net";
            string port = "3306";
            string database = "db_a5617e_webapi";
            string user = "a5617e_webapi";
            string password = "pophets3003";
            //string connectionString = $"Server={server};Database={database};Uid={user};Password={password}";
            string connectionString = $"Server={server};Port={port};Database={database};Uid={user};Password={password}";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext> ();
                optionsBuilder.UseMySql (connectionString);
                //optionsBuilder.UseSqlServer (connectionString);
                return new MyContext (optionsBuilder.Options);
            }
        }
}
