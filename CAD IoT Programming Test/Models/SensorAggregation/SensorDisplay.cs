using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAD_IoT_Programming_Test.Models.SensorAggregation
{
    public class SensorDisplay
    {
        public String RoomArea { get; set; }
        public String DateStamp { get; set; }
        public Double MaxT { get; set; }
        public Double MinT { get; set; }
        public Double AvgT { get; set; }
        public Double MedianT { get; set; }
        public Double MaxH { get; set; }
        public Double MinH { get; set; }
        public Double AvgH { get; set; }
        public Double MedianH { get; set; }

        public SensorDisplay(String RoomArea, String DateStamp, Double MaxT, Double MinT, Double AvgT, Double MedianT, Double MaxH, Double MinH, Double AvgH, Double MedianH)
        {
            this.RoomArea = RoomArea;
            this.DateStamp = DateStamp;
            this.MaxT = MaxT;
            this.MinT = MinT;
            this.AvgT = AvgT;
            this.MedianT = MedianT;
            this.MaxH = MaxH;
            this.MinH = MinH;
            this.AvgH = AvgH;
            this.MedianH = MedianH;
        }


    }
}
