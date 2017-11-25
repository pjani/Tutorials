using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace TimeFunctioningPatterns.Web.MVC.Models
{
    public abstract class Memo
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [Range(0, 350)]
        public int Tempo { get; set; }

        [Required]
        [StringLength(30)]
        public string OverallRating { get; set; }

        public RhythmVersion RhythmVersion { get; set; }
    }

    public class FatBackMemo : Memo { }

    public class SnareAndBassMemo : Memo { }

    public class HiHatMemo : Memo { }
}