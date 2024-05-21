using System.Collections.Concurrent;

namespace CSharpTest
{
    internal class ConcurrentDictionary_
    {
        public ConcurrentDictionary_()
        {
            var dictionary = new ConcurrentDictionary<int, string>();
            string newValue = dictionary.AddOrUpdate(0,
                                                     key => "Zero",            // Add
                                                     (key, value) => "Zero");  // Update
            dictionary[1] = "One"; // Add or Update

            bool keyExists = dictionary.TryGetValue(0, out string currentValue);
            bool keyExisted = dictionary.TryRemove(0, out string removeValue);
        }
    }
}
