using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI.WebControls;

namespace L2_LD_18
{
    /// <summary>
    /// methods for reading data from files and writing results
    /// </summary>
    public class InOutUtils {
        /// <summary>
        /// Reads car data from a file and creates a linked list of cars
        /// </summary>
        /// <param name="fileName">Path to the file containing car data</param>
        /// <returns>A linked list of Car objects</returns>
        public static LListCar ReadCars(string fileName) {
            LListCar carList = new LListCar();
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 0; i < lines.Length; i++) {
                string[] Values = lines[i].Split(';');
                string manufacturer = Values[0];
                string model = Values[1];
                string carNumbers = Values[2];
                int manufacturingYear = int.Parse(Values[3]);
                int mileage = int.Parse(Values[4]);

                Car car = new Car(manufacturer, model, carNumbers, manufacturingYear, mileage);
                carList.Append(car);
            }

            return carList;
        }

        /// <summary>
        /// Reads driver data from a file and creates a linked list of drivers
        /// </summary>
        /// <param name="fileName">Path to the file containing driver data</param>
        /// <returns>A linked list of Driver objects</returns>
        public static LListDriver ReadDrivers(string fileName) {
            LListDriver carList = new LListDriver();
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 0; i < lines.Length; i++) {
                string[] Values = lines[i].Split(';');
                string firstName = Values[0];
                string lastName = Values[1];
                string carNumbers = Values[2];

                Driver driver = new Driver(firstName, lastName, carNumbers);
                carList.Append(driver);
            }

            return carList;
        }

        /// <summary>
        /// Creates a table displaying taxi data
        /// </summary>
        /// <param name="taxiList">Linked list of taxis</param>
        /// <param name="table">Table control used to display the data</param>
        public static void CreateCarTable(LListTaxi taxiList, Table table) {
            table.Rows.Clear();
            table.CssClass = "taxiTable";

            TableRow header = new TableRow();
            header.Cells.Add(new TableHeaderCell { Text = "Manufacturer", HorizontalAlign = HorizontalAlign.Left });
            header.Cells.Add(new TableHeaderCell { Text = "Model", HorizontalAlign = HorizontalAlign.Left });
            header.Cells.Add(new TableHeaderCell { Text = "Age", HorizontalAlign = HorizontalAlign.Right });
            header.Cells.Add(new TableHeaderCell { Text = "Driver First Name", HorizontalAlign = HorizontalAlign.Left });
            header.Cells.Add(new TableHeaderCell { Text = "Driver Last Name", HorizontalAlign = HorizontalAlign.Left });
            table.Rows.Add(header);

            for (taxiList.Begin(); taxiList.Exist(); taxiList.Next()) {
                Taxi taxi = taxiList.GetTaxi();
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell { Text = taxi.Manufacturer, HorizontalAlign = HorizontalAlign.Left });
                row.Cells.Add(new TableCell { Text = taxi.Model, HorizontalAlign = HorizontalAlign.Left });
                row.Cells.Add(new TableCell { Text = taxi.Age.ToString(), HorizontalAlign = HorizontalAlign.Right });
                row.Cells.Add(new TableCell { Text = taxi.DriverFirstName, HorizontalAlign = HorizontalAlign.Left });
                row.Cells.Add(new TableCell { Text = taxi.DriverLastName, HorizontalAlign = HorizontalAlign.Left });

                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Writes unique taxi manufacturers to a table
        /// </summary>
        /// <param name="taxiList">Linked list of taxis</param>
        /// <param name="table">Table control used to display the manufacturers</param>
        public static void WriteUniqueManufacturers(LListTaxi taxiList, Table table) {
            table.Rows.Clear();
            table.CssClass = "taxiTable";

            TableRow header = new TableRow();
            header.Cells.Add(new TableHeaderCell { Text = "Unique car manufacturers", HorizontalAlign = HorizontalAlign.Left });
            table.Rows.Add(header);

            List<string> uniqueManufacturers = TaskUtils.FindUniqueManufacturers(taxiList);

            foreach (string manufacturer in uniqueManufacturers) {
                TableRow row = new TableRow();
                row.Cells.Add(new TableCell { Text = manufacturer, HorizontalAlign = HorizontalAlign.Left });
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// Displays the most exploited car and its driver in a table
        /// </summary>
        /// <param name="car">The car with the highest mileage</param>
        /// <param name="driver">Driver of the car</param>
        /// <param name="table">Table control used to display the data</param>
        public static void WriteMostExploitedCar(Car car, Driver driver, Table table) {
            table.Rows.Clear();
            table.CssClass = "taxiTable";

            TableRow carHeaderTitle = new TableRow();
            carHeaderTitle.Cells.Add(new TableHeaderCell { Text = "Most exploited car", ColumnSpan = 5, HorizontalAlign = HorizontalAlign.Center });
            table.Rows.Add(carHeaderTitle);

            TableRow carHeader = new TableRow();
            carHeader.Cells.Add(new TableHeaderCell { Text = "Manufacturer", HorizontalAlign = HorizontalAlign.Left });
            carHeader.Cells.Add(new TableHeaderCell { Text = "Model", HorizontalAlign = HorizontalAlign.Left });
            carHeader.Cells.Add(new TableHeaderCell { Text = "Car Number", HorizontalAlign = HorizontalAlign.Left });
            carHeader.Cells.Add(new TableHeaderCell { Text = "Year", HorizontalAlign = HorizontalAlign.Right });
            carHeader.Cells.Add(new TableHeaderCell { Text = "Mileage", HorizontalAlign = HorizontalAlign.Right });
            table.Rows.Add(carHeader);

            TableRow carRow = new TableRow();
            carRow.Cells.Add(new TableCell { Text = car.Manufacturer, HorizontalAlign = HorizontalAlign.Left });
            carRow.Cells.Add(new TableCell { Text = car.Model, HorizontalAlign = HorizontalAlign.Left });
            carRow.Cells.Add(new TableCell { Text = car.CarNumbers, HorizontalAlign = HorizontalAlign.Left });
            carRow.Cells.Add(new TableCell { Text = car.ManufacturingYear.ToString(), HorizontalAlign = HorizontalAlign.Right });
            carRow.Cells.Add(new TableCell { Text = car.Mileage.ToString(), HorizontalAlign = HorizontalAlign.Right });
            table.Rows.Add(carRow);

            TableRow spacer = new TableRow();
            spacer.Cells.Add(new TableCell { Text = "", ColumnSpan = 5 });
            table.Rows.Add(spacer);

            TableRow driverHeaderTitle = new TableRow();
            driverHeaderTitle.Cells.Add(new TableHeaderCell { Text = "Most exploited car driver", ColumnSpan = 2, HorizontalAlign = HorizontalAlign.Center });
            table.Rows.Add(driverHeaderTitle);

            TableRow driverHeader = new TableRow();
            driverHeader.Cells.Add(new TableHeaderCell { Text = "First Name", HorizontalAlign = HorizontalAlign.Left });
            driverHeader.Cells.Add(new TableHeaderCell { Text = "Last Name", HorizontalAlign = HorizontalAlign.Left });
            table.Rows.Add(driverHeader);

            TableRow driverRow = new TableRow();
            driverRow.Cells.Add(new TableCell { Text = driver.FirstName, HorizontalAlign = HorizontalAlign.Left });
            driverRow.Cells.Add(new TableCell { Text = driver.LastName, HorizontalAlign = HorizontalAlign.Left });
            table.Rows.Add(driverRow);
        }

        /// <summary>
        /// Writes car data to a text file
        /// </summary>
        /// <param name="carList">Linked list of cars</param>
        /// <param name="filePath">File path where the data will be written</param>
        public static void PrintCarData(LListCar carList, string filePath) {
            string text = string.Empty;
            text += new string('-', 80) + Environment.NewLine;
            text += String.Format("| {0, -15} | {1, -15} | {2, -15} | {3, -4} | {4, -15} |", "Manufacturer", "Model", "Car Numbers", "Year", "Mileage") + Environment.NewLine;
            text += new string('-', 80) + Environment.NewLine;
            for (carList.Begin(); carList.Exist(); carList.Next()) {
                Car car = carList.GetCar();
                text += car.ToString() + Environment.NewLine;
            }
            text += new string('-', 80) + Environment.NewLine + Environment.NewLine;

            File.AppendAllText(filePath, text);
        }

        /// <summary>
        /// Writes driver data to a text file
        /// </summary>
        /// <param name="driverList">Linked list of drivers</param>
        /// <param name="filePath">File path where the data will be written</param>
        public static void PrintDriverData(LListDriver driverList, string filePath) {
            string text = string.Empty;
            text += new string('-', 55) + Environment.NewLine;
            text += String.Format("| {0, -15} | {1, -15} | {2, -15} |", "FirstName", "LastName", "Car Numbers") + Environment.NewLine;
            text += new string('-', 55) + Environment.NewLine;
            for (driverList.Begin(); driverList.Exist(); driverList.Next()) {
                Driver driver = driverList.GetDriver();
                text += driver.ToString() + Environment.NewLine;
            }
            text += new string('-', 55) + Environment.NewLine + Environment.NewLine;

            File.AppendAllText(filePath, text);
        }

        /// <summary>
        /// Writes taxi data to a text file
        /// </summary>
        /// <param name="taxiList">Linked list of taxis</param>
        /// <param name="filePath">File path where the data will be written</param>
        public static void PrintTaxiData(LListTaxi taxiList, string filePath) {
            string text = string.Empty;
            text += new string('-', 80) + Environment.NewLine;
            text += String.Format("| {0, -15} | {1, -15} | {2, 4} | {3, -15} | {4, -15} |", "Manufacturer", "Model", "Age", "DriverFirstName", "DriverLastName") + Environment.NewLine;
            text += new string('-', 80) + Environment.NewLine;
            for (taxiList.Begin(); taxiList.Exist(); taxiList.Next()) {
                Taxi taxi = taxiList.GetTaxi();
                text += String.Format("| {0, -15} | {1, -15} | {2, 4} | {3, -15} | {4, -15} |",
                    taxi.Manufacturer,
                    taxi.Model,
                    taxi.Age,
                    taxi.DriverFirstName,
                    taxi.DriverLastName) + Environment.NewLine;
            }
            text += new string('-', 80) + Environment.NewLine + Environment.NewLine;
            File.AppendAllText(filePath, text);
        }

        /// <summary>
        /// Writes unique taxi manufacturers to a text file
        /// </summary>
        /// <param name="taxiList">Linked list of taxis</param>
        /// <param name="filePath">File path where the data will be written</param>
        public static void PrintUniqueManufacturers(LListTaxi taxiList, string filePath) {
            string text = "";
            text += new string('-', 30) + Environment.NewLine;
            text += String.Format("| {0, -26} |", "Unique car manufacturers") + Environment.NewLine;
            text += new string('-', 30) + Environment.NewLine;

            List<string> uniqueManufacturers = TaskUtils.FindUniqueManufacturers(taxiList);

            foreach (string manufacturer in uniqueManufacturers) {
                text += String.Format("| {0, -26} |",  manufacturer) + Environment.NewLine;
            }

            text += new string('-', 30) + Environment.NewLine + Environment.NewLine;

            File.AppendAllText(filePath, text);
        }

        /// <summary>
        /// Writes information about the most exploited car to a text file
        /// </summary>
        /// <param name="mostExploitedCar">Car with the highest mileage</param>
        /// <param name="filePath">File path where the data will be written</param>
        public static void PrintMostExploitedCar(Car mostExploitedCar, string filePath) {
            string text = string.Empty;

            text += "Most exploited car" + Environment.NewLine;
            text += new string('-', 80) + Environment.NewLine;
            text += String.Format("| {0,-15} | {1,-15} | {2,-15} | {3,4} | {4,15} |",
                "Manufacturer", "Model", "Car Numbers", "Year", "Mileage") + Environment.NewLine;
            text += new string('-', 80) + Environment.NewLine;

            text += mostExploitedCar.ToString() + Environment.NewLine;

            text += new string('-', 80) + Environment.NewLine + Environment.NewLine;

            File.AppendAllText(filePath, text);
        }

        /// <summary>
        /// Writes the driver of the most exploited car to a text file
        /// </summary>
        /// <param name="driver">Driver of the car</param>
        /// <param name="filePath">File path where the data will be written</param>
        public static void PrintMostExploitedCarDriver(Driver driver, string filePath) {
            string text = string.Empty;

            text += "Most exploited car driver" + Environment.NewLine;
            text += new string('-', 37) + Environment.NewLine;
            text += String.Format("| {0,-15} | {1,-15} |",
                "FirstName", "LastName") + Environment.NewLine;
            text += new string('-', 37) + Environment.NewLine;

            text += String.Format("| {0,-15} | {1,-15} |", driver.FirstName, driver.LastName) + Environment.NewLine;

            text += new string('-', 37) + Environment.NewLine + Environment.NewLine;

            File.AppendAllText(filePath, text);
        }
    }
}