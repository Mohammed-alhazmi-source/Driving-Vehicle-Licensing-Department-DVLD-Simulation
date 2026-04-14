
-- ÇÓÊÚáÇãí ÇáÊÇßÏ åá ÇÎÑ ãæÚÏ áØáÈ ÇáÑÎÕÉ ÇáãÍáíÉ ÊÌÇæÒ Çæ äÌÍ İí ÇáÇÎÊÈÇÑ 
SELECT 
	T.TestResult
FROM TestAppointments TA
JOIN
	Tests T
ON
	TA.TestAppointmentID = T.TestAppointmentID
WHERE TA.TestAppointmentID = 
( SELECT MAX(TestAppointmentID)
	FROM TestAppointments
	WHERE LocalDrivingLicenseApplicationID = 18 AND TestTypeID = 1)

-- ÇÓÊÚáÇã ÇáÏßÊæÑ áãÚÑİÉ åá ØáÈ ÇáÑÎÕÉ İí ÇÎÑ ÇÓÊÚáÇã äÌÍ İí äæÚ ÇáÇÎÊÈÇÑ
SELECT top 1
	T.TestResult
FROM LocalDrivingLicenseApplications LDLA
JOIN
	TestAppointments TA
ON	LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
JOIN
Tests T 
ON TA.TestAppointmentID = T.TestAppointmentID
WHERE LDLA.LocalDrivingLicenseApplicationID = 18 AND TA.TestTypeID = 1
ORDER BY TA.TestAppointmentID DESC;

-- ÇÓÊÚáÇãí İí ãÚÑİÉ ßã ÚÏÏ ÇáãÑÇÊ áØáÈ ÇáÑÎÕÉ ÇáãÍáíÉ ÊŞÏã Úáì  ÇáÇÎÊÈÇÑ ÓæÇÁ äÌÍ Çæ ÑÓÈ
SELECT 
	COUNT(T.TestAppointmentID)
FROM TestAppointments TA
JOIN Tests T
ON TA.TestAppointmentID = T.TestAppointmentID
WHERE TA.LocalDrivingLicenseApplicationID = 32 AND TA.TestTypeID = 3

-- -- ÇÓÊÚáÇã ÇáÏßÊæÑ İí ãÚÑİÉ ßã ÚÏÏ ÇáãÑÇÊ áØáÈ ÇáÑÎÕÉ ÇáãÍáíÉ ÊŞÏã Úáì  ÇáÇÎÊÈÇÑ ÓæÇÁ äÌÍ Çæ ÑÓÈ
SELECT 
COUNT(T.TestID)
FROM LocalDrivingLicenseApplications LDLA
JOIN
TestAppointments TA
ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
JOIN
Tests T
ON TA.TestAppointmentID = T.TestAppointmentID
WHERE LDLA.LocalDrivingLicenseApplicationID = 32 AND TA.TestTypeID = 3


-- ÊŞÏíã LocalDrivingLicenseApplicationID ÇÓÊÚáÇãí ááÊÇßÏ åá áÏì
-- Úáì ãæÚÏ áäæÚ ÇÎÊÈÑ ãÚíä æåĞÇ ÇáãæÚÏ ãÇÒÇá äÔØ áã íÊã ÇáÊŞÏíã Úáì ÇáÇÎÊÈÇÑ 
SELECT Found = 1 FROM TestAppointments WHERE TestAppointmentID = (
SELECT   MAX(TestAppointmentID)
FROM TestAppointments
WHERE LocalDrivingLicenseApplicationID = 33 AND TestTypeID = 2 AND IsLocked = 0);

-- ÊŞÏíã LocalDrivingLicenseApplicationID ÇÓÊÚáÇã ÇáÏßÊæÑ ááÊÇßÏ åá áÏì
-- Úáì ãæÚÏ áäæÚ ÇÎÊÈÑ ãÚíä æåĞÇ ÇáãæÚÏ ãÇÒÇá äÔØ áã íÊã ÇáÊŞÏíã Úáì ÇáÇÎÊÈÇÑ SELECT Found = 1
SELECT Found = 1 
FROM LocalDrivingLicenseApplications LDLA
JOIN
	TestAppointments TA
ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
JOIN Tests T
ON TA.TestAppointmentID = T.TestAppointmentID
WHERE LDLA.LocalDrivingLicenseApplicationID = 33 AND
TA.TestTypeID = 3 AND TA.IsLocked = 0



