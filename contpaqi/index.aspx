<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="contpaqi.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="HomePage.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title>Home Page </title>
</head>
   <script type="text/javascript">
       setTimeout(function () {
           //location.redload();
       }, 2000);
       function ShowP() {
           $pass = document.getElementById("inputPassword");
           $acc = document.getElementById("accion");
           if ($pass.type == "password") {
               $pass.type = "text";
               $acc.value = "Ocultar"
           }
           else {
               $pass.type = "password";
               $acc.value = "Mostrar"
           }

       }
   </script>
   <script type="text/javascript">
       setTimeout(function () {
           //location.redload();
       }, 2000);
       function ShowP1() {
           $pass = document.getElementById("Password1");
           $acc = document.getElementById("Button4");
           if ($pass.type == "password") {
               $pass.type = "text";
               $acc.value = "Ocultar"
           }
           else {
               $pass.type = "password";
               $acc.value = "Mostrar"
           }

       }
   </script>
   <script type="text/javascript">
       setTimeout(function () {
           //location.redload();
       }, 2000);
       function ShowP2() {
           $pass = document.getElementById("Password2");
           $acc = document.getElementById("Button5");
           if ($pass.type == "password") {
               $pass.type = "text";
               $acc.value = "Ocultar"
           }
           else {
               $pass.type = "password";
               $acc.value = "Mostrar"
           }

       }
   </script>
<body>
 
    <br /><br />
                <h5 class="card-title text-center"> Bienvenido a mi aplicacion! </h5>
                <form id= "form1" name="register" class="form-signin" runat="server">
                    <div align='center'>
                        <br />
      
                        <img src="User.png" width="60" height="60" alt="logo"/><br /><br />
                   <b>Correo: </b> <asp:Label ID="Correoid" runat="server"></asp:Label> <br />
                   <b>Nombre de usuario: </b> <asp:Label ID="Usernameid" runat="server"></asp:Label> <br />
                   <b>Numero de identificador: </b> <asp:Label ID="Identificadorid" runat="server"></asp:Label> <br />
                   <b>Contraseña: </b> <asp:Label ID="Label3" runat="server"></asp:Label> <br /><br />
      
                    <asp:Button ID="Button3" runat="server" Text="Mostrar"  class="btn btn-lg btn-danger btn-block text-uppercase" style="width:120px; height:50px;" onclick="view_pass"  />

                  <br /><br />
                  


        <div class="container-fluid login fontcolor" style="margin-top: -1%;">

    <div class="container" style="margin-top: -1%;" >
        <div class="row">
          <div class="col-sm-9 col-md-7 col-lg-5 mx-auto ">
            <div class="card signin my-2">
              <div class="card-body ">

                <a class="navbar-brand" style="margin-left: 10%; margin-right: 10%; margin-bottom: 1%;">
                </a>

                    
                    <div class="form-label-group">
                     <b>Actualiza tu contraseña: </b>  <br /><br />
                    <asp:Label ID="Labelpass" runat="server" for="inputPassword" Text="Contraseña actual "></asp:Label>
                    <input id="inputPassword" runat="server" type="password" name="inputPassword" class="form-control inputs" placeholder="Contraseña actual" />
                    <input id="accion" runat="server"  type ="button" value="Mostrar" class="dashicons dashicons-visibility"  onclick="ShowP()"   />

                        <br /> <br />
                    <asp:Label ID="Label2" runat="server" for="inputPassword" Text="Contraseña nueva "></asp:Label>
                    <input id="Password1" runat="server" type="password" name="inputPassword" class="form-control inputs" placeholder="Contraseña nueva" />
                     <input id="Button4" runat="server"  type ="button" value="Mostrar" class="dashicons dashicons-visibility"  onclick="ShowP1()"   />
                        <br /> <br />
                    <asp:Label ID="Label5" runat="server" for="inputPassword" Text="Confirmar contraseña"></asp:Label>
                    <input id="Password2" runat="server" type="password" name="inputPassword" class="form-control inputs" placeholder="Confirmar contraseña" />
                     <input id="Button5" runat="server"  type ="button" value="Mostrar" class="dashicons dashicons-visibility"  onclick="ShowP2()"   />
                        <br /> <br />
                    <asp:Button ID="Button1" runat="server" Text="Actualizar" class="btn btn-lg btn-danger btn-block text-uppercase" style="margin-bottom: 10px;" onclick="Update_pass" />
                    </div>
                    </div>
                    </div>
                   <br />  
                  <b>&nbsp;&nbsp;<asp:Label ID="Label22" runat="server" align="center" Text="Haz click para vincular tu cuenta "></asp:Label></b>      <br /> <br />                 
                   &nbsp;&nbsp;<asp:Label ID="Label4" runat="server" align="center" Text=" &nbsp; &nbsp;Al hacer click en este boton estas dando autorizacion a Zoho para vincular tu cuenta "></asp:Label>    <br />   <br />                   

              <asp:Button ID="Button2" runat="server" Text="Vincular cuenta" class="btn btn-lg btn-danger btn-block text-uppercase" style="margin-bottom: 10px;" Onclick="Button1_Click" />
 
   
              </div>   
              </div> <br /> 

            </div>
          </div>
         </form>

        
        
</body>
</html>