//Write a function that removes all elements with a given value
//var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
//arr.remove(1); //arr = [2,4,3,4,111,3,2,"1"];
//Attach it to the array class
//Read about prototype and how to attach methods

Array.prototype.remove = function (element) {
    var newArr = [];
    for (var i in this) {
        if (this[i] != element) {
            newArr.push(this[i]);
        }
    }
    return newArr;
}

var arr = [1, 2, 1, 4, 1, "1", 3, 4, 1, 111, 3, 2, 1, "1"];

var finalArr = arr.remove(1);

for (var i in finalArr) {
    document.write(finalArr[i] + "</br>");
}
