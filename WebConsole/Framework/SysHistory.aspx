<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="SysHistory.aspx.cs" Inherits="WebConsole.Framework.SysHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    
    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />
    
     <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false" AllowPaging="true" IsDatabasePaging="true" 
                DataKeyNames="Id" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" SortField="OperateTime" SortDirection="DESC"
                OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false" OnPageIndexChange="MainGrid_PageIndexChange">
                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                    <f:BoundField DataField="OperateType" HeaderText="操作分类" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="DataType" HeaderText="数据类别" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="OperateDesp" HeaderText="操作内容" BoxFlex="3" TextAlign="Center" />
                    <f:BoundField DataField="OperateUserName" HeaderText="操作人" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="OperateTime" HeaderText="操作时间" BoxFlex="1" TextAlign="Center"/>
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

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">

</asp:Content>
