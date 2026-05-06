namespace SmartInventoryManagement;

public class WeighingScale {

    private Item _item;
    private double TargetWeight;
    private double ActualWeight;
    private double MinWeight;
    private double MaxWeight;
    private Status status = Status.UNKNOWN;

    public void SetItem(Item item){
        _item = item;
    }


    public void setTargetWeight(double TargetWeight){
        this.TargetWeight = TargetWeight;
    }


    public Status checkWeight(double actualWeight){
        ActualWeight = actualWeight;
        if (actualWeight<MinWeight|| actualWeight>MaxWeight) {
            Console.WriteLine("The item weight is not within the weight range");
            
        }
        //Actual Weight is scanned by scanners, For simulation user input is used
        if (actualWeight < TargetWeight) {
            Console.WriteLine("Item is underweight");
            status = Status.UNDERWEIGHT;
        } else if (actualWeight > TargetWeight) {
            Console.WriteLine("Item is overweight");
            status = Status.OVERWEIGHT;
        } else if (actualWeight == TargetWeight) {
            Console.WriteLine("Item is equal to weight");
            status = Status.OK;
        }
        return status;
        
    }

    public void setScale(double MinWeight, double MaxWeight){
        this.MinWeight = MinWeight;
        this.MaxWeight = MaxWeight;
    }
    
    
}