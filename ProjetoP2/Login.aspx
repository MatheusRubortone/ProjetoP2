<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" type="text/css" href="Content/estilo.css" />
    <link rel="stylesheet" type="text/css" href="Content/bootstrap.min.css" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/Validacao.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href='Content/fonte.css' rel='stylesheet'/>
    <title>LogIn</title>
</head>
<body>
     <div class="container-fluid" id="cont">
        <div class="row">
            <div class="col" id="col1"></div>
            <div class="col">
                <div id="formulario">
                    <h2 class="text-center" style="font-family: 'Montserrat'">Log-in</h2>
                    <form id="form1" runat="server" onclientclick="return ValidaCadastro()">
                        <div id="alertPlaceholder"></div>
                        <div> 
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email"></asp:TextBox>
                            <br />
                            <asp:TextBox ID="txtSenha" class="form-control" runat="server" placeholder="Senha"></asp:TextBox>
                            <br />
                            <asp:Button ID="btnEntrar" class="btn btn-primary btn-block" runat="server" Text="Entrar" OnClick="btnEntrar_Click1" />
                            <br />
                            <asp:LinkButton ID="btnEsqueci"  runat="server" OnClick="btnEsqueci_Click">Esqueci minha senha</asp:LinkButton>
                            <br />
                        </div>
                    </form>
                </div>
            </div>
            <div class="col" id="col2"></div>
        </div>
    </div>



</body>
</html>
