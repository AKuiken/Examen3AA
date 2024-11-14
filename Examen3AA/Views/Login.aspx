<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Examen3AA.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login</h2>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:TextBox ID="txtNombreUsuario" runat="server" Placeholder="Usuario"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" Placeholder="Contraseña"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
