namespace _8200Zoo;

public class Dolphine: Mammal, ICanSwim{
    public Dolphine(string name, int id): base(name, id){
        IsPredator = true;
        Kosher = false;
        Weight = 70;
        FoodConsumption = 3;
    }
    string ICanSwim.Splash(){
        return base.Splash();
    } 
}