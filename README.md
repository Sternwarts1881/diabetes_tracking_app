# Diabetes Tracking App 🦥
![resim](https://github.com/user-attachments/assets/c92fef99-331b-4e5a-96aa-9c61bd166612)
![resim](https://github.com/user-attachments/assets/0ec54c17-8d38-4b20-88dd-89751daa3462)
![resim](https://github.com/user-attachments/assets/63556a37-cdb2-4e6d-9635-a41117309e44)


This is a Windows Forms application developed in C# for tracking diabetes-related data. It connects to a MySQL database to manage patient records, measurements, and other health-related information. This project is made for the "Programming Laboratory II" course in Kocaeli University.

---

## ⚠️ Important Notice

* The project contains multiple **hard-coded connection strings** inside the source code:

  ```csharp
  server=localhost;
  user=root;
  password=1e2g3e;
  database=diyabet_sistemi;
  port=3306;
  ```
* For the application to run successfully, **the MySQL database must exist with exactly the same name and credentials**. If not, the application will fail to connect.

* ⚠️Sadly windows forms does not work in docker (technically it does but file size will exceed 10gbs which is an insane amount for such a small project), I will try to fix this issue as much as possible in the future but this will have to suffice for now.
---

## Requirements

* **Windows OS**
* **Visual Studio 2022** or later with Windows Forms support
* **.NET Framework 4.x**
* Installed **MySQL Server** 

---

## 🛠️ Setup Instructions

1. Clone the repository:

   ```bash
   git clone https://github.com/Sternwarts1881/diabetes_tracking_app.git
   cd diabetes_tracking_app
   ```

2. Create and populate the database:

   ```bash
   mysql -u root -p
   SOURCE sql-scripts/init.sql;
   ```

3. Open `PROJE3.sln` in Visual Studio.

4. Verify the connection strings in the source code:

   > ⚠️ If you are using different credentials, update them accordingly.

5. Build the project (Rebuild Solution).

6. Run the application.

---

## ▶️ Usage

* Doctors are already defined in the database, using the ID`s and passwords you can log in as a doctor.
* A sample SQL dump is provided so the database can be quickly restored on any system.
 ## As a doctor you can:
   1) Register a patient into the database, you will have to select their symptoms and add their initial blood sugar level into the system.
       After registration, patients will recieve their log-in id`s and passwords via e-mail. After registration the system will recommend a dietary          plan and an excercise plan for the patient automatically.
   
   2) Review all of your registered patients data, such as checking how much they follow their dietary and exercise plans, the effects of the               treatment to their blood sugar levels, their insulin dosage which is recommended by the system, their blood sugar levels and so on.
   
   3) Filter your patients according to their symptoms and their average blood sugar levels.
   
   4) Send recommendations via text(similar to a standart messeage).
   
   5) Review alerts which the system automatically sends you in case of any extreme anomalies and emergency conditions.
      And much more...
 
 ## As a patient you can:
   1) You can enter whether you have followed the dietary and exercise plan into the system.
   
   2) Recieve recommended insulin dosage determined by the blood sugar levels you register into the system on that day.
   
   3) Review your statistics via simple pie chart graphs.
   
   4) Read any messeage your doctor have sent you.
   
   5) Review your previous insulin dosages.
      And much more...

---


---

##  Notes

* You can modify `dump.sql` if you need to change or expand the database schema. For example the binary data for the profile pictures are kept in the database, this sometimes causes corruption. You may need to delete the profile pictures in the 'kullanicilar' table.
* For advanced setups, you may consider converting the project to .NET Core, using EF Core, or containerizing with Docker.
* This project uses MIT license.

---
