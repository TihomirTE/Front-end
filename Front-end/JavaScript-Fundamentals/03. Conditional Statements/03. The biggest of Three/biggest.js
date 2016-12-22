/*result(['5', '2', '2']);
result(['-2', '-2', '1']);
result(['-2', '4', '3']);
result(['0', '-2.5', '5']);
result(['-0.1', '-0.5', '-1.1']);*/

function result(args) {
    let a = +args[0];
    let b = +args[1];
    let c = +args[2];
    let biggest = 0;

    if (a >= b) {
        if (a >= c) {
            biggest = a;
        } else {
            biggest = c;
        }
    } else if (b > a) {
        if (b >= c) {
            biggest = b;
        } else {
            biggest = c;
        }
    }
    return biggest;

}