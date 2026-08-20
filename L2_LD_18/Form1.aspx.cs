using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace L2_LD_18
{
    public partial class Form1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Validates that the minimal car age is not greater than the maximal car age
        /// </summary>
        /// <param name="source">Validator control that raised the event</param>
        /// <param name="args">Validation event arguments</param>
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args) {
            int minAge, maxAge;

            if (int.TryParse(TextBox1.Text, out minAge) && int.TryParse(TextBox2.Text, out maxAge)) {
                args.IsValid = minAge <= maxAge;
            }
            else {
                args.IsValid = true;
            }
        }

        /// <summary>
        /// Executes when the main button is clicked
        /// </summary>
        /// <param name="sender">Button that triggered the event</param>
        /// <param name="e">Event arguments</param>
        protected void Button1_Click(object sender, EventArgs e) {
            int minAge, maxAge;
            bool isValid = true;
            string errorMessage = "";

            if (!int.TryParse(TextBox1.Text, out minAge)) {
                isValid = false;
                errorMessage += "Minimalus amžius turi būti skaičius.<br/>";
            }
            else if (minAge < 0) {
                isValid = false;
                errorMessage += "Minimalus amžius negali būti neigiamas.<br/>";
            }

            if (!int.TryParse(TextBox2.Text, out maxAge)) {
                isValid = false;
                errorMessage += "Maksimalus amžius turi būti skaičius.<br/>";
            }
            else if (maxAge < 0) {
                isValid = false;
                errorMessage += "Maksimalus amžius negali būti neigiamas.<br/>";
            }

            if (isValid && minAge > maxAge) {
                isValid = false;
                errorMessage += "Minimalus amžius negali būti didesnis už maksimalų.<br/>";
            }

            if (!isValid) {
                Label3.Text = errorMessage; 
                return;
            }
            else {
                Label3.Text = ""; 
            }

            string inputCarFilePath = Server.MapPath("~/App_Data/U18b.txt");
            string inputDriverFilePath = Server.MapPath("~/App_Data/U18a.txt");
            string outputFilePath = Server.MapPath("~/App_Data/Result.txt");

            File.Delete(outputFilePath);

            LListCar carList = InOutUtils.ReadCars(inputCarFilePath);
            InOutUtils.PrintCarData(carList, outputFilePath);
            LListDriver driverList = InOutUtils.ReadDrivers(inputDriverFilePath);
            InOutUtils.PrintDriverData(driverList, outputFilePath);

            LListTaxi taxiList = TaskUtils.CreateTaxiList(carList, driverList, minAge, maxAge);
            taxiList.Sort();

            InOutUtils.CreateCarTable(taxiList, Table1);
            InOutUtils.PrintTaxiData(taxiList, outputFilePath);
            InOutUtils.WriteUniqueManufacturers(taxiList, Table2);
            InOutUtils.PrintUniqueManufacturers(taxiList, outputFilePath);

            Car mostExploitedCar = TaskUtils.FindMostExploitedCar(carList);
            Driver driver = TaskUtils.FindDriver(driverList, mostExploitedCar.CarNumbers);

            InOutUtils.WriteMostExploitedCar(mostExploitedCar, driver, Table3);
            InOutUtils.PrintMostExploitedCar(mostExploitedCar, outputFilePath);
            InOutUtils.PrintMostExploitedCarDriver(driver, outputFilePath);
        }
    }
}