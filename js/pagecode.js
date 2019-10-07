$(function() {

    $(".jquery_click").click(function() {
        $(".jquery_open").toggle();

    });


    $(".path_ul a").eq(1).addClass("path_first");

    $('.product_list li:nth-child(5n)').after('<div class="product_list_hr"></div>');

});

// ²£«~¦Cªítab

$(function(){
	
		var _showTab = 0;
		$('.court_tab').each(function(){			
			var $tab = $(this); 
			
			$('.tab_content', $tab).hide().eq(_showTab).show();					
			$('ul.tab li', $tab).hover(function() {			
				var $this = $(this),
				_clickTab = $this.find('a').attr('href');
				$this.addClass('active').siblings('.active').removeClass('active');
$(_clickTab).stop(false, true).fadeIn().siblings().hide();		
			})
			
			
		});
		
		$('ul.tab li:eq(0) a').addClass('active');
	
			$('ul.tab li a').hover(function() {
												   
				$('ul.tab li a').removeClass('active')
				$(this).addClass('active')	
				
			})
			$('.court_tab li:eq(0)').attr('id', 'tab_t1');
			$('.court_tab li:eq(1)').attr('id', 'tab_t2');
			$('.court_tab li:eq(2)').attr('id', 'tab_t3');
			$('.court_tab li:eq(3)').attr('id', 'tab_t4');
			$('.court_tab li:eq(4)').attr('id', 'tab_t5');
			$('.court_tab li:eq(5)').attr('id', 'tab_t6');
			$('.court_tab li:eq(5)').attr('id', 'tab_t7');
		});

$(function(){
		var $block = $('#abgne_fade_pic'), 
			$ad = $block.find('.ad'),
			showIndex = 0,		
			fadeOutSpeed = 2000,	
			fadeInSpeed = 2000,		
			defaultZ = 10,			
			isHover = false,
			timer, speed = 5000;	
		
		$ad.css({
			opacity: 0,
			zIndex: defaultZ - 1
		}).eq(showIndex).css({
			opacity: 1,
			zIndex: defaultZ
		});
	
		var str = '';
		for(var i=0;i<$ad.length;i++){
			str += '<a href="#">' + (i + 1) + '</a>';
		}
		var $controlA = $('#abgne_fade_pic').append($('<div class="control">' + str + '</div>').css('zIndex', defaultZ + 1)).find('.control a');

		$controlA.click(function(){
		
			showIndex = $(this).text() * 1 - 1;
			
		
			$ad.eq(showIndex).stop().fadeTo(fadeInSpeed, 1, function(){
				if(!isHover){
		
					timer = setTimeout(autoClick, speed + fadeInSpeed);
				}
			}).css('zIndex', defaultZ).siblings('a').stop().fadeTo(fadeOutSpeed, 0).css('zIndex', defaultZ - 1);
	
			$(this).addClass('on').siblings().removeClass('on');

			return false;
		}).focus(function(){
			$(this).blur();
		}).eq(showIndex).addClass('on');

		$block.hover(function(){
			isHover = true;

			clearTimeout(timer);
		}, function(){
			isHover = false;
	
			timer = setTimeout(autoClick, speed);
		})

		function autoClick(){
			if(isHover) return;
			showIndex = (showIndex + 1) % $controlA.length;
			$controlA.eq(showIndex).click();
		}
	
		timer = setTimeout(autoClick, speed);
	});