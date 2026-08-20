using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using System.Web;

namespace L2_LD_18
{
    /// <summary>
    /// Taxi class
    /// </summary>
    public class Taxi
    {
        public string Manufacturer { get; set; }        ///Car manufacturer
        public string Model { get; set; }               ///Car model
        public int Age { get; set; }                    ///Car age
        public string DriverFirstName { get; set; }     ///Driver first name
        public string DriverLastName { get; set; }      ///Driver last name

        /// <summary>
        /// Taxi constructor
        /// </summary>
        public Taxi()
        {
        }

        /// <summary>
        /// Taxi constructor
        /// </summary>
        /// <param name="manufacturer">Car manufacturer</param>
        /// <param name="model">Car model</param>
        /// <param name="age">Car age</param>
        /// <param name="driverFirstName">Driver first name</param>
        /// <param name="driverLastName">Driver last name</param>
        public Taxi(string manufacturer, string model, int age, string driverFirstName, string driverLastName)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Age = age;
            this.DriverFirstName = driverFirstName;
            this.DriverLastName = driverLastName;
        }

        /// <summary>
        /// Taxi ToString override
        /// </summary>
        /// <returns>a formatted string</returns>
        public override string ToString()
        {
            return String.Format("| {0, -10} | {1, -10} | {2, 5} | {3, -10} | {4, -10} |", Manufacturer, Model, Age, DriverFirstName, DriverLastName);
        }

        /// <summary>
        /// Compares this taxi with another taxi object by manufacturer and model
        /// </summary>
        /// <param name="other">other Taxi</param>
        /// <returns>A value indicating the relative order of the taxis</returns>
        public int CompareTo(Taxi other)
        {
            int manufacturerCompare = Manufacturer.CompareTo(other.Manufacturer);
            if (manufacturerCompare != 0)
            {
                return manufacturerCompare;
            }

            return Model.CompareTo(other.Model);
        }
    }
}