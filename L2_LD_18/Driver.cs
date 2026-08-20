using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;

namespace L2_LD_18
{
    /// <summary>
    /// Driver class
    /// </summary>
    public class Driver
    {
        public string FirstName { get; set; }   ///Drivers first name
        public string LastName { get; set; }    ///Drivers last name
        public string CarNumbers { get; set; }  ///Drivers car registration number
        
        /// <summary>
        /// Driver class contructor
        /// </summary>
        /// <param name="firstName">Drivers first name</param>
        /// <param name="lastName">Drivers last name</param>
        /// <param name="carNumbers">Drivers car registration number</param>
        public Driver(string firstName, string lastName, string carNumbers)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CarNumbers = carNumbers;
        }

        /// <summary>
        /// Driver class contructor
        /// </summary>
        public Driver()
        {
        }

        /// <summary>
        /// Driver ToString override
        /// </summary>
        /// <returns>a formatted string</returns>
        public override string ToString()
        {
            return String.Format("| {0, -15} | {1, -15} | {2, -15} |", FirstName, LastName, CarNumbers);
        }
    }
}