using System.Text;

namespace SmartInventoryManagement;

public class Report {
    
    WeighingScale _scale = new WeighingScale();
    private Item Item;
    private double TargetWeight;
    private double ActualWeight;
    private Status status;
    private DateOnly Date;
    
    
    //Generate report for the given item
    public Report(Item item,double TargetWeight,double ActualWeight, Status status,DateOnly Date){
        this.Item = item;
        this.TargetWeight = TargetWeight;
        this.ActualWeight = ActualWeight;
        this.status = status;
        this.Date = Date;
        
        
        StringBuilder builder = new StringBuilder();
        builder.Append("Item Name : " + item.getName()).Append("\n");
        builder.Append("Target Weight: " + TargetWeight).Append("\n");
        builder.Append("Actual Weight: " + ActualWeight).Append("\n");
        if (status == Status.UNKNOWN) {
            builder.Append("Status: Unknown");
        } else if (status == Status.UNDERWEIGHT) {
            builder.Append("Status: Underweight");
        } else if (status == Status.OK) {
            builder.Append("Status: OK");
        } else if (status == Status.OVERWEIGHT) {
            builder.Append("Status: Overweight");
        }
        else {
            builder.Append("Status: Error");
        }
        builder.Append("\n");
        builder.Append("Date: " + Date).Append("\n\n");

        Console.WriteLine(builder.ToString());
        
        File.AppendAllText("report.txt", builder.ToString());
    }
    
    public DateOnly getDate() {
        return Date;
    }
}