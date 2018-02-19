using System.Data.Entity;

namespace BeerDB
{
    public class BarDbContext : DbContext
    {
        public BarDbContext(string cnnstr) : base(cnnstr)
        {
        }
        public IDbSet<Bar> Bars { get; set; }
        public IDbSet<BarTag> BarTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bar>().HasKey(b => b.Id);
            modelBuilder.Entity<Bar>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Bar>().Property(b => b.UserId).IsRequired();
            modelBuilder.Entity<Bar>().Property(b => b.OpeningTime).IsRequired();
            modelBuilder.Entity<Bar>().Property(b => b.ClosingTime).IsRequired();
            modelBuilder.Entity<Bar>().Property(b => b.Picture).IsRequired();

            modelBuilder.Entity<Bar>().HasMany(b=>b.BarTags).WithMany(t=>t.TaggedBars);

            modelBuilder.Entity<BarTag>().HasKey(t => t.Text);

            modelBuilder.Entity<BarTag>().HasMany(t => t.TaggedBars).WithMany(b=>b.BarTags);
        }
    }
}
