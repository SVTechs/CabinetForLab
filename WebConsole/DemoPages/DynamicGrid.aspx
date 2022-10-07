<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="DynamicGrid.aspx.cs" Inherits="WebConsole.DemoPages.DynamicGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">

    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="True" EnableCheckBoxSelect="false" AllowPaging="true" IsDatabasePaging="true" 
                    DataKeyNames="Id" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" AllowSorting="True" OnSort="MainGrid_OnSort"
                    OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false" OnPageIndexChange="MainGrid_PageIndexChange" SortField="Id" SortDirection="DESC"
                    Title="值乘司机<a id='grid_btn' href='javascript:F(Ctrl.EditWindow).show();' style='display:none; padding-left:10px; color:white;'><i class='fa fa-cog' aria-hidden='true'></i></a>">
                <Columns>
                    <f:RowNumberField />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>

    <f:Window ID="EditWindow" Width="650px" Height="550px" Icon="TagBlue" Title="编辑表格" Hidden="True"
        EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
        IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Toolbars>
            <f:Toolbar runat="server">
                <Items>
                    <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭" OnClientClick="F(Ctrl.EditWindow).hide();" />
                    <f:ToolbarSeparator runat="server" />
                    <f:Button ID="btnSaveClose" Icon="SystemSaveClose" EnablePostBack="false"
                        OnClientClick="saveGrid(funcGroup);" runat="server" Text="保存后关闭" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Content>
            <div id="advanced">
                <div style="width: 48%; float: left; margin-top: 15px;"
                    class="block__list block__list_words">
                    <div class="block__list-title">显示列</div>
                    <ul id="advanced-1" style="min-height: 200px;">
                    </ul>
                </div>
                <div style="width: 48%; float: left; margin-top: 15px;"
                    class="block__list block__list_words">
                    <div class="block__list-title">所有列</div>
                    <ul id="advanced-2" style="min-height: 200px;">
                    </ul>
                </div>
            </div>
        </Content>
    </f:Window>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">

    <link rel="stylesheet" href="../Res/js/plugins/sortable/Sortable.css" type="text/css" />
    <script src="../Res/js/plugins/sortable/Sortable.min.js"></script>
    <script src="../Res/js/dynamic-grid.js"></script>

    <script>
        var funcGroup = '<%=FormId%>';
        var columnInfo = '<%=MainGridColumn%>';
        var customizationEnabled = '<%=CustomizationEnabled%>';
        var fullColumnInfo = '<%=CustomGridFull%>';

        F.ready(function () {
            if (customizationEnabled == '1') {
                initSortable();
                buildSortable(columnInfo, fullColumnInfo);
                $('#grid_btn').show();
            }
        });
    </script>

</asp:Content>
