using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    public class OrderObject
    {
        public int LineNo { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}