using System;

public class User{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string FullName {get { return FirstName + " " + LastName; }}
    public string Email {get; set;}
    public string Gender {get; set;}
    public DateTime DateOfBirth {get; set;}
    public DateTime CreatedOn {get; set;}
}