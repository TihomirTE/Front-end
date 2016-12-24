function binarySearch(x) {
    let arr,
        number,
        element,
        minIndex,
        maxIndex,
        currentIndex,
        currentElement;
    number = +x[0];
    element = +x[number + 1];
    arr = [].slice.apply(x);
    arr.pop();
    arr.shift();

    minIndex = 0;
    maxIndex = number - 1;
    while (minIndex <= maxIndex) {
        currentIndex = (minIndex + maxIndex) / 2 | 0;
        currentElement = +x[currentIndex];
        if (currentElement < element) {
            minIndex = currentIndex + 1;
        } else if (currentElement > element) {
            maxIndex = currentIndex - 1;
        } else {
            while (+x[currentIndex] === +x[currentIndex - 1]) {
                currentIndex -= 1;
            }
            console.log(currentIndex - 1);
            return;
        }
    }
    console.log(-1);
    return;
}


//binarySearch(['11', '1', '2', '4', '8', '16', '31', '32', '32', '64', '77', '99', '32']);