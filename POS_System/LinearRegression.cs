using System;
using System.Collections.Generic;

namespace POS_System
{
    public class LinearRegression
    {
        protected List<double> x;
        protected List<double> y;


        public LinearRegression(List<double> x, List<double> y)
        {
            this.x = x;
            this.y = y;
            if (x.Count != y.Count) throw new Exception(String.Format("Values are misaligned. " +
                                                                      "The X variables have {}"));
        }
    }
}