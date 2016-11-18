<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginRegistrar.aspx.cs" Inherits="redSocialProgra4.vistas.loginRegistrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="../css/portada.css" />
</head>
<body>
    <%--<form id="form1" runat="server">
    <div>
      <div>correo: <asp:TextBox id="TB6" runat="server" ></asp:TextBox>  clave: <asp:TextBox id="TB7" runat="server" ></asp:TextBox>   <asp:Button ID="Button2" runat="server" Text="Entrar" PostBackUrl="../validadores/validaLogin.aspx" /><br /> <br /></div>  
        <div>  
            <table border='1px'>
               <tr><td>Correo: </td><td> <asp:TextBox id="TB1" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Nombre        : </td><td> <asp:TextBox id="TB2" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Apellido      : </td><td> <asp:TextBox id="TB3" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Clave         : </td><td> <asp:TextBox id="TB4" runat="server" ></asp:TextBox><br /></td></tr> 
                <tr><td>Repetir Clave : </td><td> <asp:TextBox id="TB5" runat="server" ></asp:TextBox><br /></td></tr> 
               <tr><td><asp:Button ID="Button1" runat="server" Text="Registrar" PostBackUrl="../validadores/validaRegistrar.aspx" /></td></tr> 

                </table>
        </div>  
    </div>
    </form>--%>
    <form id="form1" runat="server">
    <div>
        <div class="header">
                 
           
                <div class="header2" >
                 <table border="0px">
                       <tr>
                            <td>Correo</td> 
                            <td>Contraseña </td>
                             <td></td>
                       </tr> 
                       <tr>
                            <td><asp:TextBox id="TB6" runat="server" ></asp:TextBox></td>
                            <td><asp:TextBox id="TB7" runat="server" ></asp:TextBox>   </td>  
                           <td><asp:Button class="BT2" runat="server" Text="Iniciar Sesion" PostBackUrl="../validadores/validaLogin.aspx" /></td>                     
                       </tr>
                       
                   </table>
                           
                  </div>
            </div>  
         
           
        
        <div class="body">   
            <div class="body1">
                <img src="../img/verdefb.png" alt="Alternate Text" />


            </div>
             
            <div class="body2">
                <table class="tablita" border="0px">
                    <tr><td colspan="2"><div class="titulo">INGRESE SUS DATOS PARA REGISTRARSE</div></td></tr>
                     <tr><td   colspan="2"   >
                            <asp:TextBox id="TB1" runat="server"  width="500px" padding="50px"     aling="center" placeholder="Correo"  ></asp:TextBox></td></tr>
                     <tr><td><asp:TextBox id="TB2" runat="server"   width="239px"  aling="center" placeholder="Nombre" font-weight="bold"></asp:TextBox></td>
                         <td colspan="2"> <asp:TextBox id="TB3" runat="server"  width="239px" aling="center"  placeholder="Apellido"   font-weight="bold"></asp:TextBox></td></tr> 
                     <tr><td colspan="2"><asp:TextBox id="TB4" runat="server"   width="500px" aling="center"  placeholder="Clave"   font-weight="bold"></asp:TextBox><br /></td></tr> 
                     <tr><td colspan="2"><asp:TextBox id="TB5" runat="server"   width="500px" aling="center"  placeholder="Repetir Clave"   font-weight="bold" border-radius="3px"></asp:TextBox></td></tr> 
                     <tr><td><asp:Button class="_6j mvm _6wk _6wl _58mi _3ma _6o _6v" runat="server" Text="Registrar" PostBackUrl="../validadores/validaRegistrar.aspx" /></td></tr> 
 
                </table>
           </div>
        </div>  
           
        <div class="footer">

            Creadores: <br>
            Juan Yañez - Ricardo Palma - Kattia Vial

        </div>
       
    </div>
    </form>
</body>
</html>
