# PowerExtensions

PowerExtensions are a hobby project of a senior developer which helps you to write faster, cleaner and more understandable code with the use of helpful extension methods. Those methods are used in my daily business and i guess everyone of you had written or think of them before. They are full unit-testet, feel free to use them, add pullrequests or report issues.

### Table of implemented extensions
* Linq
	* IDictionary<K,V>.AddIfMissing(key, Func<K,V>)
	* IDictionary<K,V>.GetOrAdd(key, Func<K,V>)
	* IEnumerable<T>.Add(params T[])
	* IEnumerable<T>.Append(params T[])
	* IEnumerable<T>.Chunk(chunkSize)
	* IEnumerable<TLeft>.CrossJoin(IEnumerable<TRight>)
	* IEnumerable<TLeft>.CrossJoin(IEnumerable<TRight>, Func<TLeft,TRight,TResult>)
	* IEnumerable<T>.Prepend(params T[])
	* IEnumerable<T>.Second()
	* IEnumerable<T>.Second(Predicate)
	* IEnumerable<T>.SecondOrDefault()
	* IEnumerable<T>.SecondOrDefault(Predicate)
	* IEnumerable<T>.SelectList(Func<T,R>)
	* IEnumerable<T>.Third()
	* IEnumerable<T>.Third(Predicate)
	* IEnumerable<T>.ThirdOrDefault()
	* IEnumerable<T>.ThirdOrDefault(Predicate)
* Querying
	* IDataReader.GetValue<T>(name)
	* IDataReader.GetValue<T>(ordinal)
	* IDataReader.GetValueOrDefault<T>(name)
	* IDataReader.GetValueOrDefault<T>(ordinal)
* Reflection
	* PropertyInfo.IsInstance()
	* PropertyInfo.IsNonPublic()
	* PropertyInfo.IsPublic()
	* PropertyInfo.IsStatic()
	* Type.GetFieldsAll()
	* Type.GetPropertiesAll()
	* Type.IsComplex()
	* Type.IsNullable()
	* Type.IsSimple()
* Serialization
	* IFormatter.Deserialize<T>(Stream)
	* SerializationInfo.GetValue<T>(name)
	* String.GetBytes()
	* String.GetBytes(IFormatter)
* Transformation
	* IEnumerable<IGrouping<K,V>>.ToDictionary()