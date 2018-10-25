jQuery.fn.collapse = function (options) {
    var defaults = {
        closed: false
    }
    settings = jQuery.extend({}, defaults, options);

    return this.each(function () {
        var obj = jQuery(this);
        obj.find("legend:first > img").addClass('collapsible').click(function () {
            if (obj.hasClass('collapsed')) {
                obj.removeClass('collapsed').addClass('collapsible');

            }

            jQuery(this).removeClass('collapsed');

            obj.children().not('legend').slideToggle("slow", function () {

                if (jQuery(this).is(":visible")) {
                    obj.find("legend:first").addClass('collapsible');
                    obj.find("legend:first > img").attr('src', '../../Content/Images/toggleminus.png').attr('alt','Kapat');
                }
                else {
                    obj.addClass('collapsed').find("legend").addClass('collapsed');
                    obj.find("legend:first > img").attr('src', '../../Content/Images/toggleplus.png').attr('alt','Aç');
                }


            });
        });
        if (settings.closed) {
            obj.addClass('collapsed').find("legend:first").addClass('collapsed');
            obj.children().not("legend:first").css('display', 'none');
        }
    });
};
