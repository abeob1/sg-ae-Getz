﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jamila2.Database;
using Swordfish_v2_Core.CoreElements;
using Swordfish_v2_Core.CoreManagers;
using System.Data;
using System.Text;
using System.Configuration;

public partial class EngineerHourUtilization_v2 : System.Web.UI.Page
{
    private string dbConnection = "";
    private TypeOfDatabase dbType;
    

    private SessionConfig CurSessionConfig;

    protected void back_click(object sender, EventArgs e)
    {
        base.Response.Redirect("Main.aspx");
    }

    protected void ddl_dchannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddl_engineer.Items.Clear();
        using (UserManager manager = new UserManager(this.CurSessionConfig))
        {
            ApplicationUserCollection masterUsers = manager.GetMasterUsers(this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue);
            if ((masterUsers != null) && (masterUsers.Count > 0))
            {
                foreach (ApplicationUser user in masterUsers)
                {
                    this.ddl_engineer.Items.Add(new ListItem(user.FirstName + " (" + user.UserID + ")", user.UserID));
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
        using (OpEngineerManager manager = new OpEngineerManager(this.CurSessionConfig))
        {
            DataTable table = manager.GetOpEngineerUtilHoursDataResult(int.Parse(this.ddl_year.SelectedValue), this.ddl_engineer.SelectedValue, 0x80, this.ddl_EquipmProfile.SelectedValue,"");
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
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    builder.Append("['" + table.Columns[i].ColumnName + "', " + row[i].ToString() + "]" + ((i == (table.Columns.Count - 1)) ? "" : ","));
                }
                builder.Append("]];");
                builder.AppendLine("</script>");
                this.ChartScript.Text = builder.ToString();
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)

    {

        this.CurSessionConfig = new SessionConfig(0, ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"]);
        if (!base.IsPostBack)
        {
            string text = Convert.ToString((int)(DateTime.Now.Year - 1));
            string str2 = Convert.ToString(DateTime.Now.Year);
            string str3 = Convert.ToString((int)(DateTime.Now.Year + 1));
            this.ddl_year.Items.Add(new ListItem(text, text));
            this.ddl_year.Items.Add(new ListItem(str2, str2));
            this.ddl_year.Items.Add(new ListItem(str3, str3));
            this.ddl_plant.Items.Add(new ListItem("", ""));
            this.ddl_plant.Items.Add(new ListItem("320", "320"));
            this.ddl_plant.Items.Add(new ListItem("820", "820"));
            this.ddl_dchannel.Items.Add(new ListItem("", ""));
            this.ddl_dchannel.Items.Add(new ListItem("3I", "3I"));
            this.ddl_dchannel.Items.Add(new ListItem("3O", "3O"));
            this.ddl_dchannel.Items.Add(new ListItem("3S", "3S"));
            using (UserManager manager = new UserManager(this.CurSessionConfig))
            {
                this.ddl_engineer.Items.Add(new ListItem("[All Engineer]", "%"));
                ApplicationUserCollection masterUsers = manager.GetMasterUsers();
                if (masterUsers != null)
                {
                    masterUsers.SortByName();
                    foreach (ApplicationUser user in masterUsers)
                    {
                        this.ddl_engineer.Items.Add(new ListItem(user.FirstName + " (" + user.UserID + ")", user.UserID));
                    }
                }
            }
            using (EquipmentManager manager2 = new EquipmentManager(this.CurSessionConfig))
            {
                this.ddl_EquipmProfile.Items.Add(new ListItem("[All Equipm. Profile]", "%"));
                EquipmentCollection allEquipmentProfiles = manager2.GetAllEquipmentProfiles();
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