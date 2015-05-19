<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Website Administration</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="<%= ResolveUrl("~/UI/css/bootstrap.min.css")%>" type="text/css" />
    <link rel="stylesheet" href="<%= ResolveUrl("~/UI/css/bootstrap-responsive.min.css")%>" type="text/css" />
    <link rel="stylesheet" href="<%= ResolveUrl("~/UI/css/unicorn.main.css")%>" type="text/css" />
    <link rel="stylesheet" href="<%= ResolveUrl("~/UI/css/unicorn.grey.css")%>" class="skin-color" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="<%= ResolveUrl("~/UI/js/excanvas.min.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/UI/js/jquery.min.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/UI/js/jquery.ui.custom.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/UI/js/bootstrap.min.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/UI/js/unicorn.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/Scripts/Common.js")%>" type="text/javascript"></script>
   
</script> 
    <style type="text/css">
        #maincontent
        {   
            position: absolute;
            width: 100%;
            margin-top: -38px;
            z-index: 19;
            border-radius: 8px 8px 8px 8px;
            height:600px;
        }
        #perch
        {
            position: absolute;
            width: 100%;
            margin-top: -38px;
            
            z-index: 18;
            border-radius: 8px 8px 8px 8px;
            background-color:White;
            }
        body
        {
            overflow:hidden;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <h1>
            <a href="javascript:void(0)">Website Administration</a></h1>
    </div>
  
    <Custom:HeaderTool ID="HeaderTool" runat="server" />
    <Custom:LeftMenu ID="LeftMenu" runat="server"></Custom:LeftMenu>
   
    <div id="content">
        <iframe id="maincontent" src="../Main.aspx" name="maincontent" frameborder="0"></iframe>
        
    </div>
    </form>
</body>
</html>
