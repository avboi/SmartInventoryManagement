namespace SmartInventoryManagement;

public class BarcodeScanner {

    public Barcode ScanBarcode(String barcodeID){
        return new Barcode(barcodeID);
    }
}