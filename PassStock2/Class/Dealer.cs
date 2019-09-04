using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PassStock2
{
    public class Dealer
    {
        public int IS_Count_Item { get; set; }
        public Double IS_Total_Coast { get; set; }
        public Double IS_Sum_AmoundSold { get; set; }
        public Double IS_Coast_EA { get; set; }
        public Double IS_Coast_List { get; set; }
        public Double IS_Coast_Bath { get; set; }

        public Dealer()
        {
            this.IS_Count_Item = 0;
            this.IS_Total_Coast = 0;
            this.IS_Sum_AmoundSold = 0;
            this.IS_Coast_EA = 0.0;
            this.IS_Coast_List = 0;
            this.IS_Coast_Bath = 0.0;
        }
    }
}