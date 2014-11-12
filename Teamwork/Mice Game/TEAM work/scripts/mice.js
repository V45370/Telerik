/// <reference path="references.js" />
window.onload = function startGame() {
    var MOUSE_WIDTH = 38,
        MOUSE_HEIGHT = 26,
        MOUSE_INITIAL_X = 350,
        MOUSE_INITIAL_Y = 300,
        MOUSE_SPRITE_SOURCE = '../images/Mouse.png',
        SPEED = 15,
        LEFT_ARROW_CODE = 37,
        UP_ARROW_CODE = 38,
        RIGHT_ARROW_CODE = 39,
        DOWN_ARROW_CODE = 40,
        LEFT_SCREEN_BORDER = 0,
        RIGHT_SCREEN_BORDER = 800,
        TOP_SCREEN_BORDER = 0,
        DOWN_SCREEN_BORDER = 600,
        CHEESE_WIDTH = 25,
        CHEESE_HEIGHT = 20,
        CAT_WIDTH = 50,
        CAT_HEIGHT = 50,
        CAT_JUMPS = 20,
        CAT_IMAGE_SRC = '../images/cat.png',
        CATS_COUNT = 3,
        CHEESE_IMAGE_SOURCE = '../images/cheese.png',
        scoreContainerDiv = document.getElementById('scoreContainer'),
        eatenCheese = 0,
        level = 1,
        CHEESE_PER_LEVEL = 10,
        stage = new Kinetic.Stage({
            container: 'animationContainer',
            width: RIGHT_SCREEN_BORDER,
            height: DOWN_SCREEN_BORDER
        }),
    layer = new Kinetic.Layer();

    stage.add(layer);
    generateBackground();

    // This is KineticJS way to add image
    var cheese;
    var cheeseImage = new Image();

    cheese = new Kinetic.Image({
        x: generateRandomNumber(RIGHT_SCREEN_BORDER - CHEESE_WIDTH),
        y: generateRandomNumber(DOWN_SCREEN_BORDER - CHEESE_HEIGHT),
        image: cheeseImage,
        width: CHEESE_WIDTH,
        height: CHEESE_HEIGHT
    })
    layer.add(cheese);
    layer.draw();


    cheeseImage.src = CHEESE_IMAGE_SOURCE;

    var cats = [CATS_COUNT];
    var catImage = new Image();

    function populateWithCats() {
        var currentCat;
        for (var i = 0; i < CATS_COUNT; i++) {
            cats[i] = new Kinetic.Image({
                x: generateRandomNumber(RIGHT_SCREEN_BORDER - CAT_WIDTH),
                y: generateRandomNumber(DOWN_SCREEN_BORDER - CAT_HEIGHT),
                image: catImage,
                width: CAT_WIDTH,
                height: CAT_HEIGHT
            });
            //currentCat = new Kinetic.Image(cats[i]);
            layer.add(cats[i]);
            layer.draw();
        }

    }
    populateWithCats();

    function addCat() {
        cats[CATS_COUNT] = new Kinetic.Image({
            x: generateRandomNumber(RIGHT_SCREEN_BORDER - CAT_WIDTH),
            y: generateRandomNumber(DOWN_SCREEN_BORDER - CAT_HEIGHT),
            image: catImage,
            width: CAT_WIDTH,
            height: CAT_HEIGHT
        });
        //currentCat = new Kinetic.Image(cats[i]);
        layer.add(cats[CATS_COUNT]);
        CATS_COUNT += 1;
        layer.draw();
    }

    //moving cats generateRandom==1 move TopLeft if generateRandom==2 move TopRight etc.
    function moveCats() {
        for (var i = 0; i < CATS_COUNT; i++) {
            var cat = cats[i];

            switch (generateRandomNumber(4)) {
                case 1: {
                    moveCatLeft(cat);
                    moveCatUp(cat);
                    break;
                }
                case 2: {
                    moveCatLeft(cat);
                    moveCatDown(cat);
                    break;
                }
                case 3: {
                    moveCatRight(cat);
                    moveCatUp(cat);
                    break;
                }
                case 4: {
                    moveCatRight(cat);
                    moveCatDown(cat);
                    break;
                }
            }

            layer.draw();
            stage.draw();
        }
    }

    function moveCatLeft(cat) {
        var catX = cat.attrs.x - generateRandomNumber(CAT_JUMPS);

        if (canMoveLeft(catX)) {
            cat.setX(catX);
        }
    }

    function moveCatRight(cat) {
        var catX = cat.attrs.x + generateRandomNumber(2 * CAT_JUMPS);

        if (canMoveRight(catX, CAT_WIDTH)) {
            cat.setX(catX);
        }
    }

    function moveCatUp(cat) {
        var catY = cat.attrs.y - generateRandomNumber(CAT_JUMPS);

        if (canMoveUp(catY)) {
            cat.setY(catY);
        }
    }

    function moveCatDown(cat) {
        var catY = cat.attrs.y + generateRandomNumber(2 * CAT_JUMPS);

        if (canMoveDown(catY, CAT_HEIGHT)) {
            cat.setY(catY);
        }
    }

    setInterval(function () {
        moveCats();

        var isMouseOnCat = checkIsMouseOnCat(moveMouse, cats);
        if (isMouseOnCat) {
            $('svg').remove();
            $('canvas').remove();
            scoreContainerDiv.innerHTML = "";
            showMenu();
        }
    }, 700);
    catImage.src = CAT_IMAGE_SRC;



    // This is KineticJS way to add sprite animation 
    var moveMouse;
    var mouse = new Image();
    mouse.onload = function () {
        moveMouse = new Kinetic.Sprite({
            x: MOUSE_INITIAL_X,
            y: MOUSE_INITIAL_Y,
            image: mouse,
            animation: 'idle',
            animations: {
                idle: [
                    // x, y, width, height (1 frame)
                    12, 20, 24, 26,
                ],
                moveDown: [
                    // x, y, width, height (4 frame)
                    12, 20, 24, 26,
                    60, 22, 24, 24,
                    108, 20, 24, 26,
                    156, 22, 24, 24
                ],
                moveLeft: [
                    6, 70, 38, 24,
                    52, 70, 38, 24,
                    102, 70, 38, 24,
                    148, 70, 38, 24
                ],
                moveRight: [
                    4, 118, 38, 24,
                    54, 118, 38, 24,
                    100, 118, 38, 24,
                    150, 118, 38, 24
                ],
                moveUp: [
                    12, 164, 24, 26,
                    60, 166, 24, 24,
                    108, 164, 24, 26,
                    156, 166, 24, 24
                ]
            },
            frameRate: 5,
            frameIndex: 0
        });

        layer.add(moveMouse);
        layer.draw();

        // Function "start()" come from "KineticJS"
        moveMouse.start();

        var frameCount = 0;

        // Function "on" come from "KineticJS"
        moveMouse.on('frameIndexChange', function (evt) {
            // Set 'idle image' after key is up(not presses any more)
            if ((moveMouse.animation() === 'moveLeft' || moveMouse.animation() === 'moveRight' ||
                 moveMouse.animation() === 'moveUp' || moveMouse.animation() === 'moveDown') && ++frameCount > 3
                ) {
                moveMouse.animation('idle');
                frameCount = 0;
            }
        });

        window.addEventListener('keydown', onKeyDown);
    };

    mouse.src = MOUSE_SPRITE_SOURCE;

    function onKeyDown(evt) {
        switch (evt.keyCode) {
            case LEFT_ARROW_CODE: moveMouseLeft(moveMouse); break;
            case RIGHT_ARROW_CODE: moveMouseRight(moveMouse); break;
            case DOWN_ARROW_CODE: moveMouseDown(moveMouse); break;
            case UP_ARROW_CODE: moveMouseUp(moveMouse); break;
        }

        // We need to check the position of the mouse on every key stroke
        var isMouseOnCheese = checkIsMouseOnCheese(moveMouse, cheese);


        if (isMouseOnCheese) {
            changeCheesePosition(cheese);
            eatenCheese++;
            if (eatenCheese % CHEESE_PER_LEVEL === 0) {
                levelUp();
            }
            scoreContainerDiv.innerHTML = 'Score: ' + eatenCheese + ', Level: ' + level;
        }

    };

    function levelUp() {
        level += 1;

        // TODO: Add new cat
        addCat();
        // TODO: if(level%3 === 0) { // make cats move faster }
    }

    function showMenu() {
        var gameOver = new Kinetic.Text({
            x: RIGHT_SCREEN_BORDER / 2,
            y: DOWN_SCREEN_BORDER / 2,
            text: 'GAME OVER \n score :' + eatenCheese,
            fontSize: 40,
            fontFamily: 'Calibri',
            fill: 'red'
        });

        var menu = new Kinetic.Layer();
        stage.add(menu);
        var optionsText = ['Start', 'Help', 'Highscores - not done', 'Something else'];
        var options = [];
        var selected = 0;
        var color = 'red';

        function list() {
            var curPosX = DOWN_SCREEN_BORDER / 2 + 80;
            for (var i = 0; i < optionsText.length; i++) {
                if (i == selected) {
                    color = 'green';
                }
                else {
                    color = 'red';
                }
                options[i] = new Kinetic.Text({
                    x: RIGHT_SCREEN_BORDER / 2,
                    y: curPosX + 30,
                    text: optionsText[i],
                    fontSize: 30,
                    fontFamily: 'Calibri',
                    fill: color
                });
                curPosX += 30;
            }
            menu.add(gameOver);

            for (var i = 0; i < options.length; i++) {
                menu.add(options[i]);
            }
            menu.draw();
        }
        list();

        window.addEventListener('keydown', function (evt) {
            switch (evt.keyCode) {
                case DOWN_ARROW_CODE:
                    selected++;
                    list();
                    break;
                case UP_ARROW_CODE:
                    selected--;
                    list();
                    break;
                case 13:
                    if (selected == 0) {

                        startGame();

                        //return;
                    }
                    break;
            };
        });


    }

    function moveMouseLeft(mouse) {
        var canMove = canMoveLeft(mouse.attrs.x);

        if (canMove) {
            mouse.setX(mouse.attrs.x += -1 * SPEED);
            mouse.attrs.animation = 'moveLeft';
        }
    }

    function moveMouseRight(mouse) {
        var canMove = canMoveRight(mouse.attrs.x, MOUSE_WIDTH);

        if (canMove) {
            mouse.setX(mouse.attrs.x += SPEED);
            mouse.attrs.animation = 'moveRight';
        }
    }

    function moveMouseDown(mouse) {
        var canMove = canMoveDown(mouse.attrs.y, MOUSE_HEIGHT);

        if (canMove) {
            mouse.setY(mouse.attrs.y += SPEED);
            mouse.attrs.animation = 'moveDown';
        }
    }

    function moveMouseUp(mouse) {
        var canMove = canMoveUp(mouse.attrs.y);

        if (canMove) {
            mouse.setY(mouse.attrs.y += -1 * SPEED);
            mouse.attrs.animation = 'moveUp';
        }
    }

    function canMoveLeft(x) {
        var canMoveLeft = false;

        if (x > LEFT_SCREEN_BORDER + 5) {
            canMoveLeft = true;
        }

        return canMoveLeft;
    }

    function canMoveRight(x, imageWidth) {
        var canMoveRight = false;

        if (x < RIGHT_SCREEN_BORDER - imageWidth) {
            canMoveRight = true;
        }

        return canMoveRight;
    }

    function canMoveDown(y, imageHeight) {
        var canMoveDown = false;

        if (y < DOWN_SCREEN_BORDER - imageHeight - 5) {
            canMoveDown = true;
        }

        return canMoveDown;
    }

    function canMoveUp(y) {
        var canMoveUp = false;

        if (y > TOP_SCREEN_BORDER) {
            canMoveUp = true;
        }

        return canMoveUp;
    }

    function changeCheesePosition(cheese) {
        var x = generateRandomNumber(RIGHT_SCREEN_BORDER - CHEESE_WIDTH),
            y = generateRandomNumber(DOWN_SCREEN_BORDER - CHEESE_HEIGHT);

        cheese.setPosition({ x: x, y: y });

        layer.draw();
        stage.draw();
    }

    function checkIsMouseOnCheese(mouse, cheese) {
        var isMouseOnCheese = false;

        if (
            mouse.attrs.x > cheese.attrs.x - CHEESE_WIDTH &&
            mouse.attrs.x < cheese.attrs.x + CHEESE_WIDTH &&
            mouse.attrs.y > cheese.attrs.y - CHEESE_HEIGHT &&
            mouse.attrs.y < cheese.attrs.y + CHEESE_HEIGHT
            ) {

            isMouseOnCheese = true;
        }

        return isMouseOnCheese;
    }

    function checkIsMouseOnCat(mouse, cat) {
        var isMouseOnCat = false;
        for (var i = 0; i < CATS_COUNT; i++) {
            if (
                ((mouse.attrs.x > cats[i].attrs.x &&
                mouse.attrs.x < cats[i].attrs.x + CAT_WIDTH) ||
                (mouse.attrs.x < cats[i].attrs.x &&
                mouse.attrs.x + MOUSE_WIDTH > cats[i].attrs.x)) &&
                ((mouse.attrs.y > cats[i].attrs.y &&
                mouse.attrs.y < cats[i].attrs.y + CAT_HEIGHT) ||
                (mouse.attrs.y < cats[i].attrs.y &&
                mouse.attrs.y + MOUSE_HEIGHT > cats[i].attrs.y))
                ) {
                isMouseOnCat = true;
                break;
            }
        }

        return isMouseOnCat;
    }

    function generateRandomNumber(maxNumber) {
        var randomNumber = (Math.random() * maxNumber) | 0;

        return randomNumber;
    }

    //var canvas = document.getElementById("the-canvas");
    //var ctx = canvas.getContext("2d");

    //var bgReady = false;
    //var bgImage = new Image();
    //bgImage.onload = function () {
    //    bgReady = true;
    //};
    //bgImage.src = "images/background.png";
    //var heroImage = document.createElement("div");
    //heroImage.style.width = 200 + 'px';
    //heroImage.style.height = 100 + 'px';
    //heroImage.style.border = 1 + 'px solid black';
    //heroImage.style.zIndex = 100;
    //document.body.appendChild(heroImage);

    //var hero = {
    //    speed: 256, // movement in pixels per second
    //    x: 0,
    //    y: 0
    //};
    //var monster = {
    //    x: 0,
    //    y: 0
    //};

    //function Treat() {
    //    this.sizeX = 20;
    //    this.sizeY = 20;
    //    this.y = Math.floor((Math.random() * DOWN_SCREEN_BORDER - this.sizeY) + 1);
    //    this.x = Math.floor((Math.random() * RIGHT_SCREEN_BORDER - this.sizeX) + 1);
    //    this.eaten = false;
    //}

    //var monstersCaught = 0;
    //var treatsEaten = 0;

    // Handle keyboard controls
    //var keysDown = {};

    //addEventListener("keydown", function (e) {
    //    keysDown[e.keyCode] = true;
    //}, false);

    //addEventListener("keyup", function (e) {
    //    delete keysDown[e.keyCode];
    //}, false);

    // Reset the game when the player catches a monster
    //var reset = function () {
    //    hero.x = MOUSE_INITIAL_X;
    //    hero.y = MOUSE_INITIAL_X;

    //    // Throw the monster somewhere on the screen randomly
    //    monster.x = 32 + (Math.random() * (canvas.width - 64));
    //    monster.y = 32 + (Math.random() * (canvas.height - 64));
    //};

    // Update game objects
    //var update = function (modifier) {
    //    if (38 in keysDown) { // Player holding up
    //        hero.y -= hero.speed * modifier;
    //    }
    //    if (40 in keysDown) { // Player holding down
    //        hero.y += hero.speed * modifier;
    //    }
    //    if (37 in keysDown) { // Player holding left
    //        hero.x -= hero.speed * modifier;
    //    }
    //    if (39 in keysDown) { // Player holding right
    //        hero.x += hero.speed * modifier;
    //    }

    //    // Are they touching?
    //    if (hero.x <= (monster.x + 32) &&
    //        monster.x <= (hero.x + 32) &&
    //        hero.y <= (monster.y + 32) &&
    //        monster.y <= (hero.y + 32)
    //        ) {
    //        ++monstersCaught;
    //        reset();
    //    }

    //    if (((hero.x <= cheese.x && hero.x + 100 >= cheese.x) || (hero.x >= cheese.x && hero.x <= cheese.x + cheese.sizeX)) &&
    //        ((hero.y <= cheese.y && hero.y + 100 >= cheese.y) || (hero.y >= cheese.y && hero.y <= cheese.y + cheese.sizeY))
    //        ) {
    //        cheese.eaten = true;
    //        treatsEaten++;
    //    };
    //};

    //var cheese = new Treat();

    // ???



    //function updateChees(hero, monster) {
    //    //Are they touching?
    //    //if (hero.attrs.x <= (monster.x + 32) &&
    //    //       monster.x <= (hero.attrs.x + 32) &&
    //    //       hero.attrs.y <= (monster.y + 32) &&
    //    //       monster.y <= (hero.attrs.y + 32)
    //    //       ) {
    //    //    ++monstersCaught;
    //    //    reset();
    //    //}

    //    if (((hero.attrs.x <= cheese.x && hero.x + 100 >= cheese.x) || (hero.attrs.x >= cheese.x && hero.attrs.x <= cheese.x + cheese.sizeX)) &&
    //    ((hero.attrs.y <= cheese.y && hero.attrs.y + 100 >= cheese.y) || (hero.attrs.y >= cheese.y && hero.attrs.y <= cheese.y + cheese.sizeY))
    //    ) {
    //        cheese.eaten = true;
    //        treatsEaten++;
    //    }

    //    if (cheese.eaten === true) {
    //        cheese = new Treat();
    //    }
    //}


    //var render = function () {
    //    //if (bgReady) {
    //    //    ctx.drawImage(bgImage, 0, 0);
    //    //}
    //    ctx.clearRect(0, 0, 800, 600);
    //    //if (heroReady) {
    //    ctx.fillRect(hero.x, hero.y, 100, 100);
    //    //}
    //    if (cheese.eaten === true) {
    //        cheese = new Treat();
    //    }
    //    ctx.fillRect(cheese.x, cheese.y, cheese.sizeX, cheese.sizeY);


    //    //ctx.drawImage(monsterImage, monster.x, monster.y);

    //    // Score
    //    ctx.fillStyle = "rgb(250, 250, 250)";
    //    ctx.font = "24px Helvetica";
    //    ctx.textAlign = "left";
    //    ctx.textBaseline = "top";
    //    //ctx.fillText("Monsterrs caught: " + monstersCaught, 32, 32);
    //};

    // The main game loop
    //    var main = function () {
    //        var now = Date.now();
    //        var delta = now - then;

    //        update(delta / 1000);
    //        render();

    //        then = now;

    //        // Request to do this again ASAP
    //        requestAnimationFrame(main);
    //    };

    //    // Cross-browser support for requestAnimationFrame
    //    var w = window;
    //    requestAnimationFrame = w.requestAnimationFrame ||
    //                            w.webkitRequestAnimationFrame ||
    //                            w.msRequestAnimationFrame ||
    //                            w.mozRequestAnimationFrame;

    //    // Let's play this game!
    //    var then = Date.now();
    //    reset();
    //    main();
}