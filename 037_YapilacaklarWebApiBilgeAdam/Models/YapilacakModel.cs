using _037_YapilacaklarWebApiBilgeAdam.Records.Bases;
using System;
using System.ComponentModel.DataAnnotations;

namespace _037_YapilacaklarWebApiBilgeAdam.Models
{
    public class YapilacakModel : RecordBase
    {
        [Required]
        public string Gorev { get; set; }

        public DateTime? Tarih { get; set; }

        public bool YapildiMi { get; set; }

        public int KullaniciId { get; set; }
    }
}