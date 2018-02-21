using VistaEDI.Data;
using VistaEDI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VistaEDI.BL
{
    public class VistaParser
    {
        public string ParseJson(string data)
        {
            try
            {
                string errorList = "";
                string res;
                var result = JsonConvert.DeserializeObject<List<ChemistryInfo>>(data);
                int i = 1;
                foreach (var item in result)
                {                    
                    res = new ParserData().SaveItem(item);
                    if (res == "FAIL")
                        return "ERROR";                    

                    if (res != "")
                    {
                        //if (res.ToUpper().Trim() == "HEATNOEXISTS")
                        //{
                        //    errorList += "Record No." + i.ToString() + ":" + res + "; ";
                        //}
                        errorList += "Record No." + i.ToString() + ":" + res + "; ";
                        i++;
                       
                    }
                                  
                }
                return errorList;
            }
            catch(Exception ex)
            {
                return "ERROR";
            }
        }
    }
}
