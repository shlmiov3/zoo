namespace _8200Zoo;

public class Penguin: Poultry, ICanSwim{
    public Penguin(string name, int id): base(name, id){
        Weight = 10;
        FoodConsumption = 2;
    }
    string ICanSwim.Splash(){
        return base.Splash();
    }
}