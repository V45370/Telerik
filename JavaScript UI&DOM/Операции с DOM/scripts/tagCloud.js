var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"],
	uniqueTags = [];


window.onload = function (){
	var minSize = 17,
		maxSize = 42;

	generateTagCloud(tags, minSize, maxSize);
}

function generateTagCloud(tags, minSize, maxSize) {
	uniqueTags = findUniqueTags(tags);

	for (var i = 0, len = uniqueTags[0].length; i < len; i++) {
		createRandomDiv(uniqueTags[0][i], uniqueTags[1][i], minSize, maxSize, i);
	};
}
function findUniqueTags(tags) {
    var unique = [],
    	numberOfUnique = [],
    	prev;
    
    tags.sort();
    for ( var i = 0; i < tags.length; i++ ) {
        if ( tags[i] !== prev ) {
            unique.push(tags[i]);
            numberOfUnique.push(1);
        } else {
            numberOfUnique[numberOfUnique.length-1]++;
        }
        prev = tags[i];
    }
    
    return [unique, numberOfUnique];
}

function createRandomDiv(text, size, minSize, maxSize, element){
	var div = document.createElement("div"),
		width = getRandomInt(20, 100),
		height = getRandomInt(20, 100),
		fontColor = getRandomColor(),
		countOfMostUsedTag = Math.max.apply( Math, uniqueTags[1] ),
		fontSize = Math.log(uniqueTags[1][element]) / Math.log(countOfMostUsedTag) * (maxSize - minSize) + minSize,
		left = getRandomInt(0, $(document).width() - 100),
		top = getRandomInt(0, $(document).height() - 100);

	div.style.position = "absolute";

	div.style.width = width + "px";
	div.style.height = height + "px";
	div.style.color = fontColor;
	div.style.left = left + "px";
	div.style.top = top + "px";
	div.style.fontSize = fontSize + "px";

	div.appendChild(createStrong(text));
	document.body.appendChild(div);
}

function createStrong(text) {
	var strong = document.createElement("strong");
	strong.innerText = text;
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

