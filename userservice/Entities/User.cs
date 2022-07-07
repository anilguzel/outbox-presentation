namespace userservice.Entities;

public class User
{
    public int id { get; set; }
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public bool isapproved { get; set; }
}
