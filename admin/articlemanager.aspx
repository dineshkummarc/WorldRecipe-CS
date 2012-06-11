<%@ Page Language="C#" AutoEventWireup="true" CodeFile="articlemanager.aspx.cs" Inherits="admin_articlemanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>XD World Recipe Article Manager</title>
    <link href="../CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td width="21%" align="left" valign="top">
    <div style="margin-left: 5px;">
        <h3>Article Manager</h3>
<div><asp:Label font-names="verdana" font-size="9" ID="lblusername" runat="server" /></div>
</div>
</td>
    <td width="79%"></td>
  </tr>
  <tr>
    <td width="21%" align="left" valign="top">
<!--Begin Admin Task Panel-->
<div style="margin-top: 20px; margin-left: 5px;">
 <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Admin Tasks Menu</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div class="divmenu2">
<asp:Label ID="lbCountArticle" runat="server" />
<br />
<br />
<span class="bluearrow2">»</span>&nbsp;<a title="Back to recipe manager page" href="recipemanager.aspx">Recipe Manager</a>
<br />
<br />
<span class="bluearrow2">»</span>&nbsp;<a title="Back to article category manager default view" href="articlemanager.aspx">Default View</a>
<br />
<br />
<asp:Image ID="img4" ImageAlign="AbsBottom" ImageURL="../images/addnewcategoryimg.gif" AlternateText="Click this link to Add a New article Category" runat="server" />
<a title="Click This link to add new article category" href="articlemanager.aspx#this"
  ID="AddNewCategory"
  onserverclick="ChangeToAddCat"
  runat="server">Add New Article Category</a> 
  <br />
  <br />
  <img src="../images/addnewcategoryimg.gif" /><a href="articlemanager.aspx?showeditdellink=1">Edit/Delete Article Category</a>
</div>
</div>
</div>
</div>
<br />
<!--End Admin Task Panel-->
</td>
    <td width="79%" align="left" valign="top">
        <div style="margin-left: 20px; width: 700px; margin-top: 20px;">
        <asp:Panel ID="Panel2" runat="server" Width="500px">
        <div style="width:400px">
 <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><asp:Label ID="lblheaderform" cssClass="contadmin" runat="server" /></div>
</div>
<div class="contentdisplay3">
<div class="contentdis5">
<asp:Label ID="lblnamedis2" cssClass="content2" runat="server" />
<asp:TextBox runat="server" id="CategoryName" cssClass="textbox" width="200px" maxlenght="18" />
<asp:Button runat="server" Text="Update" id="updatebutton" tooltip="Click to update" cssClass="submitadmin" OnClick="Update_Category" />
<asp:Button runat="server" Text="Add" tooltip="Click to add new category" id="AddNewCat" cssClass="submitadmin" OnClick="Add_Category"/>
<input type="text"  runat="server" id="CategoryID" name="CategoryID" class="textbox" size="2" maxlenght="2" readOnly="True" style="visibility:hidden;">
<br />
<asp:Panel ID="Panel3" runat="server">
<div style="padding-top: 4px; padding-bottom: 6px;">
<span class="content2">
<span class="cred">Are you sure you want to delete this category?
<br />
Note: all article belong to this category will be deleted as well.
</span>
<br />
<asp:Button runat="server" Text="Delete" tooltip="Click to delete category and its associated recipes" id="DelCategory" cssClass="submitadmin" />
</span>
</div>
</asp:Panel>
</div>
</div>
<br />
</div>
</asp:Panel>
<asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    <fieldset><legend>Adding Article Category Listing</legend>
    <span class="content12">Select a category</span>
    <asp:Repeater id="ArtCategoryList" runat="server" OnItemDataBound="ArtCategoryList_ItemDataBound" OnItemCommand="Delete_Category">
   <ItemTemplate>
<div class="dcnt2">
<asp:HyperLink id="editbutton2" NavigateUrl='<%# "articlemanager.aspx?editcatid=" + Eval("CAT_ID") + "&catname=" + Eval("CAT_NAME") %>' Text="Edit" ToolTip="Edit this category" cssClass="dsort" runat="server" />&nbsp;&nbsp;<asp:LinkButton id="delbutton2" ToolTip="Delete this category" Text="Delete" cssClass="dsort" runat="server" CommandName='Delete' CommandArgument='<%# Eval("CAT_ID") %>'/><img src="../images/arrow.gif" alt="" /><a class="dtcat" title="Add an article in <%# Eval("CAT_NAME") %> category." href='<%# Eval("CAT_ID", "addarticle.aspx?catid={0}") %>'><%# Eval("CAT_NAME") %></a>
</div>
   </ItemTemplate>
  </asp:Repeater>
    </fieldset>
    </div>
    <div style="margin-left: 20px; width: 700px; margin-top: 20px;">    
    <fieldset><legend>Updating Article Category Listing</legend>
    <span class="content12">Select a category</span>
    <asp:Repeater id="AdminUpdateArtCatList" runat="server">
   <ItemTemplate>
<div class="dcnt2">
<img src="../images/arrow.gif" alt="" /><a class="dtcat" title="Update an article in <%# Eval("CAT_NAME") %> category" href='<%# Eval("CAT_ID", "articlemanager.aspx?catid={0}") %>'><%# Eval("CAT_NAME") %> (<%# Eval("REC_COUNT") %>)</a>
</div>
   </ItemTemplate>
  </asp:Repeater>
    </fieldset>    
    </div>
    <div style="margin-left: 20px; width: 700px; margin-top: 20px;">  
    <asp:Panel ID="Panel1" runat="server" Width="700px">
    <fieldset><legend><asp:Label font-names="verdana" ID="lbcatname" runat="server" /> Category</legend>
    <asp:Literal id="Error" runat="server"></asp:Literal>
    <asp:Repeater id="ArticleCat" runat="server" OnItemDataBound="ArticleCat_ItemDataBound" OnItemCommand="Delete_Article">
      <ItemTemplate>
    <div class="divwrap">
       <div class="divhd">
<a class="dsort" title="Edit (<%# Eval("Title") %>) article." href='<%# Eval("ID", "updatearticle.aspx?aid={0}") %>&show=<%=ArticleUpdateSection%>'>Edit</a> - <asp:LinkButton id="delbutton" ToolTip="Delete this article" Text="Delete" cssClass="dsort" runat="server" CommandName='Delete' CommandArgument='<%# Eval("ID") %>'/> - <%# DataBinder.Eval(Container.DataItem, "Title")%> ID#: <%# DataBinder.Eval(Container.DataItem, "ID")%> 
</div>
</div>
<div style="margin: 15px;"></div>
      </ItemTemplate>
  </asp:Repeater>
  </fieldset> 
    </asp:Panel>
    </div>
</td>
  </tr>
</table>
    </form>
</body>
</html>
