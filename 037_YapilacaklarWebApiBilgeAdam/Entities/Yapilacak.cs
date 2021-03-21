using System;
using System.ComponentModel.DataAnnotations;
using _037_YapilacaklarWebApiBilgeAdam.Records.Bases;

namespace _037_YapilacaklarWebApiBilgeAdam.Entities
{
    public class Yapilacak : RecordBase
    {
        [Required]
        public string Gorev { get; set; }

        public DateTime? Tarih { get; set; }

        public bool YapildiMi { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
    }
}