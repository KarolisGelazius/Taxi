using System;
using System.Collections.Generic;
using System.Web;

namespace L2_LD_18
{
    /// <summary>
    /// Helper methods for processing cars, drivers, and taxis
    /// </summary>
    public class TaskUtils
    {
        /// <summary>
        /// Creates a list of taxis by matching cars with drivers based on car numbers and filtering cars by the specified age range
        /// </summary>
        /// <param name="carList">List of cars</param>
        /// <param name="driverList">List of drivers</param>
        /// <param name="minAge">Minimum allowed car age</param>
        /// <param name="maxAge">Maximum allowed car age</param>
        /// <returns>A linked list containing matched taxi objects</returns>
        public static LListTaxi CreateTaxiList(LListCar carList, LListDriver driverList, int minAge, int maxAge)
        {
            LListTaxi taxiList = new LListTaxi();

            for (carList.Begin(); carList.Exist(); carList.Next())
            {
                for (driverList.Begin(); driverList.Exist(); driverList.Next())
                {
                    int age = DateTime.Now.Year - carList.GetCar().ManufacturingYear;

                    if (carList.GetCar().CarNumbers == driverList.GetDriver().CarNumbers &&
                        age >= minAge && age <= maxAge)
                    {
                        Taxi taxi = new Taxi(
                            carList.GetCar().Manufacturer,
                            carList.GetCar().Model,
                            age,
                            driverList.GetDriver().FirstName,
                            driverList.GetDriver().LastName);

                        taxiList.Append(taxi);
                    }
                }
            }

            return taxiList;
        }

        /// <summary>
        /// Removes taxis from the list that have duplicate manufacturers
        /// </summary>
        /// <param name="taxiList">Linked list of taxis</param>
        public static void Remove(LListTaxi taxiList)
        {
            List<string> uniqueManufacturers = new List<string>();
            for (taxiList.Begin(); taxiList.Exist();) {
                Taxi taxi = taxiList.GetTaxi();

                if (uniqueManufacturers.Contains(taxi.Manufacturer)) {
                    taxiList.Remove();
                }
                else {
                    uniqueManufacturers.Add(taxi.Manufacturer);
                    taxiList.Next();
                }
            }
        }

        /// <summary>
        /// Finds all unique taxi manufacturers in the taxi list
        /// </summary>
        /// <param name="taxiList">Linked list of taxis</param>
        /// <returns>A list of unique manufacturer names</returns>
        public static List<string> FindUniqueManufacturers(LListTaxi taxiList) {
            List<string> uniqueManufacturers = new List<string>();

            for (taxiList.Begin(); taxiList.Exist(); taxiList.Next()) {
                Taxi taxi = taxiList.GetTaxi();

                if (!uniqueManufacturers.Contains(taxi.Manufacturer)) {
                    uniqueManufacturers.Add(taxi.Manufacturer);
                }
            }

            return uniqueManufacturers;
        }

        /// <summary>
        /// Finds the car with the highest mileage
        /// </summary>
        /// <param name="carList">Linked list of cars</param>
        /// <returns>The car with the greatest mileage</returns>
        public static Car FindMostExploitedCar(LListCar carList)
        {
            Car maxCar = null;

            for (carList.Begin(); carList.Exist(); carList.Next())
            {
                Car car = carList.GetCar();

                if (maxCar == null || car.Mileage > maxCar.Mileage)
                {
                    maxCar = car;
                }
            }

            return maxCar;
        }

        /// <summary>
        /// Finds the driver who drives the car with the specified car number
        /// </summary>
        /// <param name="driverList">Linked list of drivers</param>
        /// <param name="carNumbers">Car registration number</param>
        /// <returns>The driver associated with the specified car number</returns>
        public static Driver FindDriver(LListDriver driverList, string carNumbers)
        {
            for (driverList.Begin(); driverList.Exist(); driverList.Next())
            {
                Driver driver = driverList.GetDriver();

                if (driver.CarNumbers == carNumbers)
                {
                    return driver;
                }
            }

            return null;
        }
    }
}