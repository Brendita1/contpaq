using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace contpaqi
{


    public class Users
    {
        int id;
        string email, password, username,id_organization,user_token_access,user_token_refresh;
        
        public string User { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int ID { get => id; set => id = value; }
        public string ID_organization { get => id_organization; set => id_organization = value;}
        public string User_token_access { get => user_token_access; set => user_token_access = value; }
        public string User_token_refresh { get => user_token_refresh; set => user_token_refresh = value; }


    }
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 

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

        public string Logeo(string eml, string pass)
        {
            string respuesta = "";
            Users datosuser = null;
            if (string.IsNullOrEmpty(eml) || string.IsNullOrEmpty(pass)) //Si esta vacio entonces dara error
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosuser = LogForEml(eml);      //Hacer la consulta por Email
                if (datosuser is null)
                {
                    respuesta = "El correo no esta registrado";  //Si el correo no es encontrado dará error
                }
                else
                {
                    if (datosuser.Password != pass)
                    {
                        respuesta = "El usuario y/o contraseña no coinciden"; //Si la contraseña no coicide dará error
                    }
                    else
                    {
                        return respuesta="Es correcto";
                    }
                }
            }
            return respuesta; //Si marca algun error se retornara y si no retornara la informacion del LogForEml

        }

  

        protected void Button1_Click(object sender, EventArgs e)
        {
            string eml = Request.Form.Get("inputEmail");
            string pass = Request.Form.Get("inputPassword");      //Leemos los campos ingresados
            Users datosuser = null;
            datosuser= LogForEml(eml);
            //string user_temp = datosuser.User;
            try
            {
                string respuesta = Logeo(eml, pass);              // Obtenemos la informacion de inicio de sesion 
                if (respuesta is null)
                {
                    Response.Write("<script> alert('Error')</script");  // Si la variable es nula es porque le falta un dato
                }
                else
                {
                    if(respuesta == "Es correcto")
                    {
                        Response.Write("<script> alert('Se inicio sesion')</script"); //Si la variable esta completa y correcta entonces inicia sesion
                        //Response.Redirect("HomePage.aspx", false);
                        Session["email"] = datosuser.Email;
                        Session["id"] = datosuser.ID;
                        Session["user"] = datosuser.User;
                        Session["pass"] = datosuser.Password;
                        Session["ID_orga"] = datosuser.ID_organization;

                        if ((datosuser.User_token_access == "") && (datosuser.User_token_refresh == ""))
                        {

                            Response.Redirect("index.aspx");
                        }
                        else
                        {
                            Session["refresh_token"] = datosuser.User_token_refresh;
                            Session["access_token"] = datosuser.User_token_access;

                            Response.Redirect("https://accounts.zoho.com/oauth/v2/auth?scope=ZohoInventory.FullAccess.all,ZohoBooks.fullAccess.all&client_id=1000.CL60GXGKKU9VIY49JPBC94II8KX5FV&state=testing&response_type=code&redirect_uri=http://localhost:61593/index.aspx&access_type=offline&prompt=consent");
                        }


                    }
                    else
                    {
                        Response.Write("<script> alert('Es incorrecto')</script"); 

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }


    }
}