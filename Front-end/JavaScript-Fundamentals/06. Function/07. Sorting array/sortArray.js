function solve(args) {
    let len,
        arr,
        current,
        str = '';

    len = +args[0];
    arr = args[1].split(' ').map(Number);

    for (let i = 0; i < len; i += 1) {
        for (let j = 0; j < len - 1; j += 1) {
            if (arr[j] > arr[j + 1]) {
                current = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = current;
            }
        }
    }
    for (let i = 0; i < len; i += 1) {
        if (i === len - 1) {
            str += arr[i];
        } else {
            str += arr[i] + ' ';
        }
    }
    console.log(str);
}

//solve(['10', '36 10 1 34 28 38 31 27 30 20']);