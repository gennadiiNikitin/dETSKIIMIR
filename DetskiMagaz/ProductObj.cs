using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetskiMagaz
{
   internal class ProductObj
    {
        public static string article_number { get; set; }
        public static string name { get; set; }
        public static string unit { get; set; }
        public static decimal stoimost { get; set; }
        public static decimal max_discount { get; set; }
        public static int manufacturer { get; set; }
        public static int provider { get; set; }
        public static int? category_number { get; set; }
        public static decimal discount { get; set; }
        public static int quantity_in_stock { get; set; }
        public static string description { get; set; }
        public static string photo { get; set; }

    }
}
