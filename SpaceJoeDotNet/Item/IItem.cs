namespace SpaceJoeDotNet.Item;

abstract class Item
{
    public string Name { get; set; }
    
    protected string ShortName { get; set; }
    protected string Description { get; set; }
    protected int Price { get; set; }

    protected Item(string name, string shortName, string description, int price)
    {
        Name = name;
        ShortName = shortName;
        Description = description;
        Price = price;
    }
}