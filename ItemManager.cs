namespace SmartInventoryManagement;

public class ItemManager
{
    private List<Item?> items;
    private static EFC efc = new EFC();
    public ItemManager()
    {
        items = new List<Item?>();
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public void AddItem(String code, String itemName, String itemName2, String supplier, String itemBarcodeID)
    {

        Item item = new Item(code, itemName, itemName2, supplier, itemBarcodeID);
        items.Add(item);
        efc.Items.Add(new Item
        {
            code = code,
            itemName = itemName,
            itemName2 = itemName2,
            supplier = supplier,
            barcodeID = itemBarcodeID
        });
        efc.SaveChanges();
    }

    public void RemoveItemWithName(String itemName)
    {
        bool found = false;
        foreach (Item item in items)
        {
            if (item.getName().Equals(itemName))
            {
                found = true;
                items.Remove(item);
                Console.WriteLine($"{itemName} removed");
                break;
            }
        }

        if (!found)
        {
            throw new ArgumentException($"{itemName} doesn't exist");
        }

    }

    public void RemoveItemWithBarcode(String itemBarcode)
    {
        bool found = false;
        foreach (Item item in items)
        {
            if (item.getBarcodeID().Equals(itemBarcode))
            {
                found = true;
                items.Remove(item);
                break;
            }
        }

        if (!found)
        {
            throw new ArgumentException($"Item with {itemBarcode} doesn't exist");
        }
        Console.WriteLine($"{itemBarcode} removed");

    }

    public Item SearchItemByName(String itemName)
    {
        bool found = false;
        foreach (Item item in items)
        {
            if (item.getName().ToLower().Equals(itemName.ToLower()))
            {
                found = true;
                return item;
            }
        }
        return null;
    }

    public Item SearchItemByBarcodeID(String barcodeID)
    {
        bool found = false;
        foreach (Item item in items)
        {
            if (item.getBarcodeID().Equals(barcodeID))
            {
                found = true;
                return item;
            }

        }
        return null;
    }
}