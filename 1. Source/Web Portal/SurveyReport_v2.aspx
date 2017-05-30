<%@ page language="C#" autoeventwireup="true" inherits="SurveyReport_v2, App_Web_zyiaz0dm" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Jebsen & Jessen Technology Mobile Service</title>
    <link href="common.css" rel="stylesheet" type="text/css" />
    <link href="js/jqplot/jquery.jqplot.min.css" rel="stylesheet" type="text/css" />
	<!--[if lte IE 9]><script language="javascript" type="text/javascript" src="js/jqplot/excanvas.min.js"></script><![endif]-->
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jqplot/jquery.jqplot.min.js"></script>   
	<script type="text/javascript" src="js/jqplot/plugins/jqplot.pieRenderer.min.js"></script>   
	   
	 
    
	<style type="text/css">

		
		div.graph
		{
			width: 700px;
			height: 300px;
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
      <td class="PageHeader">Survey Report</td>
    </tr>
    <tr>
      <td>    
        <table width="100%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">

            <tr>
                <td class="DataGridToolbar">
                <asp:Label ID="Label_Year" runat="server" Text="Year: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="ddl_year" runat="server" CssClass="FormElement"></asp:DropDownList>
                <asp:DropDownList ID="ddl_dchannel" runat="server"  Visible=false CssClass="FormElement" AutoPostBack="True" OnSelectedIndexChanged="ddl_dchannel_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddl_plant" runat="server"  Visible=false CssClass="FormElement" AutoPostBack="True" OnSelectedIndexChanged="ddl_plant_SelectedIndexChanged"></asp:DropDownList>
                <asp:DropDownList ID="ddl_Employee" runat="server" CssClass="FormElement"></asp:DropDownList>
                <asp:Label ID="Label_EquipmentProfile" runat="server" Text="Equipm. Profile: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="ddl_EquipmProfile" runat="server" CssClass="FormElement"></asp:DropDownList>                                
                <asp:Button ID="display" runat="server" OnClick="display_Click" CssClass ="FormElement" Text="Display Report" />
                <asp:Button ID="Back" CssClass="FormElement" runat="server" OnClick="back_click" Text="Back" /><br /></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <!-- chart -->
                    
                    <div id="default" class="graph"></div>
                </td>
            </tr>
            <tr><td><p>&nbsp;</p></td></tr>
            <tr>
                <td>
                <asp:GridView ID="GridViewResult" runat="server"
                    BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px" Width="700px" CellPadding="5">
                    <RowStyle CssClass="DataGridRow" />
                    <PagerStyle CssClass="DataGridToolbar" />
                    <HeaderStyle CssClass="DataGridHeader" />
                </asp:GridView>                
                    <br />
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
            var plot1 = $.jqplot('default', data, {
                animate: true,
                animateReplot: true,
                gridPadding: { top: 0, bottom: 38, left: 0, right: 0 },
                seriesDefaults: {
                    renderer: $.jqplot.PieRenderer,
                    trendline: { show: false },
                    rendererOptions: { padding: 8, showDataLabels: true }
                },
                legend: {
                    show: true,
                    placement: 'outside',
                    rendererOptions: {
                        numberRows: 1
                    },
                    location: 's',
                    marginTop: '15px'
                }
            });
        }
    });
    
    </script>        
    
    
    </form>
    
   
    
</body>
</html>


