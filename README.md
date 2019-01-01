# PowerExtensions

[![NuGet version](https://img.shields.io/badge/nuget-v1.1.0-brightgreen.svg)](https://www.nuget.org/packages/PowerExtensions/)

PowerExtensions are a hobby project of a professional developer which helps you to write faster, cleaner and more understandable code with the use of helpful extension methods. It adresses .net week spots which are not intuitive to handle, not typesafe or (in my opionion) missing.
Those methods are used in my daily business and i guess everyone of you had written or think of them before. They are full unit-testet, feel free to use them, add pullrequests or report issues.

### Table of implemented extensions in Version 1.1.0

* Execution
	* Array\<T>[,].ForEach(Action\<T>) : void
	* Array\<T>[,].ForEachCol(Action<T[]>) : void
	* Array\<T>[,].ForEachRow(Action<T[]>) : void
* Linq
	* IDictionary<K, V>.AddIfMissing(key, Func<K, V>) : void
	* IDictionary<K, V>.GetOrAdd(key, Func<K, V>) : V
	* IEnumerable<IGrouping<K, V>>.ToDictionary() : IDictionary<K, IEnumerable\<V>>
	* IEnumerable\<T>.Add(params T[]) : IEnumerable\<T>
	* IEnumerable\<T>.Append(params T[]) : IEnumerable\<T>
	* IEnumerable\<T>.Chunk(chunkSize) : IEnumerable<IEnumerable\<T>>
	* IEnumerable\<TLeft>.CrossJoin(IEnumerable\<TRight>) : IEnumerable<Tuple<TLeft, TRight>>
	* IEnumerable\<TLeft>.CrossJoin(IEnumerable\<TRight>, Func<TLeft, TRight, TResult>) : IEnumerable\<TResult>
	* IEnumerable\<T>.Prepend(params T[]) : IEnumerable\<T>
	* IEnumerable\<T>.Second() : T
	* IEnumerable\<T>.Second(Predicate) : T
	* IEnumerable\<T>.SecondOrDefault() : T
	* IEnumerable\<T>.SecondOrDefault(Predicate) : T
	* IEnumerable\<T>.SelectList(Func<T, R>) : List\<R>
	* IEnumerable\<T>.Third() : T
	* IEnumerable\<T>.Third(Predicate) : T
	* IEnumerable\<T>.ThirdOrDefault() : T
	* IEnumerable\<T>.ThirdOrDefault(Predicate) : T
* Querying
	* IDataReader.GetValue\<T>(name) : T
	* IDataReader.GetValue\<T>(ordinal) : T
	* IDataReader.GetValueOrDefault\<T>(name) : T
	* IDataReader.GetValueOrDefault\<T>(ordinal) : T
	* String.ContainsAtIndex(substring, index) : bool
	* String.ContainsFromIndex(substring, index) : bool
	* String.ContailsUntilIndex(substring, index) : bool

* Reflection	
	* PropertyInfo.IsInstance() : bool
	* PropertyInfo.IsNonPublic() : bool
	* PropertyInfo.IsPublic() : bool
	* PropertyInfo.IsStatic() : bool
	* Type.GetFieldsAll() : IEnumerable\<FieldInfo>
	* Type.GetPropertiesAll() : IEnumerable\<PropertyInfo>
	* Type.IsComplex() : bool
	* Type.IsNullable() : bool
	* Type.IsSimple() : bool
* Serialization
	* IFormatter.Deserialize\<T>(Stream) : T
	* SerializationInfo.GetValue\<T>(name) : T
	* String.GetBytes() : byte[]	
	* String.GetBytes(IFormatter) : byte[]