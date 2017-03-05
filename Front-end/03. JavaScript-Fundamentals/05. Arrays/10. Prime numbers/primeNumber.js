function primeNum(x) {
    let num,
        i,
        j,
        arr;

    num = +x;
    arr = new Array(num + 1);
    for (i = 2; i <= num; i += 1) {
        arr[i] = true;
    }
    let sqr = Math.sqrt(num) | 1;
    for (i = 2; i <= sqr; i += 1) {
        for (j = i + i; j <= num; j += i) {
            arr[j] = false;
        }
    }
    for (i = num; i >= 2; i -= 1) {
        if (arr[i] !== false) {
            return console.log(i);
        }
    }
}

//primeNum('10000000');
//primeNum('126');
//primeNum('26');