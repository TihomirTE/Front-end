function GetMax(args) {
    let str = args[0],
        number, a, b, c,
        maxNum;

    numbers = str.split(' ').map(Number);
    a = numbers[0];
    b = numbers[1];
    c = numbers[2];
    if (a >= b) {
        if (a >= c) {
            maxNum = a;
        } else {
            maxNum = c;
        }
    } else if (b > a) {
        if (b >= c) {
            maxNum = b;
        } else {
            maxNum = c;
        }
    }
    console.log(maxNum);

}

//GetMax('4 3 1');
//GetMax('5 15 1');