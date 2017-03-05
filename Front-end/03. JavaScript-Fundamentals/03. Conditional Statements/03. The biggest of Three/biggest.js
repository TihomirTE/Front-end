//result(['5', '2', '2']);
//result(['-2', '-2', '1']);
//result(['-2', '4', '3']);
//result(['0', '-2.5', '5']);
//result(['-0.1', '-0.5', '-1.1']);

function result(args) {
    let a = +args[0],
        b = +args[1],
        c = +args[2],
        biggest = Number.MIN_SAFE_INTEGER;

    if (a >= b) {
        if (a >= c) {
            return biggest = a;
        } else {
            return biggest = c;
        }
    } else if (b > a) {
        if (b >= c) {
            return biggest = b;
        } else {
            return biggest = c;
        }
    }
}