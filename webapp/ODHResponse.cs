using System;
using System.Collections;
using System.Collections.Generic;
namespace hello.net
{
    public class ODHResponse
    {
        public int limit { get; set; }

        public int offset { get; set; }

        public List<EMobilityChargingData> data { get; set; }
    }
}
