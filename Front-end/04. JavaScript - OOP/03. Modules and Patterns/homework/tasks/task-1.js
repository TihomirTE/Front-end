function solve() {

    var uniqueNumbers = 1;

    function validateTitle(title) {
        if (title[0] === ' ' || title[title.length - 1] === ' ') {
            throw 'Titles can not start or end with empty spaces';
        }
        if (/\s{2}/.test(title)) {
            throw 'Titles can not have consecutive spaces';
        }
        if (title.length < 1) {
            throw 'Titles must have at least one character';
        }
    }

    function validateStudentName(name) {
        let nameArr = name.split(' '),
            firstName = nameArr[0],
            lastName = nameArr[1];

        if (nameArr.length < 2 || nameArr.length > 2) {
            throw 'Student must have two names';
        }
        if (/^[a-z]/.test(firstName) || /^[a-z]/.test(lastName)) {
            throw 'Invalid student name';
        }

        for (let i = 1; i < firstName.length; i += 1) {
            if (!/[a-z]/.test(firstName[i])) {
                throw 'Invalid student name 2';
            }
        }

        for (let i = 1; i < lastName.length; i += 1) {
            if (!/[a-z]/.test(lastName[i])) {
                throw 'Invalid student name 3';
            }
        }

        return name;
    }

    class AcademyCourse {
        constructor(title, presentations) {
            this.title = title;
            if (presentations.length < 1) {
                throw 'There are no presentations';
            }
            this._presentations = presentations;
            this._students = [];
        }

        get title() {
            return this._title;
        }
        set title(newTitle) {
            validateTitle(newTitle);
            this._title = newTitle;
        }

        get presentations() {
            return this._presentations;
        }

        get students() {
            return this._students;
        }
    }

    class Student {
        constructor(firstName, lastName) {
            this._firstName = firstName;
            this._lastName = lastName;
            this._id = uniqueNumbers++;
            this._homeworks = [];
        }

        get firstName() {
            return this._firstName;
        }
        get lastName() {
            return this._lastName;
        }
        get id() {
            return this._id;
        }
        get homeworks() {
            return this._homeworks;
        }
    }

    class Presentations {
        constructor(title) {
            this._title = title;
            this._homework = [];
        }
    }


    var Course = {
        init: function(title, presentations) {
            for (let i = 0; i < presentations.length; i += 1) {
                validateTitle(presentations[i]);
            }
            // make course global variables
            course = new AcademyCourse(title, presentations);
            return this;
        },
        addStudent: function(name) {
            validateStudentName(name);
            let nameArr = name.split(' '),
                firstName = nameArr[0],
                lastName = nameArr[1],
                student = new Student(firstName, lastName);
            course.students.push(student);
            return student.id;
        },
        getAllStudents: function() { 
            let studentsArr = [];
            for (let i = 0; i < course.students.length; i += 1) {
                let currentStudent = course.students[i];

                let objStudent = {
                    firstname: currentStudent.firstName,
                    lastname: currentStudent.lastName,
                    id: currentStudent.id
                };
                studentsArr.push(objStudent);
            }

            return studentsArr;
        },
        submitHomework: function(studentID, homeworkID) {
            if (studentID === undefined || studentID === null || isNaN(studentID) || +studentID < 0 || +studentID > uniqueNumbers) {
                throw 'Invalid studentID';
            }

            if (homeworkID === undefined || homeworkID === null || isNaN(homeworkID) || +homeworkID <= 0 || +homeworkID > course.presentations.length) {
                throw 'Invalid homeworkId';
            }

            let student = course.students.filter(st => st.id == studentID)[0];
            student.homeworks[homeworkID - 1] = true;

        },
        pushExamResults: function(results) {
            if (results.constructor !== Array) {
                throw 'The output has to be Array';
            }

            let idStudent = [];

            for (let i = 0; i < results.length; i += 1) {
                let currentObj = results[i];

                if (currentObj.StudentID === undefined || isNaN(currentObj.StudentID) || currentObj.StudentID < 0) {
                    throw 'invalid StudentID';
                }

                idStudent.push(currentObj);
            }

            if (id > Student.ID || id < Student.ID < 1) {
                throw 'Error';
            }

            return this;
        },
        getTopStudents: function() {}
    };

    return Course;
}

// let result = solve();
// console.log(result.init('JS', ['Pres1', 'Pres2']));

module.exports = solve;