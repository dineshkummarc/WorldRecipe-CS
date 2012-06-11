<%@ Control Language="C#" AutoEventWireup="true" CodeFile="newestarticle.ascx.cs" Inherits="newestarticle" EnableViewState="false"%>
<!--Begin Display Newest Article Right Side Panel-->
<div class="niftyora">
<b class="rtopora"><b class="rora1"></b><b class="rora2"></b><b class="rora3"></b><b class="rora4"></b></b>
<div class="dcntora"><span class="content3"><asp:Label ID="lbTopCount" cssClass="content3" runat="server" EnableViewState="false" />&nbsp;Newest Cooking Articles</span></div></div>
<div class="contentdisplayora">
<div class="contentdis5">
<asp:Repeater id="NewArticlesSidePanel" runat="server" OnItemDataBound="NewArticlesSidePanel_ItemDataBound" EnableViewState="false">
   <ItemTemplate>
<div class="dcnt2" style="border-bottom: 1px solid #f0f0f0; padding-bottom: 3px; padding-top: 3px;">
<a class="dt" title="Category (<%# Eval("Category") %>) - Hits (<%# Eval("Hits") %>) - <%# Eval("Date", "{0:M/d/yyyy}")%>" href='<%# Eval("ID", "articledetail.aspx?&aid={0}") %>'><%# Eval("Title") %></a>
<br />
<span class="content2"><asp:Label cssClass="content2" ID="lblgetdate" runat="server" /></span>
</div>
   </ItemTemplate>
  </asp:Repeater>
</div>
</div>
<!--End Display Newest Article Right Side Panel-->