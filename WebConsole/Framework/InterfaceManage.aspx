<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="InterfaceManage.aspx.cs" Inherits="WebConsole.Framework.InterfaceManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">

    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />

    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false"
                DataKeyNames="ItemName" DataIDField="ItemName" OnPreDataBound="MainPanel_PreDataBound" SortField="ItemName" SortDirection="ASC"
                EnableMultiSelect="false" EnableRowClickEvent="True" OnRowClick="MainGrid_OnRowClick">
                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="AliasName" HeaderText="数据类型" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="ItemName" HeaderText="实体名称" BoxFlex="1" TextAlign="Center" />
                </Columns>
            </f:Grid>
        </Items>
    </f:Panel>

    <f:TextBox ID="tbDomainName" runat="server" Label="Id" Hidden="true" />
    <f:TextBox ID="tbRoleId" runat="server" Label="Id" Hidden="true" />

    <f:Window ID="EditWindow" Width="850px" Height="475px" Icon="TagBlue" Title="编辑信息" Hidden="True"
        EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
        IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Items>
            <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
                <Regions>
                    <f:Region ID="RegionRole" ShowBorder="false" ShowHeader="false" Width="250px" Height="400px" Position="Left" Layout="VBox"
                              BoxConfigAlign="Stretch" BoxConfigPosition="Left" BodyPadding="5px 5px 5px 5px" runat="server">
                        <Items>
                            <f:Grid ID="GridRole" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false" Height="400px" 
                                DataKeyNames="ID" DataIDField="Id" AllowPaging="false" EnableMultiSelect="false" OnRowClick="LeftGrid_RowClick" EnableRowClickEvent="true">
                                <Columns>
                                    <f:RowNumberField />
                                    <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                                    <f:BoundField DataField="RoleName" HeaderText="角色名称" DataSimulateTreeLevelField="TreeLevel" BoxFlex="1" />
                                </Columns>
                            </f:Grid>
                        </Items>
                    </f:Region>

                    <f:Region ID="RegionColumn" ShowBorder="false" ShowHeader="false" Height="400px" Position="Center" Layout="VBox"
                        BoxConfigAlign="Stretch" BoxConfigPosition="Left" BodyPadding="5px 5px 5px 5px"
                        runat="server">
                        <Items>
                            <f:Grid ID="GridColumn" runat="server" Height="400px" ShowBorder="true" ShowHeader="false"
                                DataIDField="ItemName" AllowSorting="true" AllowPaging="true" IsDatabasePaging="true">
                                <Toolbars>
                                    <f:Toolbar runat="server">
                                        <Items>
                                            <f:Button ID="btnSaveColumn" runat="server" Icon="Add" EnablePostBack="true" OnClick="btnSaveColumn_Click"
                                                Text="保存" />
                                        </Items>
                                    </f:Toolbar>
                                </Toolbars>
                                <Columns>
                                    <f:CheckBoxField ColumnID="ColumnStatus" DataField="Checked" Width="30" RenderAsStaticField="False"/>
                                    <f:BoundField DataField="AliasName" SortField="AliasName" HeaderText="列名" BoxFlex="1" />
                                    <f:BoundField DataField="ItemName" SortField="ItemName" HeaderText="数据库映射" BoxFlex="1" />
                                </Columns>
                            </f:Grid>
                        </Items>
                    </f:Region>
                </Regions>
            </f:RegionPanel>
        </Items>
    </f:Window>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">

    <script src="../Res/js/framework/InterfaceManage.js?ver=0.01"></script>

</asp:Content>
