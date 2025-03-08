using System;
using System.Collections.Generic;

public class HashMap<K, V>
{
    // Define the initial capacity as a prime number close to 1000 for better hashing distribution.
    private int capacity = 997;
    private int size = 0;
    private LinkedList<KeyValuePair<K, V>>[] buckets;

    // Load factor threshold for resizing
    private const double LoadFactor = 0.7;

    public HashMap()
    {
        buckets = new LinkedList<KeyValuePair<K, V>>[capacity];
    }

    // Hash function: Converts the key to an index within the array
    private int GetBucketIndex(K key)
    {
        int hashCode = key.GetHashCode();
        return Math.Abs(hashCode) % capacity;
    }

    // Insert or update a key-value pair
    public void Insert(K key, V value)
    {
        int index = GetBucketIndex(key);

        // Initialize bucket if empty
        if (buckets[index] == null)
        {
            buckets[index] = new LinkedList<KeyValuePair<K, V>>();
        }

        // Check if key already exists and update
        foreach (var pair in buckets[index])
        {
            if (pair.Key.Equals(key))
            {
                buckets[index].Remove(pair);
                break;
            }
        }

        // Add new key-value pair
        buckets[index].AddLast(new KeyValuePair<K, V>(key, value));
        size++;

        // Resize if load factor exceeded
        if ((double)size / capacity > LoadFactor)
        {
            Resize();
        }
    }

    // Retrieve a value by key
    public V Search(K key)
    {
        int index = GetBucketIndex(key);

        if (buckets[index] != null)
        {
            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
        }

        throw new KeyNotFoundException("Key not found in HashMap");
    }

    // Delete a key-value pair
    public void Delete(K key)
    {
        int index = GetBucketIndex(key);

        if (buckets[index] != null)
        {
            foreach (var pair in buckets[index])
            {
                if (pair.Key.Equals(key))
                {
                    buckets[index].Remove(pair);
                    size--;
                    return;
                }
            }
        }

        throw new KeyNotFoundException("Key not found in HashMap");
    }

    // Resize: Increase capacity and rehash elements
    private void Resize()
    {
        int newCapacity = GetNextPrime(capacity * 2);
        var newBuckets = new LinkedList<KeyValuePair<K, V>>[newCapacity];

        foreach (var bucket in buckets)
        {
            if (bucket != null)
            {
                foreach (var pair in bucket)
                {
                    int newIndex = Math.Abs(pair.Key.GetHashCode()) % newCapacity;

                    if (newBuckets[newIndex] == null)
                    {
                        newBuckets[newIndex] = new LinkedList<KeyValuePair<K, V>>();
                    }

                    newBuckets[newIndex].AddLast(pair);
                }
            }
        }

        buckets = newBuckets;
        capacity = newCapacity;
    }

    // Helper function to find the next prime number (used for resizing)
    private int GetNextPrime(int num)
    {
        while (!IsPrime(num))
        {
            num++;
        }
        return num;
    }

    private bool IsPrime(int num)
    {
        if (num < 2) return false;
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0) return false;
        }
        return true;
    }

    // Display the HashMap (for debugging)
    public void Display()
    {
        for (int i = 0; i < capacity; i++)
        {
            if (buckets[i] != null)
            {
                foreach (var pair in buckets[i])
                {
                    Console.WriteLine($"{pair.Value}");
                }
            }
        }
    }
}

