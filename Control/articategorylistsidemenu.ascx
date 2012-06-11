<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articategorylistsidemenu.ascx.cs" Inherits="articategorylistsidemenu" EnableViewState="false"%>
<!--Begin Article Category Listing with Count Side Panel-->
<div class="niftyora">
<b class="rtopora"><b class="rora1"></b><b class="rora2"></b><b class="rora3"></b><b class="rora4"></b></b>
<div class="dcntora"><span class="content3">Browse Article Categories</span></div></div>
<div class="contentdisplayora">
<div class="contentdis5">
<asp:Repeater id="ArtCategoryList" runat="server">
   <ItemTemplate>
<div class="dcnt2">
<span class="cyel">&raquo;</span> <a class="dt" title="Browse <%# Eval("Category") %> article category" href='<%# Eval("CatID", "articlecategory.aspx?catid={0}") %>'><%# Eval("Category") %></a> <span class="content15">(<%# Eval("RecordCount")%>)</span>
</div>
   </ItemTemplate>
  </asp:Repeater>
</div>
</div>
<!--End Article Category Listing with Count Side Panel-->
