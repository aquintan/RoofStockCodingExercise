using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RoofStock.CodingExercise.Api.Data.Database;

namespace RoofStock.CodingExercise.DatabaseUtil
{
    public class Context : PropertiesContext
    {
        private readonly IConfiguration _config;

        public Context(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config["DbConnectionString"];
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}