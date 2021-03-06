﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UWPHelper.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the UWPHelperUser class
    public class UWPHelperUser : IdentityUser
    {
        [PersonalData]
        [NotMapped]
        public virtual List<History> History { get; set; }
    }

    public class History
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public string UserID { get; set; }
        public UWPHelperUser User { get; set; }
        public DateTime AddTime { get; set; }
        public string Name { get; set; }

        public string GetFolderURL()
        {
            return "SearchData\\" + UserID + "\\" + TimeToString(AddTime) + "\\";
        }

        private string TimeToString(DateTime Time)
        {
            return Time.Year.ToString() + "_" + Time.Month.ToString() + "_" + Time.Day.ToString() + "-" +
                Time.Hour.ToString() + "_" + Time.Minute.ToString() + "_" + Time.Second.ToString() + "_" + Time.Millisecond.ToString();
        }
    }
}
