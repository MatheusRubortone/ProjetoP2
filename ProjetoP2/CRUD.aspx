<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD.aspx.cs" Inherits="CRUD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Informações Gerais do Cliente:<br />
            <br />
            Código:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCodigo" runat="server" Width="58px"></asp:TextBox>
            &nbsp;
            <br />
            <br />
            Nome:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNome" runat="server" Width="220px"></asp:TextBox>
            <br />
            <br />
&nbsp;E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail" runat="server" Width="311px"></asp:TextBox>
            <br />
            <br />
            Telefone:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTelefone" runat="server" Width="193px"></asp:TextBox>
            <br />
            <br />
            CPF:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCpf" runat="server" Width="191px"></asp:TextBox>
            <br />
            <br />
            Endereço:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEndereco" runat="server" Width="459px"></asp:TextBox>
            <br />
            <br />
            Ativo:
            <asp:RadioButton ID="rdnAtivo" GroupName="Status" runat="server" Text="Sim" />
&nbsp;
            <asp:RadioButton ID="rdnInativo" GroupName="Status" runat="server" Text="Não" />
            <br />
            <br />
            <asp:Button ID="btnInserir" runat="server" OnClick="btnInserir_Click" Text="Inserir Novo Cliente" Width="159px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAtualiza" runat="server" OnClick="btnAtualiza_Click" Text="Atualizar Cliente" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir Cliente" Width="177px" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnVoltaLista" runat="server" OnClick="btnVoltaLista_Click" Text="Pesquisar Por Outro Cliente" Width="215px" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Desconectar" />
            <br />
        </div>
    </form>
</body>
</html>
