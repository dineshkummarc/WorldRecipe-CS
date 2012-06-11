<%@ Page Language="C#" MasterPageFile="~/SiteTemplate2.master" AutoEventWireup="true" CodeFile="submitrecipe.aspx.cs" Inherits="submitrecipeform" Title="Submitting Recipe Form" %>
<%@ Register TagPrefix="ucl" TagName="rsssidemenu" Src="Control/rsssidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="newestarticle" Src="Control/newestarticle.ascx" %>
<%@ Register TagPrefix="ucl" TagName="sidemenu" Src="Control/sidemenu.ascx" %>
<%@ Register TagPrefix="ucl" TagName="searchtab" Src="Control/searchtab.ascx" %>

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
    &nbsp;&nbsp;<a href="default.aspx" class="dsort" title="Back to recipe homepage">Home</a>&nbsp;<span class="bluearrow">»</span>&nbsp;<a href="submitrecipecategory.aspx" class="dsort" title="Back to recipe submit category listing">Recipe Submit Category Listing</a>&nbsp;<span class="bluearrow">»</span>&nbsp; <span class="content2">You are here: Recipe Submission Form</span>
    </div>
    <!--Begin Insert Recipe Form-->
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="70%">
      <tr>
    <td width="68%">
    <div style="padding: 2px; text-align: left; margin-left: 1px; margin-right: 26px;">
    <br />
    <span class="content2">Fields mark with red asterisk (<span class="cred2">*</span>) are required</span>
    <asp:Label ID="lbvalenght" runat="server" Font-Bold="True" ForeColor="#C00000" Font-Names="Verdana" Visible="false" /> 
    </div>
    <fieldset><legend>Submitting a <asp:Label ID="lbcatname" runat="server" /> Recipe</legend>
     <div style="padding-top: 1px;">
    <table border="0" cellpadding="2" align="center" cellspacing="2" width="60%">
      <tr>
        <td width="26%"><span class="content2">Category:</span></td>
        <td width="74%">
    <span class="cmaron"><asp:Label ID="lbcatname2" cssClass="cmaron" runat="server" /></span>
    <input type="hidden" id="Category" name="Category" class="textbox" runat="server" />&nbsp;
    <input type="hidden" id="CAT_ID" name="CAT_ID" class="textbox" runat="server" />
    </td>
      </tr>
      <tr>
        <td width="26%"><span class="content2">Name:</span><span class="cred2">*</span></td>
        <td width="74%">
    <input type="text" id="Name" name="Name" class="textbox" size="30" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="Recipename" ControlToValidate="Name"
            cssClass="cred2" errormessage="* Recipe Name:<br />"
            display="Dynamic" />
    </td>
      </tr>
      <tr>
        <td width="1%"><span class="content2">Author:</span><span class="cred2">*</span></td>
        <td width="102%">
    <input type="text" id="Author" name="Author" size="25" class="textbox" runat="server" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="authorname" ControlToValidate="Author"
            cssClass="cred2" errormessage="* Author:<br />"
            display="Dynamic" />
    </td>
      </tr>
      <tr>
        <td width="26%" valign="top"><span class="content2">Ingredients:</span><span class="cred2">*</span></td>
        <td width="74%">
    <textarea runat="server" id="Ingredients" class="textbox" textmode="multiline" cols="70" rows="14" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="RecIngred" ControlToValidate="Ingredients"
            cssClass="cred2" errormessage="* Ingredients:<br />"
            display="Dynamic" />
    </td>
      </tr>
      <tr>
        <td width="26%" valign="top"><span class="content2">Instructions:</span><span class="cred2">*</span></td>
        <td width="74%">
    <textarea runat="server" id="Instructions" class="textbox" textmode="multiline" cols="70" rows="14" onFocus="this.style.backgroundColor='#FFFCF9'" onBlur="this.style.backgroundColor='#ffffff'" />
          <asp:RequiredFieldValidator runat="server"
            id="RecInstruc" ControlToValidate="Instructions"
            cssClass="cred2" errormessage="* Instructions:<br />"
            display="Dynamic" />
    </td>
      </tr>
        <tr>
        <td width="26%" valign="top"><span class="content2">Photo:<br />(Optional)</span></td>
        <td width="74%">
    <asp:FileUpload ID="RecipeImageFileUpload" runat="server" />&nbsp;<span class="content2"><br />Maximum Image size is 200 x 200 and less than 20,000 bytes.</span>
    </td>
      </tr>
      <tr>
        <td width="26%"></td>
        <td width="74%">
    <input type="text" class="textbox" ID="hd" name="hd" runat="server" style="visibility:hidden;">
    <br />
    <span class="content2">Security Code:</span>
    <br />
    <img height="30" alt="" src="imgsecuritycode.aspx" width="80"> 
    <br />
      <asp:Label ID="lblinvalidsecode" cssClass="cred2" runat="server" visible="false" />
     <asp:TextBox ID="txtsecfield" CssClass="textbox" runat="server" Width="70"></asp:TextBox>
       <asp:RequiredFieldValidator runat="server"
          id="reqSec" ControlToValidate="txtsecfield"
          cssClass="cred2"
          ErrorMessage = "Please enter the security code."
          display="Dynamic"> </asp:RequiredFieldValidator>
    <br /><br />
    <asp:Button runat="server" Text="Submit" id="AddComments" cssClass="submitadmin" OnClick="Add_Recipe" />
    </td>
      </tr>
    </table>
     </div>
    </fieldset>
    </td>
      </tr>
    </table>
    <asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    <!--End Insert Recipe Form-->
</asp:Content>

