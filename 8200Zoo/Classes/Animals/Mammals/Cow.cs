namespace _8200Zoo;

public class Cow: Mammal, ICanWalk{
    public Cow(string name, int id): base(name, id){
        IsPredator = false;
        Kosher = true;
        Weight = 80;
        FoodConsumption = 2;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}