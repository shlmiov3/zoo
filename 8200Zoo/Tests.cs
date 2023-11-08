using Xunit;
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using _8200Zoo;
using System.Runtime.InteropServices;

public class _8200ZooTests{
    private int id = 0;
    List<string> animalTypes = new List<string>{
        "Bream", "Piranha", "Shark", 
        "Cow", "Dolphine", "Elephant", "Giraffe", 
        "Lion", "Orca", "Tiger", 
        "Chicken", "Egle", "Emu", "Owl", 
        "Parrot", "Penguin" 
    };
     
     private int GetId(){
        return id++;
     }

    [Fact]
    public  void checkAddAnimal(){
        /*
            check if all classes are defined correctly and the animals reaction is correct
        */
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
    public  void checkAnimal(){

    }
}