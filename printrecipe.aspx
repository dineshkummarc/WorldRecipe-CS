<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printrecipe.aspx.cs" Inherits="printrecipe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=strRName%></title>
    <link href="CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 50px;">
<table border="0" cellpadding="3" align="center" cellspacing="5" width="70%">
<tr>
    <td width="100%">
<asp:Label cssClass="cmaron4" ID="lblname" runat="server" />
<br />
</td>
  </tr>
  <tr>
    <td width="100%">
<b><asp:Label cssClass="content6" runat="server" id="lblingredientsdis" /></b>
<br />
<asp:Label cssClass="drecipe" ID="lblIngredients" runat="server" />
</td>
  </tr>
  <tr>
    <td width="100%">
<asp:Label cssClass="content6" runat="server" id="lblinstructionsdis" />
<br />
<asp:Label cssClass="drecipe" ID="lblInstructions" runat="server" />
</td>
  </tr>
  <tr>
    <td width="100%">
<div style="text-align: center;">
<a class="hlink" href="javascript:onClick=window.print()">Print Recipe</a>
</div>
</td>
  </tr>
</table>
</div>
    </form>
</body>
</html>
