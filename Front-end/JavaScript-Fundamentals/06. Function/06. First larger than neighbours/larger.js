function largerThanNeighbours(args) {
    let arr,
        len,
        previous,
        next,
        index = -1;

    len = +args[0];
    arr = args[1].split(' ').map(Number);

    for (let i = 0; i < len; i += 1) {
        previous = arr[i - 1];
        next = arr[i + 1];
        if (arr[i] > previous && arr[i] > next) {
            return index = i;
        }
    }
    return index;
}

//largerThanNeighbours(['6', '-26 -25 -28 31 2 27']);