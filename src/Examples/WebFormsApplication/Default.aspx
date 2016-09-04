<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApplication._Default" %>
<%@ Import Namespace="WebFormsApplication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <title>Example WebForms Application</title>
</head>
<body>
    <p>Single digits</p>
    <p>
        The application assembly is: <strong><%= Global.ApplicationAssemblyDetails.ApplicationAssembly %></strong>
    </p>
    <p>
        The application bin folder is: <strong><%= Global.ApplicationAssemblyDetails.BinFolder %></strong>
    </p>
    <p>
        The application version number is: <strong><%= Global.ApplicationAssemblyDetails.VersionNumber %></strong>
    </p>
    <p>
        This application was built in <strong><%= Global.ApplicationAssemblyDetails.BuildMode %></strong> mode.
    </p
    
        <p>Double digits</p>
          <p>
        The application assembly is: <strong><%= Global.ApplicationAssemblyDetails00.ApplicationAssembly %></strong>
    </p>
    <p>
        The application bin folder is: <strong><%= Global.ApplicationAssemblyDetails00.BinFolder %></strong>
    </p>
    <p>
        The application version number is: <strong><%= Global.ApplicationAssemblyDetails00.VersionNumber %></strong>
    </p>
    <p>
        This application was built in <strong><%= Global.ApplicationAssemblyDetails00.BuildMode %></strong> mode.
    </p>        
</body>
</html>
