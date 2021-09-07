<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="contpaqi.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server"/>
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

<div class="backgroundstyle">


          <div class="col-sm-12 col-md-7 col-lg-3 mx-auto">

              <div class="card card-signin" style="border: none!important; background-color: transparent;">
                <div class="card-body" >
                  <img src="User.png" class="mx-auto d-block" width="200" height="200" alt="loginlogo"/>
                  <h5 class="card-title text-center"> Iniciar Sesión </h5>
      
                  <form id= "form2" runat="server" class="form-signin">
                  
                    <div class="form-label-group">
                       <asp:Label ID="Labelcorreo" runat="server"  for="inputEmail"  Text="Correo electronico "></asp:Label>
                       <input id="inputEmail" runat="server" type="email" name="inputEmail" class="form-control inputs" placeholder="Correo Electrónico" />
                    </div>
                   
                    <div class="form-label-group">
                    <asp:Label ID="Labelpass" runat="server" for="inputPassword" Text="Contraseña "></asp:Label>
                    <input id="inputPassword" runat="server" type="password" name="inputPassword" class="form-control inputs" placeholder="Contraseña" />
                    <input id="accion" runat="server"  type ="button" value="Mostrar" class="dashicons dashicons-visibility"  onclick="ShowP()"   />

                    </div>
                     <br /> 
                    <div class="d-flex justify-content-center">
                        <br /> 
                            <a style="color: #acacad;" href="Register.aspx">Registrate aqui</a>
                            
                    </div>
                     <br /> 
                      <asp:Button ID="ButtonL" runat="server" Text="Iniciar Sesion" class="btn btn-lg btn-danger btn-block text-uppercase" style="margin-bottom: 40px;" OnClick="Button1_Click" />
      
                  </form>
      
                </div>
              </div>
          </div>
        </div>
   
</body>
</html>
