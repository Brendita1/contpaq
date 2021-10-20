<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="contpaqi.WebForm4" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="Login.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title>Registro </title>
   
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
<body>
        <div class="container-fluid login fontcolor" style="margin-top: 8%;">
            <div style="text-align: left;">
            
                <a href="Login.aspx"><input class="btn btn-lg btn-danger btn-block text-uppercase" style="top: 90%;width:100px;"type="button" value="Volver"/></a>
                 </div>
    <div class="container" style="margin-top: 3%;" >
        <div class="row">
          <div class="col-sm-9 col-md-7 col-lg-5 mx-auto ">
            <div class="card signin my-2">
              <div class="card-body ">
                <a class="navbar-brand" style="margin-left: 25%; margin-right: 25%; margin-bottom: 5%;">
                  <img src="User.png" width="200" height="200" alt="logo"/>
                </a>
                <h5 class="card-title text-center"> Registro de Usuarios </h5>
                <form id= "form1" name="register" class="form-signin" runat="server">
   
                  <div class="form-label-group">
                    <asp:Label ID="Labelcorreo" runat="server"  for="inputEmail"  Text="Correo electronico "></asp:Label>
                    <input id="inputEmail" runat="server" type="email" name="inputEmail" class="form-control inputs" placeholder="Correo Electrónico" />
                  </div>      
                  
                   <div class="form-label-group">
                    <asp:Label ID="Labelname" runat="server" for="inputUsername"  Text="Nombre de usuario "></asp:Label>
                    <input id="inputUsername" runat="server" type="text" name="inputUsername" class="form-control inputs" placeholder="Username" />
                  </div>      
                  
                  <div class="form-label-group">
                    <asp:Label ID="Labelpass" runat="server" for="inputPassword" Text="Contraseña "></asp:Label>
                    <input id="inputPassword" runat="server" type="password" name="inputPassword" class="form-control inputs" placeholder="Contraseña" />
                    <input id="accion" runat="server"  type ="button" value="Mostrar" class="dashicons dashicons-visibility"  onclick="ShowP()"   />
 
                      </div>    
                    <div class="form-label-group">
                    <asp:Label ID="LabelIDOrga" runat="server" for="IdOrganizacion"  Text="IDDeLaOrganizacion"></asp:Label>
                    <input id="IDDeLaOrganizacion" runat="server" type="text" name="IDDeLaOrganizacion" class="form-control inputs" placeholder="ID De La Organizacion" />
                  </div>      
    
                  <hr class="my-4"/>
                  <asp:Button ID="ButtonR" runat="server" Text="Registrar Usuario" class="btn btn-lg btn-danger btn-block text-uppercase" style="margin-bottom: 40px;" OnClick="ButtonR_Click"/>

                </form>


              </div>
            </div>
          </div>
        </div>
      </div>
       

</body>
</html>
