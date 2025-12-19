namespace Project__part_B_
{
    public class Game : LibraryItem
    {
        public Genre GameGenre { get; set; }
        public Developer Creator { get; set; } = null!;

        public bool IsInstalled { get; set; }

        public override void Install() => throw new NotImplementedException();
        public override void Uninstall() => throw new NotImplementedException();
        public override void DisplayInfo() => throw new NotImplementedException();

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
