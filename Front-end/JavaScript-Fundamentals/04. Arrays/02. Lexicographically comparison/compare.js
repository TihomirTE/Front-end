function compare(args) {
    let str1 = args[0],
        str2 = args[1],
        len;

    if (str1.length >= str2.length) {
        len = str1.length;
    } else {
        len = str2.length;
    }

    for (let i = 0; i < len; i += 1) {
        if (str1[i] < str2[i]) {
            return '<';
        } else if (str2[i] < str1[i]) {
            return '>';
        }
    }

    if (str1.length === str2.length) {
        return '=';
    } else if (str1.length < str2.length) {
        return '<';
    } else {
        return '>';
    }
}

console.log(compare(['hello', 'halo']));
console.log(compare(['food', 'food']));