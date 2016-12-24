function solve(args) {
    let number = +args[0],
        s = "",
        count = 1;
    for (let i = 0; i < number; i += 1) {
        for (let inner = 0; inner < number; inner += 1) {
            s += count + ' ';
            count++;
        }
        console.log(s);
        count = i + 2;
        s = '';
    }

}


solve(['3']);