// See https://aka.ms/new-console-template for more information
using SQL04EFCodeFirst;

Console.WriteLine("Hello, World!");


using (var db = new AppDbContext())
{
    Coach coach = new Coach()
    {
        Name = "Alain Robert",
        DateOfEmployment = new DateTime(2000, 02, 2),
        ExperienceDescription = "very experienced",
        Height = 180.34

    };
    db.Add(coach);
    db.SaveChanges();




}
