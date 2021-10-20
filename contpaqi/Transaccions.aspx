<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaccions.aspx.cs" Inherits="contpaqi.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="HomePage.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title>Prueba </title>
</head>

  <body>

      <form id= "formHP" name="register" class="form-signin" runat="server">
              <br />
      <br />
         <asp:Button ID="Button1" runat="server" Text="Volver"  class="btn btn-lg btn-danger btn-block text-uppercase" style="top: 90%;width:100px;" OnClick="volver" />


     <h5 class="card-title text-center"> Lista de transacciones </h5>
      <br />
      <br />
           <div align='center'>
          <div class="caption">
                      <b><asp:Label ID="LabelOrganizationID" runat="server"    Text="ID de la organización: "></asp:Label></b>
      <br />
                      <b><asp:Label ID="Label25" runat="server"    Text="ID de la organización "></asp:Label></b>

     <br />
     <br />

    <div  style="margin-right:400px;">
                        &nbsp;&nbsp; <b><asp:Label ID="Label22" runat="server"    Text="Filtrar por: "></asp:Label></b>&nbsp;&nbsp;
     <br /> <br />
                    <div class ="row" style="margin-left:200px;">
                        
                    &nbsp;&nbsp; <b><asp:Label ID="Label12" runat="server"    Text="Status: "></asp:Label></b>&nbsp;&nbsp;
                      
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack ="true" class="form-control" style="width:180px;" OnSelectedIndexChanged ="verLista">
                       
                        <asp:ListItem Text ="Todo" Value ="1"></asp:ListItem>
                        <asp:ListItem Text ="Sin categoria" Value ="2"></asp:ListItem>
                        <asp:ListItem Text ="Con categoria" Value ="3"></asp:ListItem>
                        <asp:ListItem Text ="Agregado manualmente" Value ="4"></asp:ListItem>
                        <asp:ListItem Text ="Excluido" Value ="5"></asp:ListItem>
                        <asp:ListItem Text ="Emparejado" Value ="6"></asp:ListItem>

                        </asp:DropDownList>
         
                  &nbsp;&nbsp;
                       <b><asp:Label ID="Label24" runat="server"    Text="Tipo: "></asp:Label></b>&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack ="true" class="form-control" style="width:180px;" OnSelectedIndexChanged ="verlista2">
                        <asp:ListItem Text ="Selecciona:" Value = ""></asp:ListItem>  
                        <asp:ListItem Text ="Deposito" Value ="1"></asp:ListItem>
                        <asp:ListItem Text ="Reembolso" Value ="2"></asp:ListItem>
                        <asp:ListItem Text ="Fondo de transferencia" Value ="3"></asp:ListItem>
                        <asp:ListItem Text ="Pago con tarjeta" Value ="4"></asp:ListItem>
                        <asp:ListItem Text ="Venta sin factura" Value ="5"></asp:ListItem>
                        <asp:ListItem Text ="Reembolso de gastos" Value ="6"></asp:ListItem>
                        <asp:ListItem Text ="Contribucion del propietario" Value ="7"></asp:ListItem>
                        <asp:ListItem Text ="Ingresos de interes" Value ="8"></asp:ListItem>
                        <asp:ListItem Text ="Otros ingresos" Value ="9"></asp:ListItem>
                        <asp:ListItem Text ="Giros de propietario" Value ="10"></asp:ListItem>
                        <asp:ListItem Text ="Devoluciones " Value ="11"></asp:ListItem>
                      </asp:DropDownList>
                    </div>
        </div>

                        <br />
    <div  style="margin-top:-111px;margin-left:500px;">
                          <b><asp:Label ID="Label23" runat="server"    Text="Rango de fecha: "></asp:Label></b>
                    <br /><br />
        </div>

                    <div class ="row" style="margin-left:760px;">
                    <asp:TextBox ID="TextBox2" runat="server" style="width:180px;" class="form-control inputs" placeholder="Fecha inicio"></asp:TextBox>
                       &nbsp;&nbsp;
                        <asp:TextBox ID="TextBox1" runat="server" style="width:180px;" class="form-control inputs" placeholder="Fecha fin"></asp:TextBox>
                        &nbsp;&nbsp;
       
         
        </div>
         <br />
     <br />
                    <asp:Button ID="ButtonL" runat="server" Text="Buscar"  class="btn btn-lg btn-danger btn-block text-uppercase" style="width:210px;" OnClick="verLista" />
         <br />
         <br />
              <br />
         <br />
                      <b><asp:Label ID="Label21" runat="server"    Text="Tabla de cuentas: "></asp:Label></b>
          <br />
     <br />
                       <asp:Repeater ID="rptCustomers" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered" cellspacing="0" rules="all" border="1">
                                <tr>
                                    <th  scope="col" style="width: 80px">
                                        transaction_id
                                    </th>
                                    <th scope="col" style="width: 120px">
                                        date
                                    </th>

                                    <th class="th" scope="col" style="width: 80px">
                                        transaction_type
                                    </th>
                                    <th scope="col" style="width: 120px">
                                        status
                                    </th>
                                    <th  scope="col" style="width: 80px">
                                        account_id
                                    </th>
                                    <th scope="col" style="width: 120px">
                                        account_name
                                    </th>
                                    <th class="th" scope="col" style="width: 100px">
                                        account_type
                                    </th>

                                    <th class="th" scope="col" style="width: 100px">
                                        customer_id
                                    </th>

                                    <th class="th" scope="col" style="width: 100px">
                                        currency_id
                                    </th>
                                    <th class="th" scope="col" style="width: 100px">
                                        currency_code
                                    </th>

                                    <th scope="col" style="width: 120px">
                                        debit_or_credit
                                    </th>
                                    <th class="th" scope="col" style="width: 100px">
                                        offset_account_name
                                    </th>
 
                                    <th class="th" scope="col" style="width: 80px">
                                        reference_number
                                    </th>
  
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td >
                                    <asp:Label ID="lblaccount_id" runat="server" Text='<%# Eval("transaction_id") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="lblccount_name" runat="server" Text='<%# Eval("date") %>' />
                                </td>
                           
 
                               <td >
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("transaction_type") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("status") %>' />
                                </td>

                               <td >
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("account_id") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("account_name") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("account_type") %>' />
                                </td>
 
                                <td >
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("customer_id") %>' />
                                </td>

                                <td >
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("currency_id") %>' />
                                </td>
                               <td >
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("currency_code") %>' />
                                </td>

                                <td >
                                    <asp:Label ID="Label14" runat="server" Text='<%# Eval("debit_or_credit") %>' />
                                </td>
                               <td >
                                    <asp:Label ID="Label15" runat="server" Text='<%# Eval("offset_account_name") %>' />
                                </td>

                                <td >
                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("reference_number") %>' />
                                </td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>



</form>
     </div>
     </div>

</body>

</html>
