<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="WebConsole.Framework.UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">

    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false" AllowPaging="true" IsDatabasePaging="true"
                DataKeyNames="Id" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" AllowSorting="True" OnSort="MainGrid_OnSort"
                OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false" OnPageIndexChange="MainGrid_PageIndexChange">
                <Toolbars>
                    <f:Toolbar ID="MainToolbar" Position="Top" runat="server">
                        <Items>
                            <f:TextBox ID="tbSearchUserName" runat="server" Label="工号" />
                            <f:TextBox ID="tbSearchRealName" runat="server" Label="姓名" />
                            <f:Button ID="btnSearchUser" runat="server" Icon="SystemSearch" EnablePostBack="true" OnClick="btnSearchUser_Click"
                                Text="查询" />
                            <f:ToolbarFill runat="server" />
                            <f:Button ID="btnInertNew" runat="server" Icon="Add" EnablePostBack="false" OnClientClick="showInsertWindow();" Text="新增用户" />
                        </Items>
                    </f:Toolbar>
                </Toolbars>

                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                    <f:BoundField DataField="UserName" SortField="UserName" HeaderText="工号" TextAlign="Center" BoxFlex="1" />
                    <f:BoundField DataField="RealName" SortField="RealName" HeaderText="姓名" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="UserTel" SortField="UserTel" HeaderText="电话" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="LastChanged" SortField="LastChanged" HeaderText="最后更改" BoxFlex="1" TextAlign="Center" />
                    <f:LinkButtonField HeaderText="权限分配" TextAlign="Center" Icon="LockOpen" ToolTip="权限" CommandName="Perm" Width="100px" />
                    <f:LinkButtonField HeaderText="信息编辑" TextAlign="Center" Icon="Pencil" ToolTip="编辑" CommandName="Edit" Width="100px" />
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
            <f:Panel ID="PanelSplit" Layout="Column" BodyPadding="10px" EnableCollapse="false" ShowBorder="false" ShowHeader="false" 
                runat="server" EnableFrame="False">
                <Items>
                    <f:SimpleForm ID="EditFormA" ShowBorder="false" ShowHeader="false" runat="server" EnableFrame="False" ColumnWidth="50%" 
                        BodyPadding="10px">
                        <Items>
                            <f:TextBox ID="tbUserId" runat="server" Label="Id" Hidden="true" />
                            <f:TextBox ID="tbUserName" runat="server" Label="工号" Required="true" ShowRedStar="true" />
                            <f:TextBox ID="tbPassword" runat="server" Label="密码" TextMode="Password" />
                            <f:TextBox ID="tbRealName" runat="server" Label="姓名" Required="true" ShowRedStar="true" />
                            <f:TextBox ID="tbUserTel" runat="server" Label="电话" />
                            <f:TextBox ID="tbAddress" runat="server" Label="住址" />
                            
                        </Items>
                    </f:SimpleForm>
                    <f:SimpleForm ID="EditFormB" ShowBorder="false" ShowHeader="false" runat="server" EnableFrame="False" ColumnWidth="50%" 
                                  BodyPadding="10px">
                        <Items>
                            <f:DropDownList ID="tbUserSex" runat="server" Label="性别">
                                <f:ListItem Text="男" Value="男"/>
                                <f:ListItem Text="女" Value="女"/>
                            </f:DropDownList>
                            <f:TextBox ID="tbIdentCard" runat="server" Label="身份证号" />
                            <f:TextBox ID="tbWorkCard" runat="server" Label="工作证号"  />
                            <f:DatePicker ID="tbRetireDate" runat="server" Label="退休时间" />
                            <f:TextBox ID="tbComment" runat="server" Label="备注" />
                        </Items>
                    </f:SimpleForm>
                </Items>
            </f:Panel>
        </Items>
    </f:Window>

    <f:Window ID="PermWindow" Width="550px" Height="550px" Icon="TagBlue" Title="权限分配" Hidden="True"
        EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
        IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Toolbars>
            <f:Toolbar runat="server">
                <Items>
                    <f:Button ID="btnPermClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                        Text="关闭" OnClientClick="F(Ctrl.PermWindow).hide();" />
                    <f:ToolbarSeparator runat="server" />
                    <f:Button ID="btnPermSaveClose" ValidateForms="PermForm" Icon="SystemSaveClose"
                        OnClick="btnPermSaveClose_Click" runat="server" Text="保存后关闭" />
                </Items>
            </f:Toolbar>
        </Toolbars>
        <Items>
            <f:SimpleForm ID="PermForm" ShowBorder="false" ShowHeader="false" runat="server"
                BodyPadding="10px" Title="信息编辑">
                <Items>
                    <f:Tree ID="treeRole" ShowBorder="false" ShowHeader="false" EnableIcons="True" EnableCheckBox="True" runat="server"></f:Tree>
                </Items>
            </f:SimpleForm>
        </Items>
    </f:Window>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">

</asp:Content>
