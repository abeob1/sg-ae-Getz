<%@ page language="C#" autoeventwireup="true" inherits="Default, App_Web_zyiaz0dm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Getz Healthare mobile service</title>
    <link href="WebStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><img src="jjtm.gif" /></td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr>
                <td width="30%">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <table width="500" border="0" cellspacing="1" cellpadding="2">
              <tr>
                <td width="199" align="left" valign="top"><table width="100%" border="0" cellspacing="1" cellpadding="2">
                  <tr>
                    <td class="FormTitle">
                        <asp:Label ID="Label_FormTitle" runat="server" Text="System Login"></asp:Label></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td class="NormalBodyText"><asp:Label ID="Label_Message" runat="server" /></td>
                  </tr>
                </table></td>
                <td class="VerticalDivider" style="width:1 px">&nbsp;</td>
                <td width="315"><table width="98%" border="0" cellspacing="1" cellpadding="2">
                  <tr>
                    <td align="left" class="FormField"><asp:Label ID="Label_LoginID" Text="Login ID" runat="server" meta:resourcekey="Label_LoginIDResource1" /></td>
                    <td align="left"><asp:TextBox CssClass="FormTextBox" ID="TextBox_LoginID" runat="server" meta:resourcekey="TextBox_LoginIDResource1" /></td>
                  </tr>
                  <tr>
                    <td align="left" class="FormField"><asp:Label ID="Label_LoginPassword" Text="Password" runat="server" meta:resourcekey="Label_LoginPasswordResource1" /></td>
                    <td align="left"><asp:TextBox CssClass="FormTextBox" ID="TextBox_Password" runat="server" TextMode="Password" meta:resourcekey="TextBox_PasswordResource1" /></td>
                  </tr>
                  <tr>
                    <td colspan="2" align="left" style="height: 28px"><asp:Button CssClass="FormButton" ID="Button_Login" runat="server" OnClick="Button_Login_Click" Text="Login" />                        </td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                  </tr>
                    <tr>
                        <td align="left" class="HorizontalDevider" colspan="2"><asp:Label CssClass="NormalBodyText" ID="Label_Instruction" runat="server"></asp:Label></td>
                  </tr>
                </table>
                </td>
              </tr>
            </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
