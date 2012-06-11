<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commentsmanager.aspx.cs" Inherits="admin_commentsmanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<title>Recipe Comment Manager - www.ex-designz.net</title>
    <link href="../CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" style="margin-top: 16px; margin-bottom: 1px;" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td width="100%" colspan="2">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td width="50%"><div style="padding-left: 20px;"><h3>Recipe Comments Manager</h3></div>
<div style="padding-left: 20px;"><asp:Label  Font-Names="verdana" font-size="9" ID="lblusername" runat="server" /></div>
<br />
</td>
  </tr>
</table>
</td>
  </tr> 
  <tr>
    <td width="21%" align="left" valign="top">
<!--Begin Admin Task Panel-->
<div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Admin Tasks Menu</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div class="divmenu2">
<asp:Label ID="lbCountRecipe" runat="server" />
<br />
<br />
<span class="bluearrow2">»</span>&nbsp;<a title="Back to recipe manager main page" href="recipemanager.aspx">Recipe Manager Main</a>
<br />
<br />
<asp:Image ID="img2" ImageAlign="AbsBottom" ImageURL="../images/commentadmin_icon.gif" AlternateTexT="Comment Manager" runat="server" />
<asp:HyperLink tooltip="Click this link to edit/delete recipe comments" runat="server" ID="countcommentlink" NavigateUrl="commentsmanager.aspx"><asp:Label ID="lbCountComments" runat="server" /></asp:HyperLink> 
</div>
</div>
</div>
<br />
<!--End Admin Task Panel-->
</td>
    <td width="79%" valign="top">
<!--Begin update edit form-->
<asp:Panel ID="Panel1" runat="server">
<div style="padding-left: 21px; width:46%;">
 <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><asp:Label ID="lblheaderform" cssClass="contadmin" runat="server" /></div>
</div>
<div class="contentdisplay3">
<div class="contentdis5">
<span class="content2">Author:</span>
<asp:TextBox runat="server" id="Author" cssClass="textbox" width="150" maxlenght="20" />
<input type="text" runat="server" id="KeyIDs" name="KeyIDs" class="textbox" size="3" maxlenght="3" readOnly="True" style="visibility:hidden;">     
<br />
<span class="content2">Email:</span>
&nbsp;&nbsp;<asp:TextBox runat="server" id="Email" cssClass="textbox" width="150" maxlenght="30" />
<br />
<span class="content2">Comment:</span>
<br />
<asp:TextBox runat="server" id="Comments" cssClass="textbox" textmode="multiline" columns="46" rows="5" />
<br />
<asp:Button runat="server" Text="Update" id="updatebutton" cssClass="submitadmin" onclick="Update_Comments" />
</div>
</div>
</div>
<br />
</asp:Panel>
<!--End update edit form-->
<table width="100%" border="0" cellspacing="1">
  <tr>
    <th scope="row"><div align="left">
     <asp:DataGrid runat="server" id="Recipes_table" cssclass="hlink" AutoGenerateColumns="False" 
     Backcolor="#ffffff" BorderStyle="none" BorderColor="#E1EDFF" cellpadding="5" Width="95%" HorizontalAlign="Center" PageSize="100" AllowPaging="True" OnPageIndexChanged="New_Page" OnItemDataBound="dgComment_ItemDataBound" DataKeyField="ID" OnDeleteCommand="Delete_Comment" onItemCommand="Edit_Handle"> 
     <HeaderStyle Font-Bold="True" BackColor="#B1D4EA" ForeColor="#ffffff" cssclass="header" />
     <AlternatingItemStyle BackColor="White" />                                   
     <Columns>
     <asp:ButtonColumn Text='<img border="0" src="../images/icon_edit.gif">' HeaderText="Edit" CommandName="edit" />
     <asp:ButtonColumn Text='<img border="0" src="../images/icon_delete.gif">' HeaderText="Delete" CommandName="Delete" />
     <asp:BoundColumn DataField="COM_ID" HeaderText="Key" SortExpression="COM_ID DESC" />  
     <asp:BoundColumn DataField="ID" HeaderText="Recipe ID#" SortExpression="ID ASC" />  
     <asp:BoundColumn DataField="Author" HeaderText="Author" SortExpression="Author ASC" />  
<asp:BoundColumn DataField="EMAIL" HeaderText="Email" SortExpression="EMAIL ASC" /> 
 <asp:BoundColumn DataField="Date" DataFormatString="{0:d}" HeaderText="Date" SortExpression="Date" />
<asp:BoundColumn DataField="COMMENTS" HeaderText="Comments" SortExpression="COMMENTS ASC" /> 
<asp:HyperLinkColumn HeaderText="Details" Text="View" DataNavigateUrlField="ID" DataNavigateUrlFormatString="../recipedetail.aspx?id={0}" target="_blank"/> 
     </Columns>
     <PagerStyle Mode="NumericPages" BackColor="#fcfcfc" HorizontalAlign="left" />
    </asp:DataGrid>                                                                                     
   </div></th>
 </tr>
</table>
</td>
  </tr>
</table>
<asp:Literal id="JSLiteral" runat="server"></asp:Literal>
</form>
<br />
<!--Begin Footer-->
<div class="footerwrap">
<br />
<img src="../images/returntop.gif" alt="return to top" align="absmiddle" border="0" /><a class="dt2" title="Return to top of the page" href="#Top">Return to top</a>
<br />
<span class="content2">
Copyright © 2000 - 2008 Ex-designz.net. All rights reserved. Developed By <a class="dt2" title="Website" href="http://www.ex-designz.net">Dexter Zafra - Ex-designz.net</a></span>
<br />
  <asp:HyperLink id="Powered" cssClass="dt2" ToolTip="Visit our portal website" NavigateURL="http://www.ex-designz.net" runat="server">Powered By Ex-designz.net World Recipe .NET version</asp:HyperLink>
 </div>
<!--End Footer-->
<br />
</body>
</html>
