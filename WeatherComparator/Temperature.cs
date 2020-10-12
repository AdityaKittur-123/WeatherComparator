using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherComparator
{
  public  class Temperature
    {
        private string city;
        private float temp;

       
        public void setCity (string city)
        {
            this.city = city;
        }

        public void setTemp(float temp)
        {
            this.temp = temp;
              }

        public string getCity()
        {
            return city;
        }

        public float getTemp()
        {
            return temp;
        }

    }
}
