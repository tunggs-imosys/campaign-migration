using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class ObservableDictionary<TKey, TValue> :
  IDictionary<TKey, TValue>,
  INotifyCollectionChanged
{
  readonly IDictionary<TKey, TValue> dictionary;
  public ICollection<TKey> Keys => dictionary.Keys;
  public ICollection<TValue> Values => dictionary.Values;
  public event NotifyCollectionChangedEventHandler CollectionChanged =
    (sender, e) => { };

  public ObservableDictionary() : this(new Dictionary<TKey, TValue>()) { }

  public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
  {
    this.dictionary = dictionary;
  }

  public TValue this[TKey key]
  {
    get => dictionary[key];
    set => UpdateWithNotification(key, value);
  }

  void UpdateWithNotification(TKey key, TValue value)
  {
    TValue existing;
    if (!dictionary.TryGetValue(key, out existing))
    {
      AddWithNotification(key, value);
      return;
    }
    dictionary[key] = value;

    CollectionChanged(this,
      new NotifyCollectionChangedEventArgs(
        NotifyCollectionChangedAction.Replace,
        new KeyValuePair<TKey, TValue>(key, value),
        new KeyValuePair<TKey, TValue>(key, existing)));
  }

  void AddWithNotification(TKey key, TValue value)
  {
    dictionary.Add(key, value);

    CollectionChanged(this,
      new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,
        new KeyValuePair<TKey, TValue>(key, value)));
  }

  bool RemoveWithNotification(TKey key)
  {
    TValue value;
    if (!(dictionary.TryGetValue(key, out value) && dictionary.Remove(key)))
      return false;

    CollectionChanged(this,
      new NotifyCollectionChangedEventArgs(
        NotifyCollectionChangedAction.Remove,
        new KeyValuePair<TKey, TValue>(key, value)));
    return true;
  }

  public void Add(KeyValuePair<TKey, TValue> item) =>
    AddWithNotification(item.Key, item.Value);

  public void Clear()
  {
    dictionary.Clear();

    CollectionChanged(this,
      new NotifyCollectionChangedEventArgs(
        NotifyCollectionChangedAction.Reset));
  }

  public bool Contains(KeyValuePair<TKey, TValue> item) =>
    dictionary.Contains(item);

  public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) =>
    dictionary.CopyTo(array, arrayIndex);

  public int Count => dictionary.Count;

  public bool IsReadOnly => dictionary.IsReadOnly;

  public bool Remove(KeyValuePair<TKey, TValue> item) =>
    RemoveWithNotification(item.Key);

  public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() =>
    dictionary.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => dictionary.GetEnumerator();

  public void Add(TKey key, TValue value) => AddWithNotification(key, value);

  public bool ContainsKey(TKey key) => dictionary.ContainsKey(key);

  public bool Remove(TKey key) => RemoveWithNotification(key);

  public bool TryGetValue(TKey key, out TValue value) =>
    dictionary.TryGetValue(key, out value);
}