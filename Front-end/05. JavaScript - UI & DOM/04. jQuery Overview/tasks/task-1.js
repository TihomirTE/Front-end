 function solve() {

     return function(selector, count) {

         if (isNaN(count)) {
             throw new Error('count is not a number');
         }

         if (count === undefined) {
             throw new Error('count is missing');
         }

         if (count < 1) {
             throw new Error('count is less than 1');
         }

         if (typeof(selector) !== 'string') {
             throw new Error('invalid string');
         }

         var element = $(selector),
             ul = $('<ul />').addClass('items-list'),
             li;


         for (var i = 0; i < count; i += 1) {
             li = $('<li />')
                 .addClass('list-item')
                 .text('List item #' + i);

             li.appendTo(ul);
         }

         ul.appendTo(element);
     };
 }


 module.exports = solve;