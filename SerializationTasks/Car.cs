﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserInterface;

namespace SerializationTasks  
{
    [Serializable]
    public class Car 
    {
        public Int32 carld;
        public decimal price;
        public Int32 quantity;
        [NonSerialized]
        public decimal total;

        public Car() { }

        public void ShowFields(IPrinter printer)
        {
            printer.Write($"carid: {carld} , price: {price} , quantity: {quantity}");
        }
    }
}
