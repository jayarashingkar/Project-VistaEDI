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
        public string ParseJson(string data, char status)
        {
            try
            {
                string errorList = "";
                ResultViewModel res;
               
                var result = JsonConvert.DeserializeObject<List<ChemistryInfo>>(data);
                foreach (var item in result)
                {
                    res = new ParserData().SaveItem(item,status);
                    if (res.Message == "FAIL")
                        return "ERROR";

                    if (res.Message != "")
                    {                      
                         errorList += "<br />"+ "Heat No." + res.HeatNo + ":" + res.Message + "; ";                        
                    }

                }
                return errorList;
               
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }
    }
}
