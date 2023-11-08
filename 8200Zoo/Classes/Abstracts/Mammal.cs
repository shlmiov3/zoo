namespace _8200Zoo;

public abstract class Mammal: Animal{
    protected Mammal(string name, int id): base(name, id){}
    bool GotMilk {get; set;} = false;
    void ToggleMilk(){
        GotMilk = !GotMilk;
    }
}