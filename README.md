# Sample Ignite app using Emoji 

My setup:
* .Net 6 which is referencing Apache.Ignite
* Ignite 2.15
* JAVA_HOME set to OpenJDK 11.0.20+8 - tried also OpenJDK_17.0.8_7 and same results.

Sample code below on setting up a dummy cache and doing Get/Update:
```
IIgnite ignite = Ignition.Start();
Apache.Ignite.Core.Cache.ICache<Guid, Person> cache = ignite.GetOrCreateCache<Guid, Person>(nameof(Person));
cache.Put( firstPerson.Id, new Person(){ Id = Guid.NewGuid(), Name="MrQ" } );

const int nbGetAndWrites = 8;
// Get, Update, Put same record multiple times and add each time an Emoji
for (int i = 0; i < nbGetAndWrites; i++)
{
    Person fromCache = cache.Get(firstPerson.Id);
    Console.WriteLine($"Step {i} got Person {fromCache}");
    fromCache.Name += $" [🐝]";
    cache.Put(fromCache.Id, fromCache);
}

```

Output:
```
Step 0 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ ]
Step 1 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' ]
Step 2 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' [🐝] ]
Step 3 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' [🐝] [🐝]( ]
Step 4 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' [🐝] [🐝]( [🐝]eee???? ]
Step 5 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' [🐝] [🐝]( [🐝]eee???? [🐝]ee???? ]
Step 6 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' [🐝] [🐝]( [🐝]eee???? [🐝]ee???? [🐝]g/garbage-collector).ee??v?? ]
Step 7 got Person [ Id=764d9799-6cb5-402e-93ba-ee3d1b87c0fb; Name=MrQ [🐝]' [🐝] [🐝]( [🐝]eee???? [🐝]ee???? [🐝]g/garbage-collector).ee??v?? [🐝]?v???v??`?v??`?v??p?v??p?v????v????v?? ]
```
