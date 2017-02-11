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

    return {
        getBook: function(name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function(name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function(name) {
            // return a book catalog instance
        },
        getMediaCatalog: function(name) {
            // return a media catalog instance
        }
    };
}

module.exports = solve;