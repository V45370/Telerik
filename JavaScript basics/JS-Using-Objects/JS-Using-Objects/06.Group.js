//Write a function that groups an array of persons by age, first or last name. The function must return an 
//    associative array, with keys - the groups, and values -arrays with persons in this groups
//Use function overloading (i.e. just one function)
//var persons = {…};
//var groupedByFname = group(persons,"firstname");
//var groupedByAge= group(persons,"age");

function group(arr, prpt) {

    var groupedArr = [];

    var finalArray = [];

    if (prpt == "age") {

        var reppeatlessElements = []; //array with reppeatless elements

        for (var i = 0; i < arr.length; i++) {

            var reppeat = false; //checks if the element reppeats

            for (var j = 0; j < i; j++) {
                if (arr[i].age == arr[j].age) {
                    reppeat = true;
                    break; //if element reppeats break the iteration
                }
            }

            if (reppeat == false) { //if element does not reppeat push it to the reppeatless array
                reppeatlessElements.push(arr[i]);
            }
        }

        for (var i = 0; i < reppeatlessElements.length; i++) {
            var tempArr = [];

            for (var j = 0; j < arr.length; j++) {
                if (reppeatlessElements[i].age == arr[j].age) {
                    tempArr.push(arr[j]);
                    //console.log(reppeatlessElements[i]);
                    //console.log(arr[i]);
                }
            }
            groupedArr.push(tempArr);
        }

        for (var i = 0; i < groupedArr.length; i++) {
            finalArray.push({ Key: groupedArr[i][0].age, Value: groupedArr[i] });
        }

    }
    else // if prpt is "firstname"
    {
        var reppeatlessElements = []; //array with reppeatless elements

        for (var i = 0; i < arr.length; i++) {

            var reppeat = false; //checks if the element reppeats

            for (var j = 0; j < i; j++) {
                if (arr[i].firstname == arr[j].firstname) {
                    reppeat = true;
                    break; //if element reppeats break the iteration
                }
            }

            if (reppeat == false) { //if element does not reppeat push it to the reppeatless array
                reppeatlessElements.push(arr[i]);
            }
        }

        for (var i = 0; i < reppeatlessElements.length; i++) {
            var tempArr = [];

            for (var j = 0; j < arr.length; j++) {
                if (reppeatlessElements[i].firstname == arr[j].firstname) {
                    tempArr.push(arr[j]);
                }
            }
            groupedArr.push(tempArr);
        }

        for (var i = 0; i < groupedArr.length; i++) {
            finalArray.push({ Key: groupedArr[i][0].firstname, Value: groupedArr[i] });
        }
    }

    return finalArray;
}


var persons = [
{ firstname: "Pesho", lastname: "Peshov", age: 20 },
{ firstname: "Gosho", lastname: "Goshov", age: 21 },
{ firstname: "Ivan", lastname: "Ivanov", age: 22 }];

console.log("grouprd by age");

var a = group(persons, "age");

for (var i in a) {
    console.log(a[i]);
}

console.log("grouprd by firstname");

var b = group(persons, "firstname");

for (var i in b) {
    console.log(b[i]);
}
document.write('look at console');
