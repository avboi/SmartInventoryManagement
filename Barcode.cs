namespace SmartInventoryManagement;

public class Barcode {
    private String barcodeID;
    private Item item;

    public Barcode(String barcodeID){
        this.barcodeID = barcodeID;
    }

    public String getBarcodeID(){
        return barcodeID;
    }

    public void setBarcodeID(String barcodeID){
        this.barcodeID = barcodeID;
    }
}