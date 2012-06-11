<%@ Control Language="C#" AutoEventWireup="true" CodeFile="recipeoftheday.ascx.cs" Inherits="recipeoftheday" EnableViewState="false"%>
  <div class="hpleft">
<span class="corange5">Recipe of the Day</span>
<br />
<asp:Label cssClass="cmaron12" runat="server" id="lbrecname" />
<br />
<span class="content8"><b>Ingredients:</b></span>
<br />
<asp:Label cssClass="content8" runat="server" id="lbingred" />
<br />
<span class="content8"><b>Instructions:</b></span>
<br />
<asp:Label cssClass="content8" runat="server" id="lbinstruct" EnableViewState="false" />
<br />
<span class="content8">Category:</span>&nbsp;<asp:HyperLink id="RanCat" cssClass="dt2" runat="server" EnableViewState="false" />
<br />
<span class="content8">Rating:&nbsp;<asp:Image id="rateimage" runat="server" ImageAlign="absmiddle" EnableViewState="false" />&nbsp;(<asp:Label cssClass="cgr" runat="server" id="lblrating" EnableViewState="false" />)&nbsp;votes&nbsp;<asp:Label cssClass="cyel" runat="server" id="lbvotes" EnableViewState="false" /></span>
<br />
<span class="content8">Hits:</span> <asp:Label cssClass="cmaron2" runat="server" id="lbhits" EnableViewState="false" />
<br />
<asp:HyperLink id="rdetails" cssClass="dt2" runat="server" EnableViewState="false" />
  </div>
