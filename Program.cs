// See https://aka.ms/new-console-template for more information

using SmartInventoryManagement;

public class Program
{

    private static ItemManager itemManager = new ItemManager();
    private static WeighingScale scaleManager = new WeighingScale();
    private static ReportManager reportManager = new ReportManager();


    private static EFC efc;




    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Item Management\n2. Weight Management");

            String option = Console.ReadLine();
            if (option == "1")
            {
                Console.WriteLine("1. Add Item\n2. Update item\n3. Remove Item\n4. Search Item");
                String itemOptions = Console.ReadLine();
                if (itemOptions == "1")
                {
                    Console.WriteLine("--Add Item--");
                    Console.WriteLine("Enter Item Code : ");
                    String itemCode = Console.ReadLine();
                    Console.WriteLine("Enter Item Name: ");
                    String itemName = Console.ReadLine();
                    Console.WriteLine("Enter Item Name2 : ");
                    String itemName2 = Console.ReadLine();
                    Console.WriteLine("Enter Item Supplier: ");
                    String itemSupplier = Console.ReadLine();
                    Console.WriteLine("Enter Item Barcode ID: ");
                    String itemBarcodeID = Console.ReadLine();

                    itemManager.AddItem(itemCode, itemName, itemName2, itemSupplier, itemBarcodeID);
                }
                else if (itemOptions == "2")
                {
                    Console.WriteLine("--Update Item--");
                    Console.WriteLine("Enter Item Name : ");
                    String itemName = Console.ReadLine();
                    Item targetItem = itemManager.SearchItemByName(itemName);
                    if (targetItem == null)
                    {
                        Console.WriteLine("Item not found");
                    }
                    Console.WriteLine("Enter new item name: ");
                    String updateItemName = Console.ReadLine();
                    Console.WriteLine("Enter new item Name2 : ");
                    String updateItemName2 = Console.ReadLine();
                    Console.WriteLine("Enter new item Supplier: ");
                    String updateItemSupplier = Console.ReadLine();
                    Console.WriteLine("Enter new item Barcode ID: ");
                    String updateItemBarcodeID = Console.ReadLine();

                    if (updateItemName == "")
                    {
                        Console.WriteLine("No updates requested for name");
                    }
                    else
                    {
                        targetItem.setItemName(updateItemName);
                        Console.WriteLine("Item name updated");
                    }
                    if (updateItemName2 == "")
                    {
                        Console.WriteLine("No updates requested for name2");
                    }
                    else
                    {
                        targetItem.setItemName2(updateItemName2);
                        Console.WriteLine("Item name2 updated");
                    }
                    if (updateItemSupplier == "")
                    {
                        Console.WriteLine("No updates requested for name Supplier");
                    }
                    else
                    {
                        targetItem.setSupplier(updateItemSupplier);
                        Console.WriteLine("Supplier name updated");
                    }
                    if (updateItemBarcodeID == "")
                    {
                        Console.WriteLine("No updates requested for Barcode ID");
                    }
                    else
                    {
                        targetItem.setBarcode(updateItemBarcodeID);
                        Console.WriteLine("Barcode updated");
                    }


                }
                else if (itemOptions == "3")
                {
                    Console.WriteLine("--Remove Item--");
                    Console.WriteLine("1. Remove by name\n2. Remove by barcode");
                    String removeOption = Console.ReadLine();
                    if (removeOption == "1")
                    {
                        Console.WriteLine("--Remove Item by Name--");
                        Console.WriteLine("Enter Item Name : ");
                        String itemName = Console.ReadLine();
                        itemManager.RemoveItemWithName(itemName);
                    }
                    else if (removeOption == "2")
                    {
                        Console.WriteLine("--Remove Item by Barcode--");
                        String itemBarcodeID = Console.ReadLine();
                        itemManager.RemoveItemWithBarcode(itemBarcodeID);
                    }

                }
                else if (itemOptions == "4")
                {
                    Console.WriteLine("--Search Item--");
                    Console.WriteLine("Filter by\n1. Name\n2. Barcode Id");
                    String searchOption = Console.ReadLine();
                    if (searchOption == "1")
                    {
                        Console.WriteLine("--Search Item by Name--");
                        Console.WriteLine("Enter Item Name : ");
                        String itemName = Console.ReadLine();
                        Item item = itemManager.SearchItemByName(itemName);
                        if (item == null)
                        {
                            Console.WriteLine("Item not found");
                            continue;
                        }
                        Console.WriteLine("Item found");
                        Console.WriteLine("Item Name: " + item.getName());
                        Console.WriteLine("Item Name2: " + item.getName2());
                        Console.WriteLine("Item Supplier: " + item.getSupplier());
                        Console.WriteLine("Item Barcode ID: " + item.getBarcodeID());
                    }
                    else if (searchOption == "2")
                    {
                        Console.WriteLine("--Search Item by Barcode--");
                        Console.WriteLine("Enter Item Barcode ID : ");
                        String itemBarcodeID = Console.ReadLine();
                        Item item = itemManager.SearchItemByBarcodeID(itemBarcodeID);
                        if (item == null)
                        {
                            Console.WriteLine("Item not found");
                            continue;
                        }
                        Console.WriteLine("Item found");
                        Console.WriteLine("Item Name: " + item.getName());
                        Console.WriteLine("Item Name2: " + item.getName2());
                        Console.WriteLine("Item Supplier: " + item.getSupplier());
                        Console.WriteLine("Item Barcode ID: " + item.getBarcodeID());

                    }
                }
            }
            else if (option == "2")
            {
                Console.WriteLine("Enter Minimum Weight: ");
                double minimumWeight = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter Maximum Weight: ");
                double maximumWeight = double.Parse(Console.ReadLine());
                scaleManager.setScale(minimumWeight, maximumWeight);
                Console.WriteLine("Enter Item Name : ");
                String itemName = Console.ReadLine();
                Item item = itemManager.SearchItemByName(itemName);
                if (item == null)
                {
                    Console.WriteLine("Item not found");
                    return;
                }

                Console.WriteLine("Item found");
                scaleManager.SetItem(item);
                Console.WriteLine("Enter Target Weight");
                double targetWeight = double.Parse(Console.ReadLine());
                scaleManager.setTargetWeight(targetWeight);
                //For simulation purpose
                Console.WriteLine("Enter Actual Weight : ");
                double actualWeight = double.Parse(Console.ReadLine());
                Status status = scaleManager.checkWeight(actualWeight);

                reportManager.GenerateReport(item, targetWeight, actualWeight, status);
                Console.WriteLine("Report generated");

            }
        }

    }


}
