﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Database
{
    class Koltuklar
    {
        int _KoltukID;
        public int KoltukID
        {
            get { return _KoltukID; }
            set { _KoltukID = value; }
        }


        int _UcusID;
        public int UcusID
        {
            get { return _UcusID; }
            set { _UcusID = value; }
        }


        int _MusteriID;
        public int MusteriID
        {
            get { return _MusteriID; }
            set { _MusteriID = value; }
        }
        int _KoltukNo;
        public int KoltukNo
        {
            get { return _KoltukNo; }
            set { _KoltukNo = value; }
        }

    }
}
