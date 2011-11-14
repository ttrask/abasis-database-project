


var $currentSection ="";

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


    $('ul.select').selectable({
        start: function () {
            $("li.ui-selected", this).removeClass("ui-selected");
        }
    });

    TrackSidebar();


    $.localScroll();

    $('#sidebar a').click(function (event) {
        event.preventDefault();
        $.scrollTo($(this).attr('href'));
        //RecenterSidebar();
    })
});


function TrackSidebar() {

    //Keep track of Sidebar navigation
    $('.Section').each(function () {

        var $sectionID = $(this).attr('id')

        $(this).children().click(function (event) {

            if ($currentSection=="")
                $currentSection = $sectionID;

            if ($sectionID != $currentSection) {

                $('#sidebar *.Selected').removeClass('Selected');

                $currentSection = $sectionID;
                $sidebarObj = $(sidebarTag + " #sidebar-" + $sectionID + " a");
                $sidebarObj.addClass('Selected').html($sidebarObj.html()); // + "<div id='dvSelector'/>");

            }
        });
    });
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
