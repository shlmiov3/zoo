namespace _8200Zoo;

public class Egle: Poultry, ICanFly{
    public Egle(string name, int id): base(name, id){
        Weight = 20;
        FoodConsumption = 2;
        IsPredator = true;
    }
    string ICanFly.AirSlash(){
        return base.AirSlash();
    }
}