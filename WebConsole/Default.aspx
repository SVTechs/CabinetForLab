<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebConsole.Default" %>

<%@ Import Namespace="WebConsole.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <link rel="stylesheet" href="Res/css/default.css">
    
    <style>
        .fa, .fas, .far, .fal, .fab, .fad{
            line-height: 20px !important;
            padding-right: 5px;
        }

        .fa-hidden {
            display: none;
        }

        .f-tree-custom-iconfont {
            width: 25px;
            text-align: center;
        }

        .f-tree-cell-inner {
            padding: 6px 2px 6px 8px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    <f:PageManager ID="mainPageManager" AutoSizePanelID="regionPanel" runat="server" />

    <f:RegionPanel ID="regionPanel" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="regionTop" CssClass="region-top" ShowBorder="false" ShowHeader="false" Position="Top" Layout="Fit" runat="server">
                <Content>
                    <div id="header">
                        <img src="Res/images/logo.png" class="logo" />
                        <a class="title"><%=Env.AppName %></a>
                        <asp:HyperLink ID="lkSystemTitle" CssClass="title" runat="server"></asp:HyperLink>
                    </div>
                    <img id="logo_right" src="Res/images/sheenline.png" class="logo_right" style="display: none;" />
                </Content>
                <Toolbars>
                    <f:Toolbar ID="topRegionToolbar" Position="Bottom" CssClass="topbar" runat="server">
                        <Items>
                            <f:ToolbarText ID="tbUserName" runat="server" />
                            <f:ToolbarSeparator runat="server" />

                            <f:ToolbarText ID="tbOnlineUserCount" runat="server" />
                            <f:ToolbarSeparator runat="server" />

                            <f:ToolbarText runat="server" Text="当前时间：" />
                            <f:ToolbarText ID="tbCurrentTime" runat="server" />

                            <f:ToolbarFill runat="server" />
                            <f:Button ID="btnRefresh" runat="server" Text="刷新" Icon="Reload" EnablePostBack="false" />
                            <f:ToolbarSeparator runat="server" />
                            <f:Button ID="btnHelp" Hidden="True" EnablePostBack="false" Icon="Help" Text="帮助" runat="server" />
                            <f:ToolbarSeparator Hidden="True" runat="server" />
                            <f:Button ID="btnExit" runat="server" Icon="UserRed" Text="安全退出" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>
            </f:Region>

            <f:Region ID="regionLeft" Split="true" EnableCollapse="true" Width="200px" ShowHeader="true"
                Title="系统菜单" Layout="Fit" Position="Left" runat="server">
                <Items>
                    <f:Tree ID="treeMenu" EnableIcons="True" ShowBorder="false" ShowHeader="false" EnableSingleClickExpand="true" runat="server">
                        <Listeners>
                            <f:Listener Event="nodeclick" Handler="onTreeNodeClick" />
                        </Listeners>
                    </f:Tree>
                </Items>
            </f:Region>

            <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center" runat="server">
                <Items>
                    <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <f:Tab ID="homeTab" Title="欢迎页面" EnableIFrame="true" IFrameUrl="Home.aspx" Icon="ChartBar"
                                runat="server">
                            </f:Tab>
                        </Tabs>
                    </f:TabStrip>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
    <script type="text/javascript" src="Res/js/framework/Default.js?v=0.05"></script>
    
    <script>
        var show_logo = '<%=Env.EnableCopyright%>';
        if (show_logo == 'True') {
            $('#logo_right').show();
        }
    </script>
</asp:Content>
