$(document).ready(function(){

$(".topmenu ul li").dropdown();

});

$.fn.dropdown = function() {

	$(this).hover(function(){
		$(this).addClass("hover");
		
	
		$('ul:first',this).css('display', 'block');
	},function(){
		$(this).removeClass("hover");
		
		$('ul:first',this).css('display', 'none');
	});

}