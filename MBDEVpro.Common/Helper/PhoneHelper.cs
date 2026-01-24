
namespace MBDEVpro.Common.Helper
{
    public class PhoneHelper
    {

        /// <summary>
        /// Format the phone number for display in the UI
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string FormatPhone(string phone)
        {
            var phoneNumber = phone;
            if (phoneNumber != null && !string.IsNullOrEmpty(phoneNumber))
            {
                Regex phoneRegex = new Regex(RegularExpressionConstants.Phone);
                return phoneRegex.Replace(phone, "($1) $2-$3");
            }
            else
            {
                return phoneNumber;
            }
        }


        /// <summary>
        /// Strip out any none digits from the phone number
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string MaskedPhone(string phone)
        {
            var phoneNumber = phone;
            if (phoneNumber != null && !string.IsNullOrEmpty(phoneNumber))
            {
                return new string(phone.Where(char.IsDigit).ToArray());
            }
            else
            {
                return phoneNumber;
            }
        }
    }
}
