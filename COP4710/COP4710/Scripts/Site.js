

(function ($) {
    $.fn.outerHTML = function () {
        return $(this).clone().wrap('<div></div>').parent().html();
    }
})(jQuery);




var $currentSection = "";

var sidebarTag = '#sidebar';

$(function () {

    //Creates Datepickers
    $('.date').datepicker({
        showOn: "button",
        buttonImage: _imgDir + "calendar.png",
        buttonImageOnly: true
    });

    //Floats Datepicker icon into input
    //looks pretty nice.
    $('.ui-datepicker-trigger').css({
        "position": 'relative', "left": "-25px ", "top": "7px"
    });


    //Generate Sidebar from Content
    GenerateSidebarHtml();




    TrackSidebar();

    HighlightSidebarSection($('.Section:first-child').attr('id'));

    $.localScroll();


    $('#sidebar #sidebarLinks a').click(function (event) {
        //scroll to section click on in sidebar
        //jQuery.scrollTo.window().queue([]).stop();

        event.preventDefault();

        $.scrollTo($(this).attr('href'), { duration: 200 });

        //highlight sidebar
        HighlightSidebarSection($(this).attr('href').replace('#', ''));
    });


    $('select, textarea').focus(function () {
        focusElement(this);
    });

    $('select, textarea').click(function () {
        focusElement(this);
    });

    $('input').focus(function () {
        if ($(this).attr('type') != 'checkbox') {
            focusElement(this);
        }
        else {
            focusElement($(this).closest('.selectable'));
        }
    }).click(function () {

        if ($(this).attr('type') != 'checkbox') {
            focusElement(this);
        }
        else {
            focusElement($(this).closest('.selectable'));
        }
    });


});

function focusElement(elem) {

    $('.focused').removeClass('focused');
    $(elem).addClass('focused');
}

function moveObject(event) {
    jQuery.scrollTo.window().queue([]).stop();
}

function TrackSidebar() {

    //Keep track of Sidebar navigation
    $('.Section').each(function () {

        var $sectionID = $(this).attr('id')

        $(this).children().click(function (event) {

            if ($currentSection == "")
                $currentSection = $sectionID;

            if ($sectionID != $currentSection) {
                HighlightSidebarSection($sectionID);
            }
        });
    });
}


function HighlightSidebarSection($sectionID) {
    $('#sidebar *.Selected').removeClass('Selected');

    $currentSection = $sectionID;
    $sidebarObj = $(sidebarTag + " #sidebar-" + $sectionID + " a");
    $sidebarObj.addClass('Selected').html($sidebarObj.html()); // + "<div id='dvSelector'/>");

}

function GenerateSidebarHtml() {


    var $sidebarHtml = "";
    $('.Content .Section').each(function () {
        var $linkID = $(this).attr('id');
        var $linkText = $(this).attr('linkText') ? $(this).attr('linkText') : $(this).find('.Header').text();

        $sidebarHtml += "<li id='sidebar-" + $linkID + "'><a href='#" + $linkID + "'>" + $linkText + "</a></li>";
    });

    $('#sidebar ul').html($sidebarHtml);

}

//validates form

$('.ValidationMessage').each(function () {
    $(this).replaceWith("<div class='ValidationMessage'>" + $(this).html() + "</div>");
});

/*
$("#logon").validate({
errorPlacement: function (error, element) {
error.insertAfter(element);
},
debug: true
})
*/
