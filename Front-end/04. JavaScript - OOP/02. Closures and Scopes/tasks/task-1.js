function solve() {
    'use strict';
    var library = (function() {
        var books = [];
        var categories = [];

        function listBooks(newBook) {

            if (!newBook) {
                return books;
            } else if (newBook.category) {
                return books.filter(function(current) {
                    return current.category === newBook.category;
                });
            } else if (newBook.author) {
                return books.filter(function(current) {
                    return current.author === newBook.author;
                });
            } else {
                return books;
            }
        }

        function addBook(book) {
            validateBook(book);

            if (categories.indexOf(book.category) < 0) {
                categories.push(book.category);
            }

            book.ID = books.length + 1;
            books.push(book);
            return book;
        }

        function listCategories() {
            return categories;
        }

        function validateBook(book) {
            // validate Title length
            if (book.title.length < 2 || book.title.length > 100) {
                throw "Error";
            }

            // check for repeating Title
            // for (let b of books) {
            //     if (b.title === book.title) {
            //         throw "Error";
            //     }
            // }
            books.some(b => {
                if (b.title === book.title) {
                    throw "Error";
                }
            });

            //validate ISBN length
            if (book.isbn.toString().length !== 10 && book.isbn.toString().length !== 13) {
                throw "Error";
            }

            // check for repeating ISBN
            for (let b of books) {
                if (b.isbn === book.isbn) {
                    throw "Error";
                }
            }

            // Validate Author
            if (book.author === '') {
                throw "Error";
            }
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
    }());
    return library;
}
module.exports = solve;