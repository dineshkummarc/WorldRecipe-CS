<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articlesortoptionlinks.ascx.cs" Inherits="articlesortoptionlinks" EnableViewState="false"%>
<div class="divsort">
<img src="images/tlcorner.gif" alt="" class="cor2" align="top">
<div style="text-align: left; padding-left: 6px; height: 18px; width: 420px;">
<span class="sortcat">Sort Option:</span>&nbsp;
<asp:HyperLink id="LinkMostPopular" cssClass="dsort" runat="server" /> <asp:Image id="ArrowImage1" runat="server" />&nbsp;&nbsp;|&nbsp;&nbsp;
<asp:HyperLink id="LinkHighestRated" cssClass="dsort" runat="server" /> <asp:Image id="ArrowImage2" runat="server" />&nbsp;&nbsp;|&nbsp;&nbsp;
<asp:HyperLink id="LinkNewest" cssClass="dsort" runat="server" /> <asp:Image id="ArrowImage4" runat="server" />&nbsp;&nbsp;|&nbsp;&nbsp;
<asp:HyperLink id="LinkName" cssClass="dsort" runat="server" /> <asp:Image id="ArrowImage3" runat="server" />
</div>
</div>
