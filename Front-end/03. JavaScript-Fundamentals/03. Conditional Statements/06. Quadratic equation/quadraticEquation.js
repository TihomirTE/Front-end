function discriminant(args) {
    let a, b, c, d;
    a = Number(args[0]);
    b = Number(args[1]);
    c = Number(args[2]);

    d = Math.pow(b, 2) - 4 * a * c;
    if (d < 0) {
        console.log('no real roots');
    } else {
        let arr = [a, b, c, d];
        findRoots(arr);
        console.log([findRoots(arr)]);
    }

    function findRoots(arr) {
        let x1, x2, a, b, c, d, result, min, max;
        a = arr[0];
        b = arr[1];
        c = arr[2];
        d = arr[3];
        if (d === 0) {
            x1 = (-b) / (2 * a);
            result = ('x1=x2=' + x1.toFixed(2));
            return result;
        } else {
            x1 = ((-b) + Math.sqrt(Math.pow(b, 2) - 4 * a * c)) / (2 * a);
            x2 = ((-b) - Math.sqrt(Math.pow(b, 2) - 4 * a * c)) / (2 * a);
            min = x1;
            max = x2;
            if (x2 < min) {
                min = x2;
                max = x1;
            }
            result = ('x1=' + min.toFixed(2) + '; x2=' + max.toFixed(2));
            return result;
        }
    }

}


/*discriminant(['2', '5', '-3']);
discriminant(['-1', '3', '0']);
discriminant(['-0.5', '4', '-8']);
discriminant(['5', '2', '8']);
discriminant(['0.2', '9.572', '0.2']);*/