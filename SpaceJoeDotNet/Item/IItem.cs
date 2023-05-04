namespace SpaceJoeDotNet.Item;

abstract class Item
{
    public string Name { get; set; }
    public string ShortName { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    protected Item(string name, string shortName, string description, int price)
    {
        Name = name;
        ShortName = shortName;
        Description = description;
        Price = price;
    }
}