using VistaEDI.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace VistaEDI.Data
{
    public class ParserData : DatabaseOperations
    {
        public ResultViewModel SaveItem(ChemistryInfo data, char status)
        {

            try
            {
                StoredProcedureName = "ChemistryInfoInsert_Proc";

                this.ConnectionString = ConfigurationManager.AppSettings["DBConnection"].ToString();
                SQLParameters = new Dictionary<string, object>();

                SQLParameters["Status"] = status;

                SQLParameters["ShipmentNumber"] = data.ShipmentNumber;
                SQLParameters["ShipmentDate"] = data.ShipmentDate;
                SQLParameters["HeatNumber"] = data.HeatNumber;
                SQLParameters["Alloy"] = data.Alloy;
                SQLParameters["Diameter"] = data.Diameter;
                SQLParameters["Al"] = data.Al;
                SQLParameters["Si"] = data.Si;
                SQLParameters["Fe"] = data.Fe;
                SQLParameters["Cu"] = data.Cu;
                SQLParameters["Mn"] = data.Mn;
                SQLParameters["Mg"] = data.Mg;
                SQLParameters["Cr"] = data.Cr;
                SQLParameters["Ni"] = data.Ni;
                SQLParameters["Zn"] = data.Zn;
                SQLParameters["Ti"] = data.Ti;
                SQLParameters["V"] = data.V;
                SQLParameters["Pb"] = data.Pb;
                SQLParameters["Sn"] = data.Sn;
                SQLParameters["B"] = data.B;
                SQLParameters["Be"] = data.Be;
                SQLParameters["Na"] = data.Na;
                SQLParameters["Ca"] = data.Ca;
                SQLParameters["Bi"] = data.Bi;
                SQLParameters["Zr"] = data.Zr;
                SQLParameters["Li"] = data.Li;
                SQLParameters["Ag"] = data.Ag;

                SQLParameters["Sc"] = data.Sc;
                SQLParameters["Sr"] = data.Sr;
                SQLParameters["TiZr"] = data.TiZr;                                                                                                                                      

                DataTable failList = Execute();

                ResultViewModel res = new ResultViewModel();

                int j;

                foreach(DataRow row in failList.Rows)
                {
                    j = 0;
                    res.Message = row[j].ToString();j++;
                    res.HeatNo = row[j].ToString(); 
                }
                return res;
                              
            }
            catch (Exception ex)
            {
                ResultViewModel res = new ResultViewModel();
                res.Message = "FAIL";
               // res.Message = ex.ToString();
                return res;
            }
            
        }
    }
}
