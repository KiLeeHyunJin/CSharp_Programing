using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._2024_01_18
{
    public class DataHashTable<TKey, TValue> where TKey : IEquatable<TKey>
    {
        struct Entry
        {
            public enum State { None, Using, Deleted,};
            public State state;
            public TKey key;
            public TValue value;
        }
        Entry[] table;
        int count;
        const int DefaultCapacity = 193;
        public TValue this[TKey key]
        {
            get
            {
                if(Find(key,out int idx))
                    return table[idx].value;
                else 
                    throw new KeyNotFoundException();
            }
            set
            {
                if (Find(key, out int idx))
                {
                    table[idx].value = value;
                    table[idx].key = key;
                }
                else
                    Add(key, value);
            }
        }
        void ReHashing()
        {
            Entry[] oldTable = table;
            table = new Entry[table.Length << 1];
            count++;
            for (int i = 0; i < oldTable.Length; i++)
            {
                Entry entry = oldTable[i];
                if (entry.state == Entry.State.Using)
                {
                    Add(entry.key, entry.value);
                }
            }
        }
        public DataHashTable()
        {
            table = new Entry[DefaultCapacity];
        }
        public DataHashTable(int capacity) 
        { 
            table = new Entry[capacity];
        }
        public void Add(TKey key, TValue value)
        {
            if(Find(key , out int idx))
            {
                throw new InvalidOperationException("Already exist key");
            }
            else
            {
                if(count > table.Length * .7f)
                {
                    ReHashing();
                }
                table[idx].key = key;
                table[idx].value = value;
                table[idx].state = Entry.State.Using;
                count++;
            }
        }
        public bool ContainsKey(TKey key)
        {
            if(Find(key,out int idx))
            {
                return true;
            }
            return false;
        }

        public bool Remove(TKey key)
        {
            if(Find(key,out int idx))
            {
                table[idx].state = Entry.State.Deleted;
                return true;
            }
            else
            { return false; }
        }

        bool Find(TKey key, out int idx)
        {
            idx = Hashing(key);
            for (int i = 0; i < table.Length; i++)
            {
                if (table[idx].state == Entry.State.None)
                {
                    return false;
                }
                else if (table[idx].state == Entry.State.Using)
                {
                    if (key.Equals(table[idx].key))
                    {
                        return true;
                    }
                    else
                    {
                        idx = Hash2(idx);
                    }
                }
                else
                {
                    return false;
                }
            }
            
            idx = -1;
            throw new InvalidDataException();
        }
        int Hashing(TKey key)
        {
            return Math.Abs(key.GetHashCode() % table.Length);

        }
        int Hash2(int idx)
        {
            return (idx + 1) % table.Length;
        }




    }
}
