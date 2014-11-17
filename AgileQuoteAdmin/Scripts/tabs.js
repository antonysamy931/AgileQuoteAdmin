$(document).ready(function() {
		//new quote tabs
		//Default Action
		$(".tab_content").hide(); //Hide all content
		$("ul.tabs li:first").addClass("active").show(); //Activate first tab
		$(".tab_content:first").show(); //Show first tab content
		
		//On Click Event
		$("ul.tabs li").click(function() {
			$("ul.tabs li").removeClass("active"); //Remove any "active" class
			$(this).addClass("active"); //Add "active" class to selected tab
			$(".tab_content").hide(); //Hide all tab content
			var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
			$(activeTab).fadeIn(); //Fade in the active content
			return false;
		});
	
	//products tabs in accordian
	$(".tab_content2").hide(); //Hide all content
	$("ul.tabs2 li:first").addClass("active2").show(); //Activate first tab
	$(".tab_content2:first").show(); //Show first tab content
	
	$("ul.tabs2 li").click(function() {
		$("ul.tabs2 li").removeClass("active2"); //Remove any "active" class
		$(this).addClass("active2"); //Add "active" class to selected tab
		$(".tab_content2").hide(); //Hide all tab content
		var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active content
		return false;
	});
	
	//products tabs in accordian
	$(".tab_content3").hide(); //Hide all content
	$("ul.tabs3 li:first").addClass("active3").show(); //Activate first tab
	$(".tab_content3:first").show(); //Show first tab content
	
	$("ul.tabs3 li").click(function() {
		$("ul.tabs3 li").removeClass("active3"); //Remove any "active" class
		$(this).addClass("active3"); //Add "active" class to selected tab
		$(".tab_content3").hide(); //Hide all tab content
		var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active content
		return false;
	});
	
	//products tabs in accordian
	$(".tab_content4").hide(); //Hide all content
	$("ul.tabs4 li:first").addClass("active2").show(); //Activate first tab
	$(".tab_content4:first").show(); //Show first tab content
	
	$("ul.tabs4 li").click(function() {
		$("ul.tabs4 li").removeClass("active4"); //Remove any "active" class
		$(this).addClass("active4"); //Add "active" class to selected tab
		$(".tab_content4").hide(); //Hide all tab content
		var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active content
		return false;
	});
	
	//products tabs in accordian
	$(".tab_content5").hide(); //Hide all content
	$("ul.tabs5 li:first").addClass("active5").show(); //Activate first tab
	$(".tab_content5:first").show(); //Show first tab content
	
	$("ul.tabs5 li").click(function() {
		$("ul.tabs5 li").removeClass("active5"); //Remove any "active" class
		$(this).addClass("active5"); //Add "active" class to selected tab
		$(".tab_content5").hide(); //Hide all tab content
		var activeTab = $(this).find("a").attr("href"); //Find the rel attribute value to identify the active tab + content
		$(activeTab).fadeIn(); //Fade in the active content
		return false;
	});
	
});