namespace _8200Zoo;

public class Parrot: Poultry, ICanFly{
    public Parrot(string name, int id): base(name, id){
        Weight = 1;
        FoodConsumption = 1;
    }
    string ICanFly.AirSlash(){
        return base.AirSlash();
    } 
}