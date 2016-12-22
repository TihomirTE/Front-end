function allocate(num) {
    let i,
        len = Number(num);
    for (i = 0; i < len; i += 1) {
        console.log(i * len);
    }
}

//allocate(['5']);