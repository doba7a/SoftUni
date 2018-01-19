function storingObjects(input) {
    class Student {
        constructor(name, age, grade) {
            this.name = name;
            this.age = age;
            this.grade = grade;
        }
    }

    let arrayOfStudents = new Array();

    for (i = 0; i < input.length; i++){
        let currentStudent = input[i].split(" -> ").filter(function(e){return e});

        let studentName = currentStudent[0];
        let studentAge = +currentStudent[1];
        let studentGrade = +currentStudent[2];

        let student = new Student();

        student.name = studentName;
        student.age = studentAge;
        student.grade = studentGrade;

        arrayOfStudents.push(student);
    }

    for(let student of arrayOfStudents){
        console.log(`Name: ${student.name}`)
        console.log(`Age: ${student.age}`)
        console.log(`Grade: ${student.grade.toFixed(2)}`)
    }
}