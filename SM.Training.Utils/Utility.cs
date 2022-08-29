using SM.Training.SharedComponent.Constants;
using SoftMart.Core.Utilities.Profiles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SM.Training.Utils
{
    public static class Utility
    {
        private const string DATE_FORMAT = "dd/MM/yyyy";

        #region Validation

        public static bool ValidateEmailAddress(string email)
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(email,
              @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            return isValid;
        }

        #endregion

        #region Getting value methods

        public static T GetDictionaryKeyByValue<T>(Dictionary<T, string> dicData, string value)
        {
            var item = dicData.FirstOrDefault(c => string.Equals(c.Value, value, StringComparison.OrdinalIgnoreCase));
            return item.Key;
        }
        public static int GetDictionaryKeyByValue(Dictionary<int, string> dicData, string value)
        {
            var item = dicData.FirstOrDefault(c => string.Equals(c.Value, value, StringComparison.OrdinalIgnoreCase));
            return item.Key;
        }
        public static bool GetDictionaryKeyByValue(Dictionary<bool, string> dicData, string value)
        {
            var item = dicData.FirstOrDefault(c => string.Equals(c.Value, value, StringComparison.OrdinalIgnoreCase));
            return item.Key;
        }

        public static int? GetObjectInt(object value)
        {
            if (value == null)
                return null;
            int? intValue = value as int?;
            if (intValue == null)
                return null;
            return intValue;
        }

        public static string CleanString(string dirtyString)
        {
            if (dirtyString == null || dirtyString.Trim() == string.Empty)
                return string.Empty;
            else
            {
                dirtyString = dirtyString.Trim();
                return System.Text.RegularExpressions.Regex.Replace(dirtyString, @"\s+", " ");
            }
        }

        public static string GetDateString(DateTime? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value.ToString(DATE_FORMAT);
        }

        public static string GetStatusByDictionary(Dictionary<int?, string> dct, object value)
        {
            if (value == null)
                return string.Empty;
            int? key = value as int?;
            if (key == null)
                return string.Empty;
            if (key.HasValue && dct.ContainsKey(key.Value))
                return dct[key];
            else
                return null;
        }
        public static string GetStatusByDictionary(Dictionary<bool?, string> dct, object value)
        {
            if (value == null)
                return string.Empty;
            bool? key = value as bool?;
            if (key == null)
                return string.Empty;
            if (key.HasValue && dct.ContainsKey(key.Value))
                return dct[key];
            else
                return null;
        }

        public static string GetDateMinuteString(DateTime? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value.ToString("dd/MM/yyyy HH:mm");
        }

        public static string GetMinuteDateString(DateTime? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value.ToString("HH:mm dd/MM/yyyy");
        }

        public static string GetDateTimeString(DateTime? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value.ToString("dd/MM/yyyy hh:mm:ss");
        }

        public static string GetTimeString(DateTime? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value.ToString("HH:mm");
        }

        public static string GetMonthString(DateTime? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value.ToString("MM/yyyy");
        }

        public static string GetString(int? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.ToString();
        }

        public static string GetString(decimal? value, int digitNumber = 2)
        {
            if (value == null)
                return string.Empty;
            else
                //return String.Format("{0:N2}", value.Value);
                return SoftMart.Core.Utilities.Utility.GetDecimalString(value.Value, digitNumber);
        }

        public static string GetString(double? value, int digitNumber = 2)
        {
            if (value == null)
                return string.Empty;
            else
                return SoftMart.Core.Utilities.Utility.GetDoubleString(value.Value, digitNumber);
        }

        public static string GetString(Single? value)
        {
            if (value == null)
                return string.Empty;
            else
            {
                decimal temp = (decimal)value;
                //return String.Format("{0:N2}", value.Value);
                return SoftMart.Core.Utilities.Utility.GetDecimalString(temp);
            }
        }

        public static string GetString(bool? value)
        {
            if (value == null)
                return string.Empty;
            else
                return value.Value ? "True" : "False";
        }

        //tra về tiền định dạng 2,000.00 
        //cho nghiệp vụ kế toán áp dụng cho bản in hạch toán
        public static string Format_Currency_ForAccounting(decimal amount, int digitNumber = 0)
        {
            string result = string.Empty;
            try
            {
                if (digitNumber == 0)
                {
                    result = amount.ToString("N0");
                }
                else
                {
                    int zezo = 0;
                    result = string.Format("{0}.{1}", amount.ToString("N0"), zezo.ToString("D" + digitNumber));
                }
            }
            catch (Exception)
            { }
            return result;
        }

        #endregion

        #region Conversion methods

        public static bool? GetNullableBool(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            bool bValue;
            if (bool.TryParse(value, out bValue))
                return bValue;

            return null;
        }

        public static int GetInt(string value)
        {
            return int.Parse(value);
        }

        public static int? GetNullableInt(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            int intValue;
            if (int.TryParse(value, out intValue))
                return intValue;

            return null;
        }

        public static long? GetNullableLong(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            long longValue;
            if (long.TryParse(value, out longValue))
                return longValue;

            return null;
        }

        public static Decimal? GetNullableDecimal(string value)
        {
            return SoftMart.Core.Utilities.Utility.GetNullableDecimal(value);
        }

        public static Double? GetNullableDouble(string value)
        {
            double db;
            bool isValid = Double.TryParse(value, out db);
            if (!string.IsNullOrEmpty(value) && isValid)
            {
                return db;
            }
            else
                return null;
        }

        public static DateTime? GetNullableDate(string value)
        {
            DateTime dt;
            bool isValid = DateTime.TryParseExact(value, DATE_FORMAT, null, System.Globalization.DateTimeStyles.None, out dt);
            if (!string.IsNullOrEmpty(value) && isValid)
            {
                return dt;
            }
            else
                return null;
        }

        /// <summary>
        /// Lấy giá trị Date từ Excel theo format: dd.MM.yyyy
        /// VD: 05.11.2017
        /// </summary>
        /// <param name="value">"05.11.2017"</param>
        /// <returns></returns>
        public static DateTime? GetDateFromExcelImport(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            value = value.Replace(" ", string.Empty);
            value = value.Replace("'", string.Empty);

            string[] dateFormats = new string[]
            {
                "dd.MM.yyyy",
                "d.MM.yyyy",
                "dd.M.yyyy",
                "d.M.yyyy"
            };

            DateTime dt;
            bool isValid = DateTime.TryParseExact(value, dateFormats, null, System.Globalization.DateTimeStyles.None, out dt);

            if (isValid)
            {
                return dt;
            }
            else
                return null;
        }

        public static DateTime? GetNullableDateTime(string value, string format = "dd/MM/yyyy hh:mm:ss")
        {
            DateTime dt;
            bool isValid = DateTime.TryParseExact(value, format, null, System.Globalization.DateTimeStyles.None, out dt);
            if (!string.IsNullOrEmpty(value) && isValid)
            {
                return dt;
            }
            else
                return null;
        }

        public static string NullIfEmptyString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;
            else
                return value.Trim();
        }

        public static string GetUrl(string documentUrl, string absoluteUri, string pathQuery)
        {
            //Lay Url ca query, localhost:1206/UI/Anouncements/Display?id=7 

            //Lay root url, localhost:1206
            absoluteUri = absoluteUri.Replace(pathQuery, "");

            if (string.IsNullOrEmpty(documentUrl))
                return absoluteUri;

            documentUrl = documentUrl.Replace(@"\", "/");
            return string.Format("{0}{1}", absoluteUri, documentUrl);
        }

        public static TimeSpan? GetTimeSpan(string input)
        {
            TimeSpan tmpTime;
            if (TimeSpan.TryParse(input, out tmpTime))
            {
                return tmpTime;
            }
            return null;
        }
        #endregion

        #region Dictionary utils

        public static string GetDictionaryValue<T>(Dictionary<T, string> dicInput, T key)
        {
            if (key != null && dicInput.ContainsKey(key))
                return dicInput[key];

            return string.Empty;
        }

        public static string GetDictionaryValue(Dictionary<int, string> dicInput, int? key)
        {
            if (key != null && dicInput.ContainsKey(key.Value))
                return dicInput[key.Value];

            return string.Empty;
        }

        public static string GetDictionaryValue(Dictionary<bool, string> dicInput, bool? key)
        {
            if (key != null && dicInput.ContainsKey(key.Value))
                return dicInput[key.Value];

            return string.Empty;
        }

        public static T GetKeyByValueDictionary<T>(Dictionary<T, string> dicInput, string value)
        {
            if (!string.IsNullOrEmpty(value))
                return dicInput.FirstOrDefault(d => d.Value.Equals(value)).Key;

            return default(T);
        }

        #endregion

        private const char CHAR_ESCAPE = (char)13;
        public static string Encrypt(int? empID, params int[] refID)
        {
            string strRefID = string.Join(CHAR_ESCAPE.ToString(), refID);

            string anyString = Guid.NewGuid().ToString();
            string plainText = string.Format("{0}#{1}#{2}", empID, anyString, strRefID);

            byte[] arrData = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(arrData);
        }

        public static void Decrypt(string cypherText, out int? empID, out int[] refID)
        {
            empID = null;
            refID = null;

            if (string.IsNullOrWhiteSpace(cypherText))
                return;

            byte[] arrData = Convert.FromBase64String(cypherText);
            string plainText = System.Text.Encoding.UTF8.GetString(arrData);
            string[] arrToken = plainText.Split(new char[] { '#' });


            if (arrToken.Length == 3)
            {
                int result = 0;
                if (int.TryParse(arrToken[0], out result))
                    empID = result;

                //if (int.TryParse(arrToken[2], out result))
                //    refID = result;

                string strRefID = arrToken[2];
                string[] strRefIDs = strRefID.Split(new char[] { CHAR_ESCAPE }, StringSplitOptions.RemoveEmptyEntries);
                refID = strRefIDs.Select(c => int.Parse(c)).ToArray();
            }
        }

        public static string Encrypt(int? empID, int? refID)
        {
            string anyString = Guid.NewGuid().ToString();
            string plainText = string.Format("{0}#{1}#{2}", empID, anyString, refID);

            byte[] arrData = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(arrData);
        }

        public static void Decrypt(string cypherText, out int? empID, out int? refID)
        {
            empID = null;
            refID = null;

            if (string.IsNullOrWhiteSpace(cypherText))
                return;

            byte[] arrData = Convert.FromBase64String(cypherText);
            string plainText = System.Text.Encoding.UTF8.GetString(arrData);
            string[] arrToken = plainText.Split(new char[] { '#' });


            if (arrToken.Length == 3)
            {
                int result = 0;
                if (int.TryParse(arrToken[0], out result))
                    empID = result;

                if (int.TryParse(arrToken[2], out result))
                    refID = result;
            }
        }

        public static string EncryptAES(string txtToEncrypt, string key, string iv, PaddingMode paddingMode = PaddingMode.Zeros)
        {
            byte[] txtBytes = ASCIIEncoding.ASCII.GetBytes(txtToEncrypt);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();

            encdec.Key = GetSha1Key(key);
            encdec.IV = ASCIIEncoding.ASCII.GetBytes(iv);
            encdec.Padding = paddingMode;

            //encdec.BlockSize = blockSize;
            //encdec.KeySize = keySize;
            //encdec.Key = ASCIIEncoding.ASCII.GetBytes(key);

            //if (cipherMode == "CBC")
            //    encdec.Mode = CipherMode.CBC;
            //else if (cipherMode == "ECB")
            //    encdec.Mode = CipherMode.ECB;

            ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);

            byte[] enc = icrypt.TransformFinalBlock(txtBytes, 0, txtBytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(enc);
        }

        public static string DecryptAES(string encrypt, string key, string iv, PaddingMode paddingMode = PaddingMode.Zeros)
        {
            byte[] encbytes = Convert.FromBase64String(encrypt);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();

            encdec.Key = GetSha1Key(key);
            encdec.IV = ASCIIEncoding.ASCII.GetBytes(iv);
            encdec.Padding = paddingMode;
            // encdec.Padding = PaddingMode.PKCS7;

            //encdec.BlockSize = blockSize;
            //encdec.KeySize = keySize;
            //encdec.Key = ASCIIEncoding.ASCII.GetBytes(key);

            //if (cipherMode == "CBC")
            //    encdec.Mode = CipherMode.CBC;
            //else if (cipherMode == "ECB")
            //    encdec.Mode = CipherMode.ECB;

            ICryptoTransform icrypt = encdec.CreateDecryptor(encdec.Key, encdec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();

            return ASCIIEncoding.UTF8.GetString(dec);
        }

        private static byte[] GetSha1Key(string pass)
        {
            byte[] sKey = System.Text.Encoding.UTF8.GetBytes(pass);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] bKey = sha.ComputeHash(sKey);
            byte[] Key = new byte[16];

            Array.Copy(bKey, 0, Key, 0, 16);

            return Key;

            //System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
            //System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            //byte[] combined = encoder.GetBytes(key);
            //hash.ComputeHash(combined);

            ////byte[16];
            ////return hash.Hash;
            ////string rethash = Convert.ToBase64String(hash.Hash);
            ////return rethash.Substring(0, 16);

            //byte[] bKey;
            //SHA1 sha = new SHA1CryptoServiceProvider();
            //bKey = sha.ComputeHash(combined);
            //byte[] result = new byte[16];

            //Array.Copy(bKey, 0, result, 0, 16);

            //return result;         
        }

        public static decimal Sum(params decimal?[] values)
        {
            decimal? result = values.Sum(c => c);
            return result == null ? 0 : result.Value;
        }

        /// <summary>
        /// Lấy folder hiện tại của ứng dụng
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyFolder()
        {
            string assemblyFolder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return assemblyFolder;
        }

        /// <summary>
        /// Tạo group cho các item liên tiếp
        /// </summary>
        /// <param name="lstItem">Các item rời rạc</param>
        /// <returns>Tuple 2 phan tu T1 = Min, T2 = Max</returns>
        public static List<(int min, int max)> BuildSequenceGroup(List<int> lstItem)
        {
            if (lstItem == null
                || lstItem.Count == 0)
            {
                return new List<(int, int)>();
            }

            if (lstItem.Count == 1)
            {
                return new List<(int, int)>() { (lstItem[0], lstItem[0]) };
            }

            // Sắp xếp tăng dần
            lstItem.Sort();

            int min, max;
            List<(int, int)> result = new List<(int, int)>();

            min = max = lstItem[0]; // Gán min, max bằng giá trị đầu tiên

            // VD. 1346
            for (int i = 1; i < lstItem.Count; i++)
            {
                if (lstItem[i] - lstItem[i - 1] != 1) // Có sự nhảy cóc  
                {
                    result.Add((min, max));

                    min = max = lstItem[i]; // Gán lại min bằng phần tử hiện tại
                }
                else // Nếu vẫn liền mạch
                {
                    max = lstItem[i];
                }

                if (i == lstItem.Count - 1) // Phần tử cuối cùng
                {
                    result.Add((min, max));
                }
            }

            return result;
        }

        #region Name To Tag
        public static string NameToTag(string strName)
        {
            if (string.IsNullOrWhiteSpace(strName))
            {
                return string.Empty;
            }

            strName = strName.ToLower();
            string strReturn = "";
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strName, "[^\\w\\s]", string.Empty).Replace(" ", "-").ToLower();
            string strFormD = strReturn.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }
        #endregion

        #region Remove Unicode

        public static string BuildT24AllowedText(string strString)
        {
            if (string.IsNullOrWhiteSpace(strString))
            {
                return string.Empty;
            }

            string result = strString.Normalize(NormalizationForm.FormD);

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            result = regex.Replace(result, string.Empty);

            result = result.Replace("đ", "d");
            result = result.Replace("Đ", "D");
            result = result.Replace("-", ".");
            result = result.Replace("_", ".");

            return result;
        }

        #endregion
        #region Remove Unicode
        public static string RemoveUnicode(string strString)
        {
            if (string.IsNullOrWhiteSpace(strString))
            {
                return string.Empty;
            }
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string strFormD = strString.Normalize(NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }
        #endregion
        public static string GetDecimalNoThousandDigit(decimal dValue, int numberDecimalPoint = 0)
        {
            string s = GetString(dValue, numberDecimalPoint);
            //s = s.Trim(new char[] { '0', '.' });
            s = s.Replace(",", string.Empty);

            return s;
            //return dValue.ToString("c" + numberDecimalPoint.ToString());
        }

        #region đọc tiền

        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
        // Hàm đọc số thành chữ
        public static string DocTienBangChu(decimal SoTien, string strTail)
        {
            int lan, i;
            decimal so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng !";
            if (SoTien > 0)
            {
                so = SoTien;
            }
            else
            {
                so = -SoTien;
            }
            //Kiểm tra số quá lớn
            if (SoTien > 8999999999999999)
            {
                SoTien = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
            {
                lan = 5;
            }
            else if (ViTri[4] > 0)
            {
                lan = 4;
            }
            else if (ViTri[3] > 0)
            {
                lan = 3;
            }
            else if (ViTri[2] > 0)
            {
                lan = 2;
            }
            else if (ViTri[1] > 0)
            {
                lan = 1;
            }
            else
            {
                lan = 0;
            }
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + strTail;
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        // Hàm đọc số có 3 chữ số
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }
        #endregion
    }
}
