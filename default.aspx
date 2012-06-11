<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" EnableViewState="false" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="alphaletter" Src="Control/alphaletter.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="recipeoftheday" Src="Control/recipeoftheday.ascx" %>
<%@ Register TagPrefix="ucl" TagName="Controllastviewedrecipe" Src="Control/lastviewedrecipe.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articategorylistsidemenu" Src="Control/articategorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:newestarticle id="nart" runat="server"></ucl:newestarticle>
    <br />
    <ucl:articategorylistsidemenu id="artcat" runat="server"></ucl:articategorylistsidemenu>
    <br />
    <ucl:rsssidemenu id="rsscont" runat="server"></ucl:rsssidemenu>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="padding: 2px; text-align: left; margin-left: 40px; margin-bottom: 15px; margin-top: 16px; margin-right: 40px;">
    <asp:Image id="Myranimage" runat="server"
     Width = 107 Height = 74
     AlternateText = "Recipe Random Image" Style="float:left; padding-right: 5px;"
    />
    <span class="drecipe">
    You need a new dish in a hurry? Stumped by how to make that something special? We can help with your busy lifestyle. Take a look around and review our hundreds of free recipes or submit one of your own favorites.
    </span>
    </div>
    <br />
    <br />
    <div style="padding: 2px; text-align: center; margin-left: 26px; margin-bottom: 12px; margin-right: 26px;">
    <ucl:alphaletter id="alpha1" runat="server"></ucl:alphaletter>
    </div>
    <div style="text-align: center; padding-top: 3px;"><asp:Label cssClass="content2" runat="server" id="lbltotalRecipe" />
    </div>
    <br />
    <div style="text-align: center;  padding-bottom: 5px;"><span style="font-family: verdana,arial; font-size: 17px; color: #CC3300;"><b>Main Course Recipe</b></span></div>
    <asp:DataList id="MainCourseCategory" RepeatColumns="3" RepeatDirection="Horizontal" runat="server" HorizontalAlign="Center">
          <ItemTemplate>
         <div style="margin-left: 60px; margin-top: 3px; margin-bottom: 3px; margin-right: 10px;">  
    <span class="bluearrow">&raquo;</span> <a class="catlink" title="Browse all <%# Eval("Category") %> recipe" href='<%# Eval("CatID", "category.aspx?catid={0}") %>'><%# Eval("Category")%></a> <span class="catcount"><i>(<%# Eval("RecordCount")%>)</i></span>
           </div>
          </ItemTemplate>
      </asp:DataList>
      <br />
      <div style="clear:both;"></div>
      <div style="text-align: center;  padding-bottom: 5px;"><span style="font-family: verdana,arial; font-size: 17px; color: #CC3300;"><b>Ethnic &amp; Regional Cuisine</b></span></div>
    <asp:DataList id="EthnicRegionalCat" RepeatColumns="3" RepeatDirection="Horizontal" runat="server" HorizontalAlign="Center">
          <ItemTemplate>
         <div style="margin-left: 60px; margin-top: 3px; margin-bottom: 3px; margin-right: 10px;">  
    <span class="bluearrow">&raquo;</span> <a class="catlink" title="Browse all <%# Eval("Category") %> recipe" href='<%# Eval("CatID", "category.aspx?catid={0}") %>'><%# Eval("Category")%></a> <span class="catcount"><i>(<%# Eval("RecordCount")%>)</i></span>
           </div>
          </ItemTemplate>
      </asp:DataList>
      <div style="clear:both; margin-top: 16px;"></div>
     <!--Begin Today and last 8 hours recipe block--> 
      <div style="margin-left: 70px; margin-right: 70px; width: auto;">
    <ucl:recipeoftheday id="recday" runat="server"></ucl:recipeoftheday>
    <ucl:Controllastviewedrecipe id="lastviewed" runat="server"></ucl:Controllastviewedrecipe>
      </div>
       <!--End Today and last 8 hours recipe block---> 
</asp:Content>

