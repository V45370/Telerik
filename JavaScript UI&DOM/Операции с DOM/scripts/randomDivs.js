function generateDivs(){
	var numbers = document.getElementById("count").value;

	for (var i = 0; i < numbers; i++) {
		createRandomDiv();
	};
}

function createRandomDiv(){
	var div = document.createElement("div"),
		width = getRandomInt(20, 100),
		height = getRandomInt(20, 100),
		backgroundColor = getRandomColor(),
		fontColor = getRandomColor(),
		left = getRandomInt(0, $(document).width() - 100),
		top = getRandomInt(0, $(document).height() - 100),
		border = getRandomInt(1, 20),
		borderRadius = getRandomInt(0, 20),
		borderColor = getRandomColor();

	div.style.position = "absolute";

	div.style.width = width + "px";
	div.style.height = height + "px";
	div.style.backgroundColor = backgroundColor;
	div.style.color = fontColor;
	div.style.left = left + "px";
	div.style.top = top + "px";
	div.style.border = border + "px" + " solid " + borderColor
	div.style.borderRadius = borderRadius + "px";

	div.appendChild(createStrong());
	document.body.appendChild(div);
}

function createStrong() {
	var strong = document.createElement("strong");
	strong.innerText = "div";
	return strong;	
}

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';
    for (var i = 0; i < 6; i++ ) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

function clearDivs() {
	var childrens = document.body.children;
	for (var len = childrens.length - 1, i = len ; i >= 0; i--) {
		if (childrens[i].className !== "buttons") {
			document.body.removeChild(childrens[i]);	
		};
	};
}