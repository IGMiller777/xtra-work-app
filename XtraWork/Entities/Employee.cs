namespace XtraWork.Entities;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    public int Age { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public Title Title { get; set; }
    public int TitleId { get; set; }
}