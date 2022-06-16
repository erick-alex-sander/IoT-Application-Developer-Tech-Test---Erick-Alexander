using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAD_IoT_Programming_Test.Models.SensorAggregation
{
    public class SensorData
    {
        public long Id { get; set; }
        public long Timestamp { get; set; }
        public Double Temperature { get; set; }
        public Double Humidity { get; set; }
        public String RoomArea { get; set; }

        public SensorData(long Id, long Timestamp,  Double Temperature,  Double Humidity,  String RoomArea)
        {
            this.Id = Id;
            this.Timestamp = Timestamp;
            this.Temperature = Temperature;
            this.Humidity = Humidity;
            this.RoomArea = RoomArea;
        }

    }
}
