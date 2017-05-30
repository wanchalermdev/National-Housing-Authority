using System;
using System.Linq;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using Test.Data;
using System.Globalization;
using System.Threading;


namespace Test.Function
{
    public class ConvertFunction
    {
        public string DateToThai(string date)
        {
            string dateReturn = "";
            DateTime dateThai = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            dateReturn = dateThai.ToString("dd MMMM yyyy");
            return dateReturn;
        }

        public string Thai(string money)
        {
            string[] split = money.Split('.');
            char[] myArray = split[0].ToCharArray();
            string myMoney = "";
            int state = 0;
            if (split[0].Length == 7)
            {
                for (int i = 0; i < 1; i++)  //ล้าน
                {
                    myMoney += myArray[i];
                    state = 1;
                }
            }
            else if (split[0].Length == 8)
            {
                for (int i = 0; i < 2; i++)  //สิบล้าน
                {
                    myMoney += myArray[i];
                    state = 2;
                }
            }
            else if (split[0].Length == 9) //ร้อยล้าน
            {
                for (int i = 0; i < 3; i++)
                {
                    myMoney += myArray[i];
                    state = 3;
                }
            }
            else if (split[0].Length == 10)  //พันล้าน
            {
                for (int i = 0; i < 4; i++)
                {
                    myMoney += myArray[i];
                    state = 4;
                }
            }
            else if (split[0].Length == 11) //หมื่นล้าน
            {
                for (int i = 0; i < 5; i++)
                {
                    myMoney += myArray[i];
                    state = 5;
                }
            }
            else if (split[0].Length == 12) //แสนล้าน
            {
                for (int i = 0; i < 6; i++)
                {
                    myMoney += myArray[i];
                    state = 6;
                }
            }
            else
            {
                return "";
            }
            string before = ThaiBaht2(myMoney);
            before += "ล้าน";
            string after = money.Substring(state, 9);
            before += ThaiBaht(after);
            return before;
        }
        private static string ThaiBaht2(string txt)
        {
            if (txt == "1")
            {
                return "หนึ่ง";
            }
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }

                if (decVal == "00")
                { }

                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }
        private static string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน", "สิบล้าน", "ร้อยล้าน", "พันล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }
    }
}