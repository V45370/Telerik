//Write functions for working with shapes in  standard Planar coordinate system
//Points are represented by coordinates P(X, Y)
//Lines are represented by two points, marking their beginning and ending
//L(P1(X1,Y1),P2(X2,Y2))
//Calculate the distance between two points
//Check if three segment lines can form a triangle


function getPoint(x,y) {
    return { x: x, y: y };
}


function getLine(point1, point2){
    return { pointA: point1, pointB: point2 };
}

function calculateDistance(point1, point2) {
    return parseInt(Math.abs(point1.x - point2.x) * Math.abs(point1.x - point2.x)
    + Math.abs(point1.y - point2.y) * Math.abs(point1.y - point2.y));
}

function IsPossibleFormingATriangle(line1, line2, line3) {
    var a = calculateDistance(line1.pointA, line1.pointB);
    var b = calculateDistance(line2.pointA, line2.pointB);
    var c = calculateDistance(line3.pointA, line3.pointB);
    if (a + b > c && a + c > b && b + c > a) {
        document.write("true");
    } else {
        document.write("false");
    }
}

var p1 = getPoint(10, 22);
var p2 = getPoint(22, 24);
var p3 = getPoint(31, 12);

var l1 = getLine(p1, p2);
var l2 = getLine(p2, p3);
var l3 = getLine(p1, p3);

var n = calculateDistance(p3, p2);
document.write(n+'<br/>');


IsPossibleFormingATriangle(l1, l2, l3);

