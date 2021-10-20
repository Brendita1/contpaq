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
    public partial class WebForm4 : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {

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

            if(contraseñaSinVerificar.Length<7)
            {
                Response.Write("<script> alert('La contraseña debe tener una longitud de almenos 7 caracteres')</script");
                return false;
            }

            //si cumple con todo, regresa true
            return true;
        }
        public bool Valida_username(string username)
        {

            MySqlDataReader reader;
            string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none"; //Realizo la conexion
            MySqlConnection con = new MySqlConnection(mycon);
            con.Open();
            string sql = "SELECT ID_USER,User_Password,User_email,User_name FROM users WHERE User_name LIKE @username"; //Realizo la consulta  en mysql
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", username);  //Obtengo el valor que quiero
            reader = cmd.ExecuteReader();
            Users usr = new Users();

            while (reader.Read())
            {
                // Users usr = new Users();
                //users.User
                usr.ID = int.Parse(reader["ID_USER"].ToString()); //Acceso a mis valores deseados y los guardo en la variable tipo Users
            }
            if (usr.ID == 0)
            {

                return true; 
            }
            else
            {
                Response.Write("<script> alert('El nombre de usuario ya esta en uso')</script");
                return false; 
            }
        }
        public bool Valida_user(string eml)
        {

            MySqlDataReader reader;
            string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none"; //Realizo la conexion
            MySqlConnection con = new MySqlConnection(mycon);
            con.Open();
            string sql = "SELECT ID_USER,User_Password,User_email,User_name FROM users WHERE User_email LIKE @eml"; //Realizo la consulta  en mysql
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@eml", eml);  //Obtengo el valor que quiero
            reader = cmd.ExecuteReader();
            Users usr = new Users();

            while (reader.Read())
            {
                // Users usr = new Users();
                //users.User
                usr.ID = int.Parse(reader["ID_USER"].ToString()); //Acceso a mis valores deseados y los guardo en la variable tipo Users
            }
            if(usr.ID == 0)
            { 

                return true; //si el usuario no existe retorno true
            }
            else
            {
                Response.Write("<script> alert('El usuario ya esta registrado')</script");
                return false; // si es igual a 0 osea que no existe entonces retorno false
            }
        }
        public bool Verifica_ID_Orga(string ID_orga)
        {
            MySqlDataReader reader;
            string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none"; //Realizo la conexion
            MySqlConnection con = new MySqlConnection(mycon);
            con.Open();
            string sql = "SELECT ID_USER,User_Password,User_email,User_name, ID_organization FROM users WHERE ID_organization LIKE @ID_orga"; //Realizo la consulta  en mysql
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ID_orga", ID_orga);  //Obtengo el valor que quiero
            reader = cmd.ExecuteReader();
            Users usr = new Users();

            while (reader.Read())
            {
                // Users usr = new Users();
                //users.User
                usr.ID = int.Parse(reader["ID_USER"].ToString()); //Acceso a mis valores deseados y los guardo en la variable tipo Users
            }
            if (usr.ID == 0)
            {

                return true; //si el usuario no existe retorno true
            }
            else
            {
                Response.Write("<script> alert('El ID de la organizacion ya esta registrado')</script");
                return false; // si es igual a 0 osea que no existe entonces retorno false
            }
        }
        protected void ButtonR_Click(object sender, EventArgs e)
        {
            string name = Request.Form.Get("inputUsername");
            string eml = Request.Form.Get("inputEmail");
            string pass = Request.Form.Get("inputPassword");
            string ID_orga = Request.Form.Get("IDDeLaOrganizacion");
            
            if(string.IsNullOrEmpty(name)|| string.IsNullOrEmpty(eml)|| string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(ID_orga))
            {
                Response.Write("<script> alert('Uno o más campos estan vacios')</script");

            }
            else 
            {
                if (Valida_username(name) == true)    //nombre de usuario
                {
                    if (Valida_user(eml) == true)    //email
                    {

                        if (ContrasenaSegura(pass) == true)   //contraseña
                        {
                            if (Verifica_ID_Orga(ID_orga) == true)  // ID de la organizacion
                            {
                                //Session["ID_Orga"] = ID_orga;
                                //string mycon = "SERVER = 127.0.0.1; PORT=3306;DATABASE = demo2;UID=root; PASSWORDS=;";
                                string mycon = "server=localhost; port=3306; database=demo2; user=root; password= ; SslMode=none";

                                MySqlConnection con = new MySqlConnection(mycon);
                                try
                                {
                                    MySqlCommand cmd = new MySqlCommand("Add_users", con);
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@_User_Name", name);
                                    cmd.Parameters.AddWithValue("@_User_Password", pass);
                                    cmd.Parameters.AddWithValue("@_User_Email", eml);
                                    cmd.Parameters.AddWithValue("@_ID_Orga", ID_orga);
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
                                Response.Write("<script> alert('Data Saved Successfully')</script");
                            }
                        }


                    }


                }
            }
           
        } 

    }
}
