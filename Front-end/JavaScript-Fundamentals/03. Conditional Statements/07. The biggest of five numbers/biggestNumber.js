function biggest(args) {
    let biggest = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < args.length; i += 1) {
        if (+args[i] > biggest) {
            biggest = +args[i];
        }
    }
    return biggest;
}

console.log(biggest(['5', '2', '2', '4', '1']));
console.log(biggest(['-2', '-22', '1', '0', '0']));
console.log(biggest(['-2', '4', '3', '2', '0']));
console.log(biggest(['0', '-2.5', '0', '5', '5']));
console.log(biggest(['-3', '-0.5', '-1.1', '-2', '-0.1']));