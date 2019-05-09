            $(document).ready(function () {
                $(".sub > a").click(function () {
                    var ul = $(this).next(),
                        clone = ul.clone().css({ "height": "auto" }).appendTo(".mini-menu"),
                        height = ul.css("height") === "0px" ? ul[0].scrollHeight + "px" : "0px";
                    clone.remove();
                    ul.animate({ "height": height });
                    return false;
                });
            $('.mini-menu > ul > li > a').click(function(){
                $('.sub a').removeClass('active');
            $(this).addClass('active');
        }),
           $('.sub ul li a').click(function(){
                $('.sub ul li a').removeClass('active');
            $(this).addClass('active');
        });
});
            $(document).ready(function () {
                $(".fancybox-button").fancybox({
                    prevEffect: 'elastic',
                    nextEffect: 'elastic',
                    closeBtn: true,
                    helpers: {
                        title: { type: 'inside' },
                        buttons: {}
                    }
                });
            });
            $(function () {

                $('div#loading').hide();

                var page = 0;
                var _inCallback = false;
                function loadItems() {
                    if (page > -1 && !_inCallback) {
                        _inCallback = true;
                        page++;
                        $('div#loading').show();

                        $.ajax({
                            type: 'GET',
                            url: '/Galleries/Index/' + page,
                            success: function (data, textstatus) {
                                if (data != '') {
                                    $("#scrolList").append(data);
                                }
                                else {
                                    page = -1;
                                }
                                _inCallback = false;
                                $("div#loading").hide();
                            }
                        });
                    }
                }
                // обработка события скроллинга
                $(window).ready(function () {
                    $(":button").click(function () {
                        loadItems();
                    })
                });
            })


$(document).ready(function () {

    $(window).scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.scrollup').fadeIn();
        } else {
            $('.scrollup').fadeOut();
        }
    });

    $('.scrollup').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });

});


