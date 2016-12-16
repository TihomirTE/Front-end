function primeNum(x) {
    let num,
        i,
        j,
        arr;

    arr = new Array(+x + 1);
    num = +x;
    for (i = 2; i <= num; i += 1) {
        arr[i] = i;
    }

    for (i = 2; i <= Math.sqrt(num); i += 1) {
        for (j = (i * i); j <= num; j += i) {
            arr[j] = false;
        }
    }
    for (i = num; i >= 2; i -= 1) {
        if (arr[i] !== false) {
            console.log(arr[i]);
            return;
        }
    }
}

primeNum(126);