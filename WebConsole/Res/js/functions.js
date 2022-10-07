function padLeft(source, count, prefix) {
    source += '';
    if (source.length < count) {
        for (var i = source.length; i < count; i++) {
            source = prefix + source;
        }
    }
    return source;
}

function getQueryString(name) {
    var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)', 'i');
    var r = window.location.search.substr(1).match(reg);
    if (r != null) {
        return decodeURIComponent(r[2]);
    }
    return null;
}

function ConvertYesOrNo(value) {
    if (value == 1) {
        return "<font color='green'>是</font>";
    }
    else if (value == 0) {
        return "<font color='red'>否</font>";
    }
    else {
        return '-';
    }
}

function onRowSelect(rowData, rowId, rowIndex) {
    if (Ctrl.tbSelectedRowId) F(Ctrl.tbSelectedRowId).setValue(rowId);
}

function showInsertWindow() {
    if (Ctrl.EditForm) {
        F(Ctrl.EditForm).reset();
    }
    else {
        if (Ctrl.EditFormA) {
            F(Ctrl.EditFormA).reset();
        }
        if (Ctrl.EditFormB) {
            F(Ctrl.EditFormB).reset();
        }
    }

    F(Ctrl.EditWindow).show();
}

function showImportWindow() {
    if (Ctrl.ImportForm) {
        F(Ctrl.ImportForm).reset();
    }
    F(Ctrl.ImportWindow).show();
}