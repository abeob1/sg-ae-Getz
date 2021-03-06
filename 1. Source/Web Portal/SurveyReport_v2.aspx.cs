﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Swordfish_v2_Core.CoreManagers;
using Swordfish_v2_Core.CoreElements;
using System.Data;
using System.Text;
using Jamila2.Database;
using System.Configuration;



public partial class SurveyReport_v2 : System.Web.UI.Page
{

    private SessionConfig CurSessionConfig;
    private string dbConnection = "";
    private TypeOfDatabase dbType;

    
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
        using (OpSurveyManager manager = new OpSurveyManager(this.CurSessionConfig))
        {
            DataTable table = manager.GetOpSurveyDataResult(int.Parse(this.ddl_year.SelectedValue), this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue, this.ddl_Employee.SelectedValue, this.ddl_EquipmProfile.SelectedValue);
            DataView view = new DataView(table);
            this.GridViewResult.DataSource = view;
            this.DataBind();
            if ((table != null) && (table.Rows.Count > 0))
            {
                StringBuilder builder = new StringBuilder();
                DataRow row = table.Rows[table.Rows.Count - 1];
                builder.AppendLine("<script type='text/javascript'>");
                builder.AppendLine("IsChartReady = true;");
                builder.Append("var data = [[");
                for (int i = 1; i <= 4; i++)
                {
                    builder.Append("['" + table.Columns[i].ColumnName + "'," + row[i].ToString() + "]" + ((i == 4) ? "" : ","));
                }
                builder.Append("]];");
                builder.AppendLine("</script>");
                this.ChartScript.Text = builder.ToString();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.dbConnection = ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"];
        
        this.CurSessionConfig = new SessionConfig(this.dbType, this.dbConnection);
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

    
}

