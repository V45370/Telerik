//Task 1
console.log("\n01. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. \n");

var Student = (function() {
    function Student(fname, lname, age, highMark) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
        this.highMark = highMark;
    }

    Student.prototype.toString = function() {
        return this.fname + " " + this.lname;
    }

    return Student;

})();

var students = [
    new Student("Aleksandyr", "Hristov", 22, 5),
    new Student("Stefan", "Kolev", 21, 2),
    new Student("Tsvetan", "Hristov", 20, 4),
    new Student("Iliana", "Eneva", 28, 3),
    new Student("Danail", "Dimitrov", 25, 5),
    new Student("Georgi", "Terzov", 19, 6)
];

var studentsFirstNameBeforeLast = _.filter(students, function(st) {
    return st.lname > st.fname;
}).reverse();

_.each(studentsFirstNameBeforeLast, function(st) {
    console.log(st.toString());
});

//Task 2
console.log("\n02. Write function that finds the first name and last name of all students with age between 18 and 24.\n ");

var studentsBetweenEighteenAndTwentyFour = _.filter(students, function(st) {
    return st.age >= 18 && st.age <= 24;
});
_.each(studentsBetweenEighteenAndTwentyFour, function(st) {
    console.log(st.toString() + " " + st.age);
});

//Task 3
console.log("\n03. Write a function that by a given array of students finds the student with highest marks\n");
var studenthighMark = _.max(students, function(st) {
    return st.highMark;
});
console.log(studenthighMark.toString() +
    " " + studenthighMark.highMark);

//Task 4
console.log("\n04. Write a function that by a given array of animals, groups them by species and sorts them by number of legs\n");

var Animal = (function() {
    function Animal(spicie, type, legs) {
        this.spicie = spicie;
        this.type = type;
        this.legs = legs;
    }

    Animal.prototype.toString = function() {
        return this.type + " legs:" + this.legs;
    }

    return Animal;
})();


var animals = [
    new Animal("Mammals", "Human", 2),
    new Animal("Mammals", "Cat", 4),
    new Animal("Mammals", "Horse", 4),
    new Animal("Insects", "Fly", 4),
    new Animal("Insects", "Spider", 8),
    new Animal("Insects", "Centipede", 100),
    new Animal("Reptiles", "Lizard", 4),
    new Animal("Reptiles", "Snake", 0),
    new Animal("Reptiles", "T-Rex", 2)
]

var orderedAnimalsBySpicie = _.groupBy(animals, 'spicie');

for (var prop in orderedAnimalsBySpicie) {
    var sortedSpiciesByLegs = _.sortBy(orderedAnimalsBySpicie[prop], function(a) {
        return a.legs;
    });
    orderedAnimalsBySpicie[prop] = sortedSpiciesByLegs;
}

console.log("\n");
_.each(orderedAnimalsBySpicie, function(a) {
    console.log(a[0].spicie + ":\n");
    for (var i in a) {
        console.log(a[i].toString());
    }
    console.log("\n");
});

//Task 5
console.log("\n05. By a given array of animals, find the total number of legs\n");
var sumLegs = _.reduce(animals, function(memo, a) {
    return memo + a.legs;
}, 0);
console.log("\nsum of legs: " + sumLegs);

//Task 6
console.log("\n06. By a given collection of books, find the most popular author (the author with the highest number of books)\n");
var Book = (function() {
    function Book(author, title) {
        this.author = author;
        this.title = title;
    }
    return Book;
})();
var books = [
    new Book("Aleko Konstantinov", "Feiletoni.Pytepisi"),
    new Book("Ivan Vazov", "Pod Igoto"),
    new Book("Aleko Konstantinov", "Bai Ganio"),
    new Book("Dimityr Dimov", "Tiutiun"),
    new Book("Aleko Konstantinov", "Do Chikago i nazad"),
    new Book("Dimityr Talev", "Jeleznia Svetilnik")
];


var mostPopularAuthor = _.countBy(books, function(b) {
    return b.author;
});

var valueOfMostPopularAuthor = _.max(mostPopularAuthor, function(a) {
    return a;
});


for (var prop in mostPopularAuthor) {
    if (mostPopularAuthor[prop] == valueOfMostPopularAuthor) {
        console.log(prop + ": " + valueOfMostPopularAuthor + " books")
    }
}
var People = (function() {
    function People(fname, lname) {
        this.fname = fname;
        this.lname = lname;
    }
    People.prototype.toString = function() {
        return "First";
    }
    return People;
})();

//Task 7
console.log("\n07. By an array of people find the most common first and last name.\n");
var peoples = [
    new People("Stefan", "Kolev"),
    new People("Tsvetan", "Hristov"),
    new People("Iliana", "Eneva"),
    new People("Danail", "Dimitrov"),
    new People("Georgi", "Terzov"),
    new People("Georgi", "Bonev"),
    new People("Vasil", "Bonev")
];

var mostPopularFirstname = _.countBy(peoples, function(p) {
    return p.fname;
});

var valueOfMostPopularFirstname = _.max(mostPopularFirstname, function(c) {
    return c;
});


for (var prop in mostPopularFirstname) {
    if (mostPopularFirstname[prop] == valueOfMostPopularFirstname) {
        console.log("\nMost common first name: " + prop +
            "  " + valueOfMostPopularFirstname + " times")
    }
}

var mostPopularLastName = _.countBy(peoples, function(p) {
    return p.lname;
});

var valueOfMostCommonLastName = _.max(mostPopularLastName, function(c) {
    return c;
});


for (var prop in mostPopularLastName) {
    if (mostPopularLastName[prop] == valueOfMostCommonLastName) {
        console.log("\nMost common last name: " + prop +
            "  " + valueOfMostCommonLastName + " times")
    }
}