window.onload = function (){
	var numbers = 5;
	clearDivs();
	for (var i = 0; i < numbers; i++) {
		createRandomDiv();
	};
}

function clearDivs() {
	var childrens = document.body.children;
	for (var len = childrens.length - 1, i = len ; i >= 0; i--) {
		if (childrens[i].className !== "buttons") {
			document.body.removeChild(childrens[i]);	
		};
	};
}