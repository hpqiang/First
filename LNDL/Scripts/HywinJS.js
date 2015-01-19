if (!Modernizr.inputtypes.date) {
    $(function () {

        $(".datecontrol").datepicker();

    });

    $(function () {
        $("#show_detail").click(function (e) {
                if (e.handled !== true) // This will prevent event triggering more then once
                {
                    //alert("showFunction clicked..");
                    var $el = $(e.target);
                    if ($el.hasClass('glyphicon-hand-down')) {
                        $("tr[class*=expandable]").show();
                        $el.removeClass('glyphicon-hand-down').addClass('glyphicon-hand-left')
                    }
                    else /*($el.hasClass('glyphicon-hand-left'))*/ {
                        $("tr[class*=expandable]").hide();
                        $el.removeClass('glyphicon-hand-left').addClass('glyphicon-hand-down')
                    }
                    e.handled = true;
                }
            });
        $('.show_detail1').click(function (e) {
            if (e.handled !== true) // This will prevent event triggering more then once, workaournd ONLY for now
            {
                var $el = $(e.target);
                if ($el.hasClass('glyphicon-arrow-down')) {
                    expandablerows = $(e.target).parent().closest("tr").nextUntil(".fix");
                    expandablerows.show();
                    $el.removeClass('glyphicon-arrow-down').addClass('glyphicon-arrow-left')
                }
                else /*($el.hasClass('glyphicon-hand-left'))*/ {
                    expandablerows = $(e.target).parent().closest("tr").nextUntil(".fix");
                    expandablerows.hide();
                    $el.removeClass('glyphicon-arrow-left').addClass('glyphicon-arrow-down')
                }
                e.handled = true;
                //alert("event for show_detail1+" + $(e.target).parent().closest("tr").nextUntil(".fix"));
                //alert("This: " + this.nodeName);
                e.handled = true;
            }
        });
    });
}