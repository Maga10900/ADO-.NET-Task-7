using System.Reflection.Metadata.Ecma335;

namespace ADO_.NET_Task_7;

public class Group
{
    public int GroupId{ get; set; }
    public string Name { get; set; }//nvarChar(10), NotNull, Not Bosh,Unique
    public int Rating { get; set; } //NotNull, 0-5
    public int Year { get; set; } //NotNull, 1-5

    public List<Student> Students { get; set; }

    public int TeacherId { get; set; }

    public Teacher Teacher { get; set; }
    public override string ToString()
    {
        return $"{GroupId}: {Name}";
    }
}
