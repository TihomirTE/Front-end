function solve(args) {
    let num,
        min = Number.MAX_VALUE,
        max = Number.MIN_VALUE,
        sum = 0,
        avrg = 0,
        len = args.length;

    for (let i = 0; i < len; i += 1) {
        num = +args[i];
        if (min > num) {
            min = num;
        }
        if (max < num) {
            max = num;
        }
        sum += num;
    }
    avrg = sum / len;

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + avrg.toFixed(2));


}

solve(['2.5', '-1.3', '4']);