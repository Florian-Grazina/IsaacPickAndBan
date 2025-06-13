using System.Collections.ObjectModel;

namespace IsaacPickAndBan.Helpers
{
    public static class ObservableCollectionExtensions
    {
        public static void ReplaceWith<T>(this ObservableCollection<T> collection, IEnumerable<T> newItems)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var oldItems = collection.ToList();

            foreach (var item in oldItems)
            {
                if (!newItems.Contains(item))
                    collection.Remove(item);
            }

            foreach (var item in newItems)
            {
                if (!collection.Contains(item))
                    collection.Add(item);
            }
        }
    }
}
