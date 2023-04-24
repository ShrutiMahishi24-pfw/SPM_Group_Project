///<summary>
///Backend database creation 
///</summary> 
create database Appointments;

CREATE TABLE Appointments.Appointments (
  appointment_id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  doctor_id INT NOT NULL,
  patient_id INT NOT NULL,
  appointment_time DATETIME NOT NULL,
  patient_name VARCHAR(255) NOT NULL,
  doctor_name VARCHAR(255) NOT NULL,
  doctor_department VARCHAR(255) NOT NULL,
  patient_disease VARCHAR(255) NOT NULL,
  patient_age INT NOT NULL
)AUTO_INCREMENT = 1;

ALTER TABLE Appointments.Appointments AUTO_INCREMENT=1;

INSERT INTO Appointments.Appointments (doctor_id, patient_id, appointment_time, patient_name, doctor_name, doctor_department, patient_disease, patient_age) VALUES
(1, 1, '2023-03-05 09:00:00', 'John Doe', 'Dr. Maya', 'Cardiology', 'Heart Attack', 56),
(2, 2, '2023-03-06 10:00:00', 'Jane Doe', 'Dr. Lee', 'Oncology', 'Breast Cancer', 42),
(3, 3, '2023-03-07 11:00:00', 'Bob Johnson', 'Dr. Wilson', 'Orthopedics', 'Fractured Arm', 35),
(4, 4, '2023-03-08 12:00:00', 'Alice Johnson', 'Dr. Smith', 'Neurology', 'Migraine', 28),
(5, 5, '2023-03-09 13:00:00', 'Sarah Lee', 'Dr. Deepthi', 'Allergy and Immunology', 'Allergies', 19),
(6, 6, '2023-03-10 14:00:00', 'Tom Davis', 'Dr. Dustin', 'Pulmonology', 'Asthma', 49),
(7, 7, '2023-03-11 15:00:00', 'Linda Wilson', 'Dr. Jack', 'Dermatology', 'Psoriasis', 61),
(8, 8, '2023-01-12 16:00:00', 'David Brown', 'Dr. Gourav', 'Infectious Disease', 'Flu', 32),
(9, 9, '2023-02-13 17:00:00', 'Samantha Green', 'Dr. Charles', 'Gastroenterology', 'Irritable Bowel Syndrome', 47),
(10, 10, '2023-01-14 18:00:00', 'Peter White', 'Dr. Joule', 'Endocrinology', 'Diabetes', 52),
(7, 11, '2023-02-15 19:00:00', 'Karen Lewis', 'Dr. Jack', 'Dermatology', 'Tooth Pain', 71),
(4, 12, '2023-02-16 20:00:00', 'Mark Roberts', 'Dr. Smith', 'Neurology', 'Parkinson Disease', 59),
(11, 13, '2023-02-17 09:00:00', 'Catherine Johnson', 'Dr.Carolin', 'Psychiatry', 'Depression', 43),
(2, 14, '2023-02-19 10:00:00', 'Alexandra Lee', 'Dr. Lee', 'Oncology', 'Lung Cancer', 34),
(5, 15, '2023-01-28 11:00:00', 'Laura Davis', 'Dr. Deepthi', 'Allergy and Immunology', 'Hay Fever', 51);

INSERT INTO Appointments.Appointments (doctor_id, patient_id, appointment_time, patient_name, doctor_name, doctor_department, patient_disease, patient_age) VALUES
(12, 16, '2023-01-12 11:00:00', 'Sierra', 'Dr. David', 'Allergy and Immunology', 'Hay Fever', 51),
(3, 3, '2023-01-25 11:00:00', 'Bob Johnson', 'Dr. Wilson', 'Orthopedics', 'Fractured Arm', 35),
(6, 6, '2023-02-17 12:00:00', 'Tom Davis', 'Dr. Wilson', 'Pulmonology', 'Pregnancy Test', 30),
(13, 17, '2023-02-22 1:00:00', 'Warner', 'Dr. Prem', 'Allergy and Immunology', 'Hay Fever', 51),
(8, 15, '2023-03-08 2:00:00', 'Laura Davis', 'Dr. Gourav', 'Allergy and Immunology', 'Hay Fever', 51),
(1, 1, '2023-02-06 3:00:00', 'John Doe', 'Dr. Maya', 'Cardiology', 'Heart Attack', 56),
(14, 17, '2023-03-09 4:00:00', 'Laura Davis', 'Dr. Deepthi', 'Allergy and Immunology', 'Hay Fever', 51),
(15, 18, '2023-02-25 6:00:00', 'Shruthi', 'Dr. Zim', 'Pulmonology', 'Hay Fever', 45),
(7, 11, '2022-12-12 7:00:00', 'Karen Lewis', 'Dr. Jack', 'Dermatology', 'Tooth Pain', 71),
(8, 8, '2021-02-1 8:00:00', 'David Brown', 'Dr. Gourav', 'Infectious Disease', 'Flu', 32);

select * from Appointments.Appointments;

DROP TABLE Appointments.Appointments;
