function RenderItemType(value, params) {
    var dataType = params.rowValue.gdMenuType;
    if (dataType == '0') {
        return "<div style='background-color: green; color: white;'>" + value + "</div>";
    }
    else if (dataType == '1') {
        return "<div style='background-color: blue; color: white;'>" + value + "</div>";
    }
    else if (dataType == '2') {
        return "<div style='background-color: blue; color: white;'>" + value + "</div>";
    }
    else {
        return "<div style='background-color: orange; color: white;'>" + value + "</div>";
    }
}

function onMenuSelect(rowData, rowId, rowIndex) {
    F(Ctrl.tbSelectedRowId).setValue(rowId);
    F(Ctrl.btnFuncCode).show();

    var menuLevel = F(Ctrl.MainGrid).getCellValue(rowIndex, 'gdTreeLevel');
    var menuType = F(Ctrl.MainGrid).getCellValue(rowIndex, 'gdMenuType');
    F(Ctrl.tbFuncType).setValue(menuType);
    if (menuType == 0) {
        //分类
        F(Ctrl.btnNewMenu).show();
        F(Ctrl.btnNewFunc).hide();
    } else if (menuType == 1 || menuType == 2) {
        //链接
        F(Ctrl.btnNewMenu).hide();
        F(Ctrl.btnNewFunc).show();
        F(Ctrl.btnNewFunc).setText('添加功能');
    } else if (menuType == 50000) {
        //功能
        F(Ctrl.btnNewMenu).hide();
        F(Ctrl.btnNewFunc).show();
        F(Ctrl.btnNewFunc).setText('添加二级功能');
    } else {
        //二级功能
        F(Ctrl.btnNewMenu).hide();
        F(Ctrl.btnNewFunc).hide();
    } 
}

function showNewMenuWindow() {
    F(Ctrl.MenuEditWindow).reset();

    F(Ctrl.MenuEditWindow).show();
}

function showNewFuncWindow() {
    F(Ctrl.FuncEditWindow).reset();

    F(Ctrl.FuncEditWindow).show();
}

function showFuncCode() {
    var funcId = F(Ctrl.tbSelectedRowId).getValue();

    $('#funcIdArea').attr('data-clipboard-text', funcId);
    $('#funcIdArea').text(funcId);
    var clipCtrl = $('#funcIdArea')[0];
    var clipboard = new Clipboard(clipCtrl);
    F(Ctrl.CodeWindow).show();
}