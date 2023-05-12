
//this is an "Is A" Relationship
public class Developer : Person                                          // Person
{                                                                        //   |
                                                                         // Developer  

    public Developer()
    {

    }

    public Developer(string firstName, string lastName, bool hasPluralsight)
    {
        FirstName = firstName;
        LastName = lastName;
        HasPluralsight = hasPluralsight;
    }

    public override string GreetSomeone(Person person)
    {
        string greeting = $"Hello, {person.FullName}! How are you! I'm Fantastic! ";

        if (person.HasPluralsight == false)
        {
            greeting += "Dude, you need to get a Pluralsight Account!";
        }
        else
        {
            greeting += "Isn't Pluralsight Awesome!";
        }

        return greeting;
    }
}
