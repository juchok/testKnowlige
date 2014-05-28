$(document).ready(function (e) {
    $('.head div').hover(function () {
        $(this).addClass('hov_div');
    },
		function () {
		    $(this).removeClass('hov_div');
		});
    $('.Categories').hide();
    $('.Tests').hide();
    $('.Discipline').show();
    $('.add').hide();
    $('.add').each(function (index, element) {
        if ($(this).attr("name") == "addDoC") {
            $(this).show();
        }
    });
    $('.head div').click(function () {
        $index = 0;
        $('.head div').each(function (index, element) {
            $(this).removeClass('act_div');
        });
        $(this).addClass('act_div');
        $('.body_div div').hide();
        $('.add').hide();

        switch ($('.head div').index(this)) {
            case 0:
                $('.Discipline').show();
                $('.add').each(function (index, element) {
                    if ($(this).attr("name") == "addDoC") {
                        $(this).show();
                    }
                });
                break;
            case 1:
                $('.Categories').show();
                $('.add').each(function (index, element) {
                    if ($(this).attr("name") == "addCat") {
                        $(this).show();
                    }
                });
                break;
            case 2:
                $('.Tests').show();
                $('.add').each(function (index, element) {
                    if ($(this).attr("name") == "addTest") {
                        $(this).show();
                    }
                });
                break;
            default:
                $('.Discipline').show();
                $('.add').attr("alt", "~/addDiscipline.aspx");
                break;
        }
    });	
});