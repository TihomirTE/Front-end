function solve(args) {
    let number = +args[0],
        result = '';
    for (let i = 1; i <= number; i += 1) {
        result += i + ' ';
    }
    console.log(result);
}

//solve(['5']);