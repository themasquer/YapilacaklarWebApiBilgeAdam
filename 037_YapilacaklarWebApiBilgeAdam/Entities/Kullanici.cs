using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _037_YapilacaklarWebApiBilgeAdam.Records.Bases;

namespace _037_YapilacaklarWebApiBilgeAdam.Entities
{
    public class Kullanici : RecordBase
    {
        [Required]
        [StringLength(32)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(16)]
        public string Sifre { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        public List<Yapilacak> Yapilacaklar { get; set; }
    }
}