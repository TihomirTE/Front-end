result(['4', '1', '3']);


function result(args) {
    let a = +args[0];
    let b = +args[1];
    let c = +args[2];


    if (a >= b) {
        if (a >= c) {
            if (c >= b)
                console.log(a, c, b);
            else
                console.log(a, b, c);
        }
    } else if (b > a) {
        if (b >= c) {
            if (c >= a)
                console.log(b, c, a);
            else
                console.log(b, c, a);
        }
    } else {
        if (a >= b) {
            if (c >= a)
                console.log(b, c, a);
            else
                console.log(b, c, a);
        }
    }

}