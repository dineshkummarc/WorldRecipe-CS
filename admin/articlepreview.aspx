<%@ Page Language="C#" AutoEventWireup="true" CodeFile="articlepreview.aspx.cs" Inherits="admin_articlepreview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Article preview</title>
    <link href="../CSS/cssreciaspx.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 150px; margin-right: 150px;">
    <asp:Label font-names="verdana" font-size="9" ID="lblusername" runat="server" />
    <br />
    <fieldset><legend>Previewing Article</legend>
    <asp:Label ID="lbtitle" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
     <asp:Label ID="lbartdetail" runat="server" Text="Label"></asp:Label>
     </fieldset>
     <br />
     <asp:Button runat="server" Text="Submit" id="btn1" cssClass="submit" ToolTip="Click to finalize article submission" OnClick="Finalize_ArticleSubmission" />&nbsp;&nbsp;<asp:Button runat="server" Text="Edit"  ToolTip="Click to make changes to article." id="btn2" cssClass="submit" OnClick="Edit_Article" />
    </div>
    <asp:Literal id="JSLiteral" runat="server"></asp:Literal>
    </form>
</body>
</html>
