namespace ADO_.NET_Task_7;

public class Faculty
{
    public int FacultyId { get; set; }
    public string Name { get; set; }

    public List<Student> Students { get; set; }
    public override string ToString()
    {
        return $"{FacultyId}: {Name}";
    }
}
