// var result = $.grep(myArray, function(e){ return e.id == id; });
findPerson([
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'John', lastname: 'Doe', age: 42 }
]);



function findPerson(args) {
    let i, len = args.length,
        person = {},
        objectsOfPeople = {},
        youngestPerson = 1000;

    for (i = 0; i < len; i += 1) {
        objectsOfPeople = args[i];

        if (objectsOfPeople.age < youngestPerson) {
            youngestPerson = objectsOfPeople.age;
            for (let k in objectsOfPeople) {
                person[k] = objectsOfPeople[k];
            }
        }
    }
    console.log(person.firstname + " " + person.lastname);


}