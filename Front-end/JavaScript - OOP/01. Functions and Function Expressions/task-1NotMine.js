function solve() {
    let library = (function() {
        let books = [];
        let categories = [];

        function listBooks(param) {
            let result = [];

            if (!param) {
                result = books;
            } else if (param.category) {
                result = books.filter(function(b) {
                    return b.category === param.category;
                });
            } else if (param.author) {
                result = books.filter(function(b) {
                    return b.author === param.author;
                });
            }

            result = result.sort((book1, book2) => {
                return book1.ID - book2.ID;
            });

            return result;
        }

        function addBook(book) {

            //validate title
            if (book.title.length < 2 || book.title.length > 100) {
                throw '';
            }

            if (isTitleUnique(book)) {
                throw '';
            }

            //validate author
            if (book.author === '') {
                throw '';
            }

            //validate isbn
            if (book.isbn.length !== 10 && book.isbn.length !== 13) {
                throw '';
            }

            if (isIsbnUnique(book)) {
                throw '';
            }

            //validate category
            if (categories.indexOf(book.category) === -1) {
                categories.push(book.category);
            }

            book.ID = books.length + 1;
            books.push(book);

            return book;
        }

        function listCategories() {
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };

        // Helper functions        
        function isNumber(num) {
            return !isNaN(parseFloat(num)) && isFinite(num);
        }

        function isTitleUnique(someBook) {

            return books.some(b => {
                return b.title === someBook.title;
            });
        }

        function isIsbnUnique(someBook) {

            return books.some(b => {
                return b.isbn === someBook.isbn;
            });
        }

    }());

    return library;
}

module.exports = solve;