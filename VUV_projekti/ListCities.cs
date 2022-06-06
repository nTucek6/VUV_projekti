using System;
using System.Collections.Generic;
using System.Text;

namespace VUV_projekti
{
    class ListCities
    {
        private int _id;
        private string _city;
        private string _lat;
        private string _lng;
        private string _admin_name;
        public ListCities(int i,string c,string lt,string lg, string an)
        {
            _id = i;
            _city = c;
            _lat = lt;
            _lng = lg;
            _admin_name = an;
        }
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }
        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        public string lng
        {
            get { return _lng; }
            set { _lng = value; }
        }
        public string admin_name
        {
            get { return _admin_name; }
            set { _admin_name = value; }
        }

    }
}
