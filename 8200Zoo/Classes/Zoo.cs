using System.Reflection;
using System;
using System.Security.Cryptography.X509Certificates;

namespace _8200Zoo;

public class Zoo{
    public int MeatAmount {get; private set;} = 0;
    public int VeggiesAmount {get; private set;} = 0;
    private int _id = 0;
    private SortedDictionary<string, SortedDictionary<int, Animal>> Predators =
            new SortedDictionary<string, SortedDictionary<int, Animal>>();
    private SortedDictionary<string, SortedDictionary<int, Animal>> Herbivores =
            new SortedDictionary<string, SortedDictionary<int, Animal>>();
    private List<Cat> Cats = new List<Cat>();
    private List<Animal> Koshers = new List<Animal>();
    private List<Poultry> Poultries = new List<Poultry>();
    public void AddAnimal(string typeName, string name){   
        if(typeName == null || name == null){
            throw new ArgumentException();
        }
        
        //typeName should be in this format: namespace.class
        typeName = GetType().Namespace + '.' + char.ToUpper(typeName[0]) + typeName.Substring(1);

        int animal_id = _GetId();
        //creates an instance of the given Type
        Animal a = (Animal)_CreateInstance(typeName, name, animal_id);
        
        SortedDictionary<string, SortedDictionary<int, Animal>> animal_pool = a.IsPredator ? Predators : Herbivores;
        if (!animal_pool.ContainsKey(typeName)){
            animal_pool.Add(typeName, new SortedDictionary<int, Animal>());
        }
        animal_pool[typeName].Add(animal_id, a);
        if (a is Cat){
            Cats.Add((Cat)a);
        }
        if (a is Poultry){
            Poultries.Add((Poultry)a);
        }
        if (a.Kosher){
            Koshers.Add(a);
        }
    }
    public void AddMeat(int n){
        MeatAmount += n;
    }
    public void AddVeggie(int n){
        VeggiesAmount += n;
    }
    public string Feed(){
        string animal_reactions = "";
        int meat_used = 0;
        int veggies_used = 0;
        foreach(KeyValuePair<string, SortedDictionary<int, Animal>> predatorType in Predators){
            string type = predatorType.Key;
            foreach(KeyValuePair<int, Animal> predator in predatorType.Value){
                animal_reactions += _GetFeedingReaction(predator.Value);
                meat_used += predator.Value.FoodConsumption;
            }
        }
        foreach(KeyValuePair<string, SortedDictionary<int, Animal>> herbivoreType in Herbivores){
            string type = herbivoreType.Key;
            foreach(KeyValuePair<int, Animal> herbivore in herbivoreType.Value){
                animal_reactions += _GetFeedingReaction(herbivore.Value);
                veggies_used += herbivore.Value.FoodConsumption;
            }
        }
        if (meat_used > MeatAmount){
            throw new NotEnoughMeatException();
        }
        if(veggies_used > VeggiesAmount){
            throw new NotEnoughVeggiesException();
        }
        MeatAmount -= meat_used;
        VeggiesAmount -= veggies_used;

        return animal_reactions;
    }
    public void WakeCatUp(char c){
        c = char.ToLower(c);
        foreach(Cat cat in Cats){
            if(cat.Name.ToLower().StartsWith(c)){
                cat.IsSleeping = false;
            }
        }
    }
    public void MakeCatSleep(char c){
        c = char.ToLower(c);
        foreach(Cat cat in Cats){
            if(cat.Name.ToLower().EndsWith(c)){
                cat.IsSleeping = true;
            }
        }
    }
    public double Barbeque(){
        double fillet = 0;
        List<Animal> koshers_backup = new List<Animal>(Koshers);
        foreach(Animal animal in koshers_backup){
            if (animal is Poultry) {
                fillet += 0.9 * animal.Weight;
            }
            else if (animal is Fish) {
                fillet += 0.8 * animal.Weight;
            }
            else {
                fillet += 0.7 * animal.Weight;
            }
            _RemoveAnimal(animal);
        }
        return fillet;
    }
    public void KitCat (){
        List<Cat> awake_cats = Cats
            .Where(my_cat => !my_cat.IsSleeping)
            .ToList();
        int meatToRemove = 0;
        foreach(Cat cat in awake_cats){
            meatToRemove += cat.FoodConsumption;
        }
        if(meatToRemove > MeatAmount){
            throw new NotEnoughMeatException();
        }
        MeatAmount -= meatToRemove;
        foreach(Cat cat in awake_cats){
            cat.Weight += 0.2 * cat.Weight;
        }       
    }
    public int MakeNuggets(){
        int total_wings = 0;
        // we are doing a shallow coppy here (copying all the refs)
        // this list will be deleted at the end of the scope
        // then the actual Poultry objects in the heap will be eraces by the Garbase Collector
        List<Poultry> poultries_backup = new List<Poultry>(Poultries);
        foreach(Poultry p in poultries_backup){
            total_wings += p.WingsAmout;
            _RemoveAnimal(p);
        }
        return total_wings;
    }
    private string _GetFeedingReaction(Animal animal){
        if (animal is ICanFly){
            ICanFly canFly = (ICanFly)animal;
            return canFly.AirSlash();
        }
        if (animal is ICanSwim){
            ICanSwim canSwim = (ICanSwim)animal;
            return canSwim.Splash();
        }
        else {
            ICanWalk canWalk = (ICanWalk)animal;
            return canWalk.Rollout();
        }     
    }
    private int _GetId(){
        return _id++;
    }
    private void _RemoveAnimal(Animal animal){
        SortedDictionary<string, SortedDictionary<int, Animal>> animal_pool = animal.IsPredator ? Predators : Herbivores;
        Type type = animal.GetType();
        if (animal_pool.ContainsKey(type.ToString())){
            animal_pool[type.ToString()].Remove(animal.Id);
        }
        if (animal is Cat){
            Cats.Remove((Cat)animal);
        }
        if (animal is Poultry){
            Poultries.Remove((Poultry)animal);
        }
        if (animal.Kosher){
            Koshers.Remove(animal);
        }
    }
    private object _CreateInstance(string typeName, string name, int id)
    {
        // Use reflection to get the type by its name
        Type type = Type.GetType(typeName);
        if (type == null){
            throw new ArgumentException("Invalid type name");
        }
        // Check if the type has a constructor that accepts a string and an int parameters
        ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string), typeof(int) });
        if (constructor == null){
            throw new ArgumentException("The specified type does not have a constructor that accepts a string and int parameter.");
        }
        // Create an instance of the type with the "name" parameter
        object instance = constructor.Invoke(new object[] { name, id });
        
        return instance;
    }
}