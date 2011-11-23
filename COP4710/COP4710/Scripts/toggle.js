
$(document).ready(function () {
    /*
    Progressive enhancement.  If javascript is enabled we change the body class.  Which in turn hides the checkboxes with css.
    */
    $('body').attr("class", "js");

    /*
    Add toggle switch after each checkbox.  If checked, then toggle the switch.
    */
    $('.checkbox').after(function () {
        if ($(this).is(":checked")) {
            return "<a href='#' class='toggle checked' ref='" + $(this).attr("id") + "'></a>";
        } else {
            return "<a href='#' class='toggle' ref='" + $(this).attr("id") + "'></a>";
        }

    });

    /*
    When the toggle switch is clicked, check off / de-select the associated checkbox 
    */
    $('.toggle').click(function (e) {
        Toggle(this, e);
    }).keypress(function (e) {
        Toggle(this, e);
    });


});

function Toggle(btn, e) {
    
    var checkboxID = $(btn).attr("ref");
    var checkbox = $('#' + checkboxID);

    if (checkbox.is(":checked")) {
        checkbox.removeAttr("checked");

    } else {
        checkbox.attr("checked", "true");
    }
    $(btn).toggleClass("checked");

    e.preventDefault();

}