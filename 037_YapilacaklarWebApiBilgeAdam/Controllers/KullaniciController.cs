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
    // https://httpstatuses.com/
    // https://www.gokhan-gokalp.com/asp-net-web-api-token-based-authentication/

    [Authorize]
    public class KullaniciController : ApiController
    {
        private readonly DbContext _db = new YapilacaklarContext();
        private readonly IKullaniciService _kullaniciService;

        public KullaniciController()
        {
            _kullaniciService = new KullaniciService(_db);
        }

        //[HttpGet]
        // /api/Kullanici
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        var model = _kullaniciService.GetQuery().ToList();
        //        return Ok(model); // 200: OK
        //    }
        //    catch (Exception exc)
        //    {
        //        return BadRequest(); // 400: Bad Request
        //    }
        //}
        public IHttpActionResult GetKullanicilar()
        {
            try
            {
                var model = _kullaniciService.GetQuery().ToList();
                return Ok(model); // 200: OK
            }
            catch (Exception exc)
            {
                return BadRequest(); // 400: Bad Request
            }
        }

        //[HttpGet]
        // /api/Kullanici/3
        public IHttpActionResult Get(int id)
        {
            try
            {
                var model = _kullaniciService.GetQuery().SingleOrDefault(k => k.Id == id);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }
            catch (Exception exc)
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        // /api/Kullanici
        //public IHttpActionResult Post(KullaniciModel model)
        //{
        //    try
        //    {
        //        model.CreatedBy = User.Identity.Name;
        //        if (ModelState.IsValid)
        //        {
        //            _kullaniciService.Add(model);
        //            return Ok(model);
        //        }
        //        return BadRequest(ModelState);
        //    }
        //    catch (Exception exc)
        //    {
        //        return InternalServerError();
        //    }
        //}
        public IHttpActionResult PostKullanici(KullaniciModel model)
        {
            try
            {
                model.CreatedBy = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    _kullaniciService.Add(model);
                    return Ok(model);
                }
                return BadRequest(ModelState);
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }

        //[HttpPut]
        // /api/Kullanici
        public IHttpActionResult Put(KullaniciModel model)
        {
            try
            {
                model.UpdatedBy = User.Identity.Name;
                if (ModelState.IsValid)
                {
                    _kullaniciService.Update(model);
                    return Ok(model);
                }
                return BadRequest(ModelState);
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }

        //[HttpDelete]
        // /api/Kullanici/3
        public IHttpActionResult Delete(int id)
        {
            try
            {
                string updatedBy = User.Identity.Name;
                _kullaniciService.Delete(id, updatedBy);
                return Ok(id);
            }
            catch (Exception exc)
            {
                return InternalServerError();
            }
        }
    }
}
