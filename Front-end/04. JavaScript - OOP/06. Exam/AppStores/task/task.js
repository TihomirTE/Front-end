function solve() {

    function validateName(str, min, max) {
        if (typeof str !== 'string') {
            throw new Error('name type is not valid');
        }
        if (str.length < min || str.length > max) {
            throw new Error('name length is not valid');
        }

        if (str.match(/[^a-zA-Z1-9 ]/)) {
            throw new Error('name symbols are not valid');
        }
    }




    class App {
        constructor(name, description, version, rating) {
            this.name = name;
            this.description = description;
            this.version = version;
            this.rating = rating;
        }

        get name() {
            return this._name;
        }

        set name(n) {
            validateName(n, 1, 24);
            this._name = n;
        }

        get description() {
            return this._description;
        }

        set description(descr) {
            if (typeof descr !== 'string') {
                throw new Error('description is not a strinf');
            }

            this._description = descr;
        }

        get version() {
            return this._version;
        }

        set version(ver) {
            if (typeof ver !== 'number' || ver <= 0) {
                throw new Error('version is not valid');
            }

            this._version = ver;
        }

        get rating() {
            return this._rating;
        }

        set rating(rat) {
            if (typeof rat !== 'number' || rat < 1 || rat > 10) {
                throw new Error('rating is not valid');
            }

            this._rating = rat;
        }

        release(arg) {
            function releaseByVersion(version) {
                if (typeof version !== 'number' || version <= 0) {
                    throw new Error('argument version is not number');
                }

                let oldVersion = this.version;

                if (version <= oldVersion) {
                    throw new Error('new version is not above the old one');
                }

                this.version = version;
                return this;
            }

            function releaseByOptions(options) {
                if (typeof options.version !== 'number' || options.version <= 0 || options.version === 'undefined') {
                    throw new Error('options version is not valid');

                }
                if (options.version <= this.version) {
                    throw new Error('options version is not above the old one');
                }

                this.version = options.version;

                if (options.hasOwnProperty('description')) {
                    if (typeof options.description !== 'string') {
                        throw new Error('options description is not valid');
                    }
                    this.description = options.description;
                }

                if (options.hasOwnProperty('rating')) {
                    if (typeof rat !== 'number' || rat < 1 || rat > 10) {
                        throw new Error('options rating is not valid');
                    }
                    this.rating = options.rating;
                }

                return this;
            }

            if (typeof arg === 'object') {
                return releaseByOptions.call(this, arg);
            }
            return releaseByVersion.call(this, arg);
        }
    }

    class Store extends App {
        constructor(...params) {
            super(...params);

            this._apps = [];
        }

        get apps() {
            return this._apps;
        }


        uploadApp(app) {
            if (!(app instanceof App)) {
                throw new Error('app is not valid App instance');
            }

            let index = this._apps.findIndex(x => x.name === app.name);

            if (index >= 0) {
                this._apps.splice(index, 1);
            }

            this._apps.push({
                name: app.name,
                description: app.description,
                version: app.version,
                rating: app.rating,
                apps: app.apps // this stores in the apps
            });

            return this;
        }

        takedownApp(name) {
            const index = this._apps.findIndex(x => x.name === name);

            if (index < 0) {
                throw new Error('can not remove app with this name');
            }

            this._apps.splice(index, 1);

            return this;
        }

        search(pattern) {
            pattern = pattern.toLowerCase();

            return (this._apps
                .filter(app => app.name.toLowerCase().indexOf(pattern) >= 0)
                .sort((x, y) => x.name.localeCompare(y.name)));
        }

        listMostRecentApps(count) {

            // if (typeof count !== 'undefined' && typeof count === 'number' && count <= 10) {
            //     return this._apps
            //         .slice()
            //         .sort((x, y) => y.upload - x.upload);
            // }

            count = count || 10;

            return this._apps.slice()
                .reverse()
                .slice(0, count);
        }

        listMostPopularApps(count) {

            count = count || 10;

            return this._apps.map((app, index) => ({ app, index }))
                .sort((x, y) => {
                    if (y.app.rating !== x.app.rating) {
                        return y.app.rating - x.app.rating;
                    }
                    return y.app.index - x.app.index;
                })
                .slice(0, count)
                .map(x => x.app);

        }
    }

    class Device {
        constructor(hostname, apps) {
            this.hostname = hostname;
            this.apps = apps;
        }

        get hostname() {
            return this._hostname;
        }

        set hostname(name) {
            if (typeof name !== 'string') {
                throw new Error('invalid name');
            }
            let len = name.length;

            if (len < 1 || len > 32) {
                throw new Error('invalid number of symbols');
            }

            this._hostname = name;
        }

        get apps() {
            return this._apps;
        }

        set apps(app) {

            if (typeof app === "function") {
                throw new Error('app is not valid App instance');
            }

            this._apps = app;
        }

        search(pattern) {
            let arr = [];

            //arr = this.apps.filter(isStore);

            // function isStore(value){
            //  value.stores 
            // }

            function compare(a, b) {
                return a.name.toLowerCase().localeCompare(b.name.toLowerCase());
            }
            // sort alphabetically
            arr = this.apps.sort(compare);

            let newArr = [];

            for (let el of arr) {
                if (el.name.includes('pattern')) {
                    newArr.push(el);
                }
            }

            let latestVersion = 0;

            for (let ver of newArr) {
                if (ver.version > latestVersion) {
                    latestVersion = ver.version;
                }
            }
            return latestVersion;
        }

        install(name) {
            let index = this.apps.indexOf(app.name);

            if (index < 0) {
                throw new Error('app in installed stored');
            }

            this._apps.install(app.name);

            //for (let app of)
            return this;
        }

        uninstall(name) {
            let index = this.apps.indexOf(app.name);

            if (index < 0) {
                throw new Error('can not unistall');
            }

            this._apps.uninstall(app.name);

            return this;
        }

        listInstalled() {
            let arr = [];

            function compare(a, b) {
                return a.name().localeCompare(b.name());
            }
            // sort alphabetically
            arr = this.apps.sort(compare);

            return arr;
        }

        update() {


            return this;
        }
    }



    return {
        createApp(name, description, version, rating) {
            return new App(name, description, version, rating);
        },
        createStore(name, description, version, rating) {
            return new Store(name, description, version, rating);
        },
        createDevice(hostname, apps) {
            return new Device(hostname, apps);
        }
    };
}

// Submit the code above this line in bgcoder.com
module.exports = solve;