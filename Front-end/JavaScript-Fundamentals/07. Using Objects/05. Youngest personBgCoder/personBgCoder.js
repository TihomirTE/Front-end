/*findPerson([
    'Penka', 'Hristova', '61',
    'System', 'Failiure', '88',
    'Bat', 'Man', '16',
    'Malko', 'Kote', '72'
]);*/



function findPerson(args) {
    var i, len = args.length,
        person = {},
        youngestPerson = Number.MAX_SAFE_INTEGER,
        firstname, lastname;

    for (i = 0; i < len; i += 3) {
        person = createPerson(args[i], args[i + 1], +args[i + 2]);
        if (person.age < youngestPerson) {
            youngestPerson = person.age;
            firstname = person.firstname;
            lastname = person.lastname;
        }
    }
    console.log(firstname + " " + lastname);

    function createPerson(firstNam, lastNam, agePerson) {
        return {
            firstname: firstNam,
            lastname: lastNam,
            age: agePerson
        };
    }
}