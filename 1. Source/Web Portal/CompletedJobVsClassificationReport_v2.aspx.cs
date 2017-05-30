using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Swordfish_v2_Core.CoreManagers;
using System.Data;
using System.Text;
using Jamila2.Database;
using Swordfish_v2_Core.CoreElements;
using System.Configuration;

public partial class CompletedJobVsClassificationReport_v2 : System.Web.UI.Page
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
            DataTable table = manager.GetCompletedJobVsJobClassification(int.Parse(this.ddl_year.SelectedValue), this.ddl_dchannel.SelectedValue, this.ddl_plant.SelectedValue);
            DataView view = new DataView(table);
            this.GridViewResult.DataSource = view;
            this.DataBind();
            if ((table != null) && (table.Rows.Count > 0))
            {
                StringBuilder builder = new StringBuilder("");
                StringBuilder builder2 = new StringBuilder("");
                StringBuilder builder3 = new StringBuilder("");
                builder3.AppendLine("var LegendLabels = [");
                builder2.AppendLine("var ChartData = [");
                for (int i = 1; i < (table.Columns.Count - 1); i++)
                {
                    builder.AppendLine("var data_" + i + " = [");
                    for (int j = 0; j < (table.Rows.Count - 1); j++)
                    {
                        builder.Append(table.Rows[j][i].ToString() + ((j == (table.Rows.Count - 2)) ? "" : ","));
                    }
                    builder.Append("];");
                    builder2.Append(string.Concat(new object[] { "data_", i, "", (i == (table.Columns.Count - 2)) ? "" : "," }));
                    builder3.Append("'" + table.Columns[i].ColumnName + "'" + ((i == (table.Columns.Count - 2)) ? "" : ","));
                }
                builder2.Append("];");
                builder3.Append("];");
                this.ChartScript.Text = "<script type='text/javascript'>IsChartReady = true; " + builder.ToString() + builder2.ToString() + builder3.ToString() + "</script>";
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CurSessionConfig = new SessionConfig(0, ConfigurationManager.AppSettings["swordfish_v1_ConnectionString"]);
        if (!base.IsPostBack)
        {
            string text = Convert.ToString((int) (DateTime.Now.Year - 1));
            string str2 = Convert.ToString(DateTime.Now.Year);
            string str3 = Convert.ToString((int) (DateTime.Now.Year + 1));
            this.ddl_year.Items.Add(new ListItem(text, text));
            this.ddl_year.Items.Add(new ListItem(str2, str2));
            this.ddl_year.Items.Add(new ListItem(str3, str3));
            this.ddl_plant.Items.Add(new ListItem("320", "320"));
            this.ddl_plant.Items.Add(new ListItem("820", "820"));
            this.ddl_dchannel.Items.Add(new ListItem("3I", "3I"));
            this.ddl_dchannel.Items.Add(new ListItem("3O", "3O"));
            this.ddl_dchannel.Items.Add(new ListItem("3S", "3S"));
        }
    }

}