$(document).ready(function () {

    setTimeout(ajaxpetition, 3000)

    function ajaxpetition() {
        $.ajax({
            type: "GET",
            url: "/Shared/GetActiveNotificationsQuant",
            success: function (data) {
                $(".badge").html(data)
            }
        });
    }

    // full page menu
    $('#fullpage').fullpage({
        menu: '#menu',
        scrollingSpeed: 1000,
        controlArrows: false,
        responsiveSlides: true,
        loopBottom: true,
        fadingEffect: true,
        navigation: true,
        slidesNavigation: true,
        navigationTooltips: ['Presentación', 'Funciones','Nuestra Misión','Nuestra Visión'],
    });

    // init Isotope
    var $grid = $('.grid-isotope').isotope({
        // options
    });
    // filter items on button click
    $('.filter-button-group').on('click', 'button', function () {
        var filterValue = $(this).attr('data-filter');
        $grid.isotope({ filter: filterValue });
    });

    // init map

});