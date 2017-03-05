function solve(args) {
    var str = args[0],
        reversedStr = '',
        len = str.length;

    for (let i = len - 1; i >= 0; i -= 1) {
        reversedStr += str[i];
    }
    console.log(reversedStr);

    /*function reverse(str) {
        return str.split('').reverse().join('');
    }*/
}

//solve(['telerik']);