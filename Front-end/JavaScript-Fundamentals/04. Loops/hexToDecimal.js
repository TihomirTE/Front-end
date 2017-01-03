function solve(args) {
    let decimalNumber,
        currentNum,
        sum = 0;
    str = args + '';
    for (let i = str.length - 1; i >= 0; i -= 1) {
        currentNum = +str[i];
        if (currentNum >= 0 && currentNum <= 9) {
            decimalNumber = Math.pow(16, (str.length - i - 1)) * (currentNum);
            sum = sum + decimalNumber;
        } else {
            decimalNumber = Math.pow(16, (str.length - i - 1)) * ((str.charCodeAt(i) - 65) + 10);
            sum = sum + decimalNumber;
        }
    }
    console.log(sum);
}


//solve(['4ED528CBB4']);