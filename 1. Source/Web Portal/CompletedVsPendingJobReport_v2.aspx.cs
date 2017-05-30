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

public partial class CompletedVsPendingJobReport_v2 : System.Web.UI.Page
{
    private string dbConnection = "";
    private TypeOfDatabase dbType;


    private SessionConfig CurSessionConfig;

    protected void back_click(object sender, EventArgs e)
    {
        base.Response.Redirect("Main.aspx");
    }

    protected void display_Click(object sender, EventArgs e)
    {
        using (OpNotificationManager manager = new OpNotificationManager(this.CurSessionConfig))
        {
            DataTable table = manager.GetCompletedVsPendingJob(int.Parse(this.ddl_year.SelectedValue), int.Parse(this.ddl_Month.SelectedValue), this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue);
            DataView view = new DataView(table);
            this.GridViewResult.DataSource = view;
            this.DataBind();
            if ((table != null) && (table.Rows.Count > 0))
            {
                StringBuilder builder = new StringBuilder("");
                StringBuilder builder2 = new StringBuilder("");
                StringBuilder builder3 = new StringBuilder("");
                StringBuilder builder4 = new StringBuilder("");
                builder3.AppendLine("var LegendLabels = [");
                builder2.AppendLine("var ChartData = [");
                builder4.AppendLine("var ticks = [");
                for (int i = 0; i < (table.Rows.Count - 1); i++)
                {
                    builder.AppendLine("var data_" + i + " = [");
                    for (int k = 1; k < (table.Columns.Count - 1); k++)
                    {
                        builder.Append(table.Rows[i][k].ToString() + ((k == (table.Columns.Count - 2)) ? "" : ","));
                    }
                    builder.Append("];");
                    builder2.Append(string.Concat(new object[] { "data_", i, "", (i == (table.Rows.Count - 2)) ? "" : "," }));
                    builder3.Append("'" + table.Rows[i][0].ToString() + "'" + ((i == (table.Rows.Count - 2)) ? "" : ","));
                }
                for (int j = 1; j < (table.Columns.Count - 1); j++)
                {
                    builder4.Append("'" + table.Columns[j].ColumnName + "'" + ((j == (table.Columns.Count - 2)) ? "" : ","));
                }
                builder2.Append("];");
                builder3.Append("];");
                builder4.Append("];");
                this.ChartScript.Text = "<script type='text/javascript'>IsChartReady = true; " + builder.ToString() + builder2.ToString() + builder3.ToString() + builder4.ToString() + "</script>";
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
            this.ddl_Month.Items.Add(new ListItem("1", "1"));
            this.ddl_Month.Items.Add(new ListItem("2", "2"));
            this.ddl_Month.Items.Add(new ListItem("3", "3"));
            this.ddl_Month.Items.Add(new ListItem("4", "4"));
            this.ddl_Month.Items.Add(new ListItem("5", "5"));
            this.ddl_Month.Items.Add(new ListItem("6", "6"));
            this.ddl_Month.Items.Add(new ListItem("7", "7"));
            this.ddl_Month.Items.Add(new ListItem("8", "8"));
            this.ddl_Month.Items.Add(new ListItem("9", "9"));
            this.ddl_Month.Items.Add(new ListItem("10", "10"));
            this.ddl_Month.Items.Add(new ListItem("11", "11"));
            this.ddl_Month.Items.Add(new ListItem("12", "12"));
            this.ddl_plant.Items.Add(new ListItem("320", "320"));
            this.ddl_plant.Items.Add(new ListItem("820", "820"));
            this.ddl_dchannel.Items.Add(new ListItem("3I", "3I"));
            this.ddl_dchannel.Items.Add(new ListItem("3O", "3O"));
            this.ddl_dchannel.Items.Add(new ListItem("3S", "3S"));
        }
    }

}