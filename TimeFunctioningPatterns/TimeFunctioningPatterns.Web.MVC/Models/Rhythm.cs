using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeFunctioningPatterns.Web.MVC.Models
{
    public class Rhythm
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public List<RhythmVersion> Variants { get; set; }
    }
}