function solve() {

    const nextId = (function() {
        let counter = 0;
        return function() {
            counter += 1;
            return counter;
        };
    }());

    // Properties name, title and author are a strings between 3 and 25 characters
    function validatorNameLength(name) {
        if (typeof name !== 'string' || name.length < 3 || name.length > 25) {
            throw 'invalid name';
        }
    }

    class Player {
        constructor(name) {
            this.name = name;
            this._id = nextId();
            this._playlists = [];
        }

        get name() {
            return this._name;
        }

        set name(n) {
            validatorNameLength(n);

            this._name = n;
        }

        get id() {
            return this._id;
        }

        get playlists() {
            return this._playlists;
        }

        addPlaylist(playlistToAdd) {

            if (typeof playlistToAdd === 'undefined' ||
                typeof playlistToAdd !== this._playlists) {

                throw 'playlistToAdd must be a PlayList instance';
            }

            this._playlists.push(playlistToAdd);

            return this;
        }

        getPlaylistById(id) {
            if (typeof id !== 'number') {
                throw 'id is not a number';
            }

            if (this._playlists.find(p => p.id === id)) {
                return this;
            }
            return null;
        }

        removePlaylist(id) {
            let playlist = this._playlists.indexOf(id);
            if (playlist < 0) {
                throw 'playlist does not exist';
            }

            return this._playlists.splice(playlist, 1);
        }

        listPlaylists(page, size) {
            if (page * size >= this._playlists.length || page < 0 || size <= 0) {
                throw 'out of range';
            }

            return this._playlists
                .slice()
                .sort((x, y) => x.name - y.name)
                .sort((x, y) => x.id - y.id)
                .splice(page * size, size);
        }

        contains(playable, playlist) {

        }

        search(pattern) {

        }
    }

    class Playlist {
        constructor(name) {
            this.name = name;
            this._id = nextId();
            this._playables = [];
        }

        get name() {
            return this._name;
        }

        set name(n) {
            validatorNameLength(n);

            this._name = n;
        }

        get id() {
            return this._id;
        }

        get playables() {
            return this._playables;
        }



        addPlayable(playable) {

            this._playables.push(playable);
            return this;
        }

        getPlayableById(id) {
            if (typeof id !== 'number') {
                throw 'id is not a number';
            }
            if (this._playables.find(p => p.id === id)) {
                return this;
            }
            return null;
        }

        removePlayable(id) {
            let index = this._playables.findIndex(p => p.id === id);

            if (index < 0) {
                throw 'playable is not contained in the playlist';
            }

            this._playables.splice(index, 1);
            return this;
        }

        listPlayables(page, size) {
            if (page * size >= this._playables.length || page < 0 || size <= 0) {
                throw 'out of range';
            }

            return this._playables
                .slice()
                .sort((x, y) => x.title - y.title)
                .sort((x, y) => x.id - y.id)
                .splice(page * size, size);
        }
    }

    class Playable {
        constructor(title, author) {
            this._id = nextId();
            this.title = title;
            this.author = author;
        }

        get id() {
            return this._id;
        }

        get title() {
            return this._title;
        }

        set title(t) {
            validatorNameLength(t);

            this._title = t;
        }

        get author() {
            return this._author;
        }

        set author(auth) {
            validatorNameLength(auth);

            this._author = auth;
        }

        play() {

            return `[${this._id}]. [${this.title}] - [${this.author}]`;
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            this.length = length;
        }

        get length() {
            return this._length;
        }

        set length(len) {
            if (typeof len !== 'number' || len <= 0) {
                throw 'invalid Audio length';
            }

            this._length = len;
        }

        play() {
            return super.play() + ` - [${this.length}]`;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating() {
            return this._imdbRating;
        }

        set imdbRating(imdb) {
            if (typeof imdb !== 'number' || imdb <= 0 || imdb > 5) {
                throw 'invalid Video length';
            }

            this._imdbRating = imdb;
        }

        play() {
            return super.play() + ` - [${this.imdbRating}]`;
        }

    }

    const module = {
        getPlayer: function(name) {
            return new Player(name);
        },
        getPlaylist: function(name) {
            return new Playlist(name);
        },
        getAudio: function(title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function(title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };

    return module;
}

module.exports = solve;