using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeFunctioningPatterns.Web.MVC.Models
{
    public class RhythmVersion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public int RhythmId { get; set; }

        public Rhythm Rhythm { get; set; }

        //public List<Memo> FatBackMemos { get; set; }
        //public List<Memo> SnareAndBassMemos { get; set; }
        //public List<Memo> HiHatMemos { get; set; }
        public List<Memo> Memos { get; set; }

        public List<FatBackMemo> GetFatbackMemos()
        {
            return Memos
                ?.Where(m => m is FatBackMemo)
                .Cast<FatBackMemo>()
                .ToList();
        }

        public List<SnareAndBassMemo> GetSnareAndBassMemos()
        {
            return Memos
                ?.Where(m => m is SnareAndBassMemo)
                .Cast<SnareAndBassMemo>()
                .ToList();
        }

        public List<HiHatMemo> GetHiHatMemos()
        {
            return Memos
                ?.Where(m => m is HiHatMemo)
                .Cast<HiHatMemo>()
                .ToList();
        }
    }
}