namespace _8200Zoo;

public class Bream: Fish{
    public Bream(string name, int id): base(name, id){
        IsPredator = false;
        Kosher = true;
        Weight = 1;
        FoodConsumption = 1;
    }
}