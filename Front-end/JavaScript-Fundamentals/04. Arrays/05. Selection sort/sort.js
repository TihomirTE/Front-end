function sort(x) {
    let arr,
        number = Number(x.slice(0, 1)),
        current;

    for (let i = 1; i <= number; i += 1) {
        for (let j = 1; j < number; j += 1) {
            if (+x[j] > +x[j + 1]) {
                current = x[j];
                x[j] = x[j + 1];
                x[j + 1] = current;

            }
        }
    }
    for (let i = 1; i <= number; i += 1) {
        console.log(x[i]);
    }
}

//sort(['6', '3', '4', '1', '5', '2', '6']);
//sort(['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20']);