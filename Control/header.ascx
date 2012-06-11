<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="header" EnableViewState="false"%>
<!--Begin Header-->
<a name="Top"></a>
<div class="headerwrap">
<div class="headerlogoleft"><a title="Myasp-net.com" href="default.aspx"><img src="images/recipelogo.gif" width="357" height="70" border="0" alt="Myasp-net.com" /></a></div>
<div class="headerright">
<div class="headerrightmenu">
<span class="content2">
<a class="dt" title="About us" href="http://www.myasp-net.com/index.aspx?tabindex=1">About us</a>&nbsp;&#x2022;&nbsp;<a class="dt" title="Website feedback" href="http://www.myasp-net.com/index.aspx?tabindex=6">Contact us</a>&nbsp;&#x2022;&nbsp;<a class="dt" title="Site Map" href="http://www.ex-designz.net/resources.asp">Site Map</a>&nbsp;&#x2022;&nbsp;<a class="dt" title="Web services" href="http://www.myasp-net.com">Web Development</a>
</span>
</div>
<div class="headerrightdatetime"><span class="chdate"><%=DateTime.Now.ToString("f")%></span></div>
</div>
</div>
<div style="clear:both;"></div>
<!--End Header-->