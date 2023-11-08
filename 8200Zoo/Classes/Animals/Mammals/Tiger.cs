namespace _8200Zoo;

public class Tiger: Cat, ICanWalk{
    public Tiger(string name, int id): base(name, id){
        IsPredator = true;
        Kosher = false;
        Weight = 75;
        FoodConsumption = 4;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}