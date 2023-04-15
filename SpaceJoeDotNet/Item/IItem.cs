namespace SpaceJoeDotNet.Item;

abstract class Item
{
    protected string Name { get; set; }
    
    protected string ShortName { get; set; }
    protected string Description { get; set; }
    protected int Price { get; set; }

    protected Item(string name, string description, int price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}