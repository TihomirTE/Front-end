// var result = $.grep(myArray, function(e){ return e.id == id; });
findPerson([
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'John', lastname: 'Doe', age: 42 }
]);



function findPerson(agePerson) {
    let arrPerson = [].slice.apply(agePerson),
        currentAge;
    for (let i = 0; i < arrPerson.length; i += 1) {
        currentAge = agePerson.age;
    }
    console.log(findPerson);
}


//----------------------------------------
/*var inventory = [
    { name: 'apples', quantity: 2 },
    { name: 'bananas', quantity: 0 },
    { name: 'cherries', quantity: 5 }
];

function findCherries(fruit) {
    return fruit.name === 'cherries';
}

console.log(inventory.find(findCherries));
// { name: 'cherries', quantity: 5 }*/