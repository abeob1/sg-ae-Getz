<%@ page language="C#" autoeventwireup="true" inherits="EngineerOutstandingCompletedJob, App_Web_zyiaz0dm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Jebsen & Jessen Technology Mobile Service</title>
    <link href="common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
  <table width="100%" border="0" cellspacing="0" cellpadding="8">
    <tr>
      <td class="PageHeader">Engineer Outstanding Job</td>
    </tr>
    <tr>
      <td>     
    
    <table width="100%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">

            <tr>
                <td class="DataGridToolbar"><asp:Label ID="Label_Year" runat="server" Text="Year: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="ddl_year" runat="server" CssClass="FormElement"></asp:DropDownList>
                <asp:Label ID="Label_Month" runat="server" Text="Month: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="ddl_Month" runat="server" CssClass="FormElement"></asp:DropDownList>
                <asp:DropDownList ID="ddl_dchannel" Visible=false  runat="server" CssClass="FormElement" AutoPostBack="True" OnSelectedIndexChanged="ddl_dchannel_SelectedIndexChanged"></asp:DropDownList>                
                <asp:DropDownList ID="ddl_plant" Visible=false  runat="server" CssClass="FormElement" AutoPostBack="True" OnSelectedIndexChanged="ddl_plant_SelectedIndexChanged"></asp:DropDownList>                                             
                <asp:Label ID="Label_Engineer" runat="server" Text="Engineer: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="DropDownList_Engineer" runat="server" CssClass="FormElement"></asp:DropDownList>
                <asp:Label ID="Label_EquipmentProfile" runat="server" Text="Equipm. Profile: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="ddl_EquipmProfile" runat="server" CssClass="FormElement"></asp:DropDownList>                                                
                <asp:Button ID="Button_Display" runat="server" OnClick="Button_Display_Click" CssClass ="FormElement" Text="Display Report" />
                <asp:Button ID="Button_Back" CssClass="FormElement" runat="server" OnClick="Button_Back_Click" Text="Back" />
                <asp:Button ID="Button_Export" runat="server" OnClick="Button_Export_Click" CssClass ="FormElement" Text="Export to CSV" /><asp:HyperLink ID="HyperLink_FileDownload" runat="server" CssClass="GridViewLink"></asp:HyperLink><br /></td>
            </tr>
             <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td><asp:GridView ID="GridViewResult" runat="server" AutoGenerateColumns="False"  BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px"  CssClass="FormBorder"  CellPadding="5"  Width="100%">

                  <columns>
                    <asp:BoundField DataField="MalfunctionDate" HeaderText="Malf. start">
                      <itemstyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NotificationNo" HeaderText="Notification">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NotificationSO" HeaderText="Order">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CustomerName" HeaderText="List Name">
                      <ItemStyle HorizontalAlign="Center" />
                      <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NotificationSubject" HtmlEncode="False" HeaderText="Description">
                      <itemstyle HorizontalAlign="Left" />
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                  <asp:BoundField DataField="EmployeeName" HeaderText="Employee Resp." HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                  <asp:BoundField DataField="Status" HeaderText="User Status" HtmlEncode="False">
                      <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField>
                    </columns>
                  <RowStyle CssClass="DataGridRow" />
                  <headerstyle CssClass="DataGridHeader" />
                    <PagerStyle CssClass="DataGridToolbar" />
                </asp:GridView></td>
            </tr>
      </table>
      <asp:Label ID="Label_NoData" runat="server" Visible="false">No data available. Please try again.</asp:Label>
</td>
    </tr>
  </table>         
    </form>
</body>
</html>