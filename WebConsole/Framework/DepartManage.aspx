<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="DepartManage.aspx.cs" Inherits="WebConsole.Framework.DepartManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">

    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false"
                DataKeyNames="Id" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" SortField="Name" SortDirection="ASC"
                OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false">
                <Toolbars>
                    <f:Toolbar ID="MainToolbar" Position="Top" runat="server">
                        <Items>
                            <f:Button ID="btnInertNew" runat="server" Icon="Add" EnablePostBack="false" OnClientClick="showInsertWindow();" Text="新增部门" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>

                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                    <f:BoundField DataField="DepartName" HeaderText="部门名称" DataSimulateTreeLevelField="TreeLevel" BoxFlex="2" />
                    <f:BoundField DataField="DepartOrder" HeaderText="排序" BoxFlex="1" TextAlign="Center" Hidden="true" />
                    <f:RenderField DataField="IsEnabled" HeaderText="是否启用" BoxFlex="1" RendererFunction="ConvertYesOrNo" TextAlign="Center" />
                    <f:LinkButtonField TextAlign="Center" Icon="Pencil" ToolTip="编辑" CommandName="Edit" Width="100px" />
                    <f:LinkButtonField TextAlign="Center" Icon="Delete" ToolTip="删除"
                        ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="100px" />
                </Columns>

                <Listeners>
                    <f:Listener Event="rowselect" Handler="onRowSelect" />
                </Listeners>
            </f:Grid>
        </Items>
    </f:Panel>

    <f:TextBox ID="tbSelectedRowId" runat="server" Label="Id" Hidden="true" />

    <f:Window ID="EditWindow" Width="650px" Height="350px" Icon="TagBlue" Title="编辑信息" Hidden="True"
        EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
        IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Toolbars>
            <f:Toolbar runat="server">
                <Items>
                    <f:Button ID="btnClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭" OnClientClick="F(Ctrl.EditWindow).hide();" />
                    <f:ToolbarSeparator runat="server" />
                    <f:Button ID="btnSaveClose" ValidateForms="EditForm" Icon="SystemSaveClose"
                        OnClick="btnSaveClose_Click" runat="server" Text="保存后关闭" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:SimpleForm ID="EditForm" ShowBorder="false" ShowHeader="false" runat="server"
                BodyPadding="10px" Title="信息编辑">
                <Items>
                    <f:TextBox ID="tbDepartId" runat="server" Label="Id" Hidden="true" />
                    <f:TextBox ID="tbDepartName" runat="server" Label="部门名称" Required="true" ShowRedStar="true" />
                    <f:NumberBox ID="tbDepartOrder" Label="部门排序" Required="true" ShowRedStar="true" runat="server" />
                    <f:DropDownList ID="cbIsEnabled" Label="是否启用" Required="true" ShowRedStar="true" runat="server">
                        <f:ListItem Text="启用" Value="1" />
                        <f:ListItem Text="禁用" Value="0" />
                    </f:DropDownList>
                    <f:TextArea ID="tbDepartDesp" runat="server" Label="备注" />
                </Items>
            </f:SimpleForm>
        </Items>
    </f:Window>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
