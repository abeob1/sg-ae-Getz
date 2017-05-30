<%@ page language="C#" autoeventwireup="true" inherits="SurveyRatingReport, App_Web_zyiaz0dm" %>

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
      <td class="PageHeader">Survey Rating Report</td>
    </tr>
    <tr>
      <td>     
    <table width="100%"  border="0" cellpadding="2" cellspacing="0" class="FormTable">

        <tr>
            <td class="DataGridToolbar"><asp:Label ID="Label_Year" runat="server" Text="Year: " CssClass="FormFieldName"></asp:Label>
            <asp:DropDownList ID="ddl_year" CssClass="FormElement" runat="server"></asp:DropDownList>
            <asp:Label ID="Label_Month" runat="server" Text="Month: " CssClass="FormFieldName"></asp:Label>
            <asp:DropDownList ID="ddl_Month" CssClass="FormElement" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="ddl_dchannel"  Visible=false runat="server" CssClass="FormElement" OnSelectedIndexChanged="ddl_dchannel_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:DropDownList ID="ddl_plant"  Visible=false runat="server" CssClass="FormElement" OnSelectedIndexChanged="ddl_plant_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:DropDownList ID="ddl_Employee" runat="server" CssClass="FormElement"></asp:DropDownList>
                <asp:Label ID="Label_EquipmentProfile" runat="server" Text="Equipm. Profile: " CssClass="FormFieldName"></asp:Label>
                <asp:DropDownList ID="ddl_EquipmProfile" runat="server" CssClass="FormElement"></asp:DropDownList>                                            
            <asp:Button ID="display" CssClass="FormElement" runat="server" OnClick="display_Click" Text="Display Report" />
            <asp:Button ID="Back" CssClass="FormElement" runat="server" OnClick="back_click" Text="Back" /><br /></td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridViewResult" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px" OnPageIndexChanging="GridViewResult_PageIndexChanging"
                    PageSize="50" Width="100%">
                    <RowStyle CssClass="DataGridRow" />
                    <Columns>
                        <asp:BoundField DataField="Engineer Resp." HeaderText="Engineer Resp.">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Sold To" HeaderText="Sold To">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="notification_no" HeaderText="Notification No.">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Activity Type" HeaderText="Activity Type">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="notification_subject" HeaderText="Subject">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Equipment" HeaderText="Equipment">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SN" HeaderText="SN">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobStart" HeaderText="Job Start">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JobEnd" HeaderText="Job End">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signature_name" HeaderText="Sign By">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="signature_designation" HeaderText="Designation">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Comments" HeaderText="Comments">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                    </Columns>
                    <PagerStyle CssClass="DataGridToolbar" />
                    <HeaderStyle CssClass="DataGridHeader" />
                </asp:GridView>
            </td>
        </tr>
         <tr>
            <td>&nbsp;</td>
        </tr>
    </table>      
</td>
    </tr>
  </table>       
    </form>
</body>
</html>

