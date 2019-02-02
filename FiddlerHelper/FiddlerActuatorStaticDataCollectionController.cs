using FreeHttp.AutoTest.RunTimeStaticData;
using FreeHttp.AutoTest.RunTimeStaticData.MyStaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeHttp.FiddlerHelper
{
    public class FiddlerActuatorStaticDataCollectionController
    {
        private ActuatorStaticDataCollection actuatorStaticDataCollection;

        public FiddlerActuatorStaticDataCollectionController(ActuatorStaticDataCollection yourStaticDataCollection)
        {
            actuatorStaticDataCollection = yourStaticDataCollection;
        }

        public void SetActuatorStaticDataCollection(ActuatorStaticDataCollection yourStaticDataCollection)
        {
            actuatorStaticDataCollection = yourStaticDataCollection;
        }

        public bool SetActuatorStaticData(string key, string value)
        {
            if (actuatorStaticDataCollection == null)
            {
                return false;
            }
            IRunTimeStaticData nowStaticData = actuatorStaticDataCollection[key];
            if (nowStaticData != null)
            {
                nowStaticData.DataMoveNext();
                return actuatorStaticDataCollection.SetStaticDataValue(key, value);
            }
            else
            {
                return actuatorStaticDataCollection.AddStaticDataKey(key, new MyStaticDataValue(value));
            }
        }
    }
}
