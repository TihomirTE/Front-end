/* globals $ */

function solve() {

    return function(selector) {
        var data = {
            animals: [{
                name: 'Lion',
                url: 'https://susanmcmovies.files.wordpress.com/2014/12/the-lion-king-wallpaper-the-lion-king-2-simbas-pride-4685023-1024-768.jpg'
            }, {
                name: 'Turtle',
                url: 'http://www.enkivillage.com/s/upload/images/a231e4349b9e3f28c740d802d4565eaf.jpg'
            }, {
                name: 'Dog'
            }, {
                name: 'Cat',
                url: 'http://i.imgur.com/Ruuef.jpg'
            }, {
                name: 'Dog Again'
            }]
        };
        var template =
            '<div class="container">' +
            '<h1>Animals</h1>' +
            '<ul class="animals-list">' +
            '{{#each animals}}' +
            '<li>' +
            '{{#if url}} {{this.url}} {{/if}}' +
            '</li>' +
            '{{/each}}' +
            '</ul>' +
            '</div>';

        $(selector).html(template);
    };
};

module.exports = solve;