<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lista.aspx.cs" Inherits="Lista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 400px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            Resumo de Clientes Cadastrados no sistema<br class="auto-style1" />
            <asp:GridView ID="gdCliente" runat="server">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="codigo" DataNavigateUrlFormatString="CRUD.aspx?codigo={0}" HeaderText="Detalhe" Text="Selecionar" />
                </Columns>
            </asp:GridView>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Inserenovo" runat="server" OnClick="InsereNovo" Text="Inserir Novo Cliente" Width="155px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br class="auto-style1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Desconectar" Width="122px" />
&nbsp;&nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
