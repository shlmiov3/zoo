namespace _8200Zoo;

public class Owl: Poultry, ICanFly{
    public Owl(string name, int id): base(name, id){
        Weight = 15;
        FoodConsumption = 1;
        IsPredator = true;
    }
    string ICanFly.AirSlash(){
        return base.AirSlash();
    }
}