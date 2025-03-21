$(function () {

    // Society Type Selection
    $('body').on('change', '#societyType', function () {
        if ($(this).val() === 'other') {
            $('#otherSocietyInput').slideDown();
        } else {
            $('#otherSocietyInput').slideUp();
            $('#otherSociety').val(''); // Clear the input when hiding
        }
    });

    // Logo upload handling
    
    $('body').on('click', '.logo-placeholder', function (e) {
        e.preventDefault();
        e.stopImmediatePropagation();
        $('.input-pic-hidden').trigger('click');
    });
    $('body').on('click', '.input-pic-hidden', function (e) {
        e.stopImmediatePropagation();
    });

    $('input[name="pic"]').change(function (e) {
        if (e.target.files && e.target.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('.logo-placeholder').html(`
          <img src="${e.target.result}" style="max-width: 100%; max-height: 100%; object-fit: contain;">
        `);
            };
            reader.readAsDataURL(e.target.files[0]);
        }





    });
});






