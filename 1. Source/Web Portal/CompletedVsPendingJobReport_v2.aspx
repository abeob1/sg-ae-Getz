<%@ page language="C#" autoeventwireup="true" inherits="CompletedVsPendingJobReport_v2, App_Web_zyiaz0dm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Jebsen & Jessen Technology Mobile Service</title>
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="js/jqplot/jquery.jqplot.min.css" rel="stylesheet" type="text/css" />
	<!--[if lte IE 9]><script language="javascript" type="text/javascript" src="js/jqplot/excanvas.min.js"></script><![endif]-->
    <script type="text/javascript" src="js/jquery.min.js"></script>
	<script type="text/javascript" src="js/jqplot/jquery.jqplot.min.js"></script>   
	<script type="text/javascript" src="js/jqplot/plugins/jqplot.barRenderer.min.js"></script>   
	<script type="text/javascript" src="js/jqplot/plugins/jqplot.categoryAxisRenderer.min.js"></script>   
	<script type="text/javascript" src="js/jqplot/plugins/jqplot.pointLabels.min.js"></script>   
	<script type="text/javascript" src="js/jqplot/plugins/jqplot.highlighter.min.js"></script>   
	<style type="text/css">

		
		div.graph
		{
			width: 98%;
			height: 400px;
			float: left;
			border: 1px dashed gainsboro;
		}		
	</style>   	 
	
	<script language="javascript" type="text/javascript">

	    var IsChartReady = false;
	</script>	    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Completed vs. Pending Jobs</td>
    </tr>
    <tr>
      <td>     
    
    <table width="100%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">

        <tr>
            <td class="DataGridToolbar"><asp:Label ID="Label_Year" runat="server" Text="Year: " CssClass="FormFieldName"></asp:Label>
            <asp:DropDownList ID="ddl_year" CssClass="FormElement" runat="server"></asp:DropDownList>
            <asp:Label ID="Label_Month" runat="server" Text="Month: " CssClass="FormFieldName"></asp:Label>
            <asp:DropDownList ID="ddl_Month" CssClass="FormElement" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddl_dchannel" Visible=false runat="server" CssClass="FormElement" AutoPostBack="True"></asp:DropDownList>
            <asp:DropDownList ID="ddl_plant" Visible=false runat="server" CssClass="FormElement" AutoPostBack="True"></asp:DropDownList>                                    
            <asp:Button ID="display" CssClass="FormElement" runat="server" OnClick="display_Click" Text="Display Report" />
            <asp:Button ID="Back" CssClass="FormElement" runat="server" OnClick="back_click" Text="Back" /><br /></td>
        </tr>
        <tr>
            <td>
                <!-- chart -->
                <div id="default" class="graph"></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewResult" runat="server"
                    BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px" Width="900px" CellPadding="5">
                    <RowStyle CssClass="DataGridRow" />
                    <PagerStyle CssClass="DataGridToolbar" />
                    <HeaderStyle CssClass="DataGridHeader" />
                </asp:GridView>             
            </td>
        </tr> 
    </table>
</td>
    </tr>
  </table>       
    </div>
    
    <asp:Literal ID="ChartScript" runat="server"></asp:Literal>
    
<script type="text/javascript">


    $(function () {

        if (IsChartReady) {



            plot1 = $.jqplot('default', ChartData, {
                animate: true,
                animateReplot: true,
                seriesDefaults: {
                    renderer: $.jqplot.BarRenderer,
                    pointLabels: { show: false }
                },
                axes: {
                    xaxis: {
                        renderer: $.jqplot.CategoryAxisRenderer,
                        ticks: ticks
                    }
                },
                legend: {
                    show: true,
                    location: 's',
                    placement: 'outsideGrid',
                    labels: LegendLabels
                },
                highlighter: {
                    show: true,
                    sizeAdjust: 1,
                    tooltipOffset: -2,
                    tooltipAxes: 'y'
                }
            });

        }
    });
    
    </script>      
    
    </form>
</body>
</html>

