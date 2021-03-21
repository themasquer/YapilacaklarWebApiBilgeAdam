using _037_YapilacaklarWebApiBilgeAdam.Models;
using System.Collections.Generic;
using System.Linq;

namespace _037_YapilacaklarWebApiBilgeAdam.Services.Bases
{
    public interface IKullaniciService
    {
        IQueryable<KullaniciModel> GetQuery();
        void Add(KullaniciModel model);
        void Update(KullaniciModel model);
        void Delete(int id, string updatedBy);
        List<KullaniciModel> GetKullanicilarIncludingYapilacaklar();
    }
}
