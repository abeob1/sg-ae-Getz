﻿<%@ page language="C#" autoeventwireup="true" inherits="Header, App_Web_zyiaz0dm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Getz health care</title>
		<style type="text/css">
BODY { MARGIN: 0px }
.GeneralMenu { FONT-SIZE: 10px; COLOR: #666699; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.GeneralMenu:link { FONT-SIZE: 10px; COLOR: #669999; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.GeneralMenu:visited { FONT-SIZE: 10px; COLOR: #669999; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.GeneralMenu:hover { FONT-SIZE: 10px; COLOR: #ffcc00; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: underline }
A.GeneralMenu:active { FONT-SIZE: 10px; COLOR: #669999; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
OperationMenu { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #0099ff; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.OperationMenu:link { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #336699; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.OperationMenu:visited { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #336699; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.OperationMenu:hover { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #333333; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
A.OperationMenu:active { PADDING-RIGHT: 5px; PADDING-LEFT: 5px; FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #336699; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
.GeneralMenuBody { BORDER-BOTTOM: #999999 1px solid; BACKGROUND-COLOR: #f2f2f9 }
.OperationMenuBody { BORDER-TOP: #000066 1px groove; BORDER-BOTTOM: #cccccc 1px solid; BACKGROUND-COLOR: #dae7e7 }
		.OperationMenuBody2 {
	BACKGROUND-COLOR: #B0CCCC;
}
        .OperationMenuBody3 {
BACKGROUND-COLOR: #84B0B0}
        .SiteName {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10px;
	color: #003366;
	font-weight: bold;
}
        </style>    
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table width="100%"  border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td colspan="2" class="GeneralMenuBody"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td><table border="0" cellpadding="2" cellspacing="1">
          <tr align="center">
            <td width="80"><a href="asp/swordfish_main.asp" target="main" class="GeneralMenu">Main</a></td>
            <td width="80"><a href="Default.aspx?logout=1" target="_parent" class="GeneralMenu" onClick="return confirm('Are you sure you want to exit Swordfish Control Panel?')">Logout</a></td>
          </tr>
        </table></td>
        </tr>
    </table></td>
  </tr>
  <tr>
    <td><img src="img/header.jpg" width="504" height="80" ></td>
  <td align="right" valign="top">&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2" class="OperationMenuBody"><table border="0" cellspacing="1" cellpadding="2">
      <tr align="center">
        <td><a href="asp/swordfish_notifications.asp" target="main" class="OperationMenu">Notifications</a></td>
        <td><a href="Main.aspx" target="main" class="OperationMenu">Reports</a></td>
        <td><a href="asp/swordfish_master_act.asp" target="main" class="OperationMenu">System Setting</a></td>
        <td><a href="asp/swordfish_master_users.asp" target="main" class="OperationMenu">Users Management </a></td>
        </tr>
    </table></td>
  </tr>
</table>    
    </div>
    </form>
</body>
</html>

