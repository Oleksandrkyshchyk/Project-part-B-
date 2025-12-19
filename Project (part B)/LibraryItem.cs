using System;

namespace Project__part_B_
{
    public abstract class LibraryItem : ILibraryItem, IComparable<LibraryItem>, ICloneable
    {
        public string Title { get; set; } = null!;
        public double SizeGb { get; set; }
        public double Price { get; set; }

        public int CompareTo(ILibraryItem? other)
        {
            if (other == null) return 1;
            return this.Price.CompareTo(other.Price);
        }

        public int CompareTo(LibraryItem? other)
        {
            return CompareTo((ILibraryItem?)other);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (obj is ILibraryItem other) return CompareTo(other);
            throw new ArgumentException("Object is not a LibraryItem");
        }

        public abstract object Clone();
        public abstract void Install();
        public abstract void Uninstall();
        public abstract void DisplayInfo();
    }
}