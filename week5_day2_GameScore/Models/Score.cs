using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace week5_day2_GameScore.Models
{
    public class Score
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public string Team { get; set; }
        //this "TEAM" was added after the scaffolding and that caused an error
        //because the model had changed - A MIGRATION Could be used, but ONLY SMALL CHANGES WORK
        //After Migration have to update the View to add the New Content
    }
}