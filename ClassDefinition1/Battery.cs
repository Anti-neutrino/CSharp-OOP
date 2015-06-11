using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.GSMProperties
{
    class Battery
    {

        public enum BatteryType
        {
            LiIon, NiMH, NiCd
        }

        private BatteryType batteryModel;
        private int batteryHoursIdle;
        private int batteryHoursTalk;


        public Battery(BatteryType batteryModel, int batteryHoursIdle, int batteryHoursTalk)
        {
            this.batteryModel = batteryModel;
            this.batteryHoursIdle = batteryHoursIdle;
            this.batteryHoursTalk = batteryHoursTalk;
        }

        public BatteryType BatteryModel
        {
            get { return batteryModel; }
        }

        public int BatteryHoursIdle
        {
            get { return batteryHoursIdle; }
            set { batteryHoursIdle = value; }
        }

        public int BatteryHoursTalk
        {
            get { return batteryHoursTalk; }
            set { batteryHoursTalk = value; }
        }
    }
}
