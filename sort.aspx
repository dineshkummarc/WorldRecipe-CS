<%@ Page Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="sort.aspx.cs" Inherits="recipesorting" Title="Untitled Page" %>
<%@ Register TagPrefix="ucl" TagName="alphaletter" Src="Control/alphaletter.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sortoptionlinks" Src="Control/sortoptionlinks.ascx" %>
<%@ Register TagPrefix="ucl" TagName="categorylistsidemenu" Src="Control/categorylistsidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LeftPanel" Runat="Server">
    <ucl:sidemenu id="menu1" runat="server"></ucl:sidemenu>
    <div style="clear: both;"></div>
    <ucl:categorylistsidemenu id="catlistcont" runat="server"></ucl:categorylistsidemenu>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <ucl:searchtab id="searchcont" runat="server"></ucl:searchtab>
    <div style="margin-left: 10px; margin-right: 12px; background-color: #FFF9EC; margin-top: 0px;">
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Home</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2"><asp:Label cssClass="content2" id="lblcount" runat="server" EnableViewState="false" /></span>
    <asp:Label cssClass="content2" id="lblsortname" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    <div style="padding: 2px; margin-bottom: 14px; margin-top: 12px; margin-left: 16px; margin-right: 26px;">
    <ucl:alphaletter id="alpha1" runat="server"></ucl:alphaletter>
    <br />
    </div>
    <!--Begin Center Container-->
    <asp:PlaceHolder id="PlaceHolder1" runat="server">
    <div style="margin-left: 5px; margin-right: 5px;">
    <!--Begin sort category links-->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
      <tr>
        <td align="left" style="width: 79%">
    <ucl:sortoptionlinks id="opt1" runat="server"></ucl:sortoptionlinks>
    </td>
        <td width="20%" align="right">
        <div style="margin-right: 20px;">
    <asp:label ID="lblRecpagetop" runat="server" cssClass="content2" EnableViewState="false" />
    </div>
    </td>
      </tr>
    </table>
    <!--End sort category links-->
    <div style="float: right; text-align: right; margin-right: 18px;">
    <select name="urllayout" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=SelectedValuePrefLayout%>
    </option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=<%=psPageSize%>&layout=1" >Rows</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=<%=psPageSize%>&layout=2">Grid 2 Columns</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=<%=psPageSize%>&layout=3">Grid 3 Columns</option>
    </select>
    <select name="url" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=psPageSize + " Records Page"%>
    </option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=10&layout=<%=pLayout%>">10 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=20&layout=<%=pLayout%>">20 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=30&layout=<%=pLayout%>">30 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=40&layout=<%=pLayout%>">40 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=50&layout=<%=pLayout%>">50 Records Page</option>
    </select>
    </div>
    <div style="margin-bottom: 10px; border-top: solid 1px #D5E6FF; margin-right: 18px; margin-left: 4px;"></div>
    <div style="clear: both;"></div>
    <!--Begin repeater center content-->
    <asp:DataList id="RecipeSort" OnItemDataBound="RecipeSortItemDataBound" RepeatDirection="Horizontal" runat="server" EnableViewState="false">
          <ItemTemplate>
        <div class="divwrap5">
           <div class="divhd">
    <img src="images/arrow7.gif" alt="" />
    <a class="dtcat" title="View <%# Eval("RecipeName")%> recipe" href='<%# Eval("ID", "recipedetail.aspx?id={0}") %>'><%# Eval("RecipeName") %></a>
    <asp:Label ID="lblpopular" cssClass="hot" runat="server" EnableViewState="false" /> <asp:Image ID="newimg" runat="server" EnableViewState="false" /><asp:Image id="thumbsup" runat="server" AlternateText = "Thumsb up" EnableViewState="false" /> 
    </div> 
    <div class="divbd">
    Category:&nbsp;<a class="dt2" title="Go to <%# Eval("Category") %> category" href='<%# Eval("CatID", "category.aspx?catid={0}") %>'><%# Eval("Category") %></a>
    <br />
    Submitted by:&nbsp;<%# Eval("Author") %>
    <br />
    Rating:&nbsp;<img src="images/<%# Eval("Rating", "{0:0.0}")%>.gif" align="absmiddle" />&nbsp;(<span class="cgr"><%# Eval("Rating", "{0:0.0}")%></span>) votes <span class="cyel"><%# Eval("NoRates")%></span>
    <br />
    Added: <span class="cyel"><%# Eval("Date", "{0:M/d/yyyy}")%></span>
    <br />
    Hits: <span class="cmaron3"><%# Eval("Hits", "{0:#,###}")%></span>
        </div>
    </div>
    <div style="margin: 15px;"></div>
          </ItemTemplate>
      </asp:DataList>
      </div>
      <!--Begin repeater center content-->
    <!--End Center Container-->
    <!--Begin Record count,page count and paging link-->
    <div style="margin-left: 12px; margin-top: 22px;">
    <asp:label ID="lblRecpage" runat="server" cssClass="content2" EnableViewState="false" /><asp:label ID="lbps" runat="server" cssClass="content2" EnableViewState="false" />
    <div style="margin-top: 10px;">
    <asp:Label cssClass="content2" id="lbPagerLink" runat="server" Font-Bold="True" EnableViewState="false" />
    </div>
    </div>
    <!--End Record count,page count and paging link-->
    </asp:PlaceHolder>
    <span class="content2">Pagesize:</span>&nbsp;<select name="url2" class="ddlps" onchange="javascript:document.location = options[selectedIndex].value">
    <option selected>
    <%=psPageSize + " Records Page"%>
    </option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=10&layout=<%=pLayout%>">10 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=20&layout=<%=pLayout%>">20 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=30&layout=<%=pLayout%>">30 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=40&layout=<%=pLayout%>">40 Records Page</option>
    <option value="sort.aspx?sid=<%=psOrderBy%>&ob=<%=psOrderBy%>&sb=<%=psSortBy%>&page=<%=psPageIndex%>&ps=50&layout=<%=pLayout%>">50 Records Page</option>
    </select>
</asp:Content>

