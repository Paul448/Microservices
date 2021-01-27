using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginService.Controllers;

namespace LoginService.Views
{
    public partial class Login : System.Web.UI.Page
    {
        private Controller _Verwalter;

        public Controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Verwalter = Global.Verwalter;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Verwalter.Login(txtUID.Text, txtPW.Text);
            if(Verwalter.CheckAuth() == true)
            {
                Response.Redirect("https://localhost:44338/Views/GateHome");
            }
            else
            {
                CheckLogin();
            }
        }

        protected void CheckAuth_Click(object sender, EventArgs e)
        {
            CheckLogin();
        }

        public void CheckLogin()
        {
            string var1 = this.Verwalter.AuthID;
            if (this.Verwalter.AuthID == "-1")
            {
                lblLoginInfo.Text = "Einloggen Fehlgeschlagen";
            }
            else
            {
                if(this.Verwalter.CheckAuth() == true)
                {
                    lblLoginInfo.Text = "Auth Code: " + var1;
                    
                }
                else
                {
                    lblLoginInfo.Text = "Ihr Code ist Abgelaufen oder ungültig";
                }
            }
        }
    }
}