function GetMax(a, b, c) {
    let maxNum;
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

GetMax(4, 3, 1);
GetMax(5, 15, 1);