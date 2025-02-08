using System;

public class HashTable<K, V>
{
    private class HashNode
    {
        public K Key { get; }
        public V Value { get; set; }
        public bool IsDeleted { get; set; }

        public HashNode(K key, V value)
        {
            Key = key;
            Value = value;
            IsDeleted = false;
        }
    }

    private HashNode[] _table;
    public int _size, stepAmount = 7;
    private const double LoadFactor = 0.75;

    public HashTable()
    {
        _table = new HashNode[10];
        _size = 0;
    }

    private int PrimaryHash(K key)
    {
        return Math.Abs(key.GetHashCode()) % _table.Length % 26;
    }

    private int SecondaryHash(K key)
    {
        return 1 + (Math.Abs(key.GetHashCode()) % (_table.Length - 1) % 13);
    }

    private int GetIndex(K key)
    {
        int primaryHash = PrimaryHash(key);
        int secondaryHash = SecondaryHash(key);
        int index = primaryHash;
        int i = stepAmount;

        while (_table[index] != null)
        {
            if (!_table[index].IsDeleted && _table[index].Key.Equals(key))
                return index; // Return index if key matches and is not deleted

            index = (primaryHash + i * secondaryHash) % _table.Length;
            i += stepAmount;
        }
        return index; // Return empty/deleted slot
    }
    int insertCalls = 0;
    public void Insert(K key, V value)
    {
        insertCalls++;
        if (_size >= _table.Length * LoadFactor)
        {
            Resize();
        }

        int index = GetIndex(key);
        if (_table[index] == null || _table[index].IsDeleted)
        {
            _table[index] = new HashNode(key, value);
            _size++;
        }
        else
        {
            _table[index].Value = value;
        }
    }

    public bool Remove(K key)
    {
        int index = GetIndex(key);
        if (_table[index] != null && !_table[index].IsDeleted)
        {
            _table[index].IsDeleted = true;
            _size--;
            return true;
        }
        return false;
    }

    public bool TryGetValue(K key, out V value)
    {
        int index = GetIndex(key);
        if (_table[index] != null && !_table[index].IsDeleted)
        {
            value = _table[index].Value;
            return true;
        }
        value = default;
        return false;
    }

    private void Resize()
    {
        HashNode[] oldTable = _table;
        _table = new HashNode[_table.Length * 2];
        _size = 0; // Reset size since Insert() increments it

        foreach (var node in oldTable)
        {
            if (node != null && !node.IsDeleted)
            {
                int newIndex = GetIndex(node.Key); // Get new index based on updated size
                _table[newIndex] = new HashNode(node.Key, node.Value);
                _size++;
            }
        }
    }

    public void IterateAll()
    {
        Console.WriteLine("\n--- Hash Table Contents ---");
        for (int i = 0; i < _table.Length; i++)
        {
            if (_table[i] == null || _table[i].IsDeleted)
            {
                Console.WriteLine($"Index {i}: -");
            }
            else
            {
                Console.WriteLine($"Index {i}: Key = {_table[i].Key}, Value = {_table[i].Value}");
            }
        }
        Console.WriteLine("----------------------------\n");
    }
}