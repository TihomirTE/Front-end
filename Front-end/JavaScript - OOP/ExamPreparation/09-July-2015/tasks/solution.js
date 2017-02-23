function solve() {

    const nextId = (function() {
        let counter = 0;
        return function() {
            counter += 1;
            return counter;
        };
    });

    function validateLengthRange(str, min, max) {
        if (typeof str !== 'string') {
            throw new Error('String is not valid');
        }
        validateNumberRange(str.length, min, max);
    }

    function validateNumberRange(num, min, max) {
        if (typeof num !== 'number' || num < min || n > max) {
            throw new Error('Not a valid number');
        }
    }

    function validateNonEmpty(str) {
        if (typeof str !== 'string' || str === '') {
            throw new Error('String can not be empty');
        }
    }

    function validateIsbn(isbn) {
        if (typeof isbn !== 'string' || !isbn.match(/^([0-9]{10}|[0-9]{13})$/)) {
            throw new Error('Isbn is not valid');
        }
    }

    function validateDuration(duration) {
        if (typeof duration !== 'number' || duration <= 0) {
            throw new Error('Duration has to be greater than 0');
        }
    }

    function validateNumberBigger(n, min) {
        if (typeof n !== 'number' || n <= min) {
            throw 'Not a valid number';
        }
    }


    class Item {
        constructor(description, name) {
            this._id = nextId();
            this.description = description;
            this.name = name;
        }

        get name() {
            return this._name;
        }

        set name(currentName) {
            validateLengthRange(currentName, 2, 40);
            this._name = currentName;
        }

        get description() {
            return this._description;
        }

        set description(currentDescription) {
            validateNonEmpty(currentDescription);
            this._description = currentDescription;
        }

        get id() {
            return this._id;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);

            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn() {
            return this._isbn;
        }

        set isbn(isbn) {
            validateIsbn(isbn);
            this._isbn = isbn;
        }

        get genre() {
            return this._genre;
        }

        set genre(genre) {
            validateLengthRange(genre, 2, 20);
            this._genre = genre;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);

            this.duration = duration;
            this.rating = rating;
        }

        get duration() {
            return this._duration;
        }

        set duration(currDuration) {
            validateDuration(currDuration);
            this._duration = currDuration;
        }

        get rating() {
            return this._rating;
        }

        set rating(currRating) {
            validateNumberRange(currRating, 1, 5);
            this._rating = currRating;
        }
    }

    class Catalog {
        constructor(name) {
            this.name = name;
            this._id = nextId();
            this._items = [];
        }

        get id() {
            return this._id;
        }

        get name() {
            return this._name;
        }

        set name(n) {
            validateLengthRange(n, 2, 40);
            this._name = n;
        }

        get items() {
            return this._items;
        }

        add(...items) {

            if (Array.isArray(items[0])) {
                items = items[0];
            }

            if (items.length === 0) {
                throw new Error('The Array must have at least one item');
            }

            items.forEach(item => {
                if (typeof item !== 'object') {
                    throw new Error('Item not an object');
                }

                validateNumberBigger(item.id, 0);
                validateLengthRange(item.name, 2, 40);
                validateNonEmpty(item.description);
            });

            this._item.push(...items);
            // items.forEach(item => this._items.push(item));

            return this;
        }

        find(arg) {
            function findById(id) {
                if (typeof id !== 'number') {
                    throw new Error('id is not a number');
                }

                let item = this._items.find(item => item.id === id);
                if (typeof item === 'undefined') {
                    item = null;
                }
                return item;
                //return this._items.find(item => item.id === id) || null;

            }

            function findByOptions(options) {
                return this._items.filter(item => {
                    return ((!options.hasOwnProperty('name') || item.name === options.name) &&
                        (!options.hasOwnProperty('id') || item.id === options.id));
                });
            }

            if (typeof arg === 'object') {
                return findByOptions.call(this, arg);
            }
            return findById.call(this, arg);
        }

        search(pattern) {
            validateNonEmpty(pattern);

            return this._items.filter(item => {
                return (item.name.indexOf(pattern) >= 0 || item.description.indexOf(pattern) >= 0);
            });
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (Array.isArray(books[0])) {
                books = books[0];
            }

            books.forEach(book => {
                if (typeof book !== 'object') {
                    throw new Error('Item not an object');
                }

                validateIsbn(book.isbn);
                validateLengthRange(book.genre, 2, 20);
            });

            return super.add(books);
        }

        getGenres() {
            return this._item
                .map(book => book.genre.toLowerCase())
                .sort()
                .filter((genre, index, genres) => genre !== genres[index - 1]);
        }

        find(arg) {
            if (typeof arg === 'object') {
                const books = super.find(arg);
                if (arg.hasOwnProperty('genre')) {
                    return books.filter(book => book.genre === arg.genre);
                }
                return books;
            }

            return super.find(arg);
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...medias) {
            if (Array.isArray(medias[0])) {
                medias = medias[0];
            }

            medias.forEach(media => {
                if (typeof media !== 'object') {
                    throw 'Item not an object';
                }

                validateNumberBigger(media.duration, 0);
                validateNumberRange(media.rating, 1, 5);
            });

            return super.add(medias);
        }

        getTop(count) {
            validateNumberBigger(count, 0);

            return this._items
                .slice()
                .sort((x, y) => y.rating - x.rating)
                .slice(0, count)
                .map(x => {
                    return {
                        name: x.name,
                        id: x.id
                    };
                });
        }

        getSortedByDuration() {
            return this._items
                .slice()
                .sort((x, y) => {
                    if (x.duration === y.duration) {
                        return x.id - y.id;
                    }

                    return y.duration - x.duration;
                });
        }

        find(arg) {
            if (typeof arg === 'object') {
                const medias = super.find(arg);
                if (arg.hasOwnProperty('rating')) {
                    return medias.filter(media => media.rating === arg.rating);
                }
                return medias;
            }

            return super.find(arg);
        }
    } 


    return {
        getBook: function(name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function(name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function(name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function(name) {
            return new MediaCatalog(name);
        }
    };
}

//module.exports = solve;