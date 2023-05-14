// See https://aka.ms/new-console-template for more information
using SQL02Repositories;

Console.WriteLine("Hello, World!");

PersonsRepository personsRepository = new PersonsRepository();
Person[] people = personsRepository.GetPersons();

foreach (var p in people)
{
    Console.WriteLine(p.FirstName + " " + p.LastName +" \t"+ p.ID);
}


Person newPerson = new Person()
{
    FirstName = "jan",
    LastName = "kowalski"
};
personsRepository.CreatePerson(newPerson);

personsRepository.DeletePerson(1002);


foreach (var p in people)
{
    Console.WriteLine(p.FirstName + " " + p.LastName);
}


personsRepository.TestingMethod1(1, 2, 3);

personsRepository.TestingMethod2(new int[3] { 1, 2, 3 });


personsRepository.TestingMethod3(new int[3] { 1, 2, 3 });

personsRepository.TestingMethod3(1);

personsRepository.TestingMethod3(1, 3);

personsRepository.TestingMethod3(1, 4, 5, 6, 7, 8);
