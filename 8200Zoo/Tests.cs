using Xunit;
using _8200Zoo;


public class _8200ZooTests{
    List<string> animalTypes = new List<string>{
        "Bream", "Piranha", "Shark", 
        "Cow", "Dolphine", "Elephant", "Giraffe", 
        "Lion", "Orca", "Tiger", 
        "Chicken", "Egle", "Emu", "Owl", 
        "Parrot", "Penguin" 
    };
     
    [Fact]
    public void testAddAnimal(){
        //check if all classes are defined correctly and the animals reaction is correct
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
    
    [Fact]
    public void testInvalidType(){
        Zoo zoo = new Zoo();
        // invalid type given to AddAnimal.
        Assert.Throws<ArgumentException>(() => zoo.AddAnimal("Pigeon", "Pigeon"));
        Assert.Throws<ArgumentException>(() => zoo.AddAnimal(null, "Pigeon"));
    }

    [Fact]
    public void testFoodAmount(){
        Zoo zoo = new Zoo();
        
        // Feed where there are no animals
        Assert.Equal("", zoo.Feed());
        zoo.AddAnimal("Lion","Arie");
        Assert.Throws<NotEnoughMeatException>(() => zoo.Feed());
        zoo.AddMeat(4);
        zoo.AddAnimal("Chicken","kukuriku");
        Assert.Throws<NotEnoughVeggiesException>(() => zoo.Feed());
        zoo.AddVeggie(1);
        string res = "Arie ===> weeeeeehhh\nkukuriku ===> weeeeeehhh\n";
        Assert.Equal(res, zoo.Feed());
        Assert.Throws<NotEnoughMeatException>(() => zoo.Feed());
        
        zoo.AddMeat(4);
        zoo.AddVeggie(1);
        zoo.KitCat();
        Assert.Equal(res, zoo.Feed());
        zoo.WakeCatUp('a');
        Assert.Throws<NotEnoughMeatException>(() => zoo.KitCat());
    }

    [Fact]
    public void testFeedingOrder(){
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
        string res = "Arie ===> weeeeeehhh\nArie2 ===> weeeeeehhh\nArie3 ===> weeeeeehhh\nTiger ===> weeeeeehhh\nTiger2 ===> weeeeeehhh\nkoko ===> weeeeeehhh\nkoko2 ===> weeeeeehhh\nkoko3 ===> weeeeeehhh\nCoco ===> Shvoooonng\nCoco2 ===> Shvoooonng\n";
        Assert.Equal(res, zoo.Feed());
        zoo.MakeNuggets();
        res = "Arie ===> weeeeeehhh\nArie2 ===> weeeeeehhh\nArie3 ===> weeeeeehhh\nTiger ===> weeeeeehhh\nTiger2 ===> weeeeeehhh\n";
        Assert.Equal(res, zoo.Feed());
        zoo.AddAnimal("Chicken","koko");
        zoo.AddAnimal("Chicken","koko2");
        zoo.AddAnimal("Cow","moomoo");
        zoo.AddAnimal("Cow","moomoo2");
        zoo.Barbeque();
        res = "Arie ===> weeeeeehhh\nArie2 ===> weeeeeehhh\nArie3 ===> weeeeeehhh\nTiger ===> weeeeeehhh\nTiger2 ===> weeeeeehhh\n";
        Assert.Equal(res, zoo.Feed());
    }
}