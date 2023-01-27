// formulario de webforms// ver codigo // pegar lo siguiente

using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prueba
{
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Creacionpedido();
        }

        static void Creacionpedido()
        {
            try
            {
                if (Servidorsap.Open())
                {

                    Servidorsap.myCompany.StartTransaction();
                    Documents myDoc = Servidorsap.myCompany.GetBusinessObject(BoObjectTypes.oOrders);
                    myDoc.CardCode = "C00102";
                    myDoc.DocDate = DateTime.Now;
                    myDoc.DocDueDate = DateTime.Now;
                    myDoc.TaxDate = DateTime.Now;
                    // myDoc.NumAtCard = "creado con diapi";
                    myDoc.UserFields.Fields.Item("U_BXP_SOL").Value = "DEVSTEST"; //solicitante
                    //myDoc.UserFields.Fields.Item("U_BXP_LIQ").Value = "50446"; //LIQUIDACION
                    myDoc.UserFields.Fields.Item("U_BXP_ORIGEN").Value = "ACA"; //ORIGEN HOJA RUTA
                    myDoc.UserFields.Fields.Item("U_BXP_DESTINO").Value = "ABA"; //DESTINO HOJA RUTA
                    myDoc.UserFields.Fields.Item("U_BXP_OPERADOR").Value = "GALINDO GARCIA LUIS ALBERTO"; //OPERADOR
                    myDoc.UserFields.Fields.Item("U_BXP_TRACTO").Value = "1596"; //TRACTO
                    myDoc.UserFields.Fields.Item("U_BXP_CAJA").Value = "C1010"; //CAJA
                    myDoc.UserFields.Fields.Item("U_BXP_VACIO").Value = "NO"; //vacio
                    myDoc.UserFields.Fields.Item("U_BXP_DESTHOJARUTA").Value = "ACA"; //DESTINO CARTA PORTE
                    myDoc.UserFields.Fields.Item("U_BXP_ORICARTPOR").Value = "ABA"; //ORIGEN CARTA

                    myDoc.UserFields.Fields.Item("U_BXP_PESO").Value = 14900; //PESO
                    myDoc.UserFields.Fields.Item("U_BXP_DOBLEOP").Value = "NO"; //DOBLEOPERADOR
                    myDoc.UserFields.Fields.Item("U_BXP_BANDAS").Value = 2; //BANDAS

                    myDoc.UserFields.Fields.Item("U_Verificador").Value = "1002"; //VERIFICACION

                    myDoc.UserFields.Fields.Item("U_BXP_CARGA").Value = "SI"; // CARGA GNERAL
                    myDoc.UserFields.Fields.Item("U_TIPOCAJA").Value = "53"; //TIPO CAJA

                    myDoc.UserFields.Fields.Item("U_U_BXP_ENCENDIDO").Value = "NO"; //THERMO

                    //myDoc.DocType = BoDocumentTypes.dDocument_Service;


                    myDoc.Lines.ItemCode = "SERV003";
                    myDoc.Lines.Quantity = 1;


                    myDoc.Lines.TaxCode = "IVAT16";




                    //myDoc.Add();

                    if (myDoc.Add() != 0)
                    {
                        Console.WriteLine(Servidorsap.myCompany.GetLastErrorDescription());
                        Servidorsap.myCompany.EndTransaction(BoWfTransOpt.wf_RollBack);

                    }
                    else
                    {
                        var numCarta = Servidorsap.myCompany.GetNewObjectKey();
                        Servidorsap.myCompany.EndTransaction(BoWfTransOpt.wf_Commit);
                        Console.WriteLine("pedido fue un exito" + numCarta);

                    }
                    //segunda linea 


                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
