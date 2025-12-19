namespace Project__part_B_
{
    public class Game : LibraryItem
    {
        public Genre GameGenre { get; set; }
        public Developer Creator { get; set; } = null!;

        public bool IsInstalled { get; set; }

        public override void Install()
        {
            IsInstalled = true;
            Console.WriteLine($"Гру {Title} встановлено");
        }
        public override void Uninstall()
        {
            IsInstalled = false;
            Console.WriteLine($"Гру {Title} видалено");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Game] {Title} | Genre: {GameGenre} | Price: {Price} | Installed: {IsInstalled}");
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
                IsInstalled = this.IsInstalled
            };
        }
    }
}
