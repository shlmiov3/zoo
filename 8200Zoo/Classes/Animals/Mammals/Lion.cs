namespace _8200Zoo;

public class Lion: Cat, ICanWalk{
    public Lion(string name, int id): base(name, id){
        Name = name;
        IsPredator = true;
        Kosher = false;
        Weight = 70;
        FoodConsumption = 4;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}