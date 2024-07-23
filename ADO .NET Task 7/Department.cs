namespace ADO_.NET_Task_7;

public class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; }

    public decimal Financing { get; set; }

    public List<Teacher> Teachers{ get; set; }

    public override string ToString()
    {
        return $"{DepartmentId}: {Name}";
    }
}
