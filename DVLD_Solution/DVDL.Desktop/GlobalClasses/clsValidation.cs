namespace DVDL.Desktop.Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string EmailAddress)
        {
            if (EmailAddress.StartsWith("@")) return false;

            else if (EmailAddress.EndsWith("@")) return false;

            int Index = -1;
            if (EmailAddress.Contains("@"))
                Index = EmailAddress.IndexOf('@');

            if (Index == -1) return false;

            string PrefixEmail = EmailAddress.Substring(0, Index);
            EmailAddress = EmailAddress.Remove(0, Index);
            string EmailSyntax = EmailAddress.Substring(0, EmailAddress.Length);

            if (EmailSyntax == "@gmail.com" && !string.IsNullOrEmpty(PrefixEmail)) return true;

            return false;


            // منطق متقدم
            //if (string.IsNullOrWhiteSpace(Email))
            //    return false;

            //// نمط Regex المعياري للتحقق من معظم الإيميلات الصالحة
            //string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            //// استخدام الـ Regex.IsMatch
            //return Regex.IsMatch(Email, emailPattern);
        }

        public static bool IsNumber(string Value)
        {
            if (decimal.TryParse(Value, out decimal Number))
                return true;

            return false;
        }
    }
}