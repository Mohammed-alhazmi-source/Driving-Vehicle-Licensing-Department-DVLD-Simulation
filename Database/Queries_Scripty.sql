-- „⁄·Ê„«   ﬁœÌ„ «·ÿ·»«  Ê«·«‘Œ«’ «·„ﬁœ„Ì‰ Ê‰Ê⁄ «·ÿ·» Ê«·„” Œœ„Ì‰ «·Ì ﬁ«„Ê »«‰‘«¡ «·ÿ·»
SELECT 
	A.ApplicationID,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
	A.ApplicationDate,
	ATY.ApplicationTypeTitle,
	U.UserName
FROM
	Applications A
JOIN
	ApplicationTypes ATY
ON
	A.ApplicationTypeID = ATY.ApplicationTypeID
JOIN
	People P
ON
	A.ApplicantPersonID = P.PersonID
JOIN
	Users U
ON
	U.UserID = A.CreatedByUserID;

-- ⁄—÷ „⁄·Ê„«  «·—Œ’ «·„Õ Ã“… —ﬁ„ «·—Œ’… «·„Õ Ã“… Ê«”„ «·›∆… ··—Œ’… Ê—ﬁ„ „⁄—› «·”«∆ﬁ
-- Ê«·«”„ «·ﬂ«„· ··‘Œ’ «·Ì —Œ’ Â „Õ Ã“…
SELECT
	DL.DetainID,
	DL.LicenseID,
	LC.ClassName,
	D.DriverID,
	P.NationalNo,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName
FROM
	DetainedLicenses DL
JOIN
	Licenses L
ON
	DL.LicenseID = L.LicenseID
JOIN
	Drivers D
ON
	L.DriverID = D.DriverID
JOIN
	People P
ON
	D.PersonID = P.PersonID
JOIN
	LicenseClasses LC
ON
	L.LicenseClass = LC.LicenseClassID;
	
-- ⁄—÷ «·—Œ’ »Õ”» «·—ﬁ„ «·Êÿ‰Ì  «Ê —ﬁ„ «·—Œ’… ( „⁄—› «·”«∆ﬁ) «·„⁄·Ê„«  «·Ì —«Õ  ‰⁄—÷
-- „⁄—› «·—Œ’… Ê«”„ ›∆… «·—Œ’… Ê„⁄—› «·”«∆ﬁ Ê«”„ «·”«∆ﬁ ··—Œ’…
SELECT DISTINCT
	LC.ClassName,
	D.DriverID,
	P.NationalNo,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName
FROM
	Licenses L
JOIN
	Drivers D
ON
	L.DriverID = D.DriverID
JOIN
	People P
ON
	P.PersonID = D.PersonID
JOIN
	LicenseClasses LC
ON
	L.LicenseClass = LC.LicenseClassID;

-- ⁄—÷ «·—Œ’ «·‰‘ÿ… ·ﬂ· —ﬁ„  ⁄—Ì› ”«∆ﬁ „⁄ »⁄÷ «·„⁄·Ê„«  ›Ì «·⁄—÷
SELECT DISTINCT
	D.DriverID,
	P.PersonID,
	P.NationalNo,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
	D.CreatedDate,
    (SELECT  COUNT(DriverID) FROM Licenses WHERE DriverID = L.DriverID AND IsActive = 1) AS NumberOfActiveLicenses
FROM
	Licenses L
JOIN
	Drivers D
ON
	L.DriverID = D.DriverID
JOIN
	People P
ON
	D.PersonID = P.PersonID;

-- ⁄—÷ «·—Œ’ «·€Ì— ‰‘ÿ… ·ﬂ· —ﬁ„  ⁄—Ì› ”«∆ﬁ „⁄ »⁄÷ «·„⁄·Ê„«  ›Ì «·⁄—÷
SELECT DISTINCT
	D.DriverID,
	P.PersonID,
	P.NationalNo,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
	D.CreatedDate,
    (SELECT  COUNT(DriverID) FROM Licenses WHERE DriverID = L.DriverID AND IsActive = 0) AS NumberOfInActiveLicenses
FROM
	Licenses L
JOIN
	Drivers D
ON
	L.DriverID = D.DriverID
JOIN
	People P
ON
	D.PersonID = P.PersonID;

-- ⁄—÷ „Ê«⁄Ìœ «·«Œ »«—«  ·ﬂ· ÿ·» —Œ’… ﬁÌ«œ… „Õ·Ì… ﬂ„ «Œ »«—«  «Ã—Ì  ⁄·ÌÂ«
-- Ê‰Ê⁄ Õﬁ· «·«Œ »«— ·ﬂ· „Ê⁄œ Ê«”„ «·›∆… ··—Œ’… «·„Õ·Ì…
-- Ê «—ÌŒ „Ê⁄œ «·«Œ »«— Ê«·—”Ê„ «·„œ›Ê⁄… Ê«·«”„ «·ﬂ«„· ··‘Œ’ «·„ ﬁœ„ ··—Œ’…
-- ÊÂ· Õ«·… „ﬁ›·… «„ ·« ‰‘ÿ… Ê „ «‰Â«¡ «Œ »«—«  ⁄·Ï „«Ì — » ⁄·Ï «·—Œ’… ··Õ’Ê· ⁄·ÌÂ«
SELECT 
	TA.TestAppointmentID,
	TA.LocalDrivingLicenseApplicationID,
	TT.TestTypeTitle,
	LC.ClassName,
	TA.AppointmentDate,
	TA.PaidFees,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
	 TA.IsLocked
FROM
	TestAppointments TA
JOIN
	LocalDrivingLicenseApplications L
ON
	TA.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID
JOIN
	TestTypes TT
ON
	TA.TestTypeID = TT.TestTypeID
JOIN
	Applications A
ON
	L.ApplicationID = A.ApplicationID
JOIN
	People P
ON
	A.ApplicantPersonID = P.PersonID
JOIN
	LicenseClasses LC
ON
	L.LicenseClassID = LC.LicenseClassID;

-- ⁄—÷ „⁄·Ê„«  ⁄‰ «·—Œ’ «·„Õ·Ì… ·ﬂ· —Œ’… „Õ·Ì… 
-- „⁄ »⁄÷ «·„⁄·Ê„«  ‰Ê⁄ «·›∆… Ê«·—ﬁ„ «·Êÿ‰Ì ·Â–Â «·—Œ’… Ê«·«”„ ·Â–Â «·—Œ’…
-- Êﬂ„ ⁄œœ «·«Œ »«—«  «·‰«ÃÕ… «· Ì «Ã—Ì  Õ Ï «·Õ’Ê· ⁄·Ï «·—Œ’…
-- Ê„«ÂÌ Õ«·… «·—Œ’… Â· «ﬂ „· ﬂ· «·‘—Êÿ Ê«·«Œ »«—«  «„ „«“«· Â‰«ﬂ «Ã—«¡«  ·„ Ì „ «·Õ’Ê· ⁄·Ï «·—Œ’…
SELECT
	L.LocalDrivingLicenseApplicationID,
	LC.ClassName, P.NationalNo, 
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
    (SELECT COUNT(DISTINCT TestTypeID)
     FROM  TestAppointments AS TA
      WHERE  (LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID)) AS PassedTestCount, 
      CASE WHEN A.ApplicationStatus = 1 THEN 'New' WHEN A.ApplicationStatus = 2 THEN 'Cancel' WHEN A.ApplicationStatus = 3 THEN 'Completed' END AS Status
FROM            
	LocalDrivingLicenseApplications AS L 
	INNER JOIN
    LicenseClasses AS LC 
	ON L.LicenseClassID = LC.LicenseClassID 
	INNER JOIN
    Applications AS A 
	ON L.ApplicationID = A.ApplicationID 
	INNER JOIN
    People AS P 
	ON A.ApplicantPersonID = P.PersonID;

-- ⁄—÷ «”„ «·”«∆ﬁ Ê—ﬁ„  ⁄—Ì› «·”«∆ﬁ Ê «—ÌŒ «‰‘«¡ —ﬁ„ «·”«∆ﬁ Ê⁄œœ «·—Œ’ «·œÊ·Ì… ·ﬂ· —ﬁ„  ⁄—Ì› ”«∆ﬁ
SELECT
	D.DriverID,
	D.CreatedDate,
	CONCAT(P.FirstName,' ', P.SecondName, ' ', P.ThirdName, ' ', P.LastName) AS FullName,
	(SELECT COUNT(DriverID)  FROM InternationalLicenses WHERE DriverID = D.DriverID) AS
	InternationalLicensesCount
FROM
	Drivers D
JOIN
	People P
ON
	D.PersonID = P.PersonID;
