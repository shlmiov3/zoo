namespace _8200Zoo;

public abstract class Poultry: Animal{
    protected Poultry(string name, int id): base(name, id){}
    public int WingsAmout {get; protected set;} = 2;
}
