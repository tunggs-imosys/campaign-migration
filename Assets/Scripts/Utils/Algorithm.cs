using System.Collections.Generic;
using System;
using System.Collections;
using System.Linq;
using MyBox;
using System.Xml;

namespace Utils
{
  public static class Algorithm
  {
    public static R CastTo<R>(this IConvertible source) =>
      (R)Convert.ChangeType(source, typeof(R));

    public static R As<R>(this System.Object source) where R : class =>
      source as R;

    public static bool HasContent(this string source) =>
      !String.IsNullOrWhiteSpace(source);

    public static int ToInt(this string str) => int.Parse(str);

    public static bool OnlyCharactersIn(this string source,
      string allowedChars) => source.ToCharArray().All(allowedChars.Contains);

    public static bool InRange<T>(this T source, T minValue, T maxValue)
      where T : IComparable =>
      source.CompareTo(minValue) >= 0 && source.CompareTo(maxValue) <= 0;

    public static bool InRange(this int source, RangedInt range) =>
      InRange(source, range.Min, range.Max);

    public static bool InRange(this float source, RangedFloat range) =>
      InRange(source, range.Min, range.Max);

    public static T ClampTo<T>(this T source, T minValue, T maxValue)
      where T : IComparable => source.CompareTo(minValue) < 0 ? minValue :
      source.CompareTo(maxValue) > 0 ? maxValue :
      source;

    public static int Difference(this int source, int target) =>
      Math.Abs(source - target);

    public static (T1, T2) MakeTuple<T1, T2>(this T1 item1, T2 item2) =>
      (item1, item2);

    public static (T1, T2, T3) MakeTuple<T1, T2, T3>(this T1 item1,
      T2 item2,
      T3 item3) =>
      (item1, item2, item3);

    public static (T1, T2) MakeTupleAppend<T1, T2>(this T2 item2, T1 item1) =>
      (item1, item2);

    public static (T1, T2, T3) MakeTupleAppend<T1, T2, T3>(this T3 item3,
      T1 item1,
      T2 item2) => (item1, item2, item3);

    public static T PassTo<T>(this T argument, Action<T> action)
    {
      action(argument);
      return argument;
    }

    public static (T1, T2) PassTo<T1, T2>(this (T1, T2) arguments,
      Action<T1, T2> action)
    {
      action(arguments.Item1, arguments.Item2);
      return arguments;
    }

    public static (T1, T2, T3) PassTo<T1, T2, T3>(this (T1, T2, T3) arguments,
      Action<T1, T2, T3> action)
    {
      action(arguments.Item1, arguments.Item2, arguments.Item3);
      return arguments;
    }

    public static R PassTo<T, R>(this T argument, Func<T, R> function) =>
      function(argument);

    public static R PassTo<T1, T2, R>(this (T1, T2) arguments,
      Func<T1, T2, R> function) =>
      function(arguments.Item1, arguments.Item2);

    public static R PassTo<T1, T2, T3, R>(this (T1, T2, T3) arguments,
      Func<T1, T2, T3, R> function) =>
      function(arguments.Item1, arguments.Item2, arguments.Item3);

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source,
      Action<T> action)
    {
      foreach (T element in source) action(element);
      return source;
    }

    public static IEnumerable<R> SelectByIndex<T, R>(this IEnumerable<T> source,
      Func<int, R> selector)
    {
      IEnumerable<R> result = Enumerable.Empty<R>();
      int sourceLength = source.Count();
      for (int i = 0; i < sourceLength; ++i)
        result = result.Append(selector(i));
      return result;
    }

    public static R ConvertBy<T, R>(this T source, Func<T, R> converter) =>
      converter(source);

    public static Nullable<T> NullIf<T>(this T source, bool condition)
      where T : struct =>
      condition ? null : new Nullable<T>(source);

    public static Nullable<T> NullIf<T>(this T source, Predicate<T> condition)
      where T : struct =>
      condition(source) ? null : new Nullable<T>(source);

    public static IDictionary<TKey, TValue> Replace<TKey, TValue>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      TValue value,
      Action<TValue> actionForExistingValue = null)
    {
      if (source.ContainsKey(key)) actionForExistingValue?.Invoke(source[key]);
      source[key] = value;
      return source;
    }

    public static TValue ElementAtOrFillWith<TKey, TValue>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      TValue customDefault)
    {
      if (!source.ContainsKey(key)) source[key] = customDefault;
      return source[key];
    }

    public static TValue ElementAtOrFillWith<TKey, TValue>(
      this IDictionary<TKey, TValue> source,
      TKey key,
      Func<TValue> customDefault)
    {
      if (!source.ContainsKey(key)) source[key] = customDefault();
      return source[key];
    }

    public static IEnumerable<T> FillToSize<T>(this IEnumerable<T> source,
      int size,
      Func<T> generator)
    {
      int sourceLength = source.Count();
      var additions = Enumerable.Repeat(generator(), sourceLength);
      return source.Concat(additions);
    }

    public static IEnumerable<KeyValuePair<TK, RV>> ValueSelect<TK, TV, RV>(
      this IDictionary<TK, TV> source,
      Func<TV, RV> valueSelector) =>
      source.Select(pair => new KeyValuePair<TK, RV>(pair.Key,
        valueSelector(pair.Value)));

    public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(
      this IEnumerable<KeyValuePair<TKey, TValue>> source) =>
      source.ToDictionary(pair => pair.Key, pair => pair.Value);

    public static T MaxBy<T, S>(this IEnumerable<T> source, Func<T, S> selector)
      where S : IComparable<S>
      => source.Aggregate((e, n) =>
        selector(e).CompareTo(selector(n)) > 0 ? e : n);

    public static T MinBy<T, S>(this IEnumerable<T> source, Func<T, S> selector)
      where S : IComparable<S>
      => source.Aggregate((e, n) =>
        selector(e).CompareTo(selector(n)) < 0 ? e : n);

    public static T LoopingElementAt<T>(this IEnumerable<T> source, int i) =>
      source.ElementAt(i % source.Count());

    public static IEnumerable<int> IndicesWhere<T>(this IEnumerable<T> source,
      Predicate<T> predicate)
    {
      var indices = Enumerable.Empty<int>();
      int sourceLength = source.Count();
      for (int i = 0; i < sourceLength; ++i)
        if (predicate(source.ElementAt(i))) indices = indices.Append(i);
      return indices;
    }

    public static IEnumerable<T> Exclude<T>(this IEnumerable<T> source,
      T element) where T : class => source.Where(se => se != element);

    public static Random Randomizer = new Random();

    public static int Multiply(this int source, int right) => source * right;

    public static float Multiply(this int source, float right) =>
      source * right;

    public static float Multiply(this float source, float right) =>
      source * right;

    public static float Plus(this float source, float right) =>
      source + right;

    public static int Plus(this int source, int right) => source + right;

    public static float Sqrt(this float source) => (float)Math.Sqrt(source);

    public static float Pow(this float source, float power) =>
      (float)Math.Pow(source, power);

    public static int Round(this float source) => (int)Math.Round(source);

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) =>
      source.OrderBy(e => Randomizer.Next());

    static XmlDocument _xmlDoc = new XmlDocument();
    public static XmlNode ImportTo(this string source,
      XmlDocument document)
    {
      _xmlDoc.LoadXml(source);
      return document.ImportNode(_xmlDoc.DocumentElement, true);
    }
  }

  public static class Algorithm2
  {
    public static T NullIf<T>(this T source, bool condition)
      where T : class =>
      condition ? null : source;

    public static T NullIf<T>(this T source, Predicate<T> condition)
      where T : class =>
      condition(source) ? null : source;
  }
}