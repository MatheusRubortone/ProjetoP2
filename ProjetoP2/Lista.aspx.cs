using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Lista : System.Web.UI.Page
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
            PopulaGrid();
        }
    }

    public void Autenticacao()
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

    public void PopulaGrid()
    {
        cls_ConectaDB conn = new cls_ConectaDB();
        DataTable dt = conn.Dt_SQL("SELECT CODIGO, nome FROM T_Cliente ORDER BY nome");

        gdCliente.DataSource = dt;
        gdCliente.DataBind();

        conn.Close();
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("login.aspx");
    }


    protected void InsereNovo(object sender, EventArgs e)
    {
        Response.Redirect("CRUD.aspx");
    }
}