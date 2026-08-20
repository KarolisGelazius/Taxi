# Taxi Fleet Analytics

A system for taxi fleet and driver relational analysis, custom linked list filtering, and vehicle utilization tracking built with C# and ASP.NET.

## Program User Manual

### 1. Data Preparation
Prepare two text data files separated by semicolons (`;`) or spaces before uploading them via the application:

* **Driver Information File:**  
  Stores the registry of taxi drivers. Each line represents a driver with delimited values:  
  `<First_Name>;<Last_Name>;<License_Plate>`  
  * **Fields:** Driver's first name, last name, and assigned vehicle license plate number (used as the relational key).  
  * *Example:*
    ```text
    Jonas;Jonaitis;ABC123
    Petras;Petraitis;DEF456
    ```

* **Vehicle Information File:**  
  Contains technical and operational records of the taxi fleet. Each line represents a car with delimited values:  
  `<Make>;<Model>;<License_Plate>;<Manufacture_Year>;<Annual_Mileage>`  
  * **Fields:** Vehicle manufacturer, model name, license plate number, year of manufacture, and annual mileage/usage intensity.  
  * *Example:*
    ```text
    Toyota;Prius;ABC123;2018;45.5
    Volkswagen;Passat;DEF456;2015;62.0
    ```

---

### 2. How to Use

1. **Launch the Project:** Open and run `L3_LD_L18.sln` in Visual Studio.
2. **Upload Files:** Use the file input controls on the web page to select and upload both the drivers and vehicles data files.
3. **Specify Age Filter:** Enter numeric bounds into the **Min Age** and **Max Age** input fields.
4. **Execute:** Click the **"Show Results"** button.
