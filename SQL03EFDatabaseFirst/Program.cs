// See https://aka.ms/new-console-template for more information
using SQL03EFDatabaseFirst.Models;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello");

LocaldbMssqllocaldbContext db = new LocaldbMssqllocaldbContext();

Person[] people = db.Persons.ToArray();

//foreach(Person person in people)
//{
//    Console.WriteLine(person.FirstName + " " + person.LastName);
//}




// Object Relation Maping (ORM) - map database into objects in our c# app

// 1) EntityFramework
// 2) LINQ-to-SQL - (obsolete)
// 3) Hibernate 


// Creating

//Person person1 = new Person()
//{
//    FirstName = "Joe",
//    LastName = "Oli"
//};
//db.Persons.Add(person1);
//db.SaveChanges();

//update

//Person toBeEdited = db.Persons.FirstOrDefault(x => x.Id == 12);
////Console.WriteLine(toBeEdited.FirstName + " " + toBeEdited.LastName);
//toBeEdited.FirstName = "editname";
//db.SaveChanges();


//deleting

//using is good practice it will be destroyed after completing it's task
using (var db2 = new LocaldbMssqllocaldbContext())
{
    Person toBeDeleted = db.Persons.FirstOrDefault(x => x.Id == 13);
    db.Persons.Remove(toBeDeleted);
    db.SaveChanges();
}

