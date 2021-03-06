﻿using System.Web.UI;
using System.Web.SessionState;
using System.Windows.Forms;
using Jamila2.Database;
using System.Web.UI.HtmlControls;
using System.Configuration;
using Swordfish_v2_Core.CoreElements;
using System;
using Swordfish_v2_Core.CoreManagers;
using System.Web;
using System.Web.Profile;

public partial class Default : System.Web.UI.Page
{
    //protected Button Button_Login;
    private string dbConnection = "";
    private TypeOfDatabase dbType;
    //protected HtmlForm form1;
    //protected Label Label_FormTitle;
    //protected Label Label_Instruction;
    //protected Label Label_LoginID;
   // protected Label Label_LoginPassword;
    //protected Label Label_Message;
    //protected TextBox TextBox_LoginID;
    //protected TextBox TextBox_Password;

    public void Button_Login_Click(object sender, EventArgs e)
    {
        string returnMessage = "";
        this.dbConnection = ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"];
        SessionConfig privateSessionConfig = new SessionConfig(this.dbType, this.dbConnection);
        this.Session["CurSessionConfig"] = privateSessionConfig;
        if ((this.TextBox_LoginID.Text.Trim().Length > 0) && (this.TextBox_Password.Text.Trim().Length > 0))
        {
            using (UserManager manager = new UserManager(privateSessionConfig))
            {
                ApplicationUser user = manager.Login(this.TextBox_LoginID.Text.Trim(), this.TextBox_Password.Text.Trim(), false, this.dbConnection, this.dbType, ref returnMessage);
                if (((returnMessage.Trim().Length > 0) || (user == null)) || (user.InternalID.Length <= 0))
                {
                    this.Label_Message.Text = returnMessage.ToString();
                }
                else
                {
                    base.Response.Redirect("index2.htm");
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    /*
    protected HttpApplication ApplicationInstance
    {
        get
        {
            return this.Context.ApplicationInstance;
        }
    }

    protected DefaultProfile Profile
    {
        get
        {
            return (DefaultProfile)this.Context.Profile;
        }
    }*/
}
