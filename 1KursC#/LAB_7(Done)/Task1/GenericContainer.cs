using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace Task1
{
    public class GenericContainer<T> : IFileContainer<T>, IEnumerable<T>, IEnumerator<T>
    {
        private T[] items = new T[0];
        private int position = -1;
        private bool isDataSaved = false;

        public int Count => items.Length;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException("Index out of range!");
                return items[index]!;
            }
            set
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException("Index out of range!");
                items[index] = (T)value!;
            }
        }

        public bool IsDataSaved => isDataSaved;

        public void Add(T element)
        {
            T[] newItems = new T[items.Length + 1];
            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }
            newItems[items.Length] = element;
            items = newItems;
            isDataSaved = false;
        }

        public void Delete(T element)
        {
            int index = Array.IndexOf(items, element);
            if (index == -1)
                return;

            T[] newItems = new T[items.Length - 1];
            for (int i = 0, j = 0; i < items.Length; i++)
            {
                if (i == index) continue;
                newItems[j++] = items[i];
            }
            items = newItems;
            isDataSaved = false;
        }

        public void Save(string fileName)
        {
            using StreamWriter writer = new StreamWriter(fileName);
            foreach (var item in items)
            {
                writer.WriteLine(item?.ToString());
            }
            isDataSaved = true;
        }

        public void Load(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File not found!");

            string[] lines = File.ReadAllLines(fileName);
            items = new T[lines.Length];
    
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (typeof(T) == typeof(int))
                {
                    items[i] = (T)(object)int.Parse(line);
                }
                else if (typeof(T) == typeof(double))
                {
                    items[i] = (T)(object)double.Parse(line);
                }
                else if (typeof(T) == typeof(string))
                {
                    items[i] = (T)(object)line;
                }
                else if (typeof(T) == typeof(Person))
                {
                    items[i] = (T)(object)Person.FromString(line);
                }
                else
                {
                    throw new InvalidOperationException($"Load not support type: {typeof(T)}");
                }
            }
            isDataSaved = true;
        }
        
        public IEnumerator<T> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public T Current => items[position];
        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            if (position < items.Length - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset() => position = -1;
        public void Dispose() { }
        public void Sort()
        {
            Array.Sort(items);
            isDataSaved = false;
        }
        
        public GenericContainer<T> CopyFirst(int numberOfElements)
        {
            var newContainer = new GenericContainer<T>();
            for (int i = 0; i < numberOfElements && i < items.Length; i++)
            {
                newContainer.Add(items[i]);
            }
            return newContainer;
        }
    }
    
    public interface IContainer<TElement>
    {
        int Count { get; }
        Object this[int index] { get;set;}
        void Add(TElement element );
        void Delete(TElement element );
    }

    public interface IFileContainer<TElement> : IContainer<TElement>
    {
        void Save( String fileName );
        void Load( String fileName );
        bool IsDataSaved {get;}
    }
}