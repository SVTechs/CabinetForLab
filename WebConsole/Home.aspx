<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebConsole.Home" %>
<%@ Import Namespace="WebConsole.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <link rel="stylesheet" href="Res/js/plugins/liMarquee/liMarquee.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <f:PageManager ID="mainPageManager" runat="server" />

    <div style="font-size: 60px; color: white; width: 100%; text-align: center; padding-top: 70px;"><%=Env.UnitName %></div>

    <div style="width: 100%; height: 200px; padding-top: 20px;">
        <div class="marquee" style="height: 200px;">
            <div style="font-size: 50px; color: white; width: 100%; text-align: center; padding-top: 50px;">欢迎使用</div>
            <div style="font-size: 50px; color: white; width: 100%; text-align: center; padding-top: 100px; padding-bottom: 100px;"><%=Env.AppName %></div>
        </div>
    </div>

    <div class="background-pic"></div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script src="Res/js/plugins/liMarquee/jquery.liMarquee.js"></script>
    
    <script>
        $(function(){
            $('.marquee').liMarquee();
        });
    </script>
</asp:Content>
