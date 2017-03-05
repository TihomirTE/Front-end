/*result(['2.5', '3']);
result(['5', '5']);
result(['3', '4']);*/

function result(args) {
    var width = +args[0],
        height = +args[1];

    var area = width * height;
    var perimeter = (2 * width) + (2 * height);

    console.log(area.toFixed(2) + ' ' + perimeter.toFixed(2));
}