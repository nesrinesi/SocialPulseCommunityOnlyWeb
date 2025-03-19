$(function () {

    $('body').on('click', '#submit', function (e) {
        e.preventDefault();
        var mail = $('#login-email').val();
        var password = $('#login-password').val();


        $.post('/Connection/Verification', { email: mail, password: password }, function (data) {
            if (data.hasError) {
                $('#loginForm').html(data.html);
            }
            else {
                alert('u have logged in');

            }
        });


    });


});