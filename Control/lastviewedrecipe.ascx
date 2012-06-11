<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lastviewedrecipe.ascx.cs" Inherits="Controllastviewedrecipe" EnableViewState="false"%>
    <div class="hpright">
    <span class="hdgr">Most Viewed in the Last <asp:Label cssClass="hdgr" runat="server" id="lbgethour" /> Hours</span>
    <br />
    <asp:Repeater id="lastview" runat="server" OnItemDataBound="lastview_ItemDataBound" EnableViewState="false">
   <ItemTemplate>
<div class="dcnt2">
<asp:Label ID="lbseqnumber" cssClass="cgr2" runat="server"></asp:Label> <a class="dt" title="Category (<%# Eval("Category") %>) - Hits (<%# Eval("Hits") %>) Viewed: (<%# Eval("Hours") %> hr., <%# Eval("Minutes") %> min.) ago." href='<%# Eval("ID", "recipedetail.aspx?id={0}") %>'>
<%# Eval("RecipeName") %></a>
<br />
</div>
      </ItemTemplate>
  </asp:Repeater>
  </div>
