using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Swordfish_v2_Core.CoreManagers;
using Jamila2.Tools;
using Swordfish_v2_Core.CoreElements;
using System.Configuration;
using Jamila2.Database;

public partial class EngineerOutstandingCompletedJob : System.Web.UI.Page
{

    private DataObj CurPageDataObj = new DataObj();
    private SessionConfig CurSessionConfig;
    private string dbConnection = "";
    private TypeOfDatabase dbType;
    private DataTable ResultTable  = new DataTable();


    protected void Button_Back_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Main.aspx");
    }

    protected void Button_Display_Click(object sender, EventArgs e)
    {
        this.HyperLink_FileDownload.Visible = false;
        this.LoadData();
        if (this.ResultTable != null)
        {
            DataView view = new DataView(this.ResultTable);
            this.GridViewResult.DataSource = view;
            this.GridViewResult.DataBind();
        }
    }

    protected void Button_Export_Click(object sender, EventArgs e)
    {
        if (this.ResultTable != null)
        {
            string str = "EngineerJob-" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".csv";
            string responseMessage = "";
            if (GenerateCSV(this.ResultTable, base.Server.MapPath("ReportsOutput") + @"\" + str, ref responseMessage))
            {
                this.HyperLink_FileDownload.Text = "Click here to download " + str;
                this.HyperLink_FileDownload.NavigateUrl = "ReportsOutput/" + str;
                this.HyperLink_FileDownload.Visible = true;
            }
        }
    }

    protected void ddl_dchannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.DropDownList_Engineer.Items.Clear();
        this.DropDownList_Engineer.Items.Add(new ListItem("[All Engineer]", "%"));
        using (UserManager manager = new UserManager(this.CurSessionConfig))
        {
            ApplicationUserCollection masterUsers = manager.GetMasterUsers(this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue);
            if ((masterUsers != null) && (masterUsers.Count > 0))
            {
                foreach (ApplicationUser user in masterUsers)
                {
                    this.DropDownList_Engineer.Items.Add(new ListItem(user.FirstName + " (" + user.UserID + ")", user.UserID));
                }
            }
        }
    }

    protected void ddl_plant_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddl_dchannel_SelectedIndexChanged(sender, e);
    }

    public static bool GenerateCSV(DataTable ResultTable, string path, ref string ResponseMessage)
    {
        bool flag = true;
        StringBuilder builder = new StringBuilder();
        StringBuilder builder2 = new StringBuilder();
        try
        {
            if (ResultTable == null)
            {
                return flag;
            }
            foreach (DataColumn column in ResultTable.Columns)
            {
                builder2.Append(column.ColumnName + ",");
            }
            builder.AppendLine(builder2.ToString().Substring(0, builder2.ToString().Length - 1));
            foreach (DataRow row in ResultTable.Rows)
            {
                builder2 = new StringBuilder();
                foreach (DataColumn column2 in ResultTable.Columns)
                {
                    if (row[column2.ColumnName].ToString().IndexOf(",") >= 0)
                    {
                        builder2.Append("\"" + row[column2.ColumnName].ToString() + "\",");
                    }
                    else
                    {
                        builder2.Append(row[column2.ColumnName].ToString() + ",");
                    }
                }
                builder.AppendLine(builder2.ToString().Substring(0, builder2.ToString().Length - 1));
            }
            SwissArmy.FileCreate(path, builder.ToString());
        }
        catch (Exception exception)
        {
            flag = false;
            ResponseMessage = "[ReportsGenerator.GenerateCSV] : Exception : " + exception.Message;
        }
        return flag;
    }

    protected void LoadData()
    {
        this.Label_NoData.Visible = false;
        using (OpNotificationManager manager = new OpNotificationManager(this.CurSessionConfig))
        {
            DataTable table = manager.GetOutstandingReport(this.ddl_year.SelectedValue, this.ddl_Month.SelectedValue, this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue, this.DropDownList_Engineer.SelectedValue, this.ddl_EquipmProfile.SelectedValue);
            if (table != null)
            {
                this.ResultTable = new DataTable();
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.MalfunctionDate, Type.GetType("System.String")));
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.NotificationNo, Type.GetType("System.String")));
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.NotificationSO, Type.GetType("System.String")));
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.CustomerName, Type.GetType("System.String")));
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.NotificationSubject, Type.GetType("System.String")));
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.EmployeeName, Type.GetType("System.String")));
                this.ResultTable.Columns.Add(new DataColumn(this.CurPageDataObj.Status, Type.GetType("System.String")));
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataRow row = this.ResultTable.NewRow();
                        row[this.CurPageDataObj.MalfunctionDate] = table.Rows[i]["notification_requiredstart"];
                        row[this.CurPageDataObj.NotificationNo] = table.Rows[i]["notification_no"];
                        row[this.CurPageDataObj.NotificationSO] = table.Rows[i]["notification_so"];
                        row[this.CurPageDataObj.CustomerName] = table.Rows[i]["cust_name1"];
                        row[this.CurPageDataObj.NotificationSubject] = table.Rows[i]["notification_subject"];
                        row[this.CurPageDataObj.EmployeeName] = table.Rows[i]["user_firstname"];
                        row[this.CurPageDataObj.Status] = table.Rows[i]["master_desc"];
                        this.ResultTable.Rows.Add(row);
                    }
                }
                else
                {
                    this.Label_NoData.Visible = true;
                }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SessionCheck();
        this.Label_NoData.Visible = false;
        this.CurrentPageIndex = 0;
        if (!base.IsPostBack)
        {
            this.PageComponentSetup();
        }
    }

    protected void PageComponentSetup()
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
            ApplicationUserCollection masterUsers = manager2.GetMasterUsers();
            if ((masterUsers != null) && (masterUsers.Count > 0))
            {
                this.DropDownList_Engineer.Items.Add(new ListItem("[All Engineer]", "%"));
                foreach (ApplicationUser user in masterUsers)
                {
                    this.DropDownList_Engineer.Items.Add(new ListItem(user.FirstName + " (" + user.UserID + ")", user.UserID));
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

    public void SessionCheck()
    {
        if (this.Session["CurSessionConfig"] != null)
        {
            this.CurSessionConfig = (SessionConfig)this.Session["CurSessionConfig"];
        }
        else
        {
            this.dbConnection = ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"];
            this.CurSessionConfig = new SessionConfig(this.dbType, this.dbConnection);
            this.Session["CurSessionConfig"] = this.CurSessionConfig;
        }
    }

  

    protected int CurrentPageIndex
    {
        get
        {
            return (int)this.ViewState["CurrentPageIndex"];
        }
        set
        {
            this.ViewState["CurrentPageIndex"] = value;
        }
    }

    protected class DataObj
    {
        public readonly string CustomerName = "CustomerName";
        public readonly string EmployeeName = "EmployeeName";
        public readonly string MalfunctionDate = "MalfunctionDate";
        public readonly string NotificationNo = "NotificationNo";
        public readonly string NotificationSO = "NotificationSO";
        public readonly string NotificationSubject = "NotificationSubject";
        public readonly string Status = "Status";
    }
}

