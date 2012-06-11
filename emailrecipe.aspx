<%@ Page Language="C#" AutoEventWireup="true" CodeFile="emailrecipe.aspx.cs" Inherits="emailrecipe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sending <%=Request.QueryString["n"]%> Recipe to a Friend</title>
    <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server" Width="400">
<table align="center" cellspacing="0" cellpadding="0" width="100%">
<tr><td>
<br />
<div align="center"><h2>Sending <%=Request.QueryString["n"]%> Recipe to a Friend</h2></div>
<table border="0" cellspacing="1" cellpadding="1" width="100%">
  <tr>
    <td valign="top" align="right" class="content6"><b>Your Name:</b></td>
    <td>
      <asp:TextBox id="txtFromName" width="180" cssClass="textbox" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validNameRequired" ControlToValidate="txtFromName"
        cssClass="cred2" errormessage="* Name:<br />"
        display="Dynamic" />
    </td>
  </tr>
  <tr>
    <td valign="top" align="right" class="content6"><b>Your Email:</b></td>
    <td>
      <asp:TextBox id="txtFromEmail" width="180" cssClass="textbox" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validFromEmailRequired" ControlToValidate="txtFromEmail"
        cssClass="cred2" errormessage="* Email:<br />"
        display="Dynamic" />
      <asp:RegularExpressionValidator runat="server"
        id="validFromEmailRegExp" ControlToValidate="txtFromEmail"
        ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil)$"
        cssClass="cred2" errormessage="Not Valid"
        Display="Dynamic" />    
    </td>
  </tr>
<tr>
    <td valign="top" align="right" class="content6"><b>Friend's Name:</b></td>
    <td>
      <asp:TextBox id="toname" width="180" cssClass="textbox" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validFriendNameRequired" ControlToValidate="toname"
        cssClass="cred2" errormessage="* Name:<br />"
        display="Dynamic" />
    </td>
  </tr>
  <tr>
    <td valign="top" align="right" class="content6"><b>Friend's Email:</b></td>
    <td>
      <asp:TextBox id="txtToEmail" width="180" cssClass="textbox" runat="server" />
      <asp:RequiredFieldValidator runat="server"
        id="validToEmailRequired" ControlToValidate="txtToEmail"
        cssClass="cred2" errormessage="* Email:<br />"
        display="Dynamic" />
      <asp:RegularExpressionValidator runat="server"
        id="validToEmailRegExp" ControlToValidate="txtToEmail"
        ValidationExpression="^[\w-]+@[\w-]+\.(com|net|org|edu|mil)$"
        cssClass="cred2" errormessage="Not Valid:"
        Display="Dynamic" /> 
        <br />
        <asp:Button runat="server" Text="Submit" id="Sendrec" cssClass="submit" OnClick="SendingRecipe" /> 
    </td>
  </tr>
</table>
</td></tr>
</table>
</asp:Panel>
<div style="text-align: center;" class="content2"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="JavaScript:onClick= window.close()" class="content2">Close Window</asp:HyperLink></div>
<br />
<br />
<asp:Label cssClass="content2" id="lblsentmsg" runat="server" />
    </div>
    </form>
</body>
</html>
