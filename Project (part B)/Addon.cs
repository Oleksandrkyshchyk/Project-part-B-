using Project__part_B_;

public class Addon : LibraryItem
{
    public Game ParentGame { get; set; } = null!;

    public override void Install()
    {
        Console.WriteLine(
            $"Installing Addon: {Title} for {ParentGame.Title}..."
        );
        IsInstalled = true;
    }

    public override void Uninstall()
    {
        Console.WriteLine($"Removing Addon {Title}...");
        IsInstalled = false;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(
            $"[Addon] {Title} | Price: {Price} | For: {ParentGame.Title}"
        );
    }

    public override object Clone()
    {
        return new Addon
        {
            Title = this.Title,
            Price = this.Price,
            SizeGb = this.SizeGb,
            ParentGame = this.ParentGame
        };
    }
}
