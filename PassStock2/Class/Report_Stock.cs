using NoomLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PassStock2
{
    public class Report_Stock
    {
        public int Re_Count_Item { get; set; }
        public Double Re_Total_Coast { get; set; }
        public Double Re_Sum_AmoundSold { get; set; }
        public Double Re_Coast_EA { get; set; }
        public Double Re_Coast_List { get; set; }
        public Double Re_Coast_Bath { get; set; }
        public Report_Stock()
        {
            this.Re_Count_Item = 0;
            this.Re_Total_Coast = 0.0;
            this.Re_Sum_AmoundSold = 0.0;
            this.Re_Coast_EA = 0;
            this.Re_Coast_List = 0.0;
            this.Re_Coast_Bath = 0.0;
        }
    }
}