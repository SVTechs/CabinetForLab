<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Main.Master" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="WebConsole.Framework.MenuManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentHolder" runat="server">
    
    <f:PageManager ID="PageManager1" AutoSizePanelID="MainPanel" runat="server" />
    
    <f:Panel ID="MainPanel" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false" Layout="Fit">
        <Items>
            <f:Grid ID="MainGrid" runat="server" ShowBorder="true" ShowHeader="false" EnableCheckBoxSelect="false" 
                DataKeyNames="Id, MenuUrl" DataIDField="Id" OnPreDataBound="MainPanel_PreDataBound" SortField="Name" SortDirection="ASC"
                OnRowCommand="MainGrid_RowCommand" EnableMultiSelect="false">
                <Toolbars>
                    <f:Toolbar ID="MainToolbar" Position="Top" runat="server">
                        <Items>                      
                            <f:Button ID="btnNewMenu" runat="server" Icon="Add" EnablePostBack="false" Text="新增菜单" OnClientClick="showNewMenuWindow();" />  
                            <f:Button ID="btnNewFunc" runat="server" Icon="Add" EnablePostBack="false" Text="新增功能" OnClientClick="showNewFuncWindow();" Hidden="True" />   
                            <f:Button ID="btnFuncCode" runat="server" Icon="Application" EnablePostBack="false" Text="节点代码" OnClientClick="showFuncCode();" Hidden="True" />   
                        </Items>
                    </f:Toolbar>
                </Toolbars>

                <Columns>
                    <f:RowNumberField />
                    <f:BoundField DataField="Id" HeaderText="Id" BoxFlex="1" TextAlign="Center" Hidden="true" />
                    <f:BoundField DataField="MenuName" HeaderText="项目名称" DataSimulateTreeLevelField="TreeLevel" BoxFlex="2"  runat="server"/>
                    <f:RenderField DataField="MenuOrder" HeaderText="项目排序" BoxFlex="1" RendererFunction="RenderItemType" TextAlign="Center"  runat="server"/>
                    <f:BoundField ColumnID="gdTreeLevel" DataField="TreeLevel" HeaderText="项目层级" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField DataField="MenuUrl" HeaderText="链接地址" BoxFlex="1" TextAlign="Center" />
                    <f:BoundField ColumnID="gdMenuType" DataField="MenuType" HeaderText="项目类型" BoxFlex="1" TextAlign="Center" Hidden="True" />
                    <f:RenderField DataField="IsVisible" HeaderText="是否可见" BoxFlex="1" RendererFunction="ConvertYesOrNo" TextAlign="Center" />
                    <f:LinkButtonField TextAlign="Center" Icon="Pencil" ToolTip="编辑" CommandName="Edit" Width="100px" />
                    <f:LinkButtonField TextAlign="Center" Icon="Delete" ToolTip="删除"
                        ConfirmText="确定删除此记录？" ConfirmTarget="Top" CommandName="Delete" Width="100px" />
                </Columns>
                
                <Listeners>
                    <f:Listener Event="rowselect" Handler="onMenuSelect" />                    
                </Listeners>
            </f:Grid>
        </Items>
    </f:Panel>
    
    <f:TextBox ID="tbSelectedRowId" runat="server" Label="Id" Hidden="true" />
    
    <f:Window ID="MenuEditWindow" Width="650px" Height="480px" Icon="TagBlue" Title="菜单编辑" Hidden="True"
              EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
              IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Button ID="btnMenuClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                                  Text="关闭" OnClientClick="F(Ctrl.MenuEditWindow).hide();" />
                        <f:ToolbarSeparator runat="server" />
                        <f:Button ID="btnMenuSaveClose" ValidateForms="EditForm" Icon="SystemSaveClose"
                                  OnClick="btnMenuSaveClose_Click" runat="server" Text="保存后关闭" />              
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="MenuEditForm" ShowBorder="false" ShowHeader="false" runat="server"
                    BodyPadding="10px" Title="信息编辑">
                    <Items>
                        <f:TextBox ID="tbMenuId" runat="server" Label="Id" Hidden="true" />
                        <f:TextBox ID="tbMenuName" Label="菜单名称" Required="true" ShowRedStar="true" runat="server" />
                        <f:TextBox ID="tbMenuIcon" Label="菜单图标" runat="server" />
                        <f:NumberBox ID="tbMenuOrder" Label="菜单排序" Required="true" ShowRedStar="true" runat="server" />
                        <f:DropDownList ID="cbMenuType" Label="菜单类型" Required="true" ShowRedStar="true" runat="server">
                            <f:ListItem Text="分类" Value="0" />
                            <f:ListItem Text="链接-标签页/JS" Value="1" />
                            <f:ListItem Text="链接-新窗口" Value="2" />
                        </f:DropDownList>
                        <f:TextBox ID="tbMenuUrl" Label="链接地址" runat="server" />
                        <f:DropDownList ID="cbMenuVisible" Label="是否可见" Required="true" ShowRedStar="true" runat="server">
                            <f:ListItem Text="是" Value="1" />
                            <f:ListItem Text="否" Value="0" />
                        </f:DropDownList>
                        <f:TextArea ID="tbMenuDesp" runat="server" Label="备注" />                       
                    </Items>
                </f:SimpleForm>
            </Items>
    </f:Window>
    
    <f:Window ID="FuncEditWindow" Width="650px" Height="350px" Icon="TagBlue" Title="功能编辑" Hidden="True"
              EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
              IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Toolbars>
                <f:Toolbar runat="server">
                    <Items>
                        <f:Button ID="btnFuncClose" Icon="SystemClose" EnablePostBack="false" runat="server"
                                  Text="关闭" OnClientClick="F(Ctrl.FuncEditWindow).hide();" />
                        <f:ToolbarSeparator runat="server" />
                        <f:Button ID="btnFuncSaveClose" ValidateForms="EditForm" Icon="SystemSaveClose"
                                  OnClick="btnFuncSaveClose_Click" runat="server" Text="保存后关闭" />              
                    </Items>
                </f:Toolbar>
            </Toolbars>
            <Items>
                <f:SimpleForm ID="FuncEditForm" ShowBorder="false" ShowHeader="false" runat="server"
                    BodyPadding="10px" Title="信息编辑">
                    <Items>
                        <f:TextBox ID="tbFuncType" runat="server" Label="FuncType" Hidden="true" />
                        <f:TextBox ID="tbFuncId" runat="server" Label="Id" Hidden="true" />
                        <f:TextBox ID="tbFuncName" Label="功能名称" Required="true" ShowRedStar="true" runat="server" />
                        <f:NumberBox ID="tbFuncOrder" Label="功能排序" Required="true" ShowRedStar="true" runat="server" />
                        <f:TextArea ID="tbFuncDesp" runat="server" Label="备注" />                       
                    </Items>
                </f:SimpleForm>
            </Items>
    </f:Window>
    
    <f:Window ID="CodeWindow" Width="650px" Height="120px" Icon="TagBlue" Title="节点代码(双击复制)" Hidden="True"
              EnableMaximize="true" EnableCollapse="true" runat="server" EnableResize="true"
              IsModal="True" AutoScroll="true" BodyPadding="10px">
        <Items>
            <f:SimpleForm ID="CodeForm" ShowBorder="false" ShowHeader="false" runat="server"
                          BodyPadding="10px" Title="">
                <Content>
                    <div id="funcIdArea" data-clipboard-text="" style="padding: 8px; border: 1px solid gray;"></div>
                </Content>
            </f:SimpleForm>
        </Items>
    </f:Window>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptHolder" runat="server">
    
    <script src="../Res/js/plugins/clipboard.min.js"></script>
    <script src="../Res/js/framework/MenuManage.js?ver=0.01"></script>

</asp:Content>
