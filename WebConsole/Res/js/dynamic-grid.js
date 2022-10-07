var ctrlList = new Array();

function initSortable() {
    [{
        name: 'advanced',
        pull: true,
        put: true
    },
    {
        name: 'advanced',
        pull: true,
        put: true
    }].forEach(function (groupOpts, i) {
        ctrlList[i] = Sortable.create($('#advanced-' + (i + 1))[0], {
            sort: true,
            group: groupOpts,
            handle: '.drag-handle',
            animation: 150,
            delay: 0,
            touchStartThreshold: 50,
            filter: ".js-remove",
            onFilter: function (evt) {
                var item = evt.item,
                    ctrl = evt.target;
                if (Sortable.utils.is(ctrl, ".js-remove")) {  // Click on remove button
                    if (evt.from.id == 'advanced-2') {
                        ctrlList[0].el.appendChild(item);
                    }
                    else {
                        ctrlList[1].el.appendChild(item);
                    }
                }
            }
        });
    });
}

function buildSortable(defGridInfo, fullGridInfo) {
    var menuMap = new HashMap();

    if (defGridInfo.length != 0) {
        var defArray = JSON.parse(defGridInfo);
        for (var i = 0; i < defArray.length; i++) {
            menuMap.put(defArray[i].EntityName, 1);
            appendDefMenu($('#advanced-1'), defArray[i]);
        }
    }
    if (fullGridInfo.length != 0) {
        var fullArray = JSON.parse(fullGridInfo);
        for (var i = 0; i < fullArray.length; i++) {
            var isExist = menuMap.get(fullArray[i].ItemName);
            if (isExist == null) appendStMenu($('#advanced-2'), fullArray[i]);
        }
    }
}

var defId = 0, stId = 0;
function appendDefMenu(defObj, menuObj) {
    defObj.append("<li id='" + menuObj.EntityName + "' data-id='def_" + defId + "'><div class=\"drag-handle\"><i class=\"fa fa-bars\"></i></div><div class='drag-handle-text js-remove'>" + menuObj.EntityDisplayName + "</div></li>");
    defId++;
}

function appendStMenu(stObj, menuObj) {
    stObj.append("<li id='" + menuObj.ItemName + "' data-id='st_" + stId + "'><div class=\"drag-handle\"><i class=\"fa fa-bars\"></i></div><div class='drag-handle-text js-remove'>" + menuObj.AliasName + "</div></li>");
    stId++;
}

function saveGrid(funcGroup) {
    var gridData = '';
    var childList = ctrlList[0].el.childNodes;
    for (var i = 0; i < childList.length; i++) {
        if (childList[i].nodeName == "LI") {
            gridData += childList[i].id + "|" + childList[i].textContent + ",";
        }
    }
    bkSaveGrid(funcGroup, gridData, 'saveGridDone');
}

function saveGridDone(result) {
    if (result != 1) {
        F.alert('保存失败，错误代码: ' + result, '提示');
        return;
    }
    window.location.reload();
}

function bkSaveGrid(funcGroup, gridData, callback) {
    var url = BasePath + 'Framework/DataProcessing/DynamicGrid.ashx';
    if (app_path.length > 0) url = getPostPath();
    $.ajax({
        type: "POST",
        async: true,
        url: url,
        data: "funcGroup=" + funcGroup + "&gridLayout=" + gridData,
        dataType: "text",
        success: function (msg) {
            var filtered = msg.replace(/\\/g, "\\\\").replace(/'/g, "\\'");
            var script = callback + "('" + filtered + "');";
            eval(script);
        },
        error: function (e) {
            var script = callback + "('" + e.statusText + "');";
            eval(script);
        }
    });
}

function getPostPath() {
    var url = window.document.location.href;
    var index = url.indexOf(app_path + "/");
    if (index < 0) {
        return '';
    }
    var base = url.substring(0, index + app_path.length + 1);
    return base + 'Framework/DataProcessing/DynamicGrid.ashx';
}