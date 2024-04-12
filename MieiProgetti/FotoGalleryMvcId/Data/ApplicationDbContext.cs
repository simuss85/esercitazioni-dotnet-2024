using FotoGalleryMvcId.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FotoGalleryMvcId.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser> //!!! modifico il parametro passando la mia classe AppUser per estendere la classe
{
    public DbSet<Log> Logs { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
