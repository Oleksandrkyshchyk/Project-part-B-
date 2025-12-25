namespace Project__part_B_
{
    public class Game : LibraryItem
    {
        public Genre GameGenre { get; set; }
        public Developer Creator { get; set; } = null!;

        public override void Install()
        {
            Console.WriteLine($"Гру {Title} встановлено");
            IsInstalled = true;
        }

        public override void Uninstall()
        {
            Console.WriteLine($"Гру {Title} видалено");
            IsInstalled = false;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Game] {Title} | Genre: {GameGenre} | Price: {Price} | Installed: {IsInstalled}");
        }

        public override object Clone()
        {
            return new Game
            {
                Title = this.Title,
                Price = this.Price,
                SizeGb = this.SizeGb,
                GameGenre = this.GameGenre,
                Creator = this.Creator,
                IsInstalled = false
            };
        }
    }
}

