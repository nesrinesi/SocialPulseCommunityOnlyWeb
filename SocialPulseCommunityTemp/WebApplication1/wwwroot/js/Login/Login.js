// Password visibility toggle
$('.toggle-password').click(function () {
    const passwordInput = $('#login-password');
    const icon = $(this);

    if (passwordInput.attr('type') === 'password') {
        passwordInput.attr('type', 'text');
        icon.removeClass('fa-eye-slash').addClass('fa-eye');
    } else {
        passwordInput.attr('type', 'password');
        icon.removeClass('fa-eye').addClass('fa-eye-slash');
    }
});
