<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Examen3AA.Views.Agregar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Videojuego</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Agregar Nuevo Videojuego</h2>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
            <br />
            <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtCantidad" runat="server" Placeholder="Cantidad"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPrecio" runat="server" Placeholder="Precio"></asp:TextBox>
            <br />
            <asp:FileUpload ID="fileImagen" runat="server" />
            <br />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
        </div>
    </form>
</body>
</html>

