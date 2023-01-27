// crear clase de c# e insertar codgo desde linea 13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAPbobsCOM;

namespace prueba
{
    public class Servidorsap
    {

        public static Company myCompany = null;


        public static bool Open()
        {
            try
            {
                bool respuesta = false;
                myCompany = new Company();
                myCompany.Server = @"SERVIDORSAP";
                myCompany.DbServerType = BoDataServerTypes.dst_MSSQL2016;
                myCompany.CompanyDB = "zzzzMEDRANOzzzz";
                myCompany.DbUserName = "sa";
                myCompany.DbPassword = "TransMed12";
                myCompany.UserName = "sistm001";
                myCompany.Password = "TransMed1";
                myCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
                myCompany.UseTrusted = false;


                int error = myCompany.Connect();

                if (error == 0)
                {
                    respuesta = true;
                    Console.WriteLine("conexion exitosa");
                }
                else
                {
                    Console.WriteLine("error");
                }
                return respuesta;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
