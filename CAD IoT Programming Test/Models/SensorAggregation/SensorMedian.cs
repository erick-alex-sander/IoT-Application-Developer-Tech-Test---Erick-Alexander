using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAD_IoT_Programming_Test.Models.SensorAggregation
{
    public class SensorMedian
    {
        public String RoomArea { get; set; }
        public String DateStamp { get; set; }
        public Double medianT { get; set; }
        public Double medianH { get; set; }
        

        public SensorMedian(String RoomArea, String DateStamp, Double medianT, Double medianH)
        {
            this.RoomArea = RoomArea;
            this.DateStamp = DateStamp;
            this.medianT = medianT;
            this.medianH = medianH;
        }
    }
}
