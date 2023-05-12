
public class DeveloperTeamRepository
{
    private DeveloperRepository _devRepo;

    public DeveloperTeamRepository(DeveloperRepository devRepo)
    {
        _devRepo = devRepo;
        Seed();
    }

    private List<DevTeam> _devTeamDb = new List<DevTeam>();
    private int _count = 0;

    public bool AddDevTeam(DevTeam devTeamDataFromUI)
    {
        if (devTeamDataFromUI is null)
        {
            return false;
        }
        else
        {
            _count++;
            devTeamDataFromUI.ID = _count;
            _devTeamDb.Add(devTeamDataFromUI);
            return true;
        }
    }

    public List<DevTeam> GetDevTeams()
    {
        return _devTeamDb;
    }

    public DevTeam GetDevTeamByID(int devTeamID)
    {
        return _devTeamDb.FirstOrDefault(devTeam => devTeam.ID == devTeamID)!;
    }

    public bool UpdateDevTeam(int devTeamID, DevTeam newDevTeamData)
    {
        var oldDevTeamData = GetDevTeamByID(devTeamID);

        if (oldDevTeamData != null)
        {
            oldDevTeamData.TeamName = newDevTeamData.TeamName;

            //check to see if the newDevTeamData has team members
            if (newDevTeamData.Developers.Count() > 0)
            {
                oldDevTeamData.Developers = newDevTeamData.Developers;
            }
            return true;
        }
        return false;
    }

    public bool RemoveDeveloperTeam(int devTeamId)
    {
        return _devTeamDb.Remove(GetDevTeamByID(devTeamId));
    }

    public void Seed()
    {
        DevTeam fireHawk = new DevTeam()
        {
            TeamName = "FireHawk"
        };
        fireHawk.Developers.Add(_devRepo.GetDeveloperByID(1));

        DevTeam sandStorm = new DevTeam()
        {
            TeamName = "SandStorm"
        };
        sandStorm.Developers.Add(_devRepo.GetDeveloperByID(2));
        sandStorm.Developers.Add(_devRepo.GetDeveloperByID(3));

        //add them to the database
        AddDevTeam(fireHawk);
        AddDevTeam(sandStorm);

    }

}
