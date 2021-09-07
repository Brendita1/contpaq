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

    public partial class WebForm3 : System.Web.UI.Page
    {
        List<String> ids = new List<String>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label15.Text = Convert.ToString(Session["ID_orga"]);
            this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.All");
        }

        protected void ButtonOnClick(object sender, EventArgs e)

        {
            string valor=null;
            if (DropDownList1.SelectedItem.Value == "1")
            {
                this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.All");
                valor = "AccountType.All";
            }
            else
            {
                if(DropDownList1.SelectedItem.Value == "2")
                {
                    this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Active");
                    valor = "AccountType.Active";
                }
                else
                {
                    if(DropDownList1.SelectedItem.Value == "3")

                    {
                        this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Inactive");
                        valor = "AccountType.Inactive";
                    }
                    else
                    {
                        if(DropDownList1.SelectedItem.Value == "4")
                        {
                            this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Asset");
                            valor = "AccountType.Asset";
                        }
                        else
                        {
                            if(DropDownList1.SelectedItem.Value == "5")
                            {
                                this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Liability");
                                valor = "AccountType.Liability";
                            }
                            else
                            {
                                if(DropDownList1.SelectedItem.Value == "6")
                                {
                                    this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Equity");
                                    valor = "AccountType.Equity";
                                }
                                else
                                {
                                    if(DropDownList1.SelectedItem.Value == "7")
                                    {
                                        this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Income");
                                        valor = "AccountType.Equity";
                                    }
                                    else
                                    {
                                        if(DropDownList1.SelectedItem.Value == "8")
                                        {
                                            this.Filtrado(Convert.ToString(Session["access_token"]), "AccountType.Expense");
                                            valor = "AccountType.Expense";
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
            if (DropDownList2.SelectedItem.Value == "1")
            {
                this.Filtrado_Ordenar(Convert.ToString(Session["access_token"]),valor, "account_name");
            }
            else
            {
                if (DropDownList2.SelectedItem.Value == "2")
                {
                    this.Filtrado_Ordenar(Convert.ToString(Session["access_token"]), valor, "account_type");
                }
            }

        }
  


        protected void Filtrado(string access_token, string filtro)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            var client = new RestClient("https://books.zoho.com/api/v3/chartofaccounts?organization_id=" + organization_id + "&filter_by="+filtro);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Hacer_Tabla(aux,filtro);

        }
        protected void Filtrado_Ordenar(string access_token, string filtro,string ordenar)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string organization_id = Convert.ToString(Session["ID_Orga"]);
            string ultima_modificacion= Request.Form.Get("Text1");
            var client = new RestClient("https://books.zoho.com/api/v3/chartofaccounts?organization_id=" + organization_id + "&filter_by=" + filtro + "&sort_column=" + ordenar + "&last_modified_time=" + ultima_modificacion);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + access_token);
            request.AddHeader("Content-Type", "application/json;charset=UTF-8");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            string aux = response.Content;
            Hacer_Tabla(aux,filtro);

        }

     

        protected void Hacer_Tabla(string tabla,string filtro)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<Chartofaccounts> chart = new List<Chartofaccounts>();
            var model = JsonConvert.DeserializeObject<Accounts>(tabla);
            Accounts aco = new Accounts();

            //670909077
            if ((model.chartofaccounts == null) || (model.chartofaccounts.Count == 0))
            {
                Label16.Text = "No hay elementos en la lista de:&nbsp;&nbsp;" + filtro;
                rptCustomers.DataSource = chart;
                
                rptCustomers.DataBind();
                return;
            }
            else
            {
       
                for (int i = 0; i < model.chartofaccounts.Count; i++)
                {
                    chart.Add(model.chartofaccounts[i]);

                }

                Session["ListaID"] = chart;
                Label16.Text = "Tabla de cuentas:";
                rptCustomers.DataSource = chart;
                rptCustomers.DataBind();
                
            }


        }


        protected void ir(object sender, EventArgs e)
        {
            Response.Redirect("Transaccions.aspx?sincronization=todas");
        }

    }

}