point(['2.5', '2']);
point(['0', '1']);
point(['2.5', '1']);
point(['1', '2']);

function point(args) {
    let x = +args[0];
    let y = +args[1];
    let radius = 1.5;
    let posCircle = 'outside';
    let currentRadius = Math.sqrt(Math.pow(x - 1, 2) + Math.pow(y - 1, 2));
    if (currentRadius <= radius) {
        posCircle = 'inside';
    }

    let posRectangle = 'outside';
    if ((x >= -1) && (x <= 5) && (y >= -1) && (y <= 1)) {
        posRectangle = 'inside';
    }
    console.log(posCircle + ' circle ' + posRectangle + ' rectangle');

}