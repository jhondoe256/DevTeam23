
//base class 
public abstract class Person
{
    public int ID { get; set; }
    public string FirstName { get; set; } = string.Empty; //" ";
    public string LastName { get; set; } = string.Empty;
    public bool HasPluralsight { get; set; }

    //getters and setters
    //getters are "read-only"
    //setters allow us to "write over existing data"

    //FullName is a property
    public string FullName
    {
        get
        {
            return $"{FirstName} - {LastName}";
        }
    }

    public override string ToString()
    {
        // return base.ToString();  //Object Class
        string str = $"ID: {ID}\n" +
                     $"FullName: {FullName}\n" +
                     $"Has Ps: {HasPluralsight}\n" +
                     "=============================\n";

        return str;
    }

    //Methods perform actions on objects
    //Think of it as a machine, 
    //sometimes you have to "feed the machine"
    // public void GreetSomeone()
    // {
    //     System.Console.WriteLine("Hello!");
    // }

    //We have to feed this an object of type 'Person'
    //virtual keyword will allow inheriting members to 
    //"override" the base behavor.  
    public virtual string GreetSomeone(Person person)
    {
        return $"Hello, {person.FullName}! How are you!";
    }
}
