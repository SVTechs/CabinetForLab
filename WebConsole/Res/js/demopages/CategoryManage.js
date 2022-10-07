function onRowSelect(rowData, rowId, rowIndex) {
    F(Ctrl.tbSelectedRowId).setValue(rowId);
}

function showInsertWindow() {
    F(Ctrl.tbNodeId).setValue('');
    F(Ctrl.tbNodeName).setValue('');
    F(Ctrl.tbNodeOrder).setValue('');
    F(Ctrl.tbNodeDesp).setValue('');

    F(Ctrl.EditWindow).show();
}