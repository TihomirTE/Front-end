/*result(['5', '2', '2']);
result(['-2', '-2', '1']);
result(['-2', '4', '3']);
result(['0', '-2.5', '4']);
result(['-1', '-0.5', '-5.1']);*/

function result(args) {
    let a = +args['0'];
    let b = +args['1'];
    let c = +args['2'];

    if (a === 0 || b === 0 || c === 0) {
        console.log('0');
    } else if ((a < 0 && b < 0 && c > 0) || (a < 0 && c < 0 && b > 0) ||
        (b < 0 && c < 0 && a > 0) || (a > 0 && b > 0 && c > 0)) {
        console.log('+');
    } else {
        console.log('-');
    }
}