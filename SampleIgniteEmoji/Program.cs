using Apache.Ignite.Core;

IIgnite ignite = Ignition.Start();

Person firstPerson = new() { Id = Guid.NewGuid(), Name = "MrQ" };
Apache.Ignite.Core.Cache.ICache<Guid, Person> cache = ignite.GetOrCreateCache<Guid, Person>(nameof(Person));
cache.Put(firstPerson.Id, firstPerson);

const int nbGetAndWrites = 8;
// Get, Update, Put same record multiple times and add each time an Emoji
for (int i = 0; i < nbGetAndWrites; i++)
{
    Person fromCache = cache.Get(firstPerson.Id);
    Console.WriteLine($"Step {i} got Person {fromCache}");
    fromCache.Name += $" [🐝]";
    cache.Put(fromCache.Id, fromCache);
}


public class Person
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public override string ToString()
    {
        return $"[ Id={Id}; Name={Name} ]";
    }
}