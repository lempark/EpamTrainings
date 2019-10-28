using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using UserInterface;
using Logger;

namespace SerializationTasks
{
    public class SerializationTasksRunner : IRunner
    {
        public IPrinter Printer { get; set; }
        public ILogger Logger { get; set; }

        public SerializationTasksRunner(IPrinter printer , ILogger logger)
        {
            Printer = printer;
            Logger = logger;
        }

        public void DoTask1()
        {
            Car car1 = new Car();
            Car car2 = new Car();

            car1.carld = 2233;
            car1.price = 1488;
            car1.quantity = 13;

            car2.carld = 3456;
            car2.price = 1337;
            car2.quantity = 28;

            List<Car> Cars = new List<Car>();

            Cars.Add(car1);
            Cars.Add(car2);

            ListOfCarFormatter formatter = new ListOfCarFormatter();

            formatter.Cars = Cars;
            formatter.BinaryPath = ConfigurationManager.AppSettings["SerializationBinaryPath"];
            formatter.XmlPath = ConfigurationManager.AppSettings["SerializationXmlPath"];
            formatter.JsonPath = ConfigurationManager.AppSettings["SerializationJsonPath"];


            try
            {
                formatter.BinarySerialize();
                formatter.XmlSerialize();
                formatter.JsonSerialize();

                Cars = formatter.BinaryDeserialize();
                foreach (Car someCar in Cars)
                {
                    someCar.ShowFields(Printer);
                }

                Cars = formatter.XmlDeserialize();
                foreach (Car someCar in Cars)
                {
                    someCar.ShowFields(Printer);
                }

                Cars = formatter.JsonDeserialize();
                foreach (Car someCar in Cars)
                {
                    someCar.ShowFields(Printer);
                }
            }
            catch(FileNotFoundException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch(IOException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch(UnauthorizedAccessException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch (ArgumentNullException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch (ArgumentException e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }
            catch(Exception e)
            {
                Printer.Write(e.Message);
                Logger.LogException(e);
            }

            
        }

        public void Run()
        {
            DoTask1();
        }
    }
}
