'use strict'

/*
 
 */
var currentsElements = [];
var modals = [];
function closeModal(modal, manualClose = false) {
    if (!manualClose)
        RemoveCurrentElement(modal);
    modal.addClass('closeAnim');
    setTimeout(function () {
        modal.remove();
    }, 900);
}
function RemoveCurrentElement(modal) {
    var hasCurrentElement = modal.data('hascurrentelement').toLowerCase() == 'true';
    if (hasCurrentElement && currentsElements.length > 0) {
        currentsElements.pop();
    }
}
function AddCurrentElement(element, url) {
    currentsElements.push({ element: element, url, url });
}
function CreateModal( content, currentElement = null) {
    if (currentElement && currentElement != null && currentElement != undefined)
        AddCurrentElement(currentElement.element, currentElement.url);

        /*
    var html = '<div class="modal" data-hasCurrentElement="' + hasCurrentElement + '">';
    html+= '<div class="modal-inner';
    if (modalCssOptions && modalCssOptions.innerClass)
        html +=' '+ modalCssOptions.innerClass;
    html += '">';
    html += '<div class="popup-header"><div class="popup-title">';
    html += title;
    html += '</div>';
    if (hasClose) {
        html += '<i class="close-modal icon-cancel-circled"></i>';
    }
    html += '</div>';//popup-header
    html += '<div class="popup-content">';
    html += content;
    html += '</div>';//popup-content
    if (modalCssOptions && modalCssOptions.hasFooter) {
        html += '<div class="popup-footer">';
        if (modalCssOptions && modalCssOptions.hasFooter && modalCssOptions.footerButtons) {
            html += createFooter(modalCssOptions.footerButtons);
        }
        html += '</div>';
    }

    html += '</div></div>';
    */
    $('body').append(content);
}

function createFooter(footerButtons) {
    var html = "";
    $.each(footerButtons, function (index, value) {
        html += '<button class="modal-btn'
        if (value.class) {
            html += ' ' + value.class;
        }
        html += '"';
        if (value.id) {
            html += ' id="';
            html += value.id + '"';
        }
        html += '>';
        html += value.text;
        html += '</button >';
    });
    return html;
}

$(function () {
    $('body').on('click', '.modal-close-btn,.close-modal', function (e) {
        e.preventDefault();
        var modal = $(this).closest('.modal');
        closeModal(modal);
    });
});