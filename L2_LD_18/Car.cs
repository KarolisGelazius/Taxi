using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace L2_LD_18
{
    /// <summary>
    /// Car class
    /// </summary>
    public class Car
    {
        public string Manufacturer { get; set; }    ///Car manufacturer
        public string Model { get; set; }           ///Car model
        public string CarNumbers { get; set; }      ///Car registration number
        public int ManufacturingYear { get; set; }  ///Car manufacturing year
        public int Mileage { get; set; }            ///Car mileage

        /// <summary>
        /// Car constructor
        /// </summary>
        /// <param name="manufacturer">Car manufacturer</param>
        /// <param name="model">Car model</param>
        /// <param name="carNumbers">Car registration number</param>
        /// <param name="manufacturingYear">Car manufacturing year</param>
        /// <param name="mileage">Car mileage</param>
        public Car(string manufacturer, string model, string carNumbers, int manufacturingYear, int mileage)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.CarNumbers = carNumbers;
            this.ManufacturingYear = manufacturingYear;
            this.Mileage = mileage;
        }

        /// <summary>
        /// Car constructor
        /// </summary>
        public Car()
        {
        }

        /// <summary>
        /// Car ToString override
        /// </summary>
        /// <returns>a formatted string</returns>
        public override string ToString()
        {
            return String.Format("| {0, -15} | {1, -15} | {2, -15} | {3, 4} | {4, 15} |", Manufacturer, Model, CarNumbers, ManufacturingYear, Mileage);
        }
    }
}