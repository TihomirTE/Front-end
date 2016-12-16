function appearanceCount(input) {
    let arr,
        number,
        len,
        count = 0;

    len = +input[0];
    number = +input[2];
    arr = input[1].split(' ').map(Number);

    for (let i = 0; i < len; i += 1) {
        if (arr[i] === number) {
            count += 1;
        }
    }
    console.log(count);
}

appearanceCount(['8', '28 6 21 6 -7856 73 73 -56', '73']);