using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace week5_day2_GameScore.Models
{
    public class week5_day2_GameScoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public week5_day2_GameScoreContext() : base("name=week5_day2_GameScoreContext")
        {
        }

        public System.Data.Entity.DbSet<week5_day2_GameScore.Models.Score> Scores { get; set; }
    }
}
