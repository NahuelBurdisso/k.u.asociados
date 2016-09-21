$(document).ready(function () {
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
    console.log("hola");
});