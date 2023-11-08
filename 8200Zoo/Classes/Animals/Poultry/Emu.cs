namespace _8200Zoo;

public class Emu: Poultry, ICanWalk{
    public Emu(string name, int id): base(name, id){
        Weight = 50;
        IsPredator = false;
        FoodConsumption = 4;
        Kosher = false;
    }
    string ICanWalk.Rollout(){
        return base.Rollout();
    }
}