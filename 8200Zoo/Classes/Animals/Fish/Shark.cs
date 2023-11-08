namespace _8200Zoo;

public class Shark: Fish{
    public Shark(string name, int id): base(name, id){
        IsPredator = true;
        Kosher = false;
        Weight = 60;
        FoodConsumption = 3;
    }
}