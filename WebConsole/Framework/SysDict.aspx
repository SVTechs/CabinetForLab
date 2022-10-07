<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="SysDict.aspx.cs" Inherits="WebConsole.Framework.SysDict" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    
    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false" AllowPaging="true" IsDatabasePaging="true" 
                DataKeyNames="Id" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" SortField="Name" SortDirection="ASC"
                OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false" OnPageIndexChange="MainGrid_PageIndexChange">
                <Toolbars>
                    <f:Toolbar ID="MainToolbar" Position="Top" runat="server">
                        <Items>                      
                            <f:Button ID="btnInertNew" runat="server" Icon="Add" EnablePostBack="false" OnClientClick="showInsertWindow();" Text="新增项目" />              
                        </Items>
                    </f:Toolbar>
                </Toolbars>

                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                    <f:BoundField DataField="DataKey" HeaderText="Key" BoxFlex="1" />
                    <f:BoundField DataField="DataSubKey" HeaderText="SubKey" BoxFlex="1" />
                    <f:BoundField DataField="DataValue1" HeaderText="值1" BoxFlex="1" />
                    <f:BoundField DataField="DataValue2" HeaderText="值2" BoxFlex="1" />
                    <f:BoundField DataField="DataValue3" HeaderText="值3" BoxFlex="1" />
                    <f:BoundField DataField="DataValue4" HeaderText="值4" BoxFlex="1" />
                    <f:BoundField DataField="DataValue5" HeaderText="值5" BoxFlex="1" />
                    <f:BoundField DataField="DataValue6" HeaderText="值6" BoxFlex="1" />
                    <f:BoundField DataField="Comment" HeaderText="备注" BoxFlex="1" />
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
    
    <f:Window ID="EditWindow" Width="550px" Height="580px" Icon="TagBlue" Title="编辑信息" Hidden="True"
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
                        <f:TextBox ID="tbDataId" runat="server" Label="Id" Hidden="true" />
                        <f:TextBox ID="tbDataKey" runat="server" Label="Key" Required="true" ShowRedStar="true" />
                        <f:TextBox ID="tbDataSubKey" runat="server" Label="SubKey" />
                        <f:NumberBox ID="tbDataOrder" Label="排序" Required="true" ShowRedStar="true" runat="server" />
                        <f:TextBox ID="tbValue1" runat="server" Label="值1" />
                        <f:TextBox ID="tbValue2" runat="server" Label="值2" />
                        <f:TextBox ID="tbValue3" runat="server" Label="值3" />
                        <f:TextBox ID="tbValue4" runat="server" Label="值4" />
                        <f:TextBox ID="tbValue5" runat="server" Label="值5" />
                        <f:TextBox ID="tbValue6" runat="server" Label="值6" />
                        <f:TextArea ID="tbComment" runat="server" Label="备注" />                       
                    </Items>
                </f:SimpleForm>
            </Items>
    </f:Window>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">

</asp:Content>
