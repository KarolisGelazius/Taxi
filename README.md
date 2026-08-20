# Taxi
Taxi fleet and driver management system implementing custom linked lists, age-based filtering, and sorting.

## Program User Manual

### Data Preparation
Before launching the application, prepare the input data files inside the `App_Data` folder:

* **`App_Data/U18a.txt` (Driver Information):**  
  Stores the registry of taxi drivers. Each line represents a driver with space-separated values:  
  `<First_Name> <Last_Name> <License_Plate>`  
  * **Fields:** Driver's first name, last name, and assigned vehicle license plate number (used as the relational key).  
  * *Example:*
    ```text
    Jonas Jonaitis ABC123
    Petras Petraitis DEF456
    ```

* **`App_Data/U18b.txt` (Vehicle Information):**  
  Contains technical and operational records of the taxi fleet. Each line represents a car with space-separated values:  
  `<Make> <Model> <License_Plate> <Manufacture_Year> <Annual_Mileage_k_km>`  
  * **Fields:** Vehicle manufacturer, model name, license plate number, year of manufacture, and annual mileage (in thousands of kilometers).  
  * *Example:*
    ```text
    Toyota Prius ABC123 2018 45.5
    Volkswagen Passat DEF456 2015 62.0
    ```
