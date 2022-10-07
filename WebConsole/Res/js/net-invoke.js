function CallNet(funcName, data, onSuccess, onError) {
    var strUrl = window.location.href;
    var arrUrl = strUrl.split("/");
    var strPage = arrUrl[arrUrl.length - 1];
    if (strPage.length === 0) {
        strPage = 'Default.aspx';
    }

    $.ajax({
        type: "POST",
        url: strPage + "/" + funcName,
        data: data,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: onSuccess,
        error: onError
    });
}


//function onSuccess(result) {}

function CompabilityLayer() {

}

CompabilityLayer.prototype.direct = function () {

}

function DirectLayer() {

}

DirectLayer.prototype.LogOut = function () {
    onLogOut();
}

var App = new CompabilityLayer();
App.direct = new DirectLayer();