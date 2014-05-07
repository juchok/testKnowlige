$(document).ready(function(e) {
    $('.head div').hover(function(){
		$(this).addClass('hov_div');
		},
		function(){
			$(this).removeClass('hov_div');
		});
	$('.head div').click(function(){		
		$('.head div').each(function(index, element) {
                    $(this).removeClass('act_div');
                });
		$(this).addClass('act_div');
		});
});