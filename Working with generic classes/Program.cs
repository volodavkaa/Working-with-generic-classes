using System;
using System.Collections.Generic;
using System.Linq;

public class Organism
{
    public string Name { get; set; }
    public string ClassType { get; set; }

    public Organism(string name, string classType)
    {
        Name = name;
        ClassType = classType;
    }
}

public class Animal : Organism
{
    public double Speed { get; set; }

    public Animal(string name, string classType, double speed) : base(name, classType)
    {
        Speed = speed;
    }
}

public class Plant : Organism
{
    public double Height { get; set; }

    public Plant(string name, string classType, double height) : base(name, classType)
    {
        Height = height;
    }
}

public class OrganismAccessor
{
    public string GetNormalizedName(Organism organism)
    {
        return organism.Name.ToUpper();
    }

    public string GetNormalizedClass(Organism organism)
    {
        return organism.ClassType.ToUpper();
    }
}

public class AnimalAccessor : OrganismAccessor
{
    public double GetSpeed(Animal animal)
    {
        return animal.Speed;
    }

    public List<Animal> GetAnimalsSortedBySpeed(List<Animal> animals)
    {
        return animals.OrderByDescending(a => a.Speed).ToList();
    }
}

public class PlantAccessor : OrganismAccessor
{
    public double GetHeight(Plant plant)
    {
        return plant.Height;
    }

    public List<Plant> GetPlantsSortedByHeight(List<Plant> plants)
    {
        return plants.OrderByDescending(p => p.Height).ToList();
    }
}

public class Program
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        List<Plant> plants = new List<Plant>();

        Console.Write("Скільки тварин ви хочете ввести? ");
        int animalCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < animalCount; i++)
        {
            Console.WriteLine($"\nВведіть інформацію про тварину №{i + 1}:");
            Console.Write("Назва тварини: ");
            string animalName = Console.ReadLine();
            Console.Write("Клас тварини: ");
            string animalClass = Console.ReadLine();
            Console.Write("Швидкість тварини (км/год): ");
            double animalSpeed = double.Parse(Console.ReadLine());

            animals.Add(new Animal(animalName, animalClass, animalSpeed));
        }

        Console.Write("\nСкільки рослин ви хочете ввести? ");
        int plantCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < plantCount; i++)
        {
            Console.WriteLine($"\nВведіть інформацію про рослину №{i + 1}:");
            Console.Write("Назва рослини: ");
            string plantName = Console.ReadLine();
            Console.Write("Клас рослини: ");
            string plantClass = Console.ReadLine();
            Console.Write("Висота рослини (м): ");
            double plantHeight = double.Parse(Console.ReadLine());

            plants.Add(new Plant(plantName, plantClass, plantHeight));
        }

        AnimalAccessor animalAccessor = new AnimalAccessor();
        PlantAccessor plantAccessor = new PlantAccessor();



//тварини сортуються від найшвидшого до повільнішого рослини по росту

        List<Animal> sortedAnimals = animalAccessor.GetAnimalsSortedBySpeed(animals);
        Console.WriteLine("\nТварини від найшвидшої до найповільнішої:");
        foreach (Animal animal in sortedAnimals)
        {
            Console.WriteLine($"Назва: {animalAccessor.GetNormalizedName(animal)}, Клас: {animalAccessor.GetNormalizedClass(animal)}, Швидкість: {animalAccessor.GetSpeed(animal)} км/год");
        }

        List<Plant> sortedPlants = plantAccessor.GetPlantsSortedByHeight(plants);
        Console.WriteLine("\nРослини від найвищої до найнижчої:");
        foreach (Plant plant in sortedPlants)
        {
            Console.WriteLine($"Назва: {plantAccessor.GetNormalizedName(plant)}, Клас: {plantAccessor.GetNormalizedClass(plant)}, Висота: {plantAccessor.GetHeight(plant)} м");
        }
    }
}