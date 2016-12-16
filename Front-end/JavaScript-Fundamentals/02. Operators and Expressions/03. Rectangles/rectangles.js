result(['2.5', '3']);
result(['5', '5']);
result(['3', '4']);

function result(args) {
    let width = +args[0];
    let height = +args[1];

    let area = width * height;
    let perimeter = (2 * width) + (2 * height);

    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));

}