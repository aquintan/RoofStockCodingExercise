using Microsoft.EntityFrameworkCore;
using RoofStock.CodingExercise.Api.Data.Database;

namespace RoofStock.CodingExercise.DatabaseUtil
{
    public class Context : PropertiesContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=RoofStock;User Id=sa;Password=4lv4r0P4ssw0rd$;Trusted_Connection=False;");
        }
    }
}