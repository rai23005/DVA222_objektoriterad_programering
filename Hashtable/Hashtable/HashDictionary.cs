using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    internal class HashDictionary<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>
    {

        const int StartHashtabel = 16; // Hur stor hastabbel
        LinkedList<KeyValuePair<K, V>>[] buckets; // Array för länkad lista

        //Konstruktor 
        public HashDictionary()
        {
            buckets = new LinkedList<KeyValuePair<K, V>>[StartHashtabel];
        }

        //Hämta buckets index
        private int BucketIndex(K key)
        {
            
            //key.GetHashCode hämtar hashkoden för nyckeln
            //% buckets.Length, modulus räkning på antal bucket som finns   
            return key.GetHashCode() % buckets.Length;
        }

        //Hämta eller tilldela värden med en nyckel av typen K och returnera värden av typen V
        public V this[K key]
        {
            get
            {
                //Kollar om det finns något värde på index 
                int index = BucketIndex(key);
                if (buckets[index] != null)
                {
                    //Går igenom hela listan efter rätt bucket 
                    foreach (var pair in buckets[index])
                    {
                        //Om nyckeln hittas retunera nyckeln
                        if (pair.Key.Equals(key))
                        {
                            return pair.Value;
                        }
                    }
                }
                //Nyckeln hittas ej
                throw new KeyNotFoundException("Key not found in dictionary.");
            }
            set
            {
                int index = BucketIndex(key);
                if (buckets[index] == null)
                    buckets[index] = new LinkedList<KeyValuePair<K, V>>();

                // Kollar om nyckeln finns redan 
                if (buckets[index].Any(pair => pair.Key.Equals(key)))
                {
                    // Tar bart den redan existerade paret 
                    var existingPair = buckets[index].First(pair => pair.Key.Equals(key));
                    buckets[index].Remove(existingPair);
                }

                // LÄgger til nya paret 
                buckets[index].AddLast(new KeyValuePair<K, V>(key, value));
            }
        }

        //Hämtar alla nycklar som finns
        public ICollection<K> Keys
        {
            get
            {
                //Skapar en lista 
                var keys = new List<K>();
                //Går igenom alla buckets
                foreach (var bucket in buckets)
                {
                    //Plockar ut alla nycklar som finns i buckets
                    if (bucket != null)
                    {
                        foreach (var pair in bucket)
                        {
                            keys.Add(pair.Key);
                        }
                    }
                }
                return keys;
            }
        }

        //Hämtar alla värden som finns
        public ICollection<V> Values
        {
            //Samma uppbyggnad som ICollection<K> Keys
            get
            {
                var values = new List<V>();
                foreach (var bucket in buckets)
                {
                    if (bucket != null)
                    {
                        foreach (var pair in bucket)
                        {
                            values.Add(pair.Value);
                        }
                    }
                }
                return values;
            }
        }

        // Metod som returnerar antalet element
        public int Count
        {
            get
            {
                int count = 0;

                //Kollar vilka buckets som är inte tomma, de inte tomma räknas 
                foreach (var bucket in buckets)
                {
                    if (bucket != null)
                        count += bucket.Count;
                }
                return count;
            }
        }

        //Är HashDictionary skrivskyddat eller inte,
        public bool IsReadOnly => false;
             

        // Metod för att lägga till ett nytt element
        public void Add(K key, V value)
        {
            int index = BucketIndex(key);

            //Finns bucket på index annars gör en länkad lista 
            if (buckets[index] == null)
            { buckets[index] = new LinkedList<KeyValuePair<K, V>>(); }


            // Kollar igenom länkade om finns redan eller inte
            foreach (var pair in buckets[index])
            {
                //Om nyckeln finns redan i listan
                if (pair.Key.Equals(key))
                    throw new ArgumentException("Key already exists in the dictionary.");
            }

            //Om inte nyckeln finns så läggs den sists i den länkade listan
            buckets[index].AddLast(new KeyValuePair<K, V>(key, value));
        }

        // Metod för att lägga till ett KeyValuePair-objekt, låter Add metoden 
        public void Add(KeyValuePair<K, V> item)
        {
            Add(item.Key, item.Value);
        }

        // Metod för att rensa listan
        public void Clear()
        {
            foreach (var bucket in buckets)
            {
                //Om buckt är NULL så körs den inte, pga  ?
                bucket?.Clear();
            }
        }

        // Metod för att kontrollera om ett KeyValuePair-objekt finns
        public bool Contains(KeyValuePair<K, V> item)
        {
            //Kollar 
            if (TryGetValue(item.Key, out V value))
            {
                //Jämför värdet som returnerats från TryGetValue samma värde retuneras true 
                return EqualityComparer<V>.Default.Equals(value, item.Value);
            }
               
            return false;
        }

        // Metod för att kontrollera om en nyckel finsn eller inte
        public bool ContainsKey(K key)
        {
            int index = BucketIndex(key);

            //Kollar på bucket index sedan går genom alla buckets efter rätt nyckl. Om nyckeln finns retuneras true
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                        return true;
                }
            }
            return false;
        }

        // Metod för att kopiera KeyValuePair-objekt till en array
        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {

            int currentIndex = arrayIndex;

            //Kollar genom alla bucket med värden
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    //Koppiera alla pair i bucket till en array 
                    foreach (var pair in bucket)
                    {
                        //Om currentIndex är mindre än arrays längd kan inte det kopieras paren till en array
                        if (currentIndex >= array.Length)
                            throw new ArgumentException("Array is too small to copy all Pair.");
                        array[currentIndex] = pair;
                        currentIndex++;
                    }
                }
            }
        }


        // Metod för att kopiera objekt till array 
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        //Iteration över alla nyckel-värdepa
        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var pair in bucket)
                    {
                        //Retunera  ett nyckel-värdepar åt gången under iterationen
                        yield return pair;
                    }
                }
            }
        }

        // Metod för att ta bort ett element med en nyckel
        public bool Remove(K key)
        {
            //Kollar om det finns någon bucket med rätt index
            int index = BucketIndex(key);
            if (buckets[index] != null)
            {

                var list = buckets[index];

                //Kollar genom Länkade listan 
                foreach (var pair in list)
                {
                    //Om det hittar ett par med rätt nyckel så tar den bort paret från listan
                    if (pair.Key.Equals(key))
                    {
                        list.Remove(pair);

                        //Lyckade att ta bort nyckeln
                        return true;
                    }
                }
            }

            //Fanns inte med rätt nyckel 
            return false;
        }

        // Metod för att ta bort ett KeyValuePair-objekt
        public bool Remove(KeyValuePair<K, V> item)
        {
            return Remove(item.Key);
        }

        // Metod för att försöka hämta värdet för en given nyckel
        public bool TryGetValue(K key, out V value)
        {
            int index = BucketIndex(key);
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        //Nyckelns värde ges till value.
                        value = pair.Value;
                        return true;
                    }
                }
            }
            //Fanns inget värde med den nyckeln, sätt value till default
            value = default(V);
            return false;
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
