using _037_YapilacaklarWebApiBilgeAdam.Entities;
using _037_YapilacaklarWebApiBilgeAdam.Models;
using _037_YapilacaklarWebApiBilgeAdam.Services.Bases;
using System;
using System.Data.Entity;
using System.Linq;

namespace _037_YapilacaklarWebApiBilgeAdam.Services
{
    public class YapilacakService : IYapilacakService
    {
        private readonly DbContext _db;

        public YapilacakService(DbContext db)
        {
            _db = db;
        }

        public void Add(YapilacakModel model)
        {
            model.CreateDate = DateTime.Now;
            var entity = new Yapilacak()
            {
                CreateDate = model.CreateDate,
                CreatedBy = model.CreatedBy,
                Gorev = model.Gorev,
                KullaniciId = model.KullaniciId,
                Tarih = model.Tarih,
                YapildiMi = model.YapildiMi
            };
            _db.Set<Yapilacak>().Add(entity);
            _db.SaveChanges();
            model.Id = entity.Id;
        }

        public void Delete(int id, string deletedBy)
        {
            var entity = _db.Set<Yapilacak>().Find(id);
            entity.UpdateDate = DateTime.Now;
            entity.UpdatedBy = deletedBy;
            entity.IsDeleted = true;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public IQueryable<YapilacakModel> GetQuery()
        {
            return _db.Set<Yapilacak>().OrderByDescending(y => y.Tarih).Where(y => !y.IsDeleted).Select(y => new YapilacakModel()
            {
                Id = y.Id,
                CreateDate = y.CreateDate,
                CreatedBy = y.CreatedBy,
                UpdateDate = y.UpdateDate,
                UpdatedBy = y.UpdatedBy,
                KullaniciId = y.KullaniciId,
                YapildiMi = y.YapildiMi,
                Tarih = y.Tarih,
                Gorev = y.Gorev
            });
        }

        public void Update(YapilacakModel model)
        {
            var entity = _db.Set<Yapilacak>().Find(model.Id);
            model.UpdateDate = DateTime.Now;
            entity.UpdateDate = model.UpdateDate;
            entity.UpdatedBy = model.UpdatedBy;
            entity.Gorev = model.Gorev;
            entity.KullaniciId = model.KullaniciId;
            entity.Tarih = model.Tarih;
            entity.YapildiMi = model.YapildiMi;
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}