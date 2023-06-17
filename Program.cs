namespace animalshelter
{
    interface IAnimal
    {
        void MakeSound();
        string GetInfo();
    }

    abstract class Animal : IAnimal
    {
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }

        protected Animal(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public abstract void MakeSound();

        public virtual string GetInfo()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}";
        }
    }

    class Cat : Animal
    {
        public Cat(string id, string name, int age) : base(id, name, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }

    class Dog : Animal
    {
        public Dog(string id, string name, int age) : base(id, name, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }

    class Bird : Animal
    {
        public Bird(string id, string name, int age) : base(id, name, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Tweet!");
        }
    }

    class Reptile : Animal
    {
        public Reptile(string id, string name, int age) : base(id, name, age)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Hiss!");
        }
    }

    class AnimalShelter
    {
        private List<Animal> animals;

        public AnimalShelter()
        {
            animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void RemoveAnimal(Animal animal)
        {
            animals.Remove(animal);
        }

        public void PrintAnimals()
        {
            if (animals.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No animals in our shelter");
                Thread.Sleep(600);
                Console.Clear();
            }
            else
                foreach (Animal animal in animals)
                {
                    Console.WriteLine(animal.GetInfo());
                }
        }
        public Animal GetAnimalById(string animalId)
        {
            foreach (Animal animal in animals)
            {
                if (animal.Id == animalId)
                {
                    return animal;
                }
            }

            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AnimalShelter animalShelter = new AnimalShelter();

            while (true)
            {
                Console.WriteLine("Animal Shelter Management");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. Remove Animal");
                Console.WriteLine("3. View Animals");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter Animal Type (cat, dog, bird, reptile):");
                        string animalType = Console.ReadLine();

                        Console.WriteLine("Enter Animal ID:");
                        string animalId = Console.ReadLine();

                        Console.WriteLine("Enter Animal Name:");
                        string animalName = Console.ReadLine();

                        Console.WriteLine("Enter Animal Age:");
                        int animalAge = Convert.ToInt32(Console.ReadLine());

                        Animal animal = null;

                        switch (animalType)
                        {
                            case "cat":
                                animal = new Cat(animalId, animalName, animalAge);
                                break;
                            case "dog":
                                animal = new Dog(animalId, animalName, animalAge);
                                break;
                            case "bird":
                                animal = new Bird(animalId, animalName, animalAge);
                                break;
                            case "reptile":
                                animal = new Reptile(animalId, animalName, animalAge);
                                break;
                            default:
                                Console.WriteLine("Invalid animal type.");
                                Thread.Sleep(600);
                                Console.Clear();
                                break;
                        }

                        if (animal != null)
                        {
                            animalShelter.AddAnimal(animal);
                            Console.WriteLine("Animal added to the shelter.");
                            Thread.Sleep(600);
                            Console.Clear();
                        }

                        break;
                    case "2":
                        Console.WriteLine("Enter Animal ID to remove:");
                        string animalIdToRemove = Console.ReadLine();

                        Animal animalToRemove = animalShelter.GetAnimalById(animalIdToRemove);

                        if (animalToRemove != null)
                        {
                            animalShelter.RemoveAnimal(animalToRemove);
                            Console.WriteLine("Animal removed from the shelter.");
                            Thread.Sleep(600);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Animal not found in the shelter.");
                            Thread.Sleep(600);
                            Console.Clear();
                        }

                        break;
                    case "3":
                        Console.WriteLine("Animals in the shelter:");
                        animalShelter.PrintAnimals();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(600);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}