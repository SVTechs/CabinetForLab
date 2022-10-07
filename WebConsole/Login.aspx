<%@ Page Title="用户登录" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebConsole.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <link rel="stylesheet" href="Res/css/login.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <f:PageManager ID="mainPageManager" runat="server" />

    <f:Window ID="windowLogin" runat="server" IsModal="false" Icon="Key" EnableClose="false"
              EnableMaximize="false" WindowPosition="GoldenSection" Title="系统登录"
              Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start" Width="400px">
        <Items>
            <f:Image ID="imageLogin" ImageUrl="Res/images/login_avatar.png" runat="server"
                     CssClass="login-image">
            </f:Image>
            <f:SimpleForm ID="formLogin" LabelAlign="Top" BoxFlex="1" runat="server" BodyPadding="10px 10px"
                          ShowBorder="false" ShowHeader="false">
                <Items>
                    <f:TextBox ID="tbUserName" FocusOnPageLoad="true" runat="server" Label="帐号" Required="true" Text=""
                               ShowRedStar="true" RequiredMessage="请输入账号！" Height="50px">
                    </f:TextBox>
                    <f:TextBox ID="tbPassword" TextMode="Password" runat="server" Required="true" ShowRedStar="true" Text=""
                               Label="密码" RequiredMessage="请输入密码！" Height="50px">
                    </f:TextBox>
                </Items>
            </f:SimpleForm>
        </Items>
        <Toolbars>
            <f:Toolbar runat="server" Position="Bottom" ToolbarAlign="Right">
                <Items>
                    <f:Button ID="btnSubmit" Icon="LockOpen" Type="Submit" runat="server" ValidateForms="formLogin"
                              EnableAjax="false" DisableControlBeforePostBack="false" OnClick="btnSubmit_Click"
                              Text="登录系统">
                    </f:Button>
                </Items>
            </f:Toolbar>
        </Toolbars>
    </f:Window>

    <div class="login-bg"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">

</asp:Content>
