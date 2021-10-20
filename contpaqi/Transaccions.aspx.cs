using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;
using System.Net;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

namespace contpaqi
{
    public class Transaccions
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Banktransactions> banktransactions { get; set; }

    }
    public class Banktransactions
    {
        public string transaction_id { get; set; }
        public string date { get; set; }
        public string amount { get; set; }
        public string transaction_type { get; set; }
        public string status { get; set; }
        public string source { get; set; }
        public string account_id { get; set; }
        public string account_name { get; set; }
        public string account_type { get; set; }
        public string price_precision { get; set; }
        public string customer_id { get; set; }
        public string payee { get; set; }
        public string is_paid_via_print_check { get; set; }
        public string currency_id { get; set; }
        public string currency_code { get; set; }
        public string currency_symbol { get; set; }
        public string debit_or_credit { get; set; }
        public string offset_account_name { get; set; }
        public string is_offsetaccount_matched { get; set; }
        public string reference_number { get; set; }
        public string imported_transaction_id { get; set; }
        public string is_rule_exist { get; set; }

    }
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label25.Text = Convert.ToString(Session["ID_Orga"]);
            string sincro = Request.QueryString["sincronization"];
            string fecha_inicio = Request.Form.Get("TextBox2");
            string fecha_fin = Request.Form.Get("TextBox1");
            if (string.IsNullOrEmpty(fecha_fin))
            {
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                TextBox1.Text = Date;
            }
            string code = Request.QueryString["account_id"];
            if (string.IsNullOrEmpty(code))
            {
                if (!string.IsNullOrEmpty(sincro))
                {
                    this.Todas(Convert.ToString(Session["access_token"]));
                }
                else
                {
                    return;
                }
                
            }
            else
            {
                string acoountID = Request.QueryString["account_id"].ToString();
                Session["account_id"] = acoountID;
                if (!string.IsNullOrEmpty(sincro))
                {
                    this.Todas(Convert.ToString(Session["access_token"]));
                }
                else
                {
                    return;
                }

            }

             
        }
        protected void volver(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void verlista2(object sender, EventArgs e)
        {
            string valor_tipo = null;
            string text = null;
            string acoountID = Request.QueryString["account_id"];
            Session["account_id"] = acoountID;
            if (!string.IsNullOrEmpty(acoountID))
            {
                if (DropDownList2.SelectedItem.Value == "1")
                {
                    valor_tipo = "deposit";
                    text = "Deposito";
                }
                else
                {
                    if (DropDownList2.SelectedItem.Value == "2")
                    {

                        valor_tipo = "refund";
                        text = "Reembolso";
                    }
                    else
                    {
                        if (DropDownList2.SelectedItem.Value == "3")
                        {
                            valor_tipo = "transfer_fund";
                            text = "Fondo de transferencia";
                        }
                        else
                        {
                            if (DropDownList2.SelectedItem.Value == "4")
                            {

                                valor_tipo = "card_payment";
                                text = "Pago con tarjeta";
                            }
                            else
                            {
                                if (DropDownList2.SelectedItem.Value == "5")
                                {
                                    valor_tipo = "sales_without_invoices";
                                    text = "Venta sin factura";
                                }
                                else
                                {
                                    if (DropDownList2.SelectedItem.Value == "6")

                                    {
                                        valor_tipo = "expense_refund";
                                        text = "Reembolso de gastos";
                                    }
                                    else
                                    {
                                        if (DropDownList2.SelectedItem.Value == "7")
                                        {
                                            valor_tipo = "owner_contribution";
                                            text = "Contribucion del propietario";
                                        }
                                        else
                                        {
                                            if (DropDownList2.SelectedItem.Value == "8")
                                            {
                                                valor_tipo = "interest_income";
                                                text = "Ingresos de interes";
                                            }
                                            else
                                            {
                                                if (DropDownList2.SelectedItem.Value == "9")
                                                {
                                                    valor_tipo = "other_income";
                                                    text = "Otros ingresos";
                                                }
                                                else
                                                {
                                                    if (DropDownList2.SelectedItem.Value == "10")
                                                    {
                                                        valor_tipo = "owner_drawings";
                                                        text = "Giros de propietario";
                                                    }
                                                    else
                                                    {
                                                        if (DropDownList2.SelectedItem.Value == "11")
                                                        {
                                                            valor_tipo = "sales_return";
                                                            text = "Devoluciones";
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                string fecha_inicio = Request.Form.Get("TextBox2");
                string fecha_fin = Request.Form.Get("TextBox1");

                if ((string.IsNullOrEmpty(fecha_inicio) && string.IsNullOrEmpty(fecha_fin)))
                {
                    this.Filtrar_por_tipo(Convert.ToString(Session["access_token"]), valor_tipo, text);
                }
                else
                {
                    this.Por_fecha_idtipo(Convert.ToString(Session["access_token"]), valor_tipo, text);
                }
            }
            else
            {
                if (DropDownList2.SelectedItem.Value == "1")
                {
                    valor_tipo = "deposit";
                    text = "Deposito";
                }
                else
                {
                    if (DropDownList2.SelectedItem.Value == "2")
                    {

                        valor_tipo = "refund";
                        text = "Reembolso";
                    }
                    else
                    {
                        if (DropDownList2.SelectedItem.Value == "3")
                        {
                            valor_tipo = "transfer_fund";
                            text = "Fondo de transferencia";
                        }
                        else
                        {
                            if (DropDownList2.SelectedItem.Value == "4")
                            {

                                valor_tipo = "card_payment";
                                text = "Pago con tarjeta";
                            }
                            else
                            {
                                if (DropDownList2.SelectedItem.Value == "5")
                                {
                                    valor_tipo = "sales_without_invoices";
                                    text = "Venta sin factura";
                                }
                                else
                                {
                                    if (DropDownList2.SelectedItem.Value == "6")

                                    {
                                        valor_tipo = "expense_refund";
                                        text = "Reembolso de gastos";
                                    }
                                    else
                                    {
                                        if (DropDownList2.SelectedItem.Value == "7")
                                        {
                                            valor_tipo = "owner_contribution";
                                            text = "Contribucion del propietario";
                                        }
                                        else
                                        {
                                            if (DropDownList2.SelectedItem.Value == "8")
                                            {
                                                valor_tipo = "interest_income";
                                                text = "Ingresos de interes";
                                            }
                                            else
                                            {
                                                if (DropDownList2.SelectedItem.Value == "9")
                                                {
                                                    valor_tipo = "other_income";
                                                    text = "Otros ingresos";
                                                }
                                                else
                                                {
                                                    if (DropDownList2.SelectedItem.Value == "10")
                                                    {
                                                        valor_tipo = "owner_drawings";
                                                        text = "Giros de propietario";
                                                    }
                                                    else
                                                    {
                                                        if (DropDownList2.SelectedItem.Value == "11")
                                                        {
                                                            valor_tipo = "sales_return";
                                                            text = "Devoluciones";
                                                        }
                                                        else
                                                        {
                                                            return;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                string fecha_inicio = Request.Form.Get("TextBox2");
                string fecha_fin = Request.Form.Get("TextBox1");

                if ((string.IsNullOrEmpty(fecha_inicio) && string.IsNullOrEmpty(fecha_fin)))
                {
                    this.Filtrar_porTodo_tipo(Convert.ToString(Session["access_token"]), valor_tipo, text);
                }
                else
                {
                    this.Por_fechaTodo_idtipo(Convert.ToString(Session["access_token"]), valor_tipo, text);

                }
            }



        }

        protected void verLista(object sender, EventArgs e)
        {
            string valor = null;
            string text = null;
            string acoountID = Request.QueryString["account_id"];
            Session["account_id"] = acoountID;
            if (!string.IsNullOrEmpty(acoountID))
            {
                if (DropDownList1.SelectedItem.Value == "1")
                {
                    valor = null;
                    text = "Todo";
                }
                else
                {
                    if (DropDownList1.SelectedItem.Value == "2")
                    {
                        valor = "uncategorized";
                        text = "Sin categoria";
                    }
                    else
                    {
                        if (DropDownList1.SelectedItem.Value == "3")
                        {
                            valor = "categorized";
                            text = "Con categoria";
                        }
                        else
                        {
                            if (DropDownList1.SelectedItem.Value == "4")
                            {
                                valor = "manually_added";
                                text = "Manualmente agregado";
                            }
                            else
                            {
                                if (DropDownList1.SelectedItem.Value == "5")
                                {
                                    valor = "excluded";
                                    text = "Excluido";
                                }
                                else
                                {
                                    if (DropDownList1.SelectedItem.Value == "6")
                                    {
                                        valor = "matched";
                                        text = "Emparejado";
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

                string fecha_inicio = Request.Form.Get("TextBox2");
                string fecha_fin = Request.Form.Get("TextBox1");
                if ((string.IsNullOrEmpty(fecha_inicio) && string.IsNullOrEmpty(fecha_fin)))
                {

                    this.Filtrarpor(Convert.ToString(Session["access_token"]), valor, text);
                }
                else
                {
                    this.Por_fecha_id(Convert.ToString(Session["access_token"]), valor, text);
                }
            }
            else
            {
                if (DropDownList1.SelectedItem.Value == "1")
                {
                    valor = null;
                    text = "Todo";
                }
                else
                {
                    if (DropDownList1.SelectedItem.Value == "2")
                    {
                        valor = "uncategorized";
                        text = "Sin categoria";
                    }
                    else
                    {
                        if (DropDownList1.SelectedItem.Value == "3")
                        {
                            valor = "categorized";
                            text = "Con categoria";
                        }
                        else
                        {
                            if (DropDownList1.SelectedItem.Value == "4")
                            {
                                valor = "manually_added";
                                text = "Manualmente agregado";
                            }
                            else
                            {
                                if (DropDownList1.SelectedItem.Value == "5")
                                {
                                    valor = "excluded";
                                    text = "Excluido";
                                }
                                else
                                {
                                    if (DropDownList1.SelectedItem.Value == "6")
                                    {
                                        valor = "matched";
                                        text = "Emparejado";
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }

                string fecha_inicio = Request.Form.Get("TextBox2");
                string fecha_fin = Request.Form.Get("TextBox1");
                if ((string.IsNullOrEmpty(fecha_inicio) && string.IsNullOrEmpty(fecha_fin)))
                {

                    this.FiltrarporTodo(Convert.ToString(Session["access_token"]), valor, text);
                }
                else
                {
                    this.Por_fecha_idtodo(Convert.ToString(Session["access_token"]), valor, text);
                }
            }
  



        }


        protected void Filtrarpor(string access_token, string filtro, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string account_id = Convert.ToString(Session["account_id"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id + "&account_id=" + account_id + "&status=" + filtro);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=B1A40C35AA22E561DAE9805D9A28D857; _zcsr_tmp=656e3a11-d8a6-4192-88cf-d976ed3bdfd9; ba05f91d88=86e4d659e5aa9a3b740db071dd22c303; zbcscook=656e3a11-d8a6-4192-88cf-d976ed3bdfd9");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Hacer_Tabla(aux, texto);
        }
        protected void FiltrarporTodo(string access_token, string filtro, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id + "&account_id="  + "&status=" + filtro);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=B1A40C35AA22E561DAE9805D9A28D857; _zcsr_tmp=656e3a11-d8a6-4192-88cf-d976ed3bdfd9; ba05f91d88=86e4d659e5aa9a3b740db071dd22c303; zbcscook=656e3a11-d8a6-4192-88cf-d976ed3bdfd9");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Sincronizar(aux, texto);
        }
        protected void Por_fecha_idtipo(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string fecha_inicio = Request.Form.Get("TextBox2");
            string fecha_fin = Request.Form.Get("TextBox1");
            string account_id = Convert.ToString(Session["account_id"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id + "&account_id=" + account_id + "&date_start=" + fecha_inicio + "&date_end=" + fecha_fin + "&transaction_type=" + tipo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            var json = JsonConvert.DeserializeObject<Transaccions>(aux);
            if ((json.banktransactions == null) || (json.banktransactions.Count == 0))
            {
                Label21.Text = "No hay elementos en la lista &nbsp;&nbsp;" + texto;
                Hacer_Tabla(aux, texto);
                return;
            }
            Hacer_Tabla(aux, texto);
            
            Response.Write("<script> alert('Recuerda que si el rango de la fecha es muy grande podrias acabarte las llamadas de zoho')</script");
        }
        protected void Por_fechaTodo_idtipo(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string fecha_inicio = Request.Form.Get("TextBox2");
            string fecha_fin = Request.Form.Get("TextBox1");
            
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id  + "&date_start=" + fecha_inicio + "&date_end=" + fecha_fin + "&transaction_type=" + tipo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            var json = JsonConvert.DeserializeObject<Transaccions>(aux);
            if ((json.banktransactions == null) || (json.banktransactions.Count == 0))
            {
                Label21.Text = "No hay elementos en la lista &nbsp;&nbsp;" + texto;
                Hacer_Tabla(aux, texto);
                return;
            }
            Sincronizar(aux, texto);
            Response.Write("<script> alert('Recuerda que si el rango de la fecha es muy grande podrias acabarte las llamadas de zoho')</script");

        }
        protected void Filtrar_por_tipo(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string account_id = Convert.ToString(Session["account_id"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id + "&account_id=" + account_id + "&transaction_type=" + tipo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=B1A40C35AA22E561DAE9805D9A28D857; _zcsr_tmp=656e3a11-d8a6-4192-88cf-d976ed3bdfd9; ba05f91d88=86e4d659e5aa9a3b740db071dd22c303; zbcscook=656e3a11-d8a6-4192-88cf-d976ed3bdfd9");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Hacer_Tabla(aux, texto);
        }

        protected void Filtrar_porTodo_tipo(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id  + "&transaction_type=" + tipo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=B1A40C35AA22E561DAE9805D9A28D857; _zcsr_tmp=656e3a11-d8a6-4192-88cf-d976ed3bdfd9; ba05f91d88=86e4d659e5aa9a3b740db071dd22c303; zbcscook=656e3a11-d8a6-4192-88cf-d976ed3bdfd9");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Sincronizar(aux, texto);
        }


        protected void Por_fecha_id(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string fecha_inicio = Request.Form.Get("TextBox2");
            string fecha_fin = Request.Form.Get("TextBox1");
            string account_id = Convert.ToString(Session["account_id"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id + "&account_id=" + account_id + "&date_start=" + fecha_inicio + "&date_end=" + fecha_fin + "&status=" + tipo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            var json = JsonConvert.DeserializeObject<Transaccions>(aux);
            if ((json.banktransactions == null) || (json.banktransactions.Count == 0))
            {
                Label21.Text = "No hay elementos en la lista &nbsp;&nbsp;" + texto;
                Hacer_Tabla(aux, texto);
                return;
            }
            Hacer_Tabla(aux, texto);
            Response.Write("<script> alert('Recuerda que si el rango de la fecha es muy grande podrias acabarte las llamadas de zoho')</script");

        }
        protected void Por_fecha_idtodo(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string fecha_inicio = Request.Form.Get("TextBox2");
            string fecha_fin = Request.Form.Get("TextBox1");
  
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id  + "&date_start=" + fecha_inicio + "&date_end=" + fecha_fin + "&status=" + tipo);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            var json = JsonConvert.DeserializeObject<Transaccions>(aux);
            if ((json.banktransactions == null) || (json.banktransactions.Count == 0))
            {
                Label21.Text = "No hay elementos en la lista &nbsp;&nbsp;" + texto;
                Sincronizar(aux, texto);
                return;
            }
            Sincronizar(aux, texto);
            Response.Write("<script> alert('Recuerda que si el rango de la fecha es muy grande podrias acabarte las llamadas de zoho')</script");

        }
        protected void Obtener_lista(string access_token, string tipo, string texto)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=B1A40C35AA22E561DAE9805D9A28D857; _zcsr_tmp=656e3a11-d8a6-4192-88cf-d976ed3bdfd9; ba05f91d88=86e4d659e5aa9a3b740db071dd22c303; zbcscook=656e3a11-d8a6-4192-88cf-d976ed3bdfd9");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Hacer_Tabla(aux, texto);
        }


        protected void Hacer_Tabla(string tabla, string texto)
        {

            string account_id = Convert.ToString(Session["account_id"]);
            List<Banktransactions> chart = new List<Banktransactions>();
            List<Banktransactions> vacio = new List<Banktransactions>();
            var model = JsonConvert.DeserializeObject<Transaccions>(tabla);
            //670909077
            if ((model.banktransactions == null) || (model.banktransactions.Count == 0))
            {
                Label21.Text = "No hay elementos en la lista de:&nbsp;&nbsp;" + texto;
                rptCustomers.DataSource = chart;
                rptCustomers.DataBind();
                return;
            }
            else
            {

                for (int i = 0; i < model.banktransactions.Count; i++)
                {
                    chart.Add(model.banktransactions[i]);


                }

                Console.WriteLine(chart);
                Label21.Text = "Tabla de cuentas:";
                rptCustomers.DataSource = chart;
                rptCustomers.DataBind();

            }



        }

        protected void Sincronizar(string tabla,string texto)
        {
            List<Banktransactions> chart = new List<Banktransactions>();
            List<Banktransactions> vacio = new List<Banktransactions>();
            var model = JsonConvert.DeserializeObject<Transaccions>(tabla);
            //670909077
            if ((model.banktransactions == null) || (model.banktransactions.Count == 0))
            {
                Label21.Text = "No hay elementos en la lista &nbsp;&nbsp;"+ texto;
                rptCustomers.DataSource = chart;
                rptCustomers.DataBind();
                return;
            }
            else
            {
                List<Chartofaccounts> chat = (List<Chartofaccounts>)Session["ListaID"];
               

                for (int i = 0; i < model.banktransactions.Count; i++)
                {
                 
                    for(int j = 0; j < chat.Count; j++)
                    {
                        if (chat[j].account_id == model.banktransactions[i].account_id  )
                        {
                            chart.Add(model.banktransactions[i]);
                        }
                     
                    }


                }

                Console.WriteLine(chart);
                Label21.Text = "Cuentas con transacciones:";
                rptCustomers.DataSource = chart;
                rptCustomers.DataBind();

            }

        }

        protected void Todas(string access_token)
        {
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            var client = new RestClient("https://books.zoho.com/api/v3/banktransactions?organization_id=" + organization_id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            request.AddHeader("Cookie", "JSESSIONID=B1A40C35AA22E561DAE9805D9A28D857; _zcsr_tmp=656e3a11-d8a6-4192-88cf-d976ed3bdfd9; ba05f91d88=86e4d659e5aa9a3b740db071dd22c303; zbcscook=656e3a11-d8a6-4192-88cf-d976ed3bdfd9");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Sincronizar(aux , "");
        }
    }
}