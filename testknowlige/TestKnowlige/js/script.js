$(document).ready(function(e) {
    $('.head div').hover(function(){
		$(this).addClass('hov_div');
		},
		function(){
			$(this).removeClass('hov_div');
		});
	$('.Categories').hide();		
	$('.head div').click(function(){		
		$index = 0;
		$('.head div').each(function(index, element) {
                    $(this).removeClass('act_div');
                });
		$(this).addClass('act_div');
		$('.body_div div').hide();
		if($('.head div').index(this) == 0){			
				$('.Discipline').show();			
			}
			else {
				$('.Categories').show()
			}
		});
});