using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess;

public class ApplicationDbContext : DbContext
{
    // establish connection with entity framework and pass options
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    // create a Db Set
    // DbSet<model name> TableName
    // This will create a category table with the name Categories with 4 column from the category model
    public DbSet<Category> Categories { get; set; }
}
