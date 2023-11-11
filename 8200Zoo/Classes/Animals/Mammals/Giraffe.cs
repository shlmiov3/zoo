namespace _8200Zoo;

public class Giraffe: Mammal, ICanWalk{
    public Giraffe(string name, int id): base(name, id){
        IsPredator = false;
        Kosher = true;
        Weight = 80;
        FoodConsumption = 4;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}