namespace _8200Zoo;

public class Chicken: Poultry, ICanWalk{
    public Chicken(string name, int id): base(name, id){
        Weight = 4;
        FoodConsumption = 1;
        Kosher = true;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}