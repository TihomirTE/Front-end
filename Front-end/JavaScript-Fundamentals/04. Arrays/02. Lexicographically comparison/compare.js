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
            return console.log('<');

        } else if (str2[i] < str1[i]) {
            return console.log('>');
        }
    }

    if (str1.length === str2.length) {
        return console.log('=');
    } else if (str1.length < str2.length) {
        return console.log('<');
    } else {
        return console.log('>');
    }
}

//compare(['hello', 'halo']);
//compare(['food', 'food']);