function commonCallback(data, dataCallback) {
    if (data && data != null && data != undefined) {
        var hasError = false;
        if (data.hasDicoError && data.dicoError && data.dicoError.length > 0) {
            $.each(data.dicoError, function (index, item) {
                $(item.id).html(item.msg);
            });
            hasError = true;
        }
        if (data.hasModalError && data.hasModalError) {
            post('/Error/ErrorModal', { dataSend: data.errorModalMessage }, function (data, dataCallback) {
                CreateModal(data.content.content);
            });
            hasError = true;
        }
        if (!hasError) {
            if (data && data != undefined && data.isModal) {
                if (dataCallback && dataCallback != undefined &&
                    dataCallback.currentElement && dataCallback.currentElement != undefined) {
                    CreateModal(data.content.content, dataCallback.currentElement);
                }
                else {
                    CreateModal(data.content.content);
                }

            }
            else if (dataCallback && dataCallback != undefined && dataCallback.element) {
                dataCallback.element.html(data.content.content);
            }


            if (dataCallback && dataCallback != undefined && dataCallback.modal) {
                var modal = dataCallback.modal;
                var hasCurrentElement = modal.data('hascurrentelement').toLowerCase() == 'true';
                if (hasCurrentElement) {
                    var currentElement = currentsElements.pop();
                    if (dataCallback.noPostback) {
                        currentElement.element.innerHTML = data.content.content
                        closeModal(modal, true);
                    }
                    else {
                        post(currentElement.url, { dataSend: data.content.sendData, dataCallback: { element: currentElement.element } }, function (data, dataCallback) {
                            dataCallback.element.innerHTML = data.content.content;
                            closeModal(modal, true);
                        });
                    }

                }
                else
                    closeModal(dataCallback.modal);
            }

            if (data.hasVerticalTab)
                toggleDarkClass();
        }
    }
    if (isLoad())
        endLoad();
}