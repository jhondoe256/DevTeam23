
public class DeveloperRepository
{
    public DeveloperRepository()
    {
        Seed();
    }

    //This is our Database (fake)
    //List<T> -> T is a generic type
    private List<Developer> _devDb = new List<Developer>();

    //to simulate our database we need a counter
    private int _count = 0;

    //C.R.U.D

    //Create
    public bool AddDeveloper(Developer devDataFromUI)
    {
        if (devDataFromUI is null)
        {
            return false;
        }
        else
        {
            _count++;  //increment up by one
            devDataFromUI.ID = _count;
            _devDb.Add(devDataFromUI);
            return true;
        }
    }

    //Read (read all of the data from the database)
    public List<Developer> GetDevelopers()
    {
        return _devDb;
    }

    //Read a Single Developer from the database (Helper Method)
    public Developer GetDeveloperByID(int devID)
    {
        //loop the entire database
        foreach (Developer dev in _devDb)
        {
            //check if we have a matching developer
            if (dev.ID == devID)
            {
                //we'll give back everying about this developer to the user (in the UI)
                return dev;
            }
        }
        //otherwise give back nothing
        return null;

        //  return _devDb.SingleOrDefault(d => d.ID == devID);
    }

    //Update
    public bool UpdateDevData(int devId, Developer newDevDataFromUI)
    {
        //we need to use the helper method
        Developer oldDevData = GetDeveloperByID(devId);

        //check to see if this developer exist!
        if (oldDevData != null)
        {
            oldDevData.FirstName = newDevDataFromUI.FirstName;
            oldDevData.LastName = newDevDataFromUI.LastName;
            oldDevData.HasPluralsight = newDevDataFromUI.HasPluralsight;
            return true;
        }
        return false;
    }

    //Delete
    public bool RemoveDeveloper(int devId)
    {
        return _devDb.Remove(GetDeveloperByID(devId));
    }

    //The developers w/o pluralsight
    public List<Developer> DevsWithoutPS()
    {
        //need an empty list
        List<Developer> devWoPs = new List<Developer>();

        //go through the ENTIRE DATABASE
        foreach (Developer developer in _devDb)
        {
            if (developer.HasPluralsight == false)
            {
                //add the developer to the devWoPs collection/list
                devWoPs.Add(developer);
            }
        }

        return devWoPs;
    }

    private void Seed()
    {
        Developer dude = new Developer("Dude", "In Blue", true);
        Developer sarah = new Developer("Sarah", "Peach", false);
        Developer jane = new Developer("Jane", "Doe", false);

        //we need to add them to the database!
        AddDeveloper(dude);
        AddDeveloper(sarah);
        AddDeveloper(jane);
    }
}
