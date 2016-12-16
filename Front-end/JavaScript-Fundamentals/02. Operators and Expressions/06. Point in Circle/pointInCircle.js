circle(['-2', '0']);
circle(['-1', '2']);
circle(['-1.5', '-1.5']);
circle(['100', '-30']);
circle(['0', '0']);
circle(['0.9', '-1.93']);
circle(['1', '1.655']);
circle(['0', '1']);

function circle(args) {
    let x = +args[0];
    let y = +args[1];
    let r = 2;
    let currentRadius = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
    if (currentRadius <= r) {
        console.log('yes {0}', currentRadius.toFixed(2));
    } else {
        console.log('no {0}', currentRadius.toFixed(2));
    }
}