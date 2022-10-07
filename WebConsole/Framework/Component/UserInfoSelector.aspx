<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="UserInfoSelector.aspx.cs" Inherits="WebConsole.Framework.Component.UserInfoSelector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    
    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false" AllowPaging="true" IsDatabasePaging="true"
                DataKeyNames="Id,RealName" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" AllowSorting="True" OnSort="MainGrid_OnSort"
                OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false" OnPageIndexChange="MainGrid_PageIndexChange">
                <Toolbars>
                    <f:Toolbar ID="MainToolbar" Position="Top" runat="server">
                        <Items>
                            <f:TextBox ID="tbSearchUserName" runat="server" Label="工号" />
                            <f:TextBox ID="tbSearchRealName" runat="server" Label="姓名" />
                            <f:Button ID="btnSearchUser" runat="server" Icon="SystemSearch" EnablePostBack="true" OnClick="btnSearchUser_Click"
                                Text="查询" />
                            <f:ToolbarFill runat="server" />
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
                    <f:LinkButtonField TextAlign="Center" Icon="Accept" ToolTip="选择" CommandName="Confirm" Width="100px" />
                </Columns>

                <Listeners>
                    <f:Listener Event="rowselect" Handler="onRowSelect" />
                </Listeners>
            </f:Grid>
        </Items>
    </f:Panel>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
</asp:Content>
