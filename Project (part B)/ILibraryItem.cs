using System;

namespace Project__part_B_
{
    public interface ILibraryItem : IComparable<ILibraryItem>, ICloneable
    {
        double Price { get; set; }
        double SizeGb { get; set; }
        string Title { get; set; }
        void Install();
    }
}