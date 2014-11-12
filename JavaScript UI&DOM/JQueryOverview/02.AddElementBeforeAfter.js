// extend jquery functionality
$.prototype.addElementBefore = function (elementToAppend) {
    $(this).before(elementToAppend);
};

$.prototype.addElementAfter = function (elementToPrepend) {
    $(this).after(elementToPrepend);
};

var countBefore = 0;
var countAfter = 0;

$('#add-top').on('click', function () {
    countBefore++;

    var elementToAddBefore = $('<div />');
    elementToAddBefore.addClass('added-top');
    elementToAddBefore.text('top ' + countBefore);

    $('.elementToSurround').addElementBefore(elementToAddBefore);
});

$('#add-bottom').on('click', function () {
    countAfter++;

    var elementToAddAfter = $('<div />');
    elementToAddAfter.addClass('added-bottom');
    elementToAddAfter.text('bottom ' + countAfter);

    $('.elementToSurround').addElementAfter(elementToAddAfter);
});