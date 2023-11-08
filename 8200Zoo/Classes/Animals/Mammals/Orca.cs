namespace _8200Zoo;

public class Orca: Mammal, ICanSwim{
    public Orca(string name, int id): base(name, id){
        IsPredator = true;
        Kosher = false;
        Weight = 100;
        FoodConsumption = 4;
    }
    string ICanSwim.Splash(){
        return base.Splash();
    } 
}