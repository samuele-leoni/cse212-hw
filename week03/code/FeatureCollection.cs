public class FeatureCollection
{
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string Type { get; set; }
    public Metadata Metadata { get; set; }
    public double?[] Bbox { get; set; }
    public Feature[] Features { get; set; }
}