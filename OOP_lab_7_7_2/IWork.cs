using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_lab_7_7_2
{
    interface IWork
    {
        public void Add();

        public void Remove();

        public void Edit();

        public void SortByDate();

        public void SortByTemperatureAndWindSpeed();

        public void InitialiseBase(int n);
    }
}
