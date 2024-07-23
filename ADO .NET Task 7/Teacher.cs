using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ADO_.NET_Task_7;

public class Teacher
{
    public int TeacherId { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime EmploymentDate { get; set; }
    public decimal Premium { get; set; }
    public decimal Salary { get; set; }

    public int DepartamentId { get; set; }

    public Department Department { get; set; }


    public List<Group> Groups { get; set; }

    public override string ToString()
    {
        return $"{TeacherId}: {FirstName} - {LastName}";
    }

}
