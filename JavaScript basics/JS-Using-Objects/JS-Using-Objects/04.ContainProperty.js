//Write a function that checks if a given object contains a given property
//var obj  = …;
//var hasProp = hasProperty(obj,"length");

function hasProperty(obj, prpt) {
    for (var i in obj) {
        if (i == prpt) {
            return true;
        }
    }
    return false;
}

var test = {
    name: 5,
    age: 7,
    hair: 9
}

var hasPropertyOf = hasProperty(test, "hair");
document.write(hasPropertyOf);
