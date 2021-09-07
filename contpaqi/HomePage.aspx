<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="contpaqi.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="HomePage.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous"/>
    <title>Prueba </title>
</head>
  <body>


 <div align='center'>
      <br />
      <br />
     <h5 class="card-title text-center"> Catalogo de cuentas </h5>
      <br />
      <br />

<div class="caption">
<form id= "formHP" name="register" class="form-signin" runat="server">

                      <b><asp:Label ID="LabelOrganizationID" runat="server"    Text="ID de la organización "></asp:Label></b>
      <br />
     <br />
                     <b><asp:Label ID="Label15" runat="server"    Text="ID de la organización "></asp:Label></b>

     <br />
     <br />
                  
                    <div class ="row" style="margin-left:350px;">
                        
                     &nbsp;&nbsp; <b><asp:Label ID="Label12" runat="server"    Text="Filtrar por: "></asp:Label></b>&nbsp;&nbsp;
                      
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack ="true" class="form-control" style="width:180px;" OnSelectedIndexChanged ="ButtonOnClick">
         
                        <asp:ListItem Text ="Todas las cuentas" Value ="1"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas activas" Value ="2"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas inactivas" Value ="3"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas Asset" Value ="4"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas Liability" Value ="5"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas Equity" Value ="6"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas Income" Value ="7"></asp:ListItem>
                        <asp:ListItem Text ="Cuentas Expense" Value ="8"></asp:ListItem>     
                        </asp:DropDownList>
                        
                        
                     &nbsp;&nbsp; <b><asp:Label ID="Label13" runat="server"  Text="Ordenar por: "></asp:Label></b>&nbsp;&nbsp;
                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack ="true" class="form-control" style="width:180px;" OnSelectedIndexChanged ="ButtonOnClick">
                        <asp:ListItem Text ="Selecciona:" Value = ""></asp:ListItem>  
                        <asp:ListItem Text ="Nombre" Value ="1"></asp:ListItem>
                        <asp:ListItem Text ="Tipo" Value ="2"></asp:ListItem>
                        </asp:DropDownList>
                    
                            
     
                               
                           </div>

                    
         <br />
     <br />
                        <asp:Button ID="ButtonL" runat="server" Text="Sincronizar todas" class="btn btn-lg btn-danger btn-block text-uppercase" style="width:250px;" OnClick="ir" />
      <br />
     <br />
                       
                         <b><asp:Label ID="Label16" runat="server"    Text="Tabla de cuentas: "></asp:Label></b>
       <br />
     <br />
                       <asp:Repeater ID="rptCustomers" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered" cellspacing="0" rules="all" border="1">
                                <tr>
                                    <th  scope="col" style="width: 80px">
                                        account_id
                                    </th>
                                    <th scope="col" style="width: 120px">
                                        ccount_name
                                    </th>
                                    <th  scope="col" style="width: 100px">
                                        account_type
                                    </th>
                                    <th class="th" scope="col" style="width: 80px">
                                        is_user_created
                                    </th>
                                    <th scope="col" style="width: 120px">
                                        is_system_account
                                    </th>
                                    <th  scope="col" style="width: 100px">
                                        is_standalone_account
                                    </th>
                                    <th  scope="col" style="width: 80px">
                                        is_active
                                    </th>

                                    <th class="th" scope="col" style="width: 100px">
                                        is_involved_in_transaction
                                    </th>
                                    <th scope="col" style="width: 120px">
                                        parent_account_id 
                                    </th>
                                    <th class="th" scope="col" style="width: 100px">
                                        parent_account_name
                                    </th>

                                    <th scope="col" style="width: 120px">
                                        created_time
                                    </th>
                                    <th class="th" scope="col" style="width: 100px">
                                        last_modified_time
                                    </th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td >
  
                                    <a href='Transaccions.aspx?account_id=<%#DataBinder.Eval(Container.DataItem, "account_id") %>'>
                                        <asp:Label ID="lblNewsTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "account_id") %>'></asp:Label> </a>

                                </td>
                                <td >
                                    <asp:Label ID="lblccount_name" runat="server" Text='<%# Eval("account_name") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="lblaccount_type" runat="server" Text='<%# Eval("account_type") %>' />
                                </td>
                               <td >
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("is_user_created") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("is_system_account") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("is_standalone_account") %>' />
                                </td>
                               <td >
                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("is_active") %>' />
                                </td>

                                <td >
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("is_involved_in_transaction") %>' />
                                </td>
                               <td >
                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("parent_account_id") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("parent_account_name") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("created_time") %>' />
                                </td>
                                <td >
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("last_modified_time") %>' />
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
