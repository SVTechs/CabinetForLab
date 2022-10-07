F.ready(function() {
    // 时间显示
    setCurrentTime();
    window.setInterval(setCurrentTime, 1000);

    // 添加按钮事件
    F(Ctrl.btnRefresh).on('click', function () {
        onRefreshClick();
    });
    F(Ctrl.btnExit).on('click', function () {
        onLogOut();
    });
});

function updateNodeText(nodeId, text) {
    F(Ctrl.treeMenu).setNodeText(nodeId, text);
}
function setCurrentTime() {
    var today = new Date();
    var year = today.getFullYear().toString();
    var month = padTime(today.getMonth() + 1);
    var date = padTime(today.getDate());
    var hour = padTime(today.getHours());
    var minute = padTime(today.getMinutes());
    var second = padTime(today.getSeconds());
    F(Ctrl.tbCurrentTime).setText(year + '-' + month + '-' + date + ' ' + hour + ':' + minute + ':' + second);
}

function padTime(source) {
    return padLeft(source, '2', '0');
}

function onTreeNodeClick(event, nodeId) {
    var nodeData = F(Ctrl.treeMenu).getNodeData(nodeId);
    if (nodeData.attrs) {
        var dest = nodeData.attrs['target'];
        var title = nodeData.attrs['title'];
        if (nodeData.attrs['type'] == 0) {
            addTabByHref(nodeData.id, title, dest, true);
        }
        else if (nodeData.attrs['type'] == 1) {
            window.open(dest);
        }
        else if (nodeData.attrs['type'] == 10) {
            eval(dest.substring(11));
        }
    }
}

function addTabByHref(id, title, href, isActive) {
    var mainTabStrip = F(Ctrl.mainTabStrip);
    var tabOptions = {
        id: id,
        iframeUrl: href,
        title: title
    };
    F.addMainTab(mainTabStrip, tabOptions, isActive);
}

function onRefreshClick(event) {
    var mainTabStrip = F(Ctrl.mainTabStrip);

    var activeTab = mainTabStrip.getActiveTab();
    if (activeTab.iframe) {
        var iframeWnd = activeTab.getIFrameWindow();
        iframeWnd.location.reload();
    }
}

function onLogOut() {
    CallNet("LogOut", null, onLogOutFinished);
}

function onLogOutFinished() {
    location.href = "Login.aspx";
}