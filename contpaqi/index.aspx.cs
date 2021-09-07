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
using System.Timers;
using System.Text.RegularExpressions;

namespace contpaqi
{
    public class Repeater : System.Web.UI.Control, System.Web.UI.INamingContainer
    {

    }
    public class Accounts
    {
        public int code { get; set; }
        public string message { get; set; }
        public List<Chartofaccounts> chartofaccounts { get; set; }

    }
    public class TokenModel
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
    }
    public class Chartofaccounts
    {
       
        public string account_id { get; set; }
        public string account_name { get; set; }
        public string account_type { get; set; }
        public bool is_user_created { get; set; }
        public bool is_system_account { get; set; }
        public bool is_standalone_account { get; set; }
        public bool is_active { get; set; }
        public bool can_show_in_ze { get; set; }
        public bool is_involved_in_transaction { get; set; }
        public string parent_account_id { get; set; }
        public string parent_account_name { get; set; }
        public bool has_attachment { get; set; }
        public string created_time { get; set; }
        public string last_modified_time { get; set; }
       

    }
    public partial class WebForm1 : System.Web.UI.Page
    {
      
     
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["code"];

            if (!String.IsNullOrEmpty(code))
            {

               // Label4.Text = code;
                curl_example(code);
                update_token(Convert.ToString(Session["refresh_token"]));
                get_organizacionid(Convert.ToString(Session["access_token"]));
               // Lista(Convert.ToString(Session["access_token"]));
                
            }
                if (!IsPostBack)
                {

                    if (Convert.ToString(Session["email"]) == null) return;
                    if (Convert.ToString(Session["id"]) == null) return;
                    if (Convert.ToString(Session["user"]) == null) return;
                    Correoid.Text = Convert.ToString(Session["email"]);
                    Identificadorid.Text = Convert.ToString(Session["id"]);
                    Usernameid.Text = Convert.ToString(Session["user"]);
                    //this.Lista(Convert.ToString(Session["access_token"]));

                }
            Users datosuser = null;
            string eml = Convert.ToString(Session["email"]);
            datosuser= LogForEml(eml);
            if(datosuser.User_token_refresh != "")
            {
                update_token(Convert.ToString(Session["refresh_token"]));

            }


        }
        public Users LogForEml(string eml)
        {

            MySqlDataReader reader;
            string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none"; //Realizo la conexion
            MySqlConnection con = new MySqlConnection(mycon);
            con.Open();
            string sql = "SELECT ID_USER,User_Password,User_email,User_name,User_token_access,User_token_refresh,ID_organization FROM users WHERE User_email LIKE @eml"; //Realizo la consulta  en mysql
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@eml", eml);  //Obtengo el valor que quiero
            reader = cmd.ExecuteReader();
            Users usr = new Users();

            while (reader.Read())
            {
                // Users usr = new Users();
                //users.User
                usr.ID = int.Parse(reader["ID_USER"].ToString()); //Acceso a mis valores deseados y los guardo en la variable tipo Users
                usr.Email = reader["User_email"].ToString();
                usr.Password = reader["User_Password"].ToString();
                usr.User = reader["User_name"].ToString();
                usr.ID_organization = reader["ID_organization"].ToString();
                usr.User_token_access = reader["User_token_access"].ToString();
                usr.User_token_refresh = reader["User_token_refresh"].ToString();

            }

            return usr;  //Retorno mi variable con los datos obtenidos
        }
        public void Button1_Click(object sender, EventArgs e)
        {
            //'https://accounts.zoho.com/oauth/v2/auth?scope=ZohoInventory.FullAccess.all,ZohoBooks.fullAccess.all&client_id=1000.CL60GXGKKU9VIY49JPBC94II8KX5FV&state=testing&response_type=code&redirect_uri=https://azul.facturacionzoho.com/Auth/authorization.php&access_type=offline&prompt=consent'
            Response.Redirect("https://accounts.zoho.com/oauth/v2/auth?scope=ZohoInventory.FullAccess.all,ZohoBooks.fullAccess.all&client_id=1000.CL60GXGKKU9VIY49JPBC94II8KX5FV&state=testing&response_type=code&redirect_uri=http://localhost:61593/index.aspx&access_type=offline&prompt=consent");
        
        }

        public void curl_example(string code)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string url = "https://accounts.zoho.com/oauth/v2/token?redirect_uri=http://localhost:61593/index.aspx&code=" + code + "&client_id=1000.CL60GXGKKU9VIY49JPBC94II8KX5FV&client_secret=b6dede482e189714c298f52cba526d74795c263d30&grant_type=authorization_code";
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            //  Label4.Text = response.Content;
            string aux = response.Content;
            var json = JsonConvert.DeserializeObject<TokenModel>(aux);
            ButtonR_Update(json.access_token, json.refresh_token);
            Session["refresh_token"] = json.refresh_token;
            Session["access_token"] = json.access_token;
            Label22.Text = "¡Hecho!";
            // Label4.Text = "Tu cuenta ha sido vinculada :)";
            //update_token(json.refresh_token);
            //Response.Redirect("HomePage.aspx");


        }



        protected void get_organizacionid(string access_token)
        {


            var client = new RestClient("https://books.zoho.com/api/v3/organizations");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Zoho-oauthtoken "+access_token);
            request.AddHeader("Cookie", "JSESSIONID=444B2DFF7EACC741DB8FC2F220D11888; _zcsr_tmp=5ebe6990-86c9-485a-a5d5-cca917948a76; ba05f91d88=768ef23991388f9f9984a65b3eb655f2; zbcscook=5ebe6990-86c9-485a-a5d5-cca917948a76");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Response.Redirect("HomePage.aspx");

        }




        public void update_token(string refreshT)
        {
            var timer = new System.Timers.Timer(TimeSpan.FromMinutes(2).TotalMilliseconds); 
            timer.Elapsed += async (sender, e) => {
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string url = "https://accounts.zoho.com/oauth/v2/token?refresh_token=" + refreshT + "&client_id=1000.CL60GXGKKU9VIY49JPBC94II8KX5FV&client_secret=b6dede482e189714c298f52cba526d74795c263d30&redirect_uri=http://localhost:61593/index.aspx&grant_type=refresh_token";
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
               // Label1.Text = response.Content;
                string aux = response.Content;
                var json = JsonConvert.DeserializeObject<TokenModel>(aux);
                Session["access_token"] = json.access_token;
                ButtonT_Update(Convert.ToString(Session["access_token"]));
                
            };
            timer.Start();
            
            Response.Redirect("HomePage.aspx");
        }

        protected void ButtonT_Update(string access_token)
        {
            string emls = Convert.ToString(Session["email"]);

            var _acces_token = access_token;
            WebForm2 obj = new WebForm2();
            Users datosuser = null;
            datosuser = obj.LogForEml(emls);

            string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none";

            MySqlConnection con = new MySqlConnection(mycon);
            try
            {
                // i = i + 1;

                MySqlCommand cmd = new MySqlCommand("Update_tokenA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_ID", datosuser.ID);
                cmd.Parameters.AddWithValue("@_Access_token", _acces_token);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
                return;
            }
        }
        protected void ButtonR_Update(string access_token, string refresh_token)
        {
            string emls = Convert.ToString(Session["email"]);

            var _acces_token = access_token;
            var _refresh_token = refresh_token;
            WebForm2 obj = new WebForm2();
            Users datosuser = null;
            datosuser = obj.LogForEml(emls);

            string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none";

            MySqlConnection con = new MySqlConnection(mycon);
            try
            {
               // i = i + 1;

                MySqlCommand cmd = new MySqlCommand("Update_users", con);
                cmd.CommandType = CommandType.StoredProcedure;
           //   cmd.Parameters.AddWithValue("@_ID_USER", Identificadorid.Text);
                cmd.Parameters.AddWithValue("@_ID_USER",datosuser.ID);
                cmd.Parameters.AddWithValue("@_User_token_access", _acces_token);
                cmd.Parameters.AddWithValue("@_User_token_refresh", _refresh_token);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
                return;
            }
            

        }

        
        protected void view_pass(object sender, EventArgs e)
        {


            if (Convert.ToString(Session["pass"]) == null) return;
            Label3.Text =  Convert.ToString(Session["pass"]);

        }
        public bool ContrasenaSegura(string contraseñaSinVerificar)
        {
            //letras de la A a la Z, mayusculas y minusculas
            Regex letras = new Regex(@"\b[A-Z]\w*\b");
            //digitos del 0 al 9
            Regex numeros = new Regex(@"[0-9]");
            //cualquier caracter del conjunto
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            // bool cumpleCriterios = false;

            //si no contiene las letras, regresa false
            if (!letras.IsMatch(contraseñaSinVerificar))
            {
                Response.Write("<script> alert('No contiene minimo una mayuscula')</script");
                return false;
            }
            //si no contiene los numeros, regresa false
            if (!numeros.IsMatch(contraseñaSinVerificar))
            {
                Response.Write("<script> alert('No contiene almenos un numero')</script");
                return false;
            }

            //si no contiene los caracteres especiales, regresa false
            if (!caracEsp.IsMatch(contraseñaSinVerificar))
            {
                Response.Write("<script> alert('Debe contener almenos un caracter especial')</script");
                return false;
            }

            if (contraseñaSinVerificar.Length < 7)
            {
                Response.Write("<script> alert('La contraseña debe tener una longitud de almenos 7 caracteres')</script");
                return false;
            }

            //si cumple con todo, regresa true
            return true;
        }


        protected void Update_pass(object sender, EventArgs e)
        {
            string pass_temp = Convert.ToString(Session["pass"]);
            string eml = Correoid.Text;
            string pass = Request.Form.Get("inputPassword");
            string pass_new = Request.Form.Get("Password1");
            string pass_conf = Request.Form.Get("Password2");
            Users datosuser = null;
            bool verifica = false;

            verifica = ContrasenaSegura(pass_new);
            if (verifica == true)
            {
                string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none";



                MySqlConnection con = new MySqlConnection(mycon);
                if (pass_temp == pass)
                {
                    if (pass_new != pass_temp)
                    {
                        if (pass_new == pass_conf)
                        {


                            try
                            {


                                MySqlCommand cmd = new MySqlCommand("Update_password", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                WebForm2 obj = new WebForm2();

                                datosuser = obj.LogForEml(eml);

                                //cmd.Parameters.AddWithValue("@_ID_USER", Identificadorid.Text);
                                cmd.Parameters.AddWithValue("@_ID_USER", datosuser.ID);
                                cmd.Parameters.AddWithValue("@_NewPassword", pass_new);

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                Session["pass"] = pass_new;

                            }
                            catch (Exception ex)
                            {
                                Response.Write("<script>alert('" + ex.Message + "')</script>");
                                con.Close();
                                return;
                            }


                        }
                        else
                        {
                            Response.Write("<script> alert('Las contraseñas no coinciden')</script");
                            return;
                        }

                    }
                    else
                    {
                        Response.Write("<script> alert('Su contraseña es igual a la anterior o algun campo esta vacio intente de nuevo')</script");
                        return;
                    }
                }

                else
                {
                    Response.Write("<script> alert('Su contraseña es incorrecta, intente de nuevo')</script");
                    return;
                }


                Response.Write("<script> alert('Data Saved Successfully')</script");



            }
        }
  
    }


}
    





