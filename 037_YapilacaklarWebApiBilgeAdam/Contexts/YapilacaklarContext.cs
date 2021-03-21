using System.Data.Entity;
using _037_YapilacaklarWebApiBilgeAdam.Entities;

namespace _037_YapilacaklarWebApiBilgeAdam.Contexts
{
    public class YapilacaklarContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Yapilacak> Yapilacaklar { get; set; }

        public YapilacaklarContext() : base("YapilacaklarContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().ToTable("Kullanicilar");

            modelBuilder.Entity<Yapilacak>().ToTable("Yapilacaklar")
                .HasRequired(y => y.Kullanici)
                .WithMany(k => k.Yapilacaklar)
                .HasForeignKey(y => y.KullaniciId)
                .WillCascadeOnDelete(false);
        }
    }
}