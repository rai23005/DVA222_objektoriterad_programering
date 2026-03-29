using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    /* public class ChainedHashDictionary<TKey, TValue> : IDictionary<TKey, TValue>
     {
         private const int DefaultCapacity = 25;
         private LinkedList<KeyValuePair<TKey, TValue>>[] items;

         public ChainedHashDictionary()
         {
             items = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
         }

         // GetHashCode-metoden för att beräkna hashvärdet
         private int GetHashCode(TKey key)
         {
             return Math.Abs(key.GetHashCode() % items.Length);
         }

         public void AddOrUpdate(TKey key, TValue value)
         {
             int index = GetHashCode(key);
             if (items[index] == null)
             {
                 items[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
             }

             // Sök igenom kedjan för att se om nyckeln redan finns
             foreach (var node in items[index])
             {
                 if (EqualityComparer<TKey>.Default.Equals(node.Value.Key, key))
                 {
                     // Uppdatera värdet för befintlig nyckel
                     node.Value = new KeyValuePair<TKey, TValue>(key, value);
                     return;
                 }
             }

             // Lägg till nytt nyckel-värdepar i kedjan
             items[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
         }

         public TValue this[TKey key]
         {
             get
             {
                 if (TryGetValue(key, out TValue value))
                     return value;
                 throw new KeyNotFoundException();
             }
             set => AddOrUpdate(key, value,
                     // Uppdatera värdet för befintlig nyckel
                     node);
         }

         public void Add(TKey key, TValue value)
         {
             AddOrUpdate(key, value,
                     // Uppdatera värdet för befintlig nyckel
                     node);
         }

         public bool ContainsKey(TKey key)
         {
             int index = GetHashCode(key);
             if (items[index] != null)
             {
                 foreach (var kvp in items[index])
                 {
                     if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                     {
                         return true;
                     }
                 }
             }
             return false;
         }

         public ICollection<TKey> Keys
         {
             get
             {
                 List<TKey> keys = new List<TKey>();
                 foreach (var chain in items)
                 {
                     if (chain != null)
                     {
                         foreach (var kvp in chain)
                         {
                             keys.Add(kvp.Key);
                         }
                     }
                 }
                 return keys;
             }
         }

         public bool Remove(TKey key)
         {
             int index = GetHashCode(key);
             if (items[index] != null)
             {
                 LinkedListNode<KeyValuePair<TKey, TValue>> current = items[index].First;
                 while (current != null)
                 {
                     if (EqualityComparer<TKey>.Default.Equals(current.Value.Key, key))
                     {
                         items[index].Remove(current);
                         return true;
                     }
                     current = current.Next;
                 }
             }
             return false;
         }

         public bool TryGetValue(TKey key, out TValue value)
         {
             int index = GetHashCode(key);
             if (items[index] != null)
             {
                 foreach (var kvp in items[index])
                 {
                     if (EqualityComparer<TKey>.Default.Equals(kvp.Key, key))
                     {
                         value = kvp.Value;
                         return true;
                     }
                 }
             }
             value = default(TValue);
             return false;
         }

         public ICollection<TValue> Values
         {
             get
             {
                 List<TValue> values = new List<TValue>();
                 foreach (var chain in items)
                 {
                     if (chain != null)
                     {
                         foreach (var kvp in chain)
                         {
                             values.Add(kvp.Value);
                         }
                     }
                 }
                 return values;
             }
         }

         public void Add(KeyValuePair<TKey, TValue> item)
         {
             AddOrUpdate(item.Key, item.Value,
                     // Uppdatera värdet för befintlig nyckel
                     node);
         }

         public void Clear()
         {
             items = new LinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
         }

         public bool Contains(KeyValuePair<TKey, TValue> item)
         {
             int index = GetHashCode(item.Key);
             if (items[index] != null)
             {
                 foreach (var kvp in items[index])
                 {
                     if (EqualityComparer<TKey>.Default.Equals(kvp.Key, item.Key) && EqualityComparer<TValue>.Default.Equals(kvp.Value, item.Value))
                     {
                         return true;
                     }
                 }
             }
             return false;
         }

         public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
         {
             foreach (var chain in items)
             {
                 if (chain != null)
                 {
                     foreach (var kvp in chain)
                     {
                         array[arrayIndex++] = kvp;
                     }
                 }
             }
         }

         public int Count
         {
             get
             {
                 int count = 0;
                 foreach (var chain in items)
                 {
                     if (chain != null)
                     {
                         count += chain.Count;
                     }
                 }
                 return count;
             }
         }

         public bool IsReadOnly => false;

         public bool Remove(KeyValuePair<TKey, TValue> item)
         {
             return Remove(item.Key);
         }

         public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
         {
             foreach (var chain in items)
             {
                 if (chain != null)
                 {
                     foreach (var kvp in chain)
                     {
                         yield return kvp;
                     }
                 }
             }
         }

         IEnumerator IEnumerable.GetEnumerator()
         {
             return GetEnumerator();
         }
     }
    */
}
