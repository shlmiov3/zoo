using System.Runtime.CompilerServices;

namespace _8200Zoo;

public abstract class Cat: Mammal{
    protected Cat(string name, int id): base(name, id){}
    public bool IsSleeping {get; set;} = true;
}