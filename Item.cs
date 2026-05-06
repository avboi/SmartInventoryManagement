using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartInventoryManagement;

public class Item
{
    [Key][Column("ItemCode")] public String code { get; set; }
    [Column("ItemName")] public String itemName { get; set; }
    [Column("ItemName2")] public String? itemName2 { get; set; }

    [Column("ItemSupplier")] public String supplier { get; set; }
    [Column("BarcodeID")] public String barcodeID { get; set; }

    public Item(String code, String itemName, String itemName2, String supplier, String barcodeId)
    {
        this.code = code;
        this.itemName = itemName;
        this.itemName2 = itemName2;
        this.supplier = supplier;
        this.barcodeID = barcodeId;

    }

    public Item()
    {

    }

    public void setItemName(String itemName)
    {
        this.itemName = itemName;
    }

    public void setItemName2(String itemName2)
    {
        this.itemName2 = itemName2;
    }

    public void setSupplier(String supplierName)
    {
        this.supplier = supplierName;
    }
    public void setBarcode(String barcodeId)
    {
        this.barcodeID = barcodeId;
    }


    public String getName()
    {
        return itemName;
    }

    public String getName2()
    {
        return itemName2;
    }

    public String getSupplier()
    {
        return supplier;
    }

    public String getBarcodeID()
    {
        return barcodeID;
    }

}