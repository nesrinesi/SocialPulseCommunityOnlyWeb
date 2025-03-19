'use strict'

$(function () {
    $('body').on('click', '.card', function (e) {
        e.preventDefault();
        $.post('/post/GetDetails', { model: 1 }, function (data)
        {
            $('body').append(data);
        });
    });

    $('body').on('click', '.close', function (e) {
        e.preventDefault();
        var modal = $(this).closest('.modal');
        modal.remove();
    });
});