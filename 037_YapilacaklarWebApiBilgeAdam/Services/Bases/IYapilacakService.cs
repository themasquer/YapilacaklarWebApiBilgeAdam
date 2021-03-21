using _037_YapilacaklarWebApiBilgeAdam.Models;
using System.Linq;

namespace _037_YapilacaklarWebApiBilgeAdam.Services.Bases
{
    public interface IYapilacakService
    {
        IQueryable<YapilacakModel> GetQuery();
        void Add(YapilacakModel model);
        void Update(YapilacakModel model);
        void Delete(int id, string deletedBy);
    }
}