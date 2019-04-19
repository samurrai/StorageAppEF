namespace StorageApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StorageContext : DbContext
    {
        
        public StorageContext()
            : base("name=StorageContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}