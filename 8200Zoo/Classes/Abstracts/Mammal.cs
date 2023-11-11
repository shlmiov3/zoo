namespace _8200Zoo;

public abstract class Mammal: Animal{
    protected Mammal(string name, int id): base(name, id){}
    public bool GotMilk {get; set;} = false;
    public void ToggleMilk(){
        GotMilk = !GotMilk;
    }
}