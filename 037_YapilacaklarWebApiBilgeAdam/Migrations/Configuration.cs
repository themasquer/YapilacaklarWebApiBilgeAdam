namespace _037_YapilacaklarWebApiBilgeAdam.Migrations
{
    using _037_YapilacaklarWebApiBilgeAdam.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_037_YapilacaklarWebApiBilgeAdam.Contexts.YapilacaklarContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(_037_YapilacaklarWebApiBilgeAdam.Contexts.YapilacaklarContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Yapilacak> yapilacaklar = new List<Yapilacak>()
            {
                new Yapilacak()
                {
                    Gorev = "Görev 1",
                    Tarih = DateTime.Now,
                    CreateDate = DateTime.Now,
                    CreatedBy = "system",
                    IsDeleted = false,
                    YapildiMi = false,
                    Kullanici = new Kullanici()
                    {
                        Id = 1,
                        KullaniciAdi = "cagil",
                        Sifre = "cagil",
                        CreateDate = DateTime.Now,
                        CreatedBy = "system",
                        Adi = "Çağıl",
                        Soyadi = "Alsaç",
                        IsDeleted = false
                    }
                },
                new Yapilacak()
                {
                    Gorev = "Görev 2",
                    Tarih = DateTime.Now,
                    CreateDate = DateTime.Now,
                    CreatedBy = "system",
                    IsDeleted = false,
                    YapildiMi = false,
                    Kullanici = new Kullanici()
                    {
                        KullaniciAdi = "leo",
                        Sifre = "leo",
                        CreateDate = DateTime.Now,
                        CreatedBy = "system",
                        Adi = "Leo",
                        Soyadi = "Alsaç",
                        IsDeleted = false
                    }
                },
                new Yapilacak()
                {
                    Gorev = "Görev 3",
                    Tarih = DateTime.Now,
                    CreateDate = DateTime.Now,
                    CreatedBy = "system",
                    IsDeleted = false,
                    YapildiMi = false,
                    KullaniciId = 1
                }
            };

            // context üzerinden veritabanındaki kayıtları silme
            var yapilacakEntities = context.Yapilacaklar.ToList();
            context.Yapilacaklar.RemoveRange(yapilacakEntities);
            var kullaniciEntities = context.Kullanicilar.ToList();
            context.Kullanicilar.RemoveRange(kullaniciEntities);
            context.SaveChanges();

            // context üzerinden veritabanına kayıtları ekleme
            context.Yapilacaklar.AddRange(yapilacaklar);
        }
    }
}
