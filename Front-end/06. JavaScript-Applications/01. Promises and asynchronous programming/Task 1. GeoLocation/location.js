(function() {
    var location = new Promise(function(resolve, reject) {
        navigator.geolocation.getCurrentPosition(
            function(position) {
                resolve(position);
            },
            function(error) {
                reject(error);
            });
    });

    function coordinates(position) {
        return {
            lat: position.coords.latitude,
            long: position.coords.longitude
        };
    }

    function createMapView(coords) {
        let map = document.getElementById("map"),
            src = "http://maps.googleapis.com/maps/api/staticmap?center=" +
            coords.lat +
            "," +
            coords.long +
            "&zoom=18&size=500x500&sensor=false";

        map.setAttribute("src", src);
    }

    function locationNotFound(error) {
        map.innerHTML = error.message;
    }

    location
        .then(coordinates)
        .then(createMapView)
        .catch(locationNotFound);
}());