using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

 namespace ConsoleApplication1
{
    public class Program
    {
        string _data;
        OrderObject oo = null;
        public Program()
        {            
        }
        public string returnOrderData(string OrderData, out bool result)
        {
            _data = OrderData;            
            if ( string.IsNullOrWhiteSpace(_data))
            {
                result = false;
                return "input is empty";
            }
            else
            {
                // Condition for length < 39
                if (_data.Length < 39)
                {
                    result = false;
                    return "input length is less than 39";
                }
                else
                {
                    //name//offset/type/length
                    
                    var LineNo = _data.Substring(0, 4);
                    var code = _data.Substring(4, 10);
                    var category = _data.Substring(14, 10);
                    var quant = _data.Substring(24, 5);
                    var price = _data.Substring(29, 10);
                                      
                    int i;
                    if(! int.TryParse(LineNo, out i))
                    {
                        result = false; 
                        return "Line No is not numeric";
                    }
                    if (!int.TryParse(quant, out i))
                    {
                        result = false; 
                        return "quantity is not numeric";
                    }                    
                    float f;
                    if (!float.TryParse(price, out f))
                    {
                        result = false; 
                        return "price is not a floating point number";
                    }
                    oo = new OrderObject();                    
                    oo.LineNo =  int.Parse(LineNo);
                    oo.Code = code;
                    oo.Category = category;
                    oo.Quantity= int.Parse(quant);
                   oo.Price = float.Parse(price);
                   System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                   
                    result = true;
                    return js.Serialize(oo);
                    
                }                
            }
        }
        static void Main(string[] args)
        {
            //Program p = new Program();
            //p.returnOrderData("0123456789012345678901234567890123456789");
        }
    }
}