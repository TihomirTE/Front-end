function increasingSequence(x) {
    let arr,
        count = 1,
        biggestSeq = 0;
    arr = [].slice.apply(x);
    for (let i = 0; i < arr.length - 1; i += 1) {
        if (Number(arr[i]) < Number(arr[i + 1])) {
            count += 1;
            if (count > biggestSeq) {
                biggestSeq = count;
            }
        } else {
            count = 1;
        }
    }
    console.log(biggestSeq);
}

increasingSequence(['8', '7', '3', '2', '3', '4', '2', '2', '4']);