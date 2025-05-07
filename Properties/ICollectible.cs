namespace DungeonExplorer
{
    public interface ICollectible
    {
        string Name { get; set; }
        void Use(Player player);
    }
}
