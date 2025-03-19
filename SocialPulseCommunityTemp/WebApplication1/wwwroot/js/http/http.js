'use strict'

function post(url, data, callback) {
    //denied
    var token = sessionStorage.getItem('token');
    var sendedData = {};
    sendedData.jwtModel = { token: token };
    if (data && data.dataSend) {
        sendedData.model = data.dataSend;
    }

    $.post(url, sendedData, function (receive) {
        if (receive.hasException && receive.hasException == true) {
            sessionStorage.clear();
            location.href = '/Error/Error';
        }
        if ((receive.jwtError && receive.jwtError == true) || (receive.licenseInvalid && receive.licenseInvalid == true)) {
            sessionStorage.clear();
            location.href = '/home/index';
        }
        else {
            sessionStorage.setItem('token', receive.token);
            callback(receive.data, data.dataCallback);
            // allow
        }
    });

}