<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="recipemanager.aspx.cs" Inherits="admin_recipemanager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Recipe Manager - XD World Recipe</title>
    <script type="text/javascript" src="../js/showimageajax.js"></script>
    <link href="../CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td width="100%" colspan="2">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
  <tr>
    <td width="100%" colspan="2" align="left">
<div style="padding-left: 20px;"><h3><a name="Top"></a>Recipe Manager</h3></div>
</td>
  </tr>
  <tr>
    <td width="23%" align="left">
<div style="padding-left: 20px;"><asp:Label font-names="verdana" font-size="9" ID="lblusername" runat="server" />
<br />
<asp:Button runat="server" id="logout" cssClass="submitadmin" tooltip="Logout" OnClick="LogoutButton_Click" Text="Logout"/>
<br />
<asp:Label font-names="verdana" font-size="9" ID="lblCurrentSort" Visible="false" runat="server" />
<asp:Label font-names="verdana" font-size="9" ID="lbsort" Visible="false" runat="server" />
</div>
</td>
    <td width="79%" align="left">
<div style="padding-left: 2px;"><asp:Label ID="lblSortedCat" font-names="verdana" font-size="9" runat="server" /> <asp:Label ID="lblrcdCatcount" font-names="verdana" font-size="9" runat="server" /> <asp:Label ID="lblsortorder" font-names="verdana" font-size="9" runat="server" /> <asp:Image id="orderimage" runat="server" visible="false" />
</div>
</td>
  </tr>
  <tr>
    <td width="100%" colspan="2">
      <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
          <td width="23%" align="left"></td>
          <td width="41%" align="left"><asp:Label ID="LblPageInfoTop" cssClass="content2" runat="server" />
<asp:Label Runat="server" ID="lbOrderBy" Visible="false"></asp:Label>
<asp:Label Runat="server" ID="lbDesc" Visible="false"></asp:Label>
<asp:Label ID="lblrecordperpageTop" cssClass="content2" runat="server" />
</td>
          <td width="38%" align="right">
<div style="padding-right: 25px; padding-bottom: 4px;">
<asp:Panel id="panel1" runat="server">
<span class="content2"><b>Sort Category:</b></span><asp:dropdownlist id="CategoryName" runat="server" cssClass="cselect" AutoPostBack="false"></asp:dropdownlist>
<asp:Button runat="server" ID="GO" OnClick="GetCatName_Click" cssclass="submitadmin" Text="Display"/>
</asp:Panel>
<asp:Label  ID="lblthese" font-names="verdana" font-size="9" runat="server" />
<asp:Label ID="lblunapproved2" font-names="verdana" font-size="9" runat="server" />
<asp:Label ID="lblthese2" font-names="verdana" font-size="9" runat="server" />
 </div>
   </td>
       </tr>
      </table>
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
<span class="bluearrow2">»</span>&nbsp;<asp:HyperLink runat="server" ID="lblmangermainpagelink" cssClass="dt" NavigateUrl="recipemanager.aspx"><asp:Label id="lblmangermainpage" runat="server" /></asp:HyperLink>
<br />
<span class="bluearrow2">»</span>&nbsp;<a class="dt" href="recipemanager.aspx?top=100" title="View the top 100 recipes by hits">View Top 100 Recipes</a>
<br />
<span class="bluearrow2">»</span>&nbsp;<a class="dt" href="recipemanager.aspx?img=1" title="Display recipe with photo">View Recipe With Photo</a>
<br />
<br />
<asp:Image ID="Image1" ImageAlign="AbsBottom" ImageURL="../images/commentadmin_icon.gif" AlternateText="Article Manager" runat="server" /><a class="dt" href="articlemanager.aspx" title="<%=ArticleCount%> Article - Add, edit and delete article">Article Manager: <%=ArticleCount%></a><br />
<br />
    <asp:Image ID="img1" ImageAlign="AbsBottom" ImageURL="../images/adminapproval_icon.gif" AlternateText="Aprroval Manager" runat="server" />
    <asp:HyperLink cssClass="dt" runat="server" ID="approvallink" NavigateUrl="recipemanager.aspx?tab=1"><asp:Label ID="lblunapproved" runat="server" /></asp:HyperLink>
<br />
<asp:Image ID="img2" ImageAlign="AbsBottom" ImageURL="../images/commentadmin_icon.gif" AlternateText="Comment Manager" runat="server" />
<asp:HyperLink tooltip="Click this link to edit/delete recipe comments" cssClass="dt" runat="server" ID="countcommentlink" NavigateUrl="commentsmanager.aspx"><asp:Label ID="lbCountComments" runat="server" /></asp:HyperLink>
<br />
<asp:Image ID="img3" ImageAlign="AbsBottom" ImageURL="../images/admincategory_icon.gif" AlternateText="Category Manager" runat="server" />
<asp:HyperLink tooltip="Click this link to edit/delete and add a recipe category" cssClass="dt" runat="server" ID="editcat" NavigateUrl="categorymanager.aspx"><asp:Label ID="lbCountCat" runat="server" /></asp:HyperLink>  
</div>
</div>
</div>
<br />
<!--End Admin Task Panel-->
<!--Begin Admin Page Record Panel-->
<div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Page Size Option</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="text-align: center; margin: 6px;">
<asp:Dropdownlist runat="server" ID="LstRecpage" AutoPostBack="True" OnSelectedIndexChanged="DisplayPagerecord_Click" cssClass="cselect" width="150px">
<asp:Listitem Value="40" selected>Default 40 Records</asp:Listitem>
<asp:Listitem Value="80">80 Records Per Page</asp:Listitem>
<asp:Listitem Value="120">120 Records Per Page</asp:Listitem>
<asp:Listitem Value="160">160 Records Per Page</asp:Listitem>
<asp:Listitem Value="200">200 Records Per Page</asp:Listitem>
<asp:Listitem Value="250">250 Records Per Page</asp:Listitem>
<asp:Listitem Value="300">300 Records Per Page</asp:Listitem>
</asp:Dropdownlist>
<br />
<asp:Label ID="lblrecordperpage" cssClass="content2" runat="server" />
</div>
</div>
</div>
<br />
<!--End Admin Page Record Panel-->
<!--Begin recipe name search panel-->
    <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Admin Recipe Name Search</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="margin: 12px;">
<img src="../images/search.gif" border="0" alt="Search recipe" align="absmiddle">
<asp:TextBox runat="server" id="find" cssClass="textboxsearch" width="130" />
&nbsp;<asp:Button runat="server" id="catsort" cssClass="submitadmin" tooltip="Go find it!" OnClick="AdminSearch_Click" Text="Search"/>
</div>
</div>
</div>
<div style="clear: both;"><br /></div>
<!--Begin last viewed panel-->
 <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Lastviewed Recipe in Days, Week &amp; Month Report</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="margin: 12px;">
<select class="cselect" name="lv" onchange="javascript:document.location = options[selectedIndex].value">
<option value="0" selected><%=lastviewedselectedvalue%></option>
<option value="recipemanager.aspx?lv=1">Today</option>
<option value="recipemanager.aspx?lv=2">2 days</option>
<option value="recipemanager.aspx?lv=3">3 days</option>
<option value="recipemanager.aspx?lv=4">4 days</option>
<option value="recipemanager.aspx?lv=5">5 days</option>
<option value="recipemanager.aspx?lv=6">6 days</option>
<option value="recipemanager.aspx?lv=7">1 week</option>
<option value="recipemanager.aspx?lv=14">2 weeks</option>
<option value="recipemanager.aspx?lv=30">1 month</option>
</select>
</div>
</div>
</div>
<!--End last viewed panel-->
<!--End recipe name search panel-->
<div style="clear: both;"><br /></div>
<!--Begin month search panel-->
 <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Admin Recipe Month Search</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="margin: 12px;">
<span class="content2">Year:</span><br /><asp:dropdownlist id="ddlyear" runat="server" cssClass="cselect" AutoPostBack="false"></asp:dropdownlist>
<br /><span class="content2">Month:</span><br /><asp:dropdownlist id="ddlmonth" runat="server" cssClass="cselect" AutoPostBack="false">
</asp:dropdownlist>
<asp:Button ID="bsdate" runat="server" cssClass="submitadmin" OnClick="AdminSearchByMonth_Click" Text="Submit" />
</div>
</div>
</div>
<!--End month search panel-->
<div style="clear: both;"><br /></div>
<!--Begin configured show/hide comment panel-->
    <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Show/Hide Comment</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="margin: 12px;">
<asp:dropdownlist id="ddlshowhide" runat="server" cssClass="cselect" AutoPostBack="false">
<asp:Listitem Value="1">Show Comment</asp:Listitem>
<asp:Listitem Value="2">Hide Comment</asp:Listitem>
</asp:dropdownlist>
&nbsp;<asp:Button runat="server" id="shd" cssClass="submitadmin" OnClick="AdminShowHideComment_Click" tooltip="Show/Hide comment" Text="Update"/>
</div>
</div>
</div>
<!--End configured show/hide comment panel-->
<div style="clear: both;"><br /></div>
<!--Begin configured last viewed hours panel-->
    <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Last Viewed Number of Hours</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="margin: 12px;">
<asp:dropdownlist id="ddllastviewedhours" runat="server" cssClass="cselect" AutoPostBack="false">
<asp:listitem Value="60">1 hour span</asp:listitem>
<asp:listitem Value="120">2 hours span</asp:listitem>
<asp:listitem Value="180">3 hours span</asp:listitem>
<asp:listitem Value="240">4 hour span</asp:listitem>
<asp:listitem Value="300">5 hours span</asp:listitem>
<asp:listitem Value="360">6 hours span</asp:listitem>
<asp:listitem Value="420">7 hours span</asp:listitem>
<asp:listitem Value="480">8 hour span</asp:listitem>
<asp:listitem Value="960">16 hours span</asp:listitem>
<asp:listitem Value="1860">23 hours span</asp:listitem>
</asp:dropdownlist>
&nbsp;<asp:Button runat="server" id="lvminute" cssClass="submitadmin" OnClick="AdminUpdateLastViewedHours_Click" tooltip="Change number of hours" Text="Update"/>
</div>
</div>
</div>
<!--End configured last viewed hours panel-->
<div style="clear: both;"><br /></div>
<!--Begin email SMTP configuration panel-->
    <div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenu"><span class="contadmin">Email Notification Settings</span></div>
</div>
<div class="contentdisplayadmin">
<div class="contentdis5">
<div style="margin: 12px;">
<div style="padding: 3px;">
<div style="margin-bottom: 16px">
These email addresses are use in the recipe submission and comment email notification. You need to change them into a valid email addresses.
</div>
From Email:<br />
<asp:TextBox runat="server" id="emailadd" cssClass="textboxsearch" width="180" />
</div>
<div style="padding: 3px;">
To Email:<br />
<asp:TextBox runat="server" id="smtpadd" cssClass="textboxsearch" width="180" />
</div>
<asp:Button runat="server" id="emailconfig" cssClass="submitadmin" tooltip="Update" Text="Update" OnClick="AdminUpdateEmailAndSMTPAddress_Click" />
</div>
</div>
</div>
<!--End email SMTP configuration panel-->
</td>
    <td width="79%" valign="top">
<!--Begin Alphabet Letter links-->
<div style="margin-left: 24px; margin-right: 25px;">
<div class="nifty">
<b class="rtop"><b class="r1"></b><b class="r2"></b><b class="r3"></b><b class="r4"></b></b>
<div class="dcntmenuadmin"><img src="../images/arroworange.gif" />&nbsp;<asp:Label id="lblletterlegend" cssClass="corange" runat="server" />&nbsp;<asp:Label id="lblalphaletter" runat="server" /></div>
</div>
</div>
<!--End Alphabet Letter links-->
<!--Begin display datagrid-->
<asp:DataGrid runat="server" id="dgrd_recipe" cssclass="hlink" AutoGenerateColumns="False" AllowSorting="true"
     Backcolor="#ffffff" BorderStyle="none" BorderColor="#E1EDFF" cellpadding="5" Width="95%" HorizontalAlign="Center"  onSortCommand="Recipes_SortCommand" AllowPaging="True" AllowCustomPaging="true" OnPageIndexChanged="New_Page" OnItemDataBound="dgRecipe_ItemDataBound" DataKeyField="ID" OnDeleteCommand="Delete_Recipes" onItemCommand="Edit_Handle"> 
     <HeaderStyle Font-Bold="True" BackColor="#CEE76D" cssclass="header" />
     <AlternatingItemStyle BackColor="White" />                                  
     <Columns>    
     <asp:BoundColumn DataField="ID" HeaderText="ID" SortExpression="ID" />   
     <asp:BoundColumn DataField="Name" HeaderText="Recipe Name" SortExpression="Name" />
     <asp:BoundColumn DataField="RecipeImage" HeaderText="Photo" SortExpression="RecipeImage" />
     <asp:BoundColumn DataField="Category" HeaderText="Category" SortExpression="Category" />    
     <asp:BoundColumn DataField="Author" HeaderText="Author" SortExpression="Author" />
     <asp:BoundColumn DataField="Date" DataFormatString="{0:d}" HeaderText="Date" SortExpression="Date" />
     <asp:BoundColumn DataField="Hits" HeaderText="Hits" SortExpression="Hits" />
     <asp:ButtonColumn Text='<img border="0" src="../images/icon_edit.gif">' HeaderText="Edit" CommandName="edit" />
     <asp:ButtonColumn Text='<img border="0" src="../images/icon_delete.gif">' HeaderText="Delete" CommandName="Delete" />
     </Columns>
     <PagerStyle Mode="NumericPages" BackColor="#fcfcfc" HorizontalAlign="left" />
    </asp:DataGrid>
<!--End display datagrid-->
<!--Begin display pager button-->
<div style="margin-left: 28px; margin-right: 20px; margin-top: 5px; background-color: #fff; padding-left: 2px; padding-top: 1px;">
<asp:Linkbutton id="Firstbutton" Text='<img border="0" src="../images/firstpage.gif" align="absmiddle">' CommandArgument="0" runat="server" OnCommand="FooterPagerClick"/>&nbsp;
<asp:linkbutton id="Prevbutton" Text='<img border="0" src="../images/prevpage.gif" align="absmiddle">' CommandArgument="prev" runat="server" OnCommand="FooterPagerClick"/>&nbsp;
<asp:linkbutton id="Nextbutton" Text='<img border="0" src="../images/nextpage.gif" align="absmiddle">' CommandArgument="next" runat="server" OnCommand="FooterPagerClick"/>&nbsp;
<asp:linkbutton id="Lastbutton" Text='<img border="0" src="../images/lastpage.gif" align="absmiddle">' CommandArgument="last" runat="server" OnCommand="FooterPagerClick"/>&nbsp;&nbsp;
<asp:Label ID="LblPageInfo" cssClass="content2" runat="server" />
<asp:Label ID="lblrcdCatcountfooter" cssClass="content2" runat="server" /> <asp:Label ID="lbCountRecipeFooter" cssClass="content2" runat="server" /> <asp:Label ID="lblrcdalphaletterfooter" cssClass="content2" runat="server" />&nbsp;&nbsp;<asp:Label ID="lblrecordperpageFooter" cssClass="content2" runat="server" />
</div>
<!--End display pager button-->         
</td>
  </tr>
</table>
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
