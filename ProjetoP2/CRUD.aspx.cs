using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CRUD : System.Web.UI.Page
{
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
        if(txtNome.Text == "" || txtCpf.Text == "" || txtEmail.Text == "" || txtTelefone.Text == "")
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Certifique que todos os campos estãodevidamente preenchidos!');</script>");
       else  if( rdnAtivo.Checked == false && rdnInativo.Checked == false)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Certifique que todos os campos estãodevidamente preenchidos!');</script>");
        else
        {
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
        if (txtCodigo.Text == "" || txtNome.Text == "" || txtCpf.Text == "" || txtEmail.Text == "" || txtTelefone.Text == "")
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Certifique que todos os campos estãodevidamente preenchidos!');</script>");
        else if (rdnAtivo.Checked == false && rdnInativo.Checked == false)
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Certifique que todos os campos estãodevidamente preenchidos!');</script>");
        else
        {
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