namespace WcfService
{
    public class WeatherForecast
    {
        public System.DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class ImageModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
}