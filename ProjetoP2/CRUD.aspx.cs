using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class CRUD : System.Web.UI.Page
{
    string msg = " ";
    public static bool validaCPF(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");
        if (cpf.Length != 11)
            return false;
        tempCpf = cpf.Substring(0, 9);
        soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = resto.ToString();
        tempCpf = tempCpf + digito;
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;
        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }

    public bool ValidarEmail(String email)
    {
        bool emailValido = false;

        string emailRegex = string.Format("{0}{1}",
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))",
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

        try
        {
            emailValido = Regex.IsMatch(
                email,
                emailRegex);
        }
        catch (RegexMatchTimeoutException)
        {
            emailValido = false;
        }

        return emailValido;
    }

    public bool Validar(string nome, string cpf, string email, string telefone)
    {
        bool valido = true;
        msg = "";

        if(nome == ""){
            msg = "Nome inválido" + "<br />";
            valido = false;
        }

        if (!validaCPF(cpf)) {
            msg = msg + "CPF inválido" + "<br />";
            valido = false;
        }

        if (!ValidarEmail(email)) {
            msg = msg + "Email inválido" + "<br />";
            valido = false;
        }

        if (telefone == ""){
            msg = msg + "Telefone inválido" + "<br />";
            valido = false;
        }

        if(rdnAtivo.Checked == false && rdnInativo.Checked == false)
        {
            msg = msg + "Escolha um Status";
            valido = false;
        }

        return valido;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["email"] == null || Session["senha"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            Autenticacao();
        
            if (!IsPostBack)
            {
                if (Convert.ToString(Request["codigo"]) != "")
                {
                    cls_ConectaDB conn = new cls_ConectaDB();
                    SqlDataReader dr = conn.Dr_SQL("select codigo, nome, email, telefone, cpf, endereco, ativo from T_Cliente where codigo = '" + Convert.ToString(Request["codigo"]) + "'");

                    if(dr.Read())
                    {
                       txtCodigo.Text =  dr["codigo"].ToString();
                       txtNome.Text = dr["nome"].ToString();
                       txtEmail.Text = dr["email"].ToString();
                       txtTelefone.Text = dr["telefone"].ToString();
                       txtCpf.Text = dr["cpf"].ToString();
                       txtEndereco.Text = dr["endereco"].ToString();
                        if (Convert.ToString(dr["ativo"]) == "A") rdnAtivo.Checked = true;
                        else rdnInativo.Checked = true;
                    }
                }
            }
        }
    }

    private void Autenticacao()
    {
        cls_ConectaDB conn = new cls_ConectaDB();
        SqlDataReader dr = conn.Dr_SQL("SELECT email, senha from T_Login where email = '" + Session["email"].ToString() + "' and senha = '" + Session["senha"].ToString() + "'");

        if (!dr.Read()) 
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Houve uma falha na autenticação de suas credenciais, favor tentar realizar o login novamente.');</script>");
            Response.Redirect("Login.aspx");
        }
        conn.Close();
    }

    protected void btnInserir_Click(object sender, EventArgs e)
    {
        if(!Validar(txtNome.Text, txtCpf.Text, txtEmail.Text, txtTelefone.Text))
        {
            msgErro.Text = msg;
        }
        else
        {
            msgErro.Text = "";
            string status;
            if (rdnAtivo.Checked == true) status = "A";
            else status = "I";
            try
            {
                cls_ConectaDB conn = new cls_ConectaDB();
                conn.ExecNonQuery("insert into PW.DBO.T_Cliente values ('" + txtNome.Text + "', '" + txtEmail.Text + "', '" + txtTelefone.Text + "', '" + txtCpf.Text + "', '" + txtEndereco.Text + "', '" + status + "')");
                conn.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Cliente inserido com sucesso!');</script>");
                //txtCodigo.Text = ""; txtNome.Text = ""; txtEmail.Text = ""; txtTelefone.Text = ""; txtCpf.Text = ""; txtEndereco.Text = ""; rdnAtivo.Checked = false; rdnInativo.Checked = false;
                // Response.Redirect("Lista.aspx");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ocorreu um erro ao tentar inserir um novo cliente.');</script>");
            }
        } 
    }

    protected void btnAtualiza_Click(object sender, EventArgs e)
    {
        if (!Validar(txtNome.Text, txtCpf.Text, txtEmail.Text, txtTelefone.Text))
        {
            msgErro.Text = msg;
        }
        else
        {
            msgErro.Text = "";
            string status;
            if (rdnAtivo.Checked == true) status = "A";
            else status = "I";
            try
            {
                cls_ConectaDB conn = new cls_ConectaDB();
                conn.ExecNonQuery("update PW.DBO.T_Cliente set nome = '" + txtNome.Text + "', email = '" + txtEmail.Text + "', telefone = '" + txtTelefone.Text + "', cpf = '" + txtCpf.Text + "', endereco = '" + txtEndereco.Text + "', ativo = '" + status + "' where codigo = " + txtCodigo.Text);
                conn.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Cliente atualizado com sucesso!');</script>");
                //txtCodigo.Text = ""; txtNome.Text = ""; txtEmail.Text = ""; txtTelefone.Text = ""; txtCpf.Text = ""; txtEndereco.Text = ""; rdnAtivo.Checked = false; rdnInativo.Checked = false;
                Response.Redirect("Lista.aspx");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ocorreu um erro ao tentar inserir um novo cliente.');</script>");
            }
        }
       
    }

    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        if(txtCodigo.Text == "") Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('É necessário selecionar um código de cliente para prosseguir com a exclusão');</script>");
        else
        {
            try
            {
                cls_ConectaDB conn = new cls_ConectaDB();
                conn.ExecNonQuery("delete from PW.DBO.T_Cliente where codigo = " + txtCodigo.Text);
                conn.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Cliente excluído com sucesso!');</script>");
                //txtCodigo.Text = ""; txtNome.Text = ""; txtEmail.Text = ""; txtTelefone.Text = ""; txtCpf.Text = ""; txtEndereco.Text = ""; rdnAtivo.Checked = false; rdnInativo.Checked = false;
                Response.Redirect("Lista.aspx");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Erro ao excluir cliente selecionado');</script>");
            }

        }
    }
    protected void btnVoltaLista_Click(object sender, EventArgs e)
    {
        Response.Redirect("lista.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }
}