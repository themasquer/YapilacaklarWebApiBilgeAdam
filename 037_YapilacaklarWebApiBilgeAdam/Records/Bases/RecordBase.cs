using System;
using System.ComponentModel.DataAnnotations;

namespace _037_YapilacaklarWebApiBilgeAdam.Records.Bases
{
    public abstract class RecordBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        [StringLength(32)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(32)]
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}