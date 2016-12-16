function largerThanNeighbours(args) {
    let arr,
        len,
        count = 0,
        previous,
        next;

    len = +args[0];
    arr = args[1].split(' ').map(Number);

    for (let i = 0; i < len; i += 1) {
        previous = arr[i - 1];
        next = arr[i + 1];
        if (arr[i] > previous && arr[i] > next) {
            count += 1;
        }
    }
    console.log(count);
}

largerThanNeighbours(['6', '-26 -25 -28 31 2 27']);