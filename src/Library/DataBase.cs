using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Ucu.Poo.Repositories
{
    public class Database<T>
        where T : class, IHasValue
    {
        private List<T> items = new List<T>();

        public ReadOnlyCollection<T> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        public void Add(T item)
        {
            if (item != null)
            {
                this.items.Add(item);
            }
        }

        public void Remove(T item)
        {
            this.items.Remove(item);
        }

        public T Find(string field, string value)
        {
            foreach (T item in this.items)
            {
                if (item.HasValue(field, value))
                {
                    return item;
                }
            }

            return null;
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this.items);
        }

        public void LoadFromJson(string content)
        {
            List<T> loadedItems = JsonSerializer.Deserialize<List<T>>(content);
            this.items = loadedItems ?? new List<T>();
        }

        public void SaveToFile(string filePath)
        {
            File.WriteAllText(filePath, this.ConvertToJson());
        }

        public bool LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                this.LoadFromJson(File.ReadAllText(filePath));
                return true;
            }

            return false;
        }
    }
}