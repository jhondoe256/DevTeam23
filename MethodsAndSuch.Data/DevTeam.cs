
public class DevTeam
{
    public DevTeam()
    {

    }
            // Method Signature
    public DevTeam(string teamName, List<Developer> developers)
    {
        TeamName = teamName;
        Developers = developers;
    }



    public int ID { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public List<Developer> Developers { get; set; } = new List<Developer>();
}
