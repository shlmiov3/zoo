namespace _8200Zoo;

public class Elephant: Mammal, ICanWalk{
    public Elephant(string name, int id): base(name, id){
        IsPredator = false;
        Kosher = false;
        Weight = 100;
        FoodConsumption = 3;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}