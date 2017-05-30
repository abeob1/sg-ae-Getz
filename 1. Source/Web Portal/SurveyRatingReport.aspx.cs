using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Jamila2.Database;
using System.Configuration;
using Swordfish_v2_Core.CoreManagers;
using Swordfish_v2_Core.CoreElements;
using System.Data;


public partial class SurveyRatingReport : System.Web.UI.Page
{
   
    private string dbConnection = "";
    private TypeOfDatabase dbType;
    private string SelectedYear = "";

    private SessionConfig CurSessionConfig;

    private DataTable ResultTable;
    private int CurrentPageIndex;

    protected void back_click(object sender, EventArgs e)
    {
        base.Response.Redirect("Main.aspx");
    }

    protected void ddl_dchannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (UserManager manager = new UserManager(this.CurSessionConfig))
        {
            this.ddl_Employee.Items.Clear();
            this.ddl_Employee.Items.Add(new ListItem("[All Engineer]", "%"));
            ApplicationUserCollection masterUsers = manager.GetMasterUsers(this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue);
            if (masterUsers != null)
            {
                masterUsers.SortByName();
                foreach (ApplicationUser user in masterUsers)
                {
                    this.ddl_Employee.Items.Add(new ListItem(user.FirstName + " (" + user.UserID + ")", user.UserID));
                }
            }
        }
    }

    protected void ddl_plant_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddl_dchannel_SelectedIndexChanged(sender, e);
    }

    protected void display_Click(object sender, EventArgs e)
    {
        this.CurrentPageIndex = 0;
        this.ResultTable = new DataTable();
        this.ResultTable.Columns.Add(new DataColumn("Engineer Resp.", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("Sold To", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("notification_no", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("Activity Type", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("notification_subject", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("Equipment", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("SN", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("JobStart", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("JobEnd", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("notification_signby", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("notification_signbydisgn", Type.GetType("System.String")));
        this.ResultTable.Columns.Add(new DataColumn("Comments", Type.GetType("System.String")));
        using (OpSurveyManager manager = new OpSurveyManager(this.CurSessionConfig))
        {
            this.ResultTable = manager.GetOpSurveyDataResult(int.Parse(this.ddl_Month.SelectedValue), int.Parse(this.ddl_year.SelectedValue), this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue, this.ddl_Employee.SelectedValue, this.ddl_EquipmProfile.SelectedValue);
            DataView view = new DataView(this.ResultTable);
            this.GridViewResult.DataSource = view;
            this.DataBind();
        }
    }

    protected void GridViewResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (this.ResultTable != null)
        {
            this.CurrentPageIndex = e.NewPageIndex;
            DataView view = new DataView(this.ResultTable);
            this.GridViewResult.DataSource = view;
            this.GridViewResult.PageIndex = this.CurrentPageIndex;
            this.DataBind();
        }
    }

    private void Page_Init(object sender, EventArgs e)
    {
        this.CurSessionConfig = new SessionConfig(TypeOfDatabase.MSSQL,  ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"]);
        if (!base.IsPostBack)
        {
            int num = 0x7dc;
            for (int i = num; i <= (DateTime.Today.Year + 1); i++)
            {
                string text = i.ToString();
                this.ddl_year.Items.Add(new ListItem(text, i.ToString()));
                if (i == DateTime.Today.Year)
                {
                    this.ddl_year.SelectedIndex = this.ddl_year.Items.Count - 1;
                }
            }
            for (int j = 1; j <= 12; j++)
            {
                string introduced26 = j.ToString();
                this.ddl_Month.Items.Add(new ListItem(introduced26, j.ToString()));
                if (j == DateTime.Today.Month)
                {
                    this.ddl_Month.SelectedIndex = this.ddl_Month.Items.Count - 1;
                }
            }
            using (MasterManager manager = new MasterManager(this.CurSessionConfig))
            {
                //string[] plants = manager.GetPlants();
                this.ddl_plant.Items.Add(new ListItem("[All Plants]", ""));
                //foreach (string str in plants)
                //{
                //    this.ddl_plant.Items.Add(new ListItem(str, str));
                //}
                //string[] distChannel = manager.GetDistChannel();
                this.ddl_dchannel.Items.Add(new ListItem("[All Dist. Channel]", ""));
                //foreach (string str2 in distChannel)
                //{
                //    this.ddl_dchannel.Items.Add(new ListItem(str2, str2));
                //}
            }
            using (UserManager manager2 = new UserManager(this.CurSessionConfig))
            {
                this.ddl_Employee.Items.Add(new ListItem("[All Engineer]", "%"));
                ApplicationUserCollection masterUsers = manager2.GetMasterUsers();
                if (masterUsers != null)
                {
                    masterUsers.SortByName();
                    foreach (ApplicationUser user in masterUsers)
                    {
                        this.ddl_Employee.Items.Add(new ListItem(user.FirstName + " (" + user.UserID + ")", user.UserID));
                    }
                }
            }
            using (EquipmentManager manager3 = new EquipmentManager(this.CurSessionConfig))
            {
                this.ddl_EquipmProfile.Items.Add(new ListItem("[All Equipm. Profile]", "%"));
                EquipmentCollection allEquipmentProfiles = manager3.GetAllEquipmentProfiles();
                if (allEquipmentProfiles != null)
                {
                    allEquipmentProfiles.SortByName();
                    foreach (EquipmentObj obj2 in allEquipmentProfiles)
                    {
                        if (obj2.EquipmentProfileID.Length > 0)
                        {
                            this.ddl_EquipmProfile.Items.Add(new ListItem(obj2.EquipmentProfileID, obj2.EquipmentProfileID));
                        }
                    }
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.dbConnection = ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"];

        this.CurSessionConfig = new SessionConfig(this.dbType, this.dbConnection);

        if (!base.IsPostBack)
        {
            this.CurrentPageIndex = 0;
        }
    }
}