//Write a function that makes a deep copy of an object
////The function should work for both primitive and reference types

var person = {
    name: 'Gosho',
    age: 20,
    town: 'Varna',
}

var person2 = Object.create(person);
for (var i in person2) {
    document.write(person2[i]);
}


function clone(obj) {
    if (obj == null || "Object" != typeof obj) {
        return obj;
    }

    if (obj instanceof Array) {
        var copy = [];
        for (var i = 0 ; i < obj.length ; i++) {
            copy[i] = clone(obj[i]);
        }
        return copy;
    }

    if (obj instanceof Object) {
        var copy = {};
        for (var attr in obj) {
            if (obj.hasOwnProperty(attr)) {
                copy[attr] = clone(obj[attr]);
            }
        }
        return copy;
    }
    throw new Error("Unable copy format!");
}
document.write("</br>");

var person3 = clone(person);

for (var i in person3) {
    document.write(person3[i]);
}
