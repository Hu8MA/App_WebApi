using Com.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Com.Data
{
    public class MyAppDbContext:DbContext
    {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserImage> UserImages { get; set; }
        public virtual DbSet<UserState> UserStates { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var foreignkey in builder.Model.GetEntityTypes()
                                        .SelectMany(e => e.GetForeignKeys()))

            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }


        }
    }
}
