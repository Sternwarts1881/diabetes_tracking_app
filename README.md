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

## ▶️ Usage

* Doctors are already defined in the database. Using the provided IDs and passwords, you can log in as a doctor.
* A sample SQL dump is provided so the database can be quickly restored on any system.

### As a doctor, you can:
<img src="https://github.com/user-attachments/assets/2fa6d3a1-3c35-4b98-a4a8-20e4a0ee4748" alt="resim" width="400" />


1. Register a patient into the database. You will have to select their symptoms and add their initial blood sugar level into the system.
   After registration, patients will receive their login IDs and passwords via e-mail. The system will automatically recommend a dietary and an exercise plan for the patient.
<img src="https://github.com/user-attachments/assets/0f89a89a-6113-4914-9cd5-12f73573efbc" alt="resim" width="800" />


2. Review all of your registered patients' data, such as how well they follow their dietary and exercise plans, the effects of the treatment on their blood sugar levels, the insulin dosages recommended by the system, and more.
<img src="https://github.com/user-attachments/assets/30967cd3-972a-4570-a06b-45707da11875" alt="resim" width="400" />


3. Filter your patients according to their symptoms and their average blood sugar levels.
<img src="https://github.com/user-attachments/assets/23a36a8e-6dc7-4572-9908-de88d3b2d6ec" alt="resim" width="400" />

4. Send recommendations via text (similar to a standard message).
<img src="https://github.com/user-attachments/assets/bd9e01f5-6628-4bb1-9865-e3a6fa921e98" alt="resim" width="800" />


5. Review alerts which the system automatically sends in case of extreme anomalies or emergency conditions.

And much more...

### As a patient, you can:
<img src="https://github.com/user-attachments/assets/7f6a9333-e11f-4950-b0c9-a911da24883c" alt="resim" width="250" />


1. Enter whether you have followed the dietary and exercise plans into the system.
<img src="https://github.com/user-attachments/assets/f58498db-cae5-4e89-87b8-7b4e1031ec0c" alt="resim" width="400" />
 
   (Patient did not register any blood sugar data in this example)

2. Receive recommended insulin dosages based on the blood sugar levels you register into the system.
<img src="https://github.com/user-attachments/assets/8b02d958-b57c-4bcb-b164-3a98285f117f" alt="resim" width="800" />


3. Review your statistics via simple pie chart graphs.
<img src="https://github.com/user-attachments/assets/841433cd-d204-4cdd-a7b3-5d313ee3033e" alt="resim" width="700" />


4. Read any messages your doctor has sent you.
<img src="https://github.com/user-attachments/assets/692e8ef6-e09e-4f7d-9acf-2826c2940a2a" alt="resim" width="400" />


5. Review your previous insulin dosages.
 
And much more...

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

## 🔍 Notes

* You can modify `dump.sql` if you need to change or expand the database schema. For example, the binary data for the profile pictures is stored in the database, which may sometimes cause corruption. You may need to delete the profile pictures in the 'kullanicilar' table.
* For advanced setups, you may consider converting the project to .NET Core, using EF Core, or containerizing with Docker.
* This project uses the MIT license.

