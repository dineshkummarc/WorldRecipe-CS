<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" EnableViewState="false" AutoEventWireup="true" CodeFile="articledetail.aspx.cs" Inherits="articledetail" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articategorylistsidemenu" Src="Control/articategorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="articlesearchtab" Src="Control/articlesearchtab.ascx" %>

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
    <div style="text-align: left; margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-bottom: 10px;">&nbsp;
                            <a class="dsort" title="Back to recipe homepage" href="default.aspx">Home</a>
                           <span class="bluearrow">»</span>
                         <a class="dsort" href="articlecategory.aspx?&catid=<%=ArtCatId%>" title="Browse <%=strCatName%> cooking article category"><%=strCatName%></a>
                      </div>                
    <asp:PlaceHolder id="PlaceHolder2" runat="server">
    <div style="margin-left: 25px; margin-right: 25px; margin-top: 25px;">
        <h1><asp:Label ID="lbtitle" runat="server"></asp:Label></h1>
        <div style="margin-bottom: 2px;">
        <span class="content2">Author:&nbsp;<asp:Label ID="lbauthor" CssClass="content2" runat="server" />&nbsp;&nbsp;Date Posted:&nbsp;<asp:Label runat="server" id="lbldate" cssClass="cyel" />&nbsp;&nbsp;Hits:&nbsp;<asp:Label ID="lbhits" CssClass="cmaron3" runat="server" />
        &nbsp;&nbsp;Rating:&nbsp;<asp:Image id="starimage" runat="server" />&nbsp;(<asp:Label cssClass="cgr" runat="server" id="lblrating" />) votes <asp:Label cssClass="cyel" runat="server" id="lblvotescount" />&nbsp;&nbsp;Word Count:&nbsp;<asp:Label ID="lblwordcount" CssClass="cmaron3" runat="server" /></span>
        <br />
        <img src="images/save_icon.gif" align="absmiddle" alt="Save/Add <%=strArtTitle%> recipe to your favorite"> 
    <a class="dt" title="Save/Add <%=strArtTitle%> article to favorite" href="javascript:bookmark('<%=strArtTitle%> Article', '<%=strBookmarkURL%>')">Save to favorite</a>&nbsp;&nbsp;
    <img src="images/print_icon.gif" align="absmiddle" alt="Print <%=strArtTitle%> recipe"> 
    <a class="dt" title="Print <%=strArtTitle%> article" href="#" onClick="window.open('printarticle.aspx?aid=<%=Request.QueryString["aid"]%>','','width=750,height=600,scrollbars=yes,resizable=yes,status=no,left=180,top=180'); return false;">Print this article</a>&nbsp;&nbsp;
    <img src="images/email_icon.gif" align="absmiddle" alt="Email <%=strArtTitle%> article to a friend"> 
    <a class="dt" title="Email <%=strArtTitle%> recipe to friend" href="#" onClick="window.open('emailarticle.aspx?aid=<%=Request.QueryString["aid"]%>&amp;n=<%=strArtTitle%>','','width=400,height=200,status=no,left=400,top=400'); return false;">Email this article</a>
        </div>
        <div style="margin-bottom: 8px;">
    <asp:Panel ID="Panel2" runat="server" Height="50px" Width="220px">
    &nbsp;&nbsp;<b><span id="link<%=Request.QueryString["aid"]%>" class="cgr">Rate this article</span></b>
    <ul class="srating">
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Poor - 1 star'"  onmouseout="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Rate this article'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["aid"]%>&amp;rateval=1&amp;wp=<%=ArticleSection%>';" title='Rate article: Not sure - 1 star' class='onestar'>1</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Fair - 2 stars'" onmouseout="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Rate this article'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["aid"]%>&amp;rateval=2&amp;wp=<%=ArticleSection%>';" title='Rate article: Fair - 2 stars' class='twostars'>2</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Interesting - 3 stars'" onmouseout="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Rate this article'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["aid"]%>&amp;rateval=3&amp;wp=<%=ArticleSection%>';" title='Rate article: Interesting - 3 stars' class='threestars'>3</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Good - 4 stars'" onmouseout="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Rate this article'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["aid"]%>&amp;rateval=4&amp;wp=<%=ArticleSection%>';" title='Rate article: Very good - 4 stars' class='fourstars'>4</a></li>
    <li><a href="#" onmouseover="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Excellent - 5 stars'" onmouseout="document.getElementById('link<%=Request.QueryString["aid"]%>').innerHTML='Rate this article'" onclick="javascript:top.document.location.href='rate.aspx?id=<%=Request.QueryString["aid"]%>&amp;rateval=5&amp;wp=<%=ArticleSection%>';" title='Rate article: Excellent - 5 stars' class='fivestars'>5</a></li>
    </ul>
    </asp:Panel>
     </div>
        <div style="margin-top: 4px; margin-right: 50px;">
         <asp:Label ID="lbcontent" runat="server"></asp:Label>
         </div>
    </div>
    </asp:PlaceHolder>
</asp:Content>

