function solve(args) {
    let countOpen = 0,
        countClose = 0,
        text = args[0];

    for (let i = 0; i < text.length; i += 1) {
        if (text[i] === '(') {
            countOpen += 1;
        }
        if (text[i] === ')') {
            countClose += 1;
        }
    }
    if (countOpen === countClose) {
        console.log('Correct');
    } else {
        console.log('Incorrect');
    }


}

//solve(['((a+b)/5-d)']);
//solve([')(a+b))']);