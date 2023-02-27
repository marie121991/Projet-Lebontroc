using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{

    public delegate void CustomizeModelDelegate(ModelBuilder modelBuilder);
    public delegate void SeedDataDelegate(ModelBuilder modelBuilder);

    public partial class MyDal : IdentityDbContext<UserDAO, RoleDAO, Guid>
    {
        private readonly CustomizeModelDelegate customizeModel;
        private readonly SeedDataDelegate? seedData;

        public MyDal(
            DbContextOptions<MyDal> options,
            CustomizeModelDelegate? customizeModel = null,
            SeedDataDelegate? seedData = null) : base(options)
        {
            this.customizeModel = customizeModel;
            this.seedData = seedData;
            this.Database.EnsureCreated();
        }
        public virtual DbSet<PhotoDAO> Photos { get; set; }
        public virtual DbSet<ObjectDAO> Objects { get; set; }
        public virtual DbSet<LoanDAO> Loans { get; set; }
        public virtual DbSet<AppUserDAO> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (this.customizeModel != null) { this.customizeModel(modelBuilder); }
            if (this.seedData != null) { this.seedData(modelBuilder); }
        }

    }


}
