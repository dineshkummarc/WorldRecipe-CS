<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="admin_adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>XD World Recipe Administrator Login</title>
    <link href="../CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
<br />
<div align="center">
<h3>Demo Recipe Manager</h3>
<span class="content2">
<br />
<br />
<b>Username:</b> dexter
<br />
<b>Password:</b> zafra
</span>
</div>
<br />
        <div style="text-align: center; margin-bottom: 12px;">
        <asp:Label runat="server" cssClass="cred" id="lblerror" />
        </div>
        <table cellspacing="1" cellpadding="2" width="300" bgcolor="#ffffff" border="0" align="center">
                <tr>
                    <td align="left" bgcolor="#6898d0" colspan="2">
                        <span class="headerwhite">Admin Login</span>
                    </td>
                </tr>
                <tr>
                    <td width="80" bgcolor="#f7f7f7">
                        <span class="content2">User Name:</span>
                    </td>
                    <td bgcolor="#fbfbfb" style="width: 189px">
                       <asp:TextBox runat="server" id="uname" cssClass="textbox" width="140" />
                    </td>
                </tr>
                <tr>
                    <td width="80" bgcolor="#f7f7f7">
                        <span class="content2">Password</span>
                    </td>
                    <td bgcolor="#fbfbfb" style="width: 189px">
                        <asp:TextBox runat="server" id="password" cssClass="textbox" width="140" textmode="password" />
                    </td>
                </tr>
                <tr>
                    <td width="80" bgcolor="#f7f7f7">
                        <span class="content2"></span>
                    </td>
                    <td bgcolor="#fbfbfb" style="width: 189px">
                        <asp:Button ID="Button1" runat="server" cssClass="submit" OnClick="ProcessLogin" Text="Login"/>
                    </td>
                </tr>
        </table>
    </div>
    <asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    </form>
</body>
</html>
