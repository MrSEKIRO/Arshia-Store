/*=========================================================================================
    File Name: coming-soon.js
    Description: Coming Soon
    ----------------------------------------------------------------------------------------
    Item Name: Convex - Bootstrap 4 HTML Admin Dashboard Template
    Version: 2.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

/*******************************
*       js of Countdown        *
********************************/
(function(window, document, $) {
    'use strict';
    $(document).ready(function() {

        $('#clockFlat').countdown('2019/10/10').on('update.countdown', function(event) {
          var $this = $(this).html(event.strftime(''
            + '<div class="clockCard px-3 py-3 mr-3 mb-3 bg-danger white bg-darken-2 box-shadow-2"> <span>%-w</span> <br> <p class="lead mt-2 mb-0">Week%!w </p> </div>'
            + '<div class="clockCard px-3 py-3 mr-3 mb-3 bg-danger white bg-darken-2 box-shadow-2"> <span>%d</span> <br> <p class="lead mt-2 mb-0">Day%!d </p> </div>'
            + '<div class="clockCard px-3 py-3 mr-3 mb-3 bg-danger white bg-darken-2 box-shadow-2"> <span>%H</span> <br> <p class="lead mt-2 mb-0">Hour%!H </p> </div>'
            + '<div class="clockCard px-2 py-3 mr-3 mb-3 bg-danger white bg-darken-2 box-shadow-2"> <span>%M</span> <br> <p class="lead mt-2 mb-0">Minute%!M </h5> </div>'
            + '<div class="clockCard px-2 py-3 mb-3 bg-danger white bg-darken-2 box-shadow-2"> <span>%S</span> <br> <p class="lead mt-2 mb-0"> Second%!S </p> </div>'))
        });

    });
})(window, document, jQuery);