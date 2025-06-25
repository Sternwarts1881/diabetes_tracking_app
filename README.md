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

* ⚠️ Sadly Windows Forms does not work well in Docker (technically it does, but the image size exceeds 10 GB, which is an insane amount for such a small project). I will try to fix this issue as much as possible in the future, but this will have to suffice for now.

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

* Doctors are already defined in the database. Using the provided IDs and passwords, you can log in as a doctor.
* A sample SQL dump is provided so the database can be quickly restored on any system.

### As a doctor, you can:

1. Register a patient into the database. You will have to select their symptoms and add their initial blood sugar level into the system.
   After registration, patients will receive their login IDs and passwords via e-mail. The system will automatically recommend a dietary and an exercise plan for the patient.

2. Review all of your registered patients' data, such as how well they follow their dietary and exercise plans, the effects of the treatment on their blood sugar levels, the insulin dosages recommended by the system, and more.

3. Filter your patients according to their symptoms and their average blood sugar levels.

4. Send recommendations via text (similar to a standard message).

5. Review alerts which the system automatically sends in case of extreme anomalies or emergency conditions.

And much more...

### As a patient, you can:

1. Enter whether you have followed the dietary and exercise plans into the system.

2. Receive recommended insulin dosages based on the blood sugar levels you register into the system.

3. Review your statistics via simple pie chart graphs.

4. Read any messages your doctor has sent you.

5. Review your previous insulin dosages.

And much more...

---

## 🔍 Notes

* You can modify `dump.sql` if you need to change or expand the database schema. For example, the binary data for the profile pictures is stored in the database, which may sometimes cause corruption. You may need to delete the profile pictures in the 'kullanicilar' table.
* For advanced setups, you may consider converting the project to .NET Core, using EF Core, or containerizing with Docker.
* This project uses the MIT license.

