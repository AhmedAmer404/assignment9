public abstract class Shipment
{
    public string TrackingCode { get; set; }
    public string Description { get; set; }
    public decimal Weight { get; set; }
    public decimal DeliveryFee { get; set; }
    public DeliveryAddress Destination { get; set; }

    public abstract decimal EstimatedCost { get; }

    public abstract void PrintShipment();
}

public class StandardShipment : Shipment, ITrackable, IInsurable
{
    public override decimal EstimatedCost
    {
        get
        {
            return Weight * 10 + DeliveryFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("Standard Shipment");
        Console.WriteLine($"Tracking Code : {TrackingCode}");
        Console.WriteLine($"Description : {Description}");
        Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
    }

    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Ready.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.05m;
    }
}

public class ExpressShipment : Shipment, ITrackable, IInsurable
{
    public decimal ExtraFee { get; set; }

    public override decimal EstimatedCost
    {
        get
        {
            return Weight * 10 + DeliveryFee + ExtraFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("Express Shipment");
        Console.WriteLine($"Tracking Code : {TrackingCode}");
        Console.WriteLine($"Extra Fee : {ExtraFee} EGP");
        Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP");
    }

    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} is Out for Delivery.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.08m;
    }
}