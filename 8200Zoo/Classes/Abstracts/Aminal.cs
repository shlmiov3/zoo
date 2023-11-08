namespace _8200Zoo;

public abstract class Animal{
    public int Id {get; protected set;}
    public string Name {get; protected set;} = "";
    public double Weight {get ; set;}
    public bool IsPredator {get; protected set;} = false;
    public int FoodConsumption {get; protected set;}
    public bool Kosher {get; protected set;} = false;

    protected Animal(string name, int id){
        Name = name;
        Id = id;
    }

    protected string Splash(){
        return String.Format("{0} ===> flap flap\n", Name);
    }
    protected string AirSlash(){
        return string.Format("{0} ===> Shvoooonng\n", Name);   
    }
    protected string Rollout(){
        return string.Format("{0} ===> weeeeeehhh\n", Name);   
    }

}