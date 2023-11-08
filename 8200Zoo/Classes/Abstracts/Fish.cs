namespace _8200Zoo;

public abstract class Fish: Animal, ICanSwim{
    protected Fish(string name, int id): base(name, id){}
    public const bool Scales = true;
    string ICanSwim.Splash(){
        return base.Splash();
    }  
}