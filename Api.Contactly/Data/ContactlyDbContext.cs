using Api.Contactly.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Contactly.Data
{
    public class ContactlyDbContext : DbContext
    {
        public ContactlyDbContext(DbContextOptions<ContactlyDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }    
    }
}
