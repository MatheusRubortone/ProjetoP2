<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CRUD.aspx.cs" Inherits="CRUD" %>

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
    <title>Cadastrar Cliente</title>
</head>
<body> 
        <div class="container-fluid">
            <div class="col-9" id="maincol">
                <div id="titulopag">
                    <h1 style="font-family: 'Montserrat'">Cadastrar Cliente</h1>
                </div>
                <div id="conteudo">
                    <div id="areaformulario">
                    <form id="form1" runat="server">
                            <div>
                                <br />
                                <asp:TextBox ID="txtCodigo" runat="server" Width="158px" class="form-control" placeholder="Código"></asp:TextBox>
                                &nbsp;
                                <br />
                                <asp:TextBox ID="txtNome" runat="server" Width="220px" class="form-control" placeholder="Nome"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtEmail" runat="server" Width="311px" class="form-control" placeholder="Email"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtTelefone" runat="server" Width="193px" class="form-control" placeholder="Telefone"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtCpf" runat="server" Width="191px" class="form-control" placeholder="CPF"></asp:TextBox>
                                <br />
                                <asp:TextBox ID="txtEndereco" runat="server" Width="459px" class="form-control" placeholder="Endereço"></asp:TextBox>
                                <br />
                                <br />
                                Ativo:
                                <asp:RadioButton ID="rdnAtivo" GroupName="Status" runat="server" Text="Sim" />
                    &nbsp;
                                <asp:RadioButton ID="rdnInativo" GroupName="Status" runat="server" Text="Não" />
                                <br />
                                <br />
                                <asp:Label ID="msgErro" runat="server" Text="Label" ForeColor="red"></asp:Label>
                                <br />
                                <br />
                                <asp:Button ID="btnInserir" runat="server" OnClick="btnInserir_Click" Text="Inserir Novo Cliente" Width="179px" style="background-color:#b30000;border: 0;" class="btn btn-primary botao" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnAtualiza" runat="server" OnClick="btnAtualiza_Click" Text="Atualizar Cliente" class="btn btn-primary botao" style="background-color:#b30000;border: 0;"/>
                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" Text="Excluir Cliente" Width="177px" class="btn btn-primary botao" style="background-color:#b30000;border: 0;"/>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnVoltaLista" runat="server" OnClick="btnVoltaLista_Click" Text="Pesquisar Por Outro Cliente" Width="215px" class="btn btn-primary botao" style="background-color:#b30000;border: 0;"/>
                    &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Desconectar" class="btn btn-primary botao" style="background-color:#b30000;border: 0;"/>
                                <br />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <div class="col hide"></div>
        </div>
    </div> 
        

</body>
</html>
