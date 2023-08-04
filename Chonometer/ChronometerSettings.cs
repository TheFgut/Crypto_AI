using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAnalizerAI.Chonometer
{
    public class ChronometerSettings
    {
        public float smoothInteval { get; set; }
        public float saveInteval { get; set; }
        public string dataSaveWay { get; set; }
        public int buyOrdersRecordDepth { get; set; }
        public int sellOrdersRecordDepth { get; set; }


        public ChronometerSettings()
        {
            smoothInteval = 15;
            saveInteval = 3600;
            dataSaveWay = "Datasets\\";
            buyOrdersRecordDepth = 6;
            sellOrdersRecordDepth = 6;

        }



    }
}
