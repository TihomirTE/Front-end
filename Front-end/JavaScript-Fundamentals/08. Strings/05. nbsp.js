function solve(args) {
    let str = args[0],
        arr = [],
        result = '',
        len;

    arr = str.split(' ');
    len = arr.length;
    for (let i = 0; i < len - 1; i += 1) {
        result += arr[i] + '&nbsp;';
    }
    result += arr[len - 1];
    console.log(result);
}

//solve(['This text contains 4 spaces!!']);