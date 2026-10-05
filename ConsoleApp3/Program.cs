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

public class InternationalShipment : Shipment, ITrackable, IInsurable
{
    public string DestinationCountry { get; set; }

    public override decimal EstimatedCost
    {
        get
        {
            return Weight * 20 + DeliveryFee;
        }
    }

    public override void PrintShipment()
    {
        Console.WriteLine("International Shipment");
        Console.WriteLine($"Tracking Code : {TrackingCode}");
        Console.WriteLine($"Destination Country : {DestinationCountry}");
        Console.WriteLine($"Estimated Cost : {EstimatedCost} EGP");
    }

    public string GetTrackingStatus()
    {
        return $"Shipment {TrackingCode} has been Delivered.";
    }

    public decimal CalculateInsurance()
    {
        return EstimatedCost * 0.12m;
    }
}

public class DeliveryCenter
{
    private List<Shipment> shipments = new List<Shipment>();

    public void AddShipment(Shipment shipment)
    {
        shipments.Add(shipment);
    }

    public void PrintAllShipments()
    {
        foreach (Shipment shipment in shipments)
        {
            shipment.PrintShipment();
            Console.WriteLine("------------------------------------------");
        }
    }

    public void PrintTrackingStatuses()
    {
        foreach (Shipment shipment in shipments)
        {
            ITrackable trackable = (ITrackable)shipment;
            Console.WriteLine(trackable.GetTrackingStatus());
        }
    }

    public void PrintShipment(ITrackable shipment)
    {
        Console.WriteLine(shipment.GetTrackingStatus());
    }

    public void PrintInsurance(IInsurable shipment)
    {
        Console.WriteLine($"Insurance : {shipment.CalculateInsurance():0.00} EGP");
    }
}