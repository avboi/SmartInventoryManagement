namespace SmartInventoryManagement;

public class ReportManager {
    
    private List<Report> reports = new List<Report>();

    public void SearchReportByDate(DateTime date){
        List<Report> matchingReports = new List<Report>();
        foreach (Report report in reports) {
            if (report.getDate().Equals(date)) {
                matchingReports.Add(report);
            }
        }
        
    }

    public void SearchReportByItem(String Name){
        
    }

    public void GenerateReport(Item item,double TargetWeight,double ActualWeight,Status status){
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        Report report = new Report(item, TargetWeight, ActualWeight, status, date);
        reports.Add(report);
        
    }
}