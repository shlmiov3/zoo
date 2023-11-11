using Xunit;

namespace _8200Zoo
{
	public class StageOneTests
	{
        private readonly List<Animal> _animals;
        private readonly List<Mammal> _mammals;
        private readonly List<Poultry> _poultrys;
        private readonly List<Cat> _cats;
        private readonly List<Fish> _fishs;
        private readonly List<Animal> _wrongTypeAnimals;
        private readonly List<ICanFly> _flyers;
        private readonly List<ICanSwim> _swimmers;
        private readonly List<ICanWalk> _walkers; 

        public StageOneTests()
		{
            _mammals = new List<Mammal>();
            _poultrys = new List<Poultry>();
            _cats = new List<Cat>();
            _fishs = new List<Fish>();
            _wrongTypeAnimals = new List<Animal>();
            _flyers = new List<ICanFly>();
            _swimmers = new List<ICanSwim>();
            _walkers = new List<ICanWalk>();

            _animals = new List<Animal>()
            {
                new Bream("Bream", 1), new Piranha("Piranha", 2),
                new Shark("Shark", 3), new Cow("Cow", 4), new Dolphine("Dolphine", 5), new Elephant("Elephant", 6),
                new Giraffe("Giraffe", 7), new Lion("Lion", 8), new Orca("Orca", 9), new Tiger("Tiger", 10),
                new Chicken("Chicken",11), new Egle("Egle", 12), new Emu( "Emu",13) , new Owl( "Owl", 14),
                new Parrot("Parrot", 15), new Penguin("Penguin", 16)
            };
            
            foreach (var animal in _animals)
            {
                var type = animal.GetType();

                if(type.IsSubclassOf(typeof(Fish)))
                {
                    _fishs.Add((Fish)animal);
                }
                else if (type.IsSubclassOf(typeof(Cat)))
                {
                    _cats.Add((Cat)animal);
                }
                else if(type.IsSubclassOf(typeof(Poultry)))
                {
                    _poultrys.Add((Poultry)animal);
                }
                else if (type.IsSubclassOf(typeof(Mammal)))
                {
                    _mammals.Add((Mammal)animal);
                }
                else
                {
                    _wrongTypeAnimals.Add(animal); 
                }

                if (animal is ICanFly)
                {
                    _flyers.Add((ICanFly)animal);
                }

                if (animal is ICanSwim)
                {
                    _swimmers.Add((ICanSwim)animal);
                }

                if (animal is ICanWalk)
                {
                    _walkers.Add((ICanWalk)animal);
                }
            }
        }

        //OOP
        [Fact]
        public void AnimalTypesAreCorerct()
        {
            //check if any animal is not in the correct type
            Assert.Equal(6, _poultrys.Count);
            Assert.Equal(_poultrys.Select(bird => bird.Name), new List<string>(){ "Chicken","Egle","Emu", "Owl", "Parrot", "Penguin" });
            Assert.Equal(3, _fishs.Count);
            Assert.Equal(_fishs.Select(fish => fish.Name), new List<string>() { "Bream", "Piranha", "Shark" });
            Assert.Equal(2, _cats.Count);
            Assert.Equal(_cats.Select(cat => cat.Name), new List<string>() { "Lion", "Tiger" });
            Assert.Equal(5, _mammals.Count);
            Assert.Equal(_mammals.Select(mammal => mammal.Name), new List<string>() { "Cow", "Dolphine", "Elephant", "Giraffe", "Orca" });
            Assert.Empty(_wrongTypeAnimals);
        }

        [Fact]
        public void AnimalInterfacesAreCorrect()
        {
            //check if all have the correct interface 
            Assert.Equal(3, _flyers.Count);
            Assert.Equal(6, _swimmers.Count);
            Assert.Equal(7, _walkers.Count);
        }

        //Functionality
        [Fact]
        public void KosherAnimals()
        {
            //check if any animal is not in the correct kosher
            var kosherAnimalsCount = _animals.Count(animal => animal.Kosher);
            Assert.Equal(4, kosherAnimalsCount); //when girrafe is not kosher - suppose to be 3
            var ammountOfNotKosherAnimals = _animals.Count - kosherAnimalsCount;
            Assert.Equal(12, ammountOfNotKosherAnimals);//when girrafe is not kosher - suppose to be 13
        }

        [Fact]
        public void Predators()
        {
            //check if all the predators are predators
            Assert.Equal(8, _animals.Count(animal => animal.IsPredator));
        }

        [Fact]
        public void Milk()
        {
            //check if all the predators are predators
            Assert.Equal(0, _mammals.Count(mammal => mammal.GotMilk));

            foreach (var mammal in _mammals)
            {
                mammal.ToggleMilk();
            }

            Assert.Equal(_mammals.Count, _mammals.Count(mammal => mammal.GotMilk));
        }

        [Fact]
        public void Weight()
        {
            //check if all the predators are predators
            Assert.Equal(737, _animals.Sum(animal => animal.Weight));
        }

        [Fact]
        public void Food()
        {
            //check if all the predators are predators
            Assert.Equal(41, _animals.Sum(animal => animal.FoodConsumption));
        }

        //Code design 
        [Fact]
        public void SeparatedFiles()
        {
            //check if they splitted to files as requiered 
            var filesList = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.GetFiles("*.cs", SearchOption.AllDirectories).ToList();
            filesList.RemoveAll(file => file.FullName.Contains("Debug") || file.FullName.Contains("Test") || file.FullName.Contains("Exception"));
            Assert.Equal(26, filesList.Count(file => file.FullName.Contains(".cs")));
        }
    }
}