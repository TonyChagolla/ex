<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebAppPaises.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel='stylesheet' href='../Content/bootstrap.min.css'/>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <br />
            <asp:Button ID="btnGetCiudades" runat="server" Text="Mostrar ciudades" />
            <br />
            <br />
            Buscar por nombre <asp:TextBox ID="tbxBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" Height="29px" />
            <br />
            <br />
            ID de Ciudad
            <asp:TextBox ID="tbxActID" runat="server" Width="46px"></asp:TextBox>
&nbsp;Nuevo nombre Ciudad
            <asp:TextBox ID="tbxActualizar" runat="server"></asp:TextBox>
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
            <br />
            <br />
            <div><div id="pais" style="display:inline-block"></div><div id="estado" style="display:inline-block"></div>&nbsp;Nombre Ciudad <asp:TextBox ID="tbxInsertar" runat="server" style="display:inline-block"></asp:TextBox><asp:Button ID="btnInsertar" runat="server" Text="Insertar" style="display:inline-block"/></div>
            
            <br />
            Eliminar por ID<asp:TextBox ID="tbxEliminar" runat="server"></asp:TextBox>
            &nbsp;
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
            <br />
            <div id="Grid"></div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvCiudad" runat="server">
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../scripts/jquery-3.4.1.min.js"></script>
    <script src="../scripts/functions.js"></script>
     <script src="../scripts/bootstrap.min.js"></script>
</body>
</html>
