function sort(x) {
    let arr,
        i,
        j,
        current,
        count = 1,
        biggestSeq = 0;

    for (i = 0; i < x.length; i += 1) {
        for (j = 0; j < x.length - 1; j += 1) {
            if (+x[j] >= +x[j + 1]) {
                current = x[j];
                x[j] = x[j + 1];
                x[j + 1] = current;
            }
        }
    }
    for (i = 0; i < x.length; i += 1) {
        if (Number(x[i] === x[i + 1])) {
            count += 1;
            if (count > biggestSeq) {
                biggestSeq = count;
                current = x[i];
            }
        } else {
            count = 1;
        }
    }
    console.log(current + ' (' + biggestSeq + ' times)');
}

//sort(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3'])