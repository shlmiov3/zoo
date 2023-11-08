namespace _8200Zoo;

public class Piranha: Fish{
    public Piranha(string name, int id): base(name, id){
        IsPredator = true;
        Kosher = false;
        Weight = 1;
        FoodConsumption = 2;
    }
}