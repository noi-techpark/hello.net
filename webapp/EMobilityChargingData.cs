using System;
using System.Collections.Generic;
namespace hello.net
{
    public class EMobilityChargingData
    {
        public String pcode {get;set;}
        public Dictionary<String,object> pmetadata {get;set;}

        public Dictionary<String,object> pcoordinate {get;set;}
    }
}
