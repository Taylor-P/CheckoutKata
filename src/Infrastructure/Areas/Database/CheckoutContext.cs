using System.Security.Cryptography.X509Certificates;
using BusinessCore.Areas.Offers.Models;
using BusinessCore.Areas.Product.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Areas.Database
{
    public class CheckoutContext : DbContext
    {
        public CheckoutContext(DbContextOptions<CheckoutContext> options)
            : base(options)
        {
        }

        public DbSet<ProductTable> Products { get; set; }
        public DbSet<OfferTable> Discounts { get; set; }
    }
}
