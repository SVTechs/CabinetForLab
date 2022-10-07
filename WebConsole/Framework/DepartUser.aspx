<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="DepartUser.aspx.cs" Inherits="WebConsole.Framework.DepartUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">

    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:RegionPanel ID="MainPanel" ShowBorder="false" runat="server">
        <Regions>
            <f:Region ID="RegionDepart" ShowBorder="false" ShowHeader="false" Width="250px" Position="Left"
                Layout="Fit" BodyPadding="5px" runat="server">
                <Items>
                    <f:Grid ID="GridDepart" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false"
                        DataKeyNames="ID" DataIDField="Id" AllowPaging="false" EnableMultiSelect="false" OnRowClick="LeftGrid_RowClick" EnableRowClickEvent="true">
                        <Columns>
                            <f:RowNumberField />
                            <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                            <f:BoundField DataField="DepartName" HeaderText="部门名称" DataSimulateTreeLevelField="TreeLevel" BoxFlex="1" />
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>

            <f:Region ID="RegionUser" ShowBorder="false" ShowHeader="false" Position="Center" Layout="VBox"
                BoxConfigAlign="Stretch" BoxConfigPosition="Left" BodyPadding="5px 5px 5px 0"
                runat="server">
                <Items>
                    <f:Grid ID="GridUser" runat="server" BoxFlex="1" ShowBorder="true" ShowHeader="false"
                        EnableCheckBoxSelect="False" DataIDField="Id" AllowSorting="true" AllowPaging="true" IsDatabasePaging="true"
                        OnPreDataBound="GridUser_PreDataBound" OnRowCommand="GridUser_RowCommand" OnPageIndexChange="GridUser_PageIndexChange">
                        <Toolbars>
                            <f:Toolbar runat="server">
                                <Items>
                                    <f:TextBox ID="tbSearchUserName" runat="server" Label="工号" />
                                    <f:Button ID="btnSearchUser" runat="server" Icon="SystemSearch" EnablePostBack="true" OnClick="btnSearchUser_Click"
                                        Text="查询" />
                                    <f:ToolbarFill runat="server" />
                                    <f:Button ID="btnAddUser" runat="server" Icon="Add" EnablePostBack="true" OnClick="btnAddUser_Click"
                                        Text="添加用户到当前部门" />
                                </Items>
                            </f:Toolbar>
                        </Toolbars>
                        <Columns>
                            <f:RowNumberField>
                            </f:RowNumberField>
                            <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                            <f:BoundField DataField="UserName" SortField="UserName" HeaderText="工号" BoxFlex="1" />
                            <f:BoundField DataField="RealName" SortField="RealName" HeaderText="姓名" BoxFlex="1" />
                            <f:BoundField DataField="UserTel" SortField="UserTel" HeaderText="电话" TextAlign="Center" BoxFlex="1" />

                            <f:LinkButtonField TextAlign="Center" Icon="Delete" ToolTip="从当前部门中移除此用户"
                                ConfirmText="确定从当前部门中移除此用户？" ConfirmTarget="Top" CommandName="Delete" Width="50px">
                            </f:LinkButtonField>
                        </Columns>
                    </f:Grid>
                </Items>
            </f:Region>
        </Regions>
    </f:RegionPanel>

    <f:Window ID="UserSelectWindow" Width="700px" Height="550px" Icon="TagBlue" Title="用户选择" Hidden="True" EnableIFrame="true" 
              CloseAction="HidePostBack"  EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
              IsModal="True" IFrameUrl="/Framework/Component/UserInfoSelector.aspx">
    </f:Window>
     
    <f:TextBox ID="tbEmployeeId" runat="server" Label="Id" Hidden="true" />
    <f:TextBox ID="tbEmployeeName" runat="server" Label="Id" Hidden="true" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
    
    <script>
        function onSelectCallback() {
            __doPostBack('', 'SubmitUser');
        }
    </script>

</asp:Content>
