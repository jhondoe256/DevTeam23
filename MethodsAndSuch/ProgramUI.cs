
public class ProgramUI
{
    private DeveloperRepository _devRepo = new DeveloperRepository();
    private DeveloperTeamRepository _dTeamRepo;

    public ProgramUI()
    {
        _dTeamRepo = new DeveloperTeamRepository(_devRepo);
    }

    private bool _isRunning = true;

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        while (_isRunning)
        {
            Console.Clear();

            System.Console.WriteLine("Welcome to DevTeams\n" +
            "1.  View All Developers\n" +
            "2.  View A Developer By ID\n" +
            "3.  Create Developer\n" +
            "4.  Update Developer\n" +
            "5.  Delete Developer\n" +
            "=============Dev Teams================\n" +
            "6.  View All Developer Teams\n" +
            "7.  View Team By ID\n" +
            "8.  Add Developer Team\n" +
            "9.  Update Developer Team\n" +
            "10. Delete Developer Team\n" +
            "===============Bonus Stuff=============\n" +
            "11. Developers With out PS\n" +
            "12. Add Multi Devs to Team At Once\n" +
            "00. Exit Application\n");

            int userInput = int.Parse(Console.ReadLine()!);

            switch (userInput)
            {
                case 1:
                    ViewAllDevelopers();
                    break;
                case 2:
                    ViewADeveloperByID();
                    break;
                case 3:
                    CreateDeveloper();
                    break;
                case 4:
                    UpdateDeveloper();
                    break;
                case 5:
                    DeleteDeveloper();
                    break;
                case 6:
                    ViewAllDeveloperTeams();
                    break;
                case 7:
                    ViewTeamByID();
                    break;
                case 8:
                    AddDeveloperTeam();
                    break;
                case 9:
                    UpdateDeveloperTeam();
                    break;
                case 10:
                    DeleteDeveloperTeam();
                    break;
                case 11:
                    DevelopersWithoutPS();
                    break;
                case 12:
                    AddMultiDevstoTeam();
                    break;
                case 00:
                    _isRunning = ExitApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid key entry!");
                    PressAnyKey();
                    break;
            }
        }
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press Any Key To Continue.");
        Console.ReadKey();
    }

    private bool ExitApplication()
    {
        Console.Clear();
        System.Console.WriteLine("Thanks!");
        PressAnyKey();
        Console.Clear();
        return false;
    }

    private void AddMultiDevstoTeam()
    {
        throw new NotImplementedException();
    }

    private void DevelopersWithoutPS()
    {
        throw new NotImplementedException();
    }

    private void DeleteDeveloperTeam()
    {
        throw new NotImplementedException();
    }

    private void UpdateDeveloperTeam()
    {
        throw new NotImplementedException();
    }

    private void AddDeveloperTeam()
    {
        throw new NotImplementedException();
    }

    private void ViewTeamByID()
    {
        throw new NotImplementedException();
    }

    private void ViewAllDeveloperTeams()
    {
        throw new NotImplementedException();
    }

    private void DeleteDeveloper()
    {
        Console.Clear();
        try
        {
            Console.Clear();
            System.Console.WriteLine("== Delete Developer ==");

            foreach (var dev in _devRepo.GetDevelopers())
            {
                System.Console.WriteLine($"{dev.ID} - {dev.FullName}");
            }
            System.Console.WriteLine("=============================\n");

            System.Console.WriteLine("Please input a Developer Id");
            int userInputDevId = int.Parse(Console.ReadLine()!);

            Developer selectedDev = _devRepo.GetDeveloperByID(userInputDevId);

            if (selectedDev != null)
            {
                Console.Clear();
                if (_devRepo.RemoveDeveloper(selectedDev.ID))
                {
                    System.Console.WriteLine("SUCCESS!");
                }
                else
                {
                    System.Console.WriteLine("FAIL!");
                }
            }
            else
            {
                System.Console.WriteLine($"The Developer with the id: {userInputDevId} doesn't Exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    private void UpdateDeveloper()
    {
        Console.Clear();
        try
        {
            System.Console.WriteLine("== Update Developer ==");

            foreach (var dev in _devRepo.GetDevelopers())
            {
                System.Console.WriteLine($"{dev.ID} - {dev.FullName}");
            }
            System.Console.WriteLine("=============================\n");

            System.Console.WriteLine("Please input a Developer Id");
            int userInputDevId = int.Parse(Console.ReadLine()!);

            Developer selectedDev = _devRepo.GetDeveloperByID(userInputDevId);

            if (selectedDev != null)
            {
                Console.Clear();

                //create an empty form 
                Developer developerForm = new Developer();

                System.Console.WriteLine("Please enter a First Name:");
                developerForm.FirstName = Console.ReadLine()!;

                System.Console.WriteLine("Please enter a Last Name:");
                developerForm.LastName = Console.ReadLine()!;

                System.Console.WriteLine("Does this Developer have Ps? y/n");

                string userInput = Console.ReadLine()!.ToLower();

                if (userInput == "y")
                {
                    developerForm.HasPluralsight = true;
                }
                else
                {
                    developerForm.HasPluralsight = false;
                }

                if (_devRepo.UpdateDevData(selectedDev.ID, developerForm))
                {
                    System.Console.WriteLine("SUCCESS!");
                }
                else
                {
                    System.Console.WriteLine("FAIL!");
                }
            }
            else
            {
                System.Console.WriteLine($"The Developer with the id: {userInputDevId} doesn't Exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    private void CreateDeveloper()
    {
        try
        {
            Console.Clear();

            System.Console.WriteLine("== Add Developer Menu ==");

            //create an empty form 
            Developer developerForm = new Developer();

            System.Console.WriteLine("Please enter a First Name:");
            developerForm.FirstName = Console.ReadLine()!;

            System.Console.WriteLine("Please enter a Last Name:");
            developerForm.LastName = Console.ReadLine()!;

            System.Console.WriteLine("Does this Developer have Ps? y/n");

            string userInput = Console.ReadLine()!.ToLower();

            if (userInput == "y")
            {
                developerForm.HasPluralsight = true;
            }
            else
            {
                developerForm.HasPluralsight = false;
            }

            if (_devRepo.AddDeveloper(developerForm))
            {
                System.Console.WriteLine("SUCCESS!");
            }
            else
            {
                System.Console.WriteLine("FAIL!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        PressAnyKey();
    }

    private void ViewADeveloperByID()
    {
        try
        {
            Console.Clear();
            System.Console.WriteLine("== Developer Details ==");

            foreach (var dev in _devRepo.GetDevelopers())
            {
                System.Console.WriteLine($"{dev.ID} - {dev.FullName}");
            }
            System.Console.WriteLine("=============================\n");

            System.Console.WriteLine("Please input a Developer Id");
            int userInputDevId = int.Parse(Console.ReadLine()!);

            Developer selectedDev = _devRepo.GetDeveloperByID(userInputDevId);

            if (selectedDev != null)
            {
                Console.Clear();
                System.Console.WriteLine(selectedDev);
            }
            else
            {
                System.Console.WriteLine($"The Developer with the id: {userInputDevId} doesn't Exist!");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }


        PressAnyKey();
    }

    private void ViewAllDevelopers()
    {
        Console.Clear();

        System.Console.WriteLine("== Dev Listing ==");

        foreach (var dev in _devRepo.GetDevelopers())
        {
            System.Console.WriteLine(dev);
        }

        PressAnyKey();
    }
}
