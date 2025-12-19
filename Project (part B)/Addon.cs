using Project__part_B_;
using System.Diagnostics;
public class Addon : LibraryItem
{
    public string ParentGameTitle { get; set; } = null!;

    public override void Install()
    {
        Console.WriteLine($"Installing Addon: {Title} for {ParentGameTitle}...");
    }

    public override void Uninstall() => Console.WriteLine($"Removing Addon {Title}...");

    public override void DisplayInfo()
    {
        Console.WriteLine($"[Addon] {Title} | Price: {Price} | For: {ParentGameTitle}");
    }

    public override object Clone()
    {
        return new Addon
        {
            Title = this.Title,
            Price = this.Price,
            SizeGb = this.SizeGb,
            ParentGameTitle = this.ParentGameTitle
        };
    }
}