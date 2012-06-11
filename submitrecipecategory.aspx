<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="submitrecipecategory.aspx.cs" Inherits="submitrecipecategory" Title="Submitting A Recipe" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newesttoprecipes" Src="Control/newesttoprecipes.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:newestarticle id="nart" runat="server"></ucl:newestarticle>
    <br />
    <ucl:rsssidemenu id="rsscont" runat="server"></ucl:rsssidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Home</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">You are here: Recipe Submit Category Listing</span>
    </div>
    <!--Begin Category Name Listing-->
    <br />
    <div style="padding: 2px; text-align: center; margin-left: 26px; margin-right: 26px;">
    <span class="corange">To submit a recipe. Choose a cetegory below where your recipe belong.</span>
    </div>
    <br />
    <asp:DataList id="RecipeCat" RepeatColumns="3" RepeatDirection="Horizontal" runat="server" HorizontalAlign="Center">
          <ItemTemplate>
           <div style="margin-left: 60px; margin-top: 3px; margin-bottom: 3px; margin-right: 10px;">
    <span class="bluearrow">&raquo;</span> <a class="catlink" title="Click this link to add a recipe in <%# Eval("Category") %> category" href='<%# Eval("CatID", "submitrecipe.aspx?catid={0}") %>'><%# Eval("Category")%></a> 
           </div>
          </ItemTemplate>
      </asp:DataList>
    <!--End Category Name Listing-->
</asp:Content>

