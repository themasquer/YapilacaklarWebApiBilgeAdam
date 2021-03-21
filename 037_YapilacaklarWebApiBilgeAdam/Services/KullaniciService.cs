using _037_YapilacaklarWebApiBilgeAdam.Entities;
using _037_YapilacaklarWebApiBilgeAdam.Models;
using _037_YapilacaklarWebApiBilgeAdam.Services.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace _037_YapilacaklarWebApiBilgeAdam.Services
{
    public class KullaniciService : IKullaniciService
    {
        private readonly DbContext _db;
        public KullaniciService(DbContext db) // dependency constructor injection
        {
            _db = db;
        }

        public IQueryable<KullaniciModel> GetQuery()
        {
            var query = _db.Set<Kullanici>().Where(k => k.IsDeleted == false).Select(k => new KullaniciModel()
            {
                Id = k.Id,
                KullaniciAdi = k.KullaniciAdi,
                Adi = k.Adi,
                Soyadi = k.Soyadi,
                CreateDate = k.CreateDate,
                CreatedBy = k.CreatedBy,
                UpdateDate = k.UpdateDate,
                UpdatedBy = k.UpdatedBy
            });
            //var testList = query.ToList();
            return query;
        }

        public void Add(KullaniciModel model)
        {
            model.CreateDate = DateTime.Now;
            var entity = new Kullanici()
            {
                KullaniciAdi = model.KullaniciAdi,
                Sifre = model.Sifre,
                Adi = model.Adi.Trim(),
                Soyadi = model.Soyadi.Trim(),
                CreateDate = model.CreateDate,
                CreatedBy = model.CreatedBy
            };
            _db.Set<Kullanici>().Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
        }

        public void Update(KullaniciModel model)
        {
            model.UpdateDate = DateTime.Now;
            var entity = _db.Set<Kullanici>().Find(model.Id);
            entity.KullaniciAdi = model.KullaniciAdi;
            entity.Sifre = model.Sifre;
            entity.Adi = model.Adi.Trim();
            entity.Soyadi = model.Soyadi.Trim();
            entity.UpdateDate = model.UpdateDate;
            entity.UpdatedBy = model.UpdatedBy;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id, string updatedBy)
        {
            var entity = _db.Set<Kullanici>().Find(id);
            entity.IsDeleted = true;
            entity.UpdateDate = DateTime.Now;
            entity.UpdatedBy = updatedBy;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public List<KullaniciModel> GetKullanicilarIncludingYapilacaklar()
        {
            //List<Yapilacak> testYapilacaklarLazyLoading = _db.Set<Kullanici>().FirstOrDefault(k => k.KullaniciAdi == "cagil").Yapilacaklar;
            //List<Yapilacak> testYapilacaklarEagerLoading1 = _db.Set<Kullanici>().Include("Yapilacaklar").FirstOrDefault(k => k.KullaniciAdi == "cagil").Yapilacaklar;
            //List<Yapilacak> testYapilacaklarEagerLoading2 = _db.Set<Kullanici>().Include(k => k.Yapilacaklar).FirstOrDefault(k => k.KullaniciAdi == "cagil").Yapilacaklar;

            return _db.Set<Kullanici>().Where(k => !k.IsDeleted).Select(k => new KullaniciModel()
            {
                Id = k.Id,
                Adi = k.Adi,
                Soyadi = k.Soyadi,
                KullaniciAdi = k.KullaniciAdi,
                Yapilacaklar = k.Yapilacaklar.Where(y => !y.IsDeleted).Select(y => new YapilacakModel()
                {
                    Id = y.Id,
                    Gorev = y.Gorev,
                    Tarih = y.Tarih,
                    YapildiMi = y.YapildiMi
                }).ToList()
            }).ToList();
        }
    }
}