'use strict'
function go_next(item) {
    current_fs = item.parent();
    next_fs = item.parent().next();
    console.log("Current FS:", current_fs);
    console.log("Next FS:", next_fs);
    //Add Class Active
    $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

    //show the next fieldset
    next_fs.show();
    //hide the current fieldset with style
    current_fs.animate(
        { opacity: 0 },
        {
            step: function (now) {
                // for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    display: "none",
                    position: "relative",
                });
                next_fs.css({ opacity: opacity });
            },
            duration: 500,
        }
    );
    setProgressBar(++current);
}

function setProgressBar(curStep) {
    var percent = parseFloat(100 / steps) * curStep;
    percent = percent.toFixed();
    $(".progress-bar").css("width", percent + "%");
}
var current_fs, next_fs, previous_fs; //fieldsets
var opacity;
var current = 1;
var steps = $("fieldset").length;

$(function () {
 
    // Clear error message when user focuses on an input field
    $('body').on('focus', 'input, select', function () {
        var id = $(this).attr('id');
        $('.' + id + '-error').text('');
    });
    setProgressBar(current);
    $('body').on('click', '#next-step-one', function () {
        var mail  = $('#mail').val();
        var fname = $('#fname').val();
        var lname = $('#lname').val();
        var phone = $('#phone').val();

        var item = $(this);
       
        $.post('/Authentification/NextStep1', { Mail: mail,firstname: fname, lastname: lname, phone: phone }, function (data) {
            if (data.hasError) {
                $('#step-1').html(data.html);
            }
            else {
                go_next(item);
            }
        });


    });
    $('body').on('click', '#next-step-two', function () {
     
       

        var item = $(this);

        $.post('/Authentification/NextStep2', { }, function (data) {
           
            if (data.hasError) {
                $('#step-2').html(data.html);
                
            }
            else {
                go_next(item);
            }
        });


    });

    $('body').on('click', '#next-step-three', function () {
        var companyName = $('#cname').val();
        var companyType = $('#societyType').val()
        var otherSociety = $('#otherSociety').val(); 

        var item = $(this);

        $.post('/Authentification/NextStep3', { companyname: companyName, companyType: companyType, OtherSociety: otherSociety }, function (data) {

            if (data.hasError) {
                $('#step-3').html(data.html);
                
            }
            else {
                go_next(item);
            }
        });


    });
    $('body').on('click', '#next-step-four', function () {
        
        var Adress = $('#CAdress').val(); 
        var Pcode = $('#Pcode').val(); 
        var City = $('#City').val(); 
        console.log('aderess',Adress);
        console.log(Pcode);
        console.log(City);

        var item = $(this);
        $.post('/Authentification/NextStep4', { Companyadress: Adress, Postalcode: Pcode, City: City }, function (data) {
            if (data.hasError) {
                $('#step-4').html(data.html);
                
            }
            else {
                go_next(item);
            }
        });
    });

    $('body').on('click', '#submit', function () {
        var password = $('#pwd').val();
        var cPassword = $('#cpwd').val();
        var logo = $('#pic').val();
        console.log("pword",pwd);

        var item = $(this);

        $.post('/Authentification/NextStep5', { password: password, passwordConfirm: cPassword, logo: logo }, function (data) {
            if (data.hasError) {
                $('#step-5').html(data.html);
                
            }
            else {
                go_next(item);
            }
        });


    });

    /* Prev */
    $(function () {
        // Use event delegation for previous buttons
        $('body').on('click', '.previous', function () {
            current_fs = $(this).parent();
            previous_fs = $(this).parent().prev();

            //Remove class active
            $("#progressbar li")
                .eq($("fieldset").index(current_fs))
                .removeClass("active");

            //show the previous fieldset
            previous_fs.show();

            //hide the current fieldset with style
            current_fs.animate(
                { opacity: 0 },
                {
                    step: function (now) {
                        // for making fielset appear animation
                        opacity = 1 - now;

                        current_fs.css({
                            display: "none",
                            position: "relative",
                        });
                        previous_fs.css({ opacity: opacity });
                    },
                    duration: 500,
                }
            );
            setProgressBar(--current);
        });
    });

});