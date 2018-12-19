# PowerExtensions

PowerExtensions are a hobby project of a senior developer which helps you to write faster, cleaner and more understandable code with the use of helpful extension methods. Those methods are used in my daily business and i guess everyone of you had written or think of them before. They are full unit-testet, feel free to use them, add pull requests or make some issues.

### Table of implemented extensions
* Dictionary
	* AddIfMissing(key, Func<K,V>)
	* GetOrAdd(key, Func<K,V>)
* Grouping
	* IEnumerable<IGrouping<K,V>>.ToDictionary()
* Linq
	* Second()
	* Second(Predicate condition)
	* Third()
	* Third(Predicate condition)
