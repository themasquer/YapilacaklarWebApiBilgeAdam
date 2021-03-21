using _037_YapilacaklarWebApiBilgeAdam.Contexts;
using _037_YapilacaklarWebApiBilgeAdam.Models;
using _037_YapilacaklarWebApiBilgeAdam.Services;
using _037_YapilacaklarWebApiBilgeAdam.Services.Bases;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace _037_YapilacaklarWebApiBilgeAdam.Controllers
{
    [Authorize]
    [RoutePrefix("api/Yapilacaklar")]
    public class YapilacakController : ApiController
    {
        private readonly DbContext _db;
        private readonly IYapilacakService _yapilacakService;

        public YapilacakController()
        {
            _db = new YapilacaklarContext();
            _yapilacakService = new YapilacakService(_db);
        }

        // api/Yapilacaklar/Getir
        [Route("Getir")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Listele()
        {
            try
            {
                var model = _yapilacakService.GetQuery().ToList();
                return Ok(model);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        // /api/Yapilacaklar/Getir/7
        //[Route("Getir/{yapilacakId?}")] // 1
        [Route("Getir/{yapilacakId}")] // 2
        [HttpGet]
        [AllowAnonymous]
        //public IHttpActionResult Getir(int? yapilacakId) // 1
        public IHttpActionResult Getir(int yapilacakId) // 2
        {
            try
            {
                var model = _yapilacakService.GetQuery().SingleOrDefault(y => y.Id == yapilacakId);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        // /api/Yapilacaklar/Getir/2020-01-01/2021-12-31
        [Route("Getir/{tarih1}/{tarih2}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Getir(DateTime tarih1, DateTime tarih2)
        {
            try
            {
                var model = _yapilacakService.GetQuery().Where(y => y.Tarih >= tarih1 && y.Tarih <= tarih2).ToList();
                if (model == null || model.Count == 0)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        // /api/Yapilacaklar/TariheGoreGetir
        [Route("TariheGoreGetir")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetirByTarih(YapilacakFilterModel tarihler)
        {
            try
            {
                var model = _yapilacakService.GetQuery().Where(y => y.Tarih >= tarihler.Tarih1 && y.Tarih <= tarihler.Tarih2).ToList();
                if (model == null || model.Count == 0)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        // /api/Yapilacaklar/Ekle
        [Route("Ekle")]
        [HttpPost]
        public IHttpActionResult YapilacakEkle(YapilacakModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = User.Identity.Name;
                    _yapilacakService.Add(model);
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }

        // /api/Yapilacaklar/Guncelle
        [Route("Guncelle")]
        [HttpPut]
        public IHttpActionResult YapilacakGuncelle(YapilacakModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = User.Identity.Name;
                    _yapilacakService.Update(model);
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }

        // /api/Yapilacaklar/Sil/8
        [Route("Sil/{yapilacakId}")]
        [HttpDelete]
        public IHttpActionResult YapilacakSil(int yapilacakId)
        {
            try
            {
                _yapilacakService.Delete(yapilacakId, User.Identity.Name);
                return Ok(yapilacakId);
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }
    }
}
