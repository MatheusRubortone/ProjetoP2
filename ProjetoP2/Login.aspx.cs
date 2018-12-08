using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) Session.Abandon();
    }

    protected void btnEsqueci_Click(object sender, EventArgs e)
    {
        cls_ConectaDB conn = new cls_ConectaDB();
        SqlDataReader dr = conn.Dr_SQL("select senha from pw.dbo.T_Login where email = '" + txtEmail.Text + "'");

        string senha;
        if (dr.Read())
        {
            senha = dr["senha"].ToString();

            MailAddress de = new MailAddress("projetop22018@outlook.com");
            MailAddress para = new MailAddress(txtEmail.Text);

            MailMessage email = new MailMessage();
            email.From = de;
            email.To.Add(para);
            email.Subject = "Solicitação de recover de senha.";
            email.Body = "Prezado, conforme solicitado pelo site, segue a sua senhha atual para acesso ao sistema: <br>" + senha;
            email.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com");
            try
            {
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new
                    NetworkCredential("projetop22018@outlook.com", "Web2018_");
                smtp.Send(email);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Um E-mail foi enviado com as informações de sua senha.');</script>");
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Ocorreu um erro no envio do E-mail, tente novamente mais tarde.');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('E-mail não cadastrado no sistema');</script>");
        }
        conn.Close();
    }

    public bool Acesso (string email, string senha)
    {
        try
        {
            cls_ConectaDB conn = new cls_ConectaDB();
            SqlDataReader dr = conn.Dr_SQL("SELECT email, senha from T_Login where email = '" + email + "' and senha = '" + senha + "'");

            if (dr.Read())
            {
                Session["email"] = dr["email"].ToString();
                Session["senha"] = dr["senha"].ToString();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }
        catch
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Houve falha na conexão com o banco de dados, favor entra em contato com o administrador do sistema.');</script>");
            return false;
        }
        
    }



    protected void btnEntrar_Click1(object sender, EventArgs e)
    {
        bool result;
        result = Acesso(txtEmail.Text, txtSenha.Text);

        if (result) Response.Redirect("Lista.aspx");
        else Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('As credenciais não constam no banco de dados');</script>");
    }
}