(function($){
"use strict";

var isMobile = {
    Android: function() {
        return navigator.userAgent.match(/Android/i);
    },
    BlackBerry: function() {
        return navigator.userAgent.match(/BlackBerry/i);
    },
    iOS: function() {
        return navigator.userAgent.match(/iPhone|iPad|iPod/i);
    },
    Opera: function() {
        return navigator.userAgent.match(/Opera Mini/i);
    },
    Windows: function() {
        return navigator.userAgent.match(/IEMobile/i);
    },
    any: function() {
        return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
    }
};

var blogyInits = function(){

/* Sliders */
$('.flexslider').flexslider({
    animation: "slide",
    animationLoop: false,
    prevText: "",
    nextText: ""
});

jQuery('.sidebar-widget .widget-slider').flexslider({
    animation: "slide",
    animationLoop: false
});

jQuery('.footer-container .footer-widget .widget-slider').flexslider({
    animation: "slide",
    animationLoop: false
});
/* Sliders */

/* Smooth scroll */
$('.smooth').bind('click.smoothscroll',function (e) {
    e.preventDefault();
    var target = this.hash,
    $target = $(target);
    $('html, body').stop().animate({
        'scrollTop': $target.offset().top
    }, 1000, 'swing');
});
/* Smooth scroll */

/* Panels and Tabs */
$('.panel-blogy').click(function(){
    $('.panel-blogy').removeClass('cllpse-active');  
    $(this).addClass('cllpse-active');
});

$('.tabbed-area a').click(function (e) {
    e.preventDefault();
    $(this).tab('show');
    $('.tabbed-area').find('.active').removeClass('active');
    $(this).parent().addClass('active');
});
/* Panels and Tabs */

/* Spoiler Alert */
$(document).on('click', '.spoiler', function() {
    $(this).removeClass('on');
});
/* Spoiler Alert */

/* Tooltips */
$('.has-tooltip').tooltip();
/* Tooltips */

/* Fitvids */
jQuery(".fitvids").fitVids();
/* Fitvids */

/* Mobile Menu */
$('#nav').slicknav();
/* Mobile Menu */

}

$(document).ready(function(){
if(isMobile.any()){
    $('#modern-post-effect').removeAttr('id');
    $('.intro-effect-push').removeAttr('class');
    $('.modern-title-cat').css({'display':'none'});
    $('.recent-post-materials').css({'display':'none'});
    var bgImg = $('.modern-post-bg-img').children('img').attr('src');
    $('.modern-post-bg-img img').css({"visibility":"hidden"});
    $('.modern-post-bg-img').css({"background":"url("+bgImg+") no-repeat center center"});
    $('.modern-post-bg-img').css({"background-size":"cover"});

};
if(!isMobile.any()){
/* Scroll Header */
$(".headroom").headroom({
    classes: {
      initial: "slide",
      pinned: "slide--reset",
      unpinned: "slide--up"
    }
});
/* Scroll Header */
}
blogyInits();

/* Parallax */
if(!isMobile.any()){
    jQuery(".parallax").each(function() {
        var parallaxId = $(this).attr('id');
        $('#'+parallaxId).parallax("50%", 0.4);
    });
}
/* Parallax */


$('.widget_wysija_cont').addClass('clearfix');
$(".shortcode_wysija input[type=submit]").wrap("<div class='nws-input-wrapper'></div>");

if(!isMobile.any()){
    var footersocial = jQuery(".social-area").height();
    $('.social-newsletter, .social-side').css({'height':footersocial});
}

if(isMobile.any()){
    if(jQuery(window).width() > 1000){
        $('.social-newsletter, .social-side').css({'height':jQuery(".social-area").height()});
    }
}

if($('html').is('.ie9')){
    $('.prev-next').css({'display':'none'});
}

if(jQuery('.post-line').length){
    var lineWinWidth = jQuery(window).width();
    var leftLineFar = jQuery(".post-line").offset().left;
    jQuery(".post-line").css('left', '-' + leftLineFar + 'px');
    jQuery(".post-line").css('width', lineWinWidth);
}

if(jQuery('.back-check').length){
    BackgroundCheck.init({
        targets: '.back-check',
        images: '.grid-box'
    });
}

if(jQuery('.author-back-check').length){
    BackgroundCheck.init({
        targets: '.author-page-box',
        images: '.author-back-check'
    });
}

if(jQuery('.video_sections').length == 0){
    if(jQuery('.back-check-img').length){
        BackgroundCheck.init({
            targets: '.back-check-img-wrap',
            images: '.back-check-img img'
        });
    }
}

$("#nav").superfish().supposition();

/* Scroll to Top */
$(window).scroll(function(){
    if ($(this).scrollTop() > 500) {
    jQuery('.scrollup').fadeIn();
    } else {
    jQuery('.scrollup').fadeOut();
    }
});
$('.scrollup').click(function(){
    $("html, body").animate({ scrollTop: 0 }, 600);
    return false;
});
/* Scroll to Top */

/* Reading Progress */
if(!isMobile.any()){
    if(jQuery('.inner-post-page').length){
        var postWrapper = jQuery(".blog-post-single");

        var postContent = ( postWrapper.offset().top ) / 1.2,
            bottomPost = postWrapper.outerHeight(),
            postContentAndTop = postContent * 2 + bottomPost, progressBar, stopProgress;

        var getValue = function(){
            var progressScrollTop = jQuery(window).scrollTop();
            return progressBar = ( progressScrollTop - postContent ) / ( postContentAndTop - ( postContent * 2 ) ) * 100;
        }

        $(document).on('scroll', function(){
            stopProgress = Math.floor(getValue());
            if(stopProgress<101){
                    $('.reading-progress-bar').css({ width: stopProgress+"%" });
            }
        });
    }
}
/* Reading Progress */


if(jQuery('.modern').length){

/* Modern Inits */
    var winHeight = jQuery(window).height();

    var mTitleHeight = (jQuery(window).height()/2)-68;

    if(jQuery('.parallax').length){
        var winWidth = jQuery(window).width();
        var leftFar = jQuery(".parallax").offset().left + 1;
        jQuery(".parallax").css('left', '-' + leftFar + 'px');
        jQuery(".parallax").css('width', winWidth + 1);
    }

    if(jQuery('.full-width').length){
        var divWidth = jQuery(".row").width();
        var insideDivWidth = jQuery(".full-width").width();
        var lastFar = (divWidth - insideDivWidth)/2;
        jQuery(".full-width").css('left', '-' + lastFar + 'px');
        jQuery(".full-width").css('width', divWidth);
    }

    jQuery(".modern-post-header").css('height', winHeight);
    if(!isMobile.any()){
        jQuery(".post-slider-wrapper").css('height', winHeight);
    }
    if(isMobile.any()){
        jQuery(".post-slider-wrapper ul li").css('height', winHeight);
    }
    jQuery(".modern-title").css('padding-top', mTitleHeight);
    jQuery(".loading-animation").css('margin-top', mTitleHeight);

    if(jQuery('.grid-1').length || jQuery('.grid-2').length){
        jQuery(".slides li .grid-box").each(function() {
            jQuery(this).css('height', winHeight);
        });
    }else{
        if(!isMobile.any()){
            jQuery(".slides li .grid-box").each(function() {
                jQuery(this).css('height', winHeight/2);
            });
        }else{
            jQuery(".slides li .grid-box").each(function() {
                jQuery(this).css('height', winHeight);
            });
        }
    }

    jQuery("#modern-search-wrapper").css('height', winHeight);
    jQuery( "#search-button" ).click(function(e) {
        jQuery("#modern-search-wrapper").fadeIn();
        jQuery("#modern-search-wrapper input").focus();
        e.preventDefault();
        e.stopPropagation();
    });
    jQuery( "#search-close" ).click(function(e) {
        e.preventDefault();
        jQuery("#modern-search-wrapper").fadeOut();
        jQuery("#searchform")[0].reset();
    });

    jQuery("html").on("keyup", function(e) {
    if(e.keyCode === 27){
        jQuery("#modern-search-wrapper").fadeOut();
    }
    });

    if(jQuery('.grid-1').length){
        jQuery('.modern-blog-post-title-container').css('margin-top', (winHeight/1.8)-50);
    }
    if(!isMobile.any()){
        if(jQuery('.modern-scroll-top').length){
            /* ScrollTo top when page reach to top */
            jQuery(window).on('mousewheel', function(e){
                var theEvent = e.originalEvent.wheelDelta || e.originalEvent.detail*-1;
                if(theEvent > 0){
                    var barPosi = jQuery(window).scrollTop();
                    if(barPosi < jQuery('.content').offset().top){
                        e.preventDefault();
                        jQuery('html, body').stop().animate({'scrollTop':0}, 800);
                    }
                }
            });
        }
    }
/* Modern Inits */

/* Ajax Load More */
if(jQuery('.active-infinite').length){
    $('.post-box').infinitescroll({
        navSelector : '.load-more-modern',
        nextSelector : '.load-more-modern a',
        itemSelector : '.blog-post-item',
        loading: {
            finished: undefined,
            finishedMsg: "<em>No more post!</em>",
                    img: themepathjs.template_url +"/images/loading.gif",
            msg: null,
            msgText: "",
            selector: null,
            speed: 'fast',
            start: undefined
        },
        errorCallback: function(){
          $('.post-box').css({'padding-bottom':'100px'});
          $('.load-more-modern').remove();         
        }
    }); 
    $(window).unbind('.infscr'); 
    $(".load-more-modern a").click(function(){
        $('.post-box').infinitescroll('retrieve');
        $('.load-more-modern').show();
        return false;
    });
}
/* Ajax Load More */

}

if(jQuery('.classic').length){

/* Classic Inits */
    jQuery(".open-search").click(function(e) {
        e.preventDefault();
        e.stopPropagation();
        jQuery("#classic-search-wrapper").fadeIn();
        jQuery(".open-search").fadeOut();
        jQuery(".close-search").fadeIn();
        jQuery("#classic-search-wrapper input[type='search']").focus();
    });

    jQuery(".close-search").click(function(e) {
        e.preventDefault();
        e.stopPropagation();
        jQuery("#classic-search-wrapper").fadeOut();
        jQuery(".open-search").fadeIn();
        jQuery(".close-search").fadeOut();
        jQuery('#searchform')[0].reset();
    });

    jQuery(".open-share").click(function(e) {
        e.preventDefault();
        $(this).parent().next(".share-wrapper").animate({width:'toggle'},500);
    });
/* Classic Inits */

$('.slicknav_menu').addClass('classic_mobile_nav');

}

/* Text Size Changer */
var curSize;
jQuery('#bgFont').click(function(event){
    event.preventDefault();
    curSize= parseInt(jQuery('.post-content-blog, .single-modern-content').css('font-size')) + 2;
    if(curSize<=20)
    jQuery('.post-content-blog, .single-modern-content').animate({'font-size': curSize});
});  
jQuery('#smlFont').click(function(event){
    event.preventDefault();   
    curSize= parseInt(jQuery('.post-content-blog, .single-modern-content').css('font-size')) - 2;
    if(curSize>=12)
    jQuery('.post-content-blog, .single-modern-content').animate({'font-size' : curSize});
}); 
/* Text Size Changer */

});

jQuery(window).load(function(){
if(!isMobile.any()){
    BackgroundCheck.refresh();
}

if(jQuery('.modern .sizer-wrapper').length){
    if($('.modern-post-effect-off').length){
        var divDistance = $('.post-line').offset().top - $('.modern-single-post').offset().top;
        $('.sizer-wrapper').css({'top':divDistance+3});
    }else{
        var divDistance = $('.post-line').offset().top - $('.modern-single-post').offset().top;
        $('.sizer-wrapper').css({'top':divDistance+103});
    }
}

/* Scroll to Fixed */
if(jQuery('.sizer-wrapper').length){
   if(jQuery('.classic').length){ 
        jQuery('.sizer-wrapper').css('height', jQuery(".blog-post-single").height());
    }
    if(jQuery('.modern').length){ 
        jQuery('.sizer-wrapper').css('height', jQuery(".blog-post-single").height()-300);
    }

    $("#text-exp").scrollToFixed({
        marginTop: 110,
        limit: (jQuery(".blog-post-single").height()+$(".blog-post-single").offset().top)-200,
        postFixed: function() { $("#text-exp").addClass("fixMargin"); },
        fixed: function() { $("#text-exp").removeClass("fixMargin"); },
        offsets: false,
        removeOffsets: true
    });

    $(".progress-container").scrollToFixed({
        marginTop: 0,
        limit: (jQuery(".blog-post-single").height()+$(".blog-post-single").offset().top),
        offsets: false,
        removeOffsets: true
    });
}
/* Scroll to Fixed */

if(!isMobile.any()){
/* FlexSlider with MouseWheel */
    jQuery('.post-slider').flexslider({
        animation: "slide",
        animationLoop: false,
        controlNav: false,
        directionNav: false,
        direction: "vertical",
        slideshow: false,

        start: function(slider){
            var slider = jQuery('.post-slider').data('flexslider');
            var lastSlide = 0;
            slider.bind('mousewheel', function(event, delta, deltaX, deltaY) {
                event.preventDefault();
                event.stopPropagation();
                var getTimeNow = new Date().getTime();
                if(getTimeNow - lastSlide < 500 + 1000) {
                    event.preventDefault();
                    event.stopPropagation();
                    return;
                }

                if(delta < 0 ){
                    var goPos = slider.getTarget('next');
                }else{
                    var goPos = slider.getTarget('prev');            
                }

                var lasSlide = (slider.count)-1;
                var curSlide = slider.currentSlide;

                if(curSlide == 0){
                    if(delta < 0 ){
                        if(slider.count == 1){
                            jQuery('html, body').animate({'scrollTop': jQuery('.content').offset().top}, 1200);
                        }else{
                            slider.flexAnimate(goPos, slider.vars.pauseOnAction);
                        }
                    }else{
                        jQuery(".post-slider-wrapper").animate({
                            paddingTop: "75px"
                        }, 500, function() {
                            jQuery(".post-slider-wrapper").animate({paddingTop : "0px"}, 500)
                        });
                    }
                }else if(curSlide > 0 && curSlide < lasSlide){
                    slider.flexAnimate(goPos, slider.vars.pauseOnAction);
                }else{
                    if(delta > 0 ){
                        slider.flexAnimate(goPos, slider.vars.pauseOnAction);
                    }else{
                        jQuery('html, body').animate({'scrollTop': jQuery('.content').offset().top}, 1200);
                    }
                }
                lastSlide = getTimeNow;
            });
        },
        after: function () {
            if(jQuery('.modern').length){
                BackgroundCheck.refresh();
            }
        }
    });
/* FlexSlider with MouseWheel */
}    

    /* Sidebar */
    var mySlidebars = new $.slidebars();
    $('#panel').on('click', function(e) {
        e.preventDefault();
        e.stopPropagation();
        mySlidebars.slidebars.toggle('right');
        jQuery('#panel').css({'display':'none'});
        jQuery('.slidebar-close').css({'display':'block'});
        
        if (mySlidebars.slidebars.init) { // Check if Slidebars has been initiated.
            jQuery('.widget-slider').flexslider({
                animation: "slide",
                animationLoop: false
            });
            jQuery('.intro-effect-push .modern-post-header').css({'position':'relative'});
            jQuery('.slicknav_menu a').animate({'right':'415px'},200);
        } else {

        }
    });
    $('.slidebar-close').on('click', function(e) {
        e.preventDefault();
        e.stopPropagation();
        jQuery('.intro-effect-push .modern-post-header').css({'position':'absolute'});
        jQuery('#panel').css({'display':'block'});
        jQuery('.slidebar-close').css({'display':'none'});
        jQuery('.slicknav_menu a').animate({'right':'75px'},200);
        mySlidebars.slidebars.close();
    });
    /* Sidebar */

    $('#loading-area').fadeOut().remove();

});

})(jQuery);