using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COP4710.Models
{
    public class BloodPressure
    {
        private int diastolic;
        private int systolic;

        public int Diastolic
        {
            get { return diastolic; }
            set { diastolic = value; }
        }

        public int Systolic
        {
            get { return systolic; }
            set { systolic = value; }
        }

        public BloodPressure(string bpString)
        {
            string[] s = bpString.Split('/');
            if (s.Length > 1)
            {
                Int32.TryParse(s[0], out this.systolic);
                Int32.TryParse(s[1], out this.diastolic);
            }
        }

        public BloodPressure(int systolic, int diastolic)
        {
            this.systolic = systolic;
            this.diastolic = diastolic;
        }

        public BloodPressure()
        {

        }
    }
}