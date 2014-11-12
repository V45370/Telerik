function Solve(input) {

	var dimensions = input[0].split(' ').map(Number);
	var row = dimensions[0];
	var col = dimensions[1];
	var startXY = input[1].split(' ').map(Number);
	var field = [];
	field = input.slice(2);
	console.log(field);
	
	var out = false;
	var lost = false;
	var currentPosX = parseInt(startXY[0]);
	var currentPosY = parseInt(startXY[1]);
	var sum = 0;
	while (true) {

		if (currentPosX < 0 || currentPosX > row-1
			|| currentPosY < 0 || currentPosY > col-1) {
			out = true;
			break;
		}
		if (field[currentPosX][currentPosY] == 'l') {
			console.log(field[currentPosX][currentPosY])

		}
		field[currentPosX][currentPosY] = 'x';
		console.log(field[currentPosX][currentPosY]+'\n');
		if (field[currentPosX][currentPosY] == 'x') {
			lost = true;
			break;
		}
		
		sum += (currentPosX) * col + currentPosY+1;
		if (field[currentPosX][currentPosY] == 'r') {
			
			currentPosY++;
		}
		if (field[currentPosX][currentPosY] == 'd') {
			
			currentPosX++;
		}
		if (field[currentPosX][currentPosY] == "l") {
			
			currentPosY--;
		}
		if (field[currentPosX][currentPosY] == 'u') {
			
			currentPosX--;
		}
		

	}
	if (lost == true) {
		console.log('lost' + sum);

	}
	if (out == true) {
		console.log('out' + sum);
	}
	
	
	

	
}

var input1 = [
 "3 4",
 "1 3",
 "lrrd",
 "dlll",
 "rddd"
];
var input2 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "durlddud",
 "urrrldud",
 "ulllllll"];

var input3 = [
 "5 8",
 "0 0",
 "rrrrrrrd",
 "rludulrd",
 "lurlddud",
 "urrrldud",
 "ulllllll"];
Solve(input1);

