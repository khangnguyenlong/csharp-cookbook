using ObjectComparison;

Console.WriteLine("--- Object Comparison ---");

Console.WriteLine("Compare Object without Equality");
CompareObjectWithoutEquality();

Console.WriteLine("\nCompare Object using IEquatable");
CompareUsingIEquatable();

Console.WriteLine("\nCompare Object using IEqualityComparer");
CompareUsingIEqualityComparer();

void CompareObjectWithoutEquality()
{
    var dogs = new List<Dog>()
    {
        new Dog(1, "Lyly", "Brown"),
        new Dog(2, "Coca", "Black"),
        new Dog(3, "Men", "White")
    };

    // Contains
    Console.WriteLine("=== Contains ===");
    if (dogs.Contains(new Dog(1, "Lyly", "Brown")))
    {
        Console.WriteLine("Contains(): Dog found.");
    }
    else
    {
        Console.WriteLine("Contains(): Dog NOT found.");
    }

    // Any
    Console.WriteLine("=== Any ===");
    if (dogs.Any(x => x.Equals(new Dog(1, "Lyly", "Brown"))))
    {
        Console.WriteLine("Any(): Matching dog found.");
    }
    else
    {
        Console.WriteLine("Any(): Matching dog NOT found.");
    }

    // Distinct with duplicate data
    Console.WriteLine("=== Distinct ===");
    dogs.Add(new Dog(1, "Lyly", "Brown"));
    dogs.Add(new Dog(2, "Coca", "Black"));

    Console.WriteLine($"Original count : {dogs.Count}");
    var distinctDogs = dogs.Distinct().ToList();
    Console.WriteLine($"Distinct count : {distinctDogs.Count}");

    // Hashset
    Console.WriteLine("=== HashSet ===");
    var hashSet = new HashSet<Dog>();
    hashSet.Add(new Dog(1, "Lyly", "Brown"));
    hashSet.Add(new Dog(1, "Lyly", "Brown"));
    hashSet.Add(new Dog(2, "Coca", "Black"));

    Console.WriteLine($"HashSet count : {hashSet.Count}");
}

void CompareUsingIEquatable()
{
    var dogs = new List<DogWithEquality>()
    {
        new DogWithEquality(1, "Lyly", "Brown"),
        new DogWithEquality(2, "Coca", "Black"),
        new DogWithEquality(3, "Men", "White")
    };

    // Contains
    Console.WriteLine("=== Any ===");
    if (dogs.Contains(new DogWithEquality(1, "Lyly", "Brown")))
    {
        Console.WriteLine("Contains(): Dog found.");
    }
    else
    {
        Console.WriteLine("Contains(): Dog NOT found.");
    }

    // Any
    Console.WriteLine("=== Any ===");
    if (dogs.Any(x => x.Equals(new DogWithEquality(1, "Lyly", "Brown"))))
    {
        Console.WriteLine("Any(): Matching dog found.");
    }
    else
    {
        Console.WriteLine("Any(): Matching dog NOT found.");
    }

    // Distinct with duplicate data
    Console.WriteLine("=== Distinct ===");
    dogs.Add(new DogWithEquality(1, "Lyly", "Brown"));
    dogs.Add(new DogWithEquality(2, "Coca", "Black"));

    Console.WriteLine($"Original count : {dogs.Count}");
    var distinctDogs = dogs.Distinct().ToList();
    Console.WriteLine($"Distinct count : {distinctDogs.Count}");

    // Hashset
    Console.WriteLine("=== HashSet ===");
    var hashSet = new HashSet<DogWithEquality>();
    hashSet.Add(new DogWithEquality(1, "Lyly", "Brown"));
    hashSet.Add(new DogWithEquality(1, "Lyly", "Brown"));
    hashSet.Add(new DogWithEquality(2, "Coca", "Black"));

    Console.WriteLine($"HashSet count : {hashSet.Count}");
}

void CompareUsingIEqualityComparer()
{
    var dogs = new List<Dog>()
    {
        new Dog(1, "Lyly", "Brown"),
        new Dog(2, "Coca", "Black"),
        new Dog(3, "Men", "White")
    };

    var comparer = new DogComparer();

    // Contains
    Console.WriteLine("=== Contains ===");
    if (dogs.Contains(new Dog(1, "Lyly", "Brown"), comparer))
    {
        Console.WriteLine("Contains(): Dog found.");
    }
    else
    {
        Console.WriteLine("Contains(): Dog NOT found.");
    }

    // Any
    Console.WriteLine("=== Any ===");
    if (dogs.Any(x => x.Equals(new Dog(1, "Lyly", "Brown"))))
    {
        Console.WriteLine("Any(): Matching dog found.");
    }
    else
    {
        Console.WriteLine("Any(): Matching dog NOT found.");
    }

    // Distinct with duplicate data
    Console.WriteLine("=== Distinct ===");
    dogs.Add(new Dog(1, "Lyly", "Brown"));
    dogs.Add(new Dog(2, "Coca", "Black"));

    Console.WriteLine($"Original count : {dogs.Count}");
    var distinctDogs = dogs.Distinct(comparer).ToList();
    Console.WriteLine($"Distinct count : {distinctDogs.Count}");

    // Hashset
    Console.WriteLine("=== HashSet ===");
    var hashSet = new HashSet<Dog>(comparer)
    {
        new Dog(1, "Lyly", "Brown"),
        new Dog(1, "Lyly", "Brown"),
        new Dog(2, "Coca", "Black")
    };

    Console.WriteLine($"HashSet count : {hashSet.Count}");
}