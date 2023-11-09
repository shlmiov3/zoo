using Xunit;

namespace _8200Zoo;

class Program
{
    private static int id = 0;
    static List<string> animalTypes = new List<string>{
        "Bream", "Piranha", "Shark", 
        "Cow", "Dolphine", "Elephant", "Giraffe", 
        "Lion", "Orca", "Tiger", 
        "Chicken", "Egle", "Emu", "Owl", 
        "Parrot", "Penguin" 
    };
    public static void checkAddAnimal(){
        Zoo zoo = new Zoo();
        foreach(string typeName in animalTypes) {
            zoo.AddAnimal(typeName, typeName);
        }
        zoo.AddMeat(100);
        zoo.AddVeggie(100);
        string res = zoo.Feed();
        string expectedRes = "Dolphine ===> flap flap\nEgle ===> Shvoooonng\nLion ===> weeeeeehhh\nOrca ===> flap flap\nOwl ===> Shvoooonng\nPiranha ===> flap flap\nShark ===> flap flap\nTiger ===> weeeeeehhh\nBream ===> flap flap\nChicken ===> weeeeeehhh\nCow ===> weeeeeehhh\nElephant ===> weeeeeehhh\nEmu ===> weeeeeehhh\nGiraffe ===> weeeeeehhh\nParrot ===> Shvoooonng\nPenguin ===> flap flap\n";
        Assert.Equal(res, expectedRes);
    }

    static void Main(string[] args)
    {
        Zoo zoo = new Zoo();
        zoo.AddAnimal("Tiger","Tiger");
        zoo.AddAnimal("Tiger","Tiger2");
        zoo.AddAnimal("Lion","Arie");
        zoo.AddAnimal("Lion","Arie2");
        zoo.AddAnimal("Lion","Arie3");
        zoo.AddAnimal("Chicken","koko");
        zoo.AddAnimal("Chicken","koko2");
        zoo.AddAnimal("Chicken","koko3");
        zoo.AddAnimal("Parrot","Coco");
        zoo.AddAnimal("Parrot","Coco2");
        zoo.AddMeat(100);
        zoo.AddVeggie(100);
        string reaction = zoo.Feed();
        Console.WriteLine(reaction);
        zoo.MakeNuggets();
        reaction = zoo.Feed();
        Console.WriteLine("\n=====================\n");
        Console.WriteLine(reaction);
        zoo.AddAnimal("Chicken","koko");
        zoo.AddAnimal("Chicken","koko2");
        zoo.AddAnimal("Cow","moomoo");
        zoo.AddAnimal("Cow","moomoo2");
        zoo.Barbeque();
        reaction = zoo.Feed();
        Console.WriteLine("\n=====================\n");
        Console.WriteLine(reaction);
        zoo.KitCat();
        zoo.WakeCatUp('t');
        zoo.MakeCatSleep('2');
        zoo.KitCat();

    }


}
