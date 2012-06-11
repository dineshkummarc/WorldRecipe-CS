<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="searcharticle.aspx.cs" Inherits="searcharticle" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articategorylistsidemenu" Src="Control/articategorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articlesearchtab" Src="Control/articlesearchtab.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articlesortoptionlinks" Src="Control/articlesortoptionlinks.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:newestarticle id="nart" runat="server"></ucl:newestarticle>
    <br />
    <ucl:articategorylistsidemenu id="artcat" runat="server"></ucl:articategorylistsidemenu>
    <br />
    <ucl:rsssidemenu id="rsscont" runat="server"></ucl:rsssidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:articlesearchtab id="searchcont" runat="server"></ucl:articlesearchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Home</a>&nbsp;<span class="bluearrow">»</span>&nbsp;
    <asp:Label cssClass="content2" id="lbcatname" runat="server" Font-Bold="True" /> <span class="content2"><asp:Label cssClass="content2" id="lbcount" runat="server" /></span>
    <asp:Label cssClass="content2" id="lblsortname" runat="server" Font-Bold="True" />
    </div>
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    <div style="margin-top: 32px; margin-left: 5px; margin-right: 5px;">
    <!--Begin sort category links-->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td align="left" style="width: 79%">
    <ucl:articlesortoptionlinks id="artsortoptlink" runat="server"></ucl:articlesortoptionlinks>
    </td>
        <td width="20%" align="right">
        <div style="margin-right: 20px;">
    <asp:label ID="lblRecpagetop" runat="server" cssClass="content2" />
    </div>
    </td>
      </tr>
    </table>
    <!--End sort category links-->
    </div>
    <div style="margin-bottom: 10px; border-top: solid 1px #D5E6FF; margin-right: 18px; margin-left: 9px;"></div>
    <asp:Label cssClass="content2" id="lblNorecordFound" Visible="false" runat="server" Font-Bold="True" />
    <div style="margin-left: 8px; margin-right: 180px; margin-top: 12px;">
    <asp:Repeater id="ArticleCat" OnItemDataBound="ArticleCat_ItemDataBound" runat="server">
         <ItemTemplate>
        <div class="divwrap">
           <div class="divhd">
    <img src="images/arrow.gif" alt="" />
    <a class="artcat" title="Read full details of <%# Eval("Title")%> article." href='<%# Eval("ID", "articledetail.aspx?aid={0}") %>'><%# Eval("Title") %></a> 
    <asp:Label ID="lblpopular" cssClass="hot" runat="server" EnableViewState="false" /> <asp:Image ID="newimg" runat="server" EnableViewState="false" /><asp:Image id="thumbsup" runat="server" AlternateText = "Thumsb up" EnableViewState="false" />
    </div> 
    <div class="divbd">
    <div style="margin-bottom: 3px;">
    <span class="content12"><%# Eval("Summary") %></span>
    </div>
    <div style="margin-bottom: 1px;">
    <span class="content16">
    Rating:&nbsp;<img src="images/<%# Eval("Rating", "{0:0.0}")%>.gif" />&nbsp;(<span class="cgr"><%# Eval("Rating", "{0:0.0}")%></span>) votes <span class="cyel"><%# Eval("NoRates")%></span>
    &nbsp;&nbsp;Hits: <span class="cmaron3"><%# Eval("Hits", "{0:#,###}")%></span>&nbsp;&nbsp;Posted: <span class="cyel"><%# Eval("Date", "{0:MMMM dd, yyyy}")%></span>
    &nbsp;&nbsp;Author:&nbsp;<%# Eval("Author") %>
    </span>
    </div>
    </div>
    <div style="margin: 15px;"></div>
          </ItemTemplate>
      </asp:Repeater>
    </div>
    <!--Begin Record count,page count and paging link-->
    <div style="margin-left: 12px; margin-top: 22px;">
    <asp:label ID="lblRecpage"
      Runat="server"
      cssClass="content2" EnableViewState="false" />
    <div style="margin-top: 10px;">
    <asp:Label cssClass="content2" id="lbPagerLink" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    </div>
    <!--End Record count,page count and paging link-->
    </asp:PlaceHolder>
</asp:Content>

