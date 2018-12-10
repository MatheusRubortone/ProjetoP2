<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Lista.aspx.cs" Inherits="Lista" %>

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
    <title>Lista</title>
   
</head>
<body>
    <div class="container-fluid">
        <div class="row">
            <div class="col-9" id="maincol">

                <div id="titulopag">
                        <h1 style="font-family: 'Montserrat'">Lista de Clientes</h1>                
                </div>    
                <div id="conteudo">
                    <div id="tabela">
                        <form id="form1" runat="server">
                            <div class="auto-style1">
                                <br />  
                                <asp:GridView ID="gdCliente" runat="server" UseAccessibleHeader="true" CssClass="table table-striped table-hover">
                                <Columns>                          
                                    <asp:HyperLinkField DataNavigateUrlFields="codigo" DataNavigateUrlFormatString="CRUD.aspx?codigo={0}" HeaderText="Detalhe" Text="Descrição" />
                                </Columns>
                                </asp:GridView>
                                <asp:Button ID="Inserenovo" runat="server" OnClick="InsereNovo" class="btn btn-primary" Text="Inserir Novo Cliente" Width="170px" style="background-color:#b30000;border: 0;"/>
                                <br />
                                <br/>
                                <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" class="btn btn-primary" Text="Desconectar" Width="122px" style="background-color:#b30000; border: 0;"/>
                            </div>
                        </form> 
                    </div>
                </div>
            </div>      
        </div>
    </div>
</body>
</html>
