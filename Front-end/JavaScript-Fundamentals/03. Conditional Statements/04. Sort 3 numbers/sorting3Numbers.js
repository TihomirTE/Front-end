function solve(args) {
    let str = args[0];
    let a = +(args[0]);
    let b = +(args[1]);
    let c = +(args[2]);

    if (a >= b) {
        if (a >= c && b >= c) {
            console.log(a + " " + b + " " + c);
        } else if (a >= c && c > b) {
            console.log(a + " " + c + " " + b);
        } else {
            console.log(c + " " + a + " " + b);
        }
    } else if (b > a) {
        if (b >= c && a >= c) {
            console.log(b + " " + a + " " + c);
        } else if (b >= c && c > a) {
            console.log(b + " " + c + " " + a);
        } else {
            console.log(c + " " + b + " " + a);
        }
    }
}


//solve([5, 1, 2]);
/*ort(['-2', '-2', '1']);
sort(['-2', '4', '3']);
sort(['0', '-2.5', '5']);
sort(['-1.1', '-0.5', '-0.1']);
sort(['10', '20', '30']);
sort(['1', '1', '1']);*/