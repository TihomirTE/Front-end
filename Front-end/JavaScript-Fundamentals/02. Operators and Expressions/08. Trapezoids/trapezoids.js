/*trapezoid(['5', '7', '12']);
trapezoid(['2', '1', '33']);
trapezoid(['8.5', '4.3', '2.7']);
trapezoid(['100', '200', '300']);
trapezoid(['0.222', '0.333', '0.555']);*/



function trapezoid(args) {
    var a = +args['0'],
        b = +args['1'],
        h = +args['2'],
        area = (a + b) / 2 * h;
    console.log(area.toFixed(7));
}