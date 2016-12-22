function sequence(x) {
    let arr,
        count = 1,
        biggestSeq = 0;
    arr = [].slice.apply(x);
    for (let i = 0; i < arr.length - 1; i += 1) {
        if (Number(arr[i] === arr[i + 1])) {
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




//sequence(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']);