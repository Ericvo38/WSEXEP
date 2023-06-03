using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WTERP
{
    public class CN
    {
        public static string str = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        public static String getDateNowE()
        {
            string today = "";
                today =
                "Year " + DateTime.Now.Year.ToString() +
                " Month " + DateTime.Now.Month.ToString() +
                " Day " + DateTime.Now.Day.ToString();
            return today;
        }
        //Get Time
        public static string getTimeNowE()
        {
            string timenow = "";
            timenow = "Now Hour: " + DateTime.Now.Hour.ToString() + " Minute " + DateTime.Now.Minute.ToString() + " seconds " + DateTime.Now.Second.ToString();
            return timenow;
        }
        public static String getDateNow()
        {
            string today = "";
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                 today =
                 "Năm " + DateTime.Now.Year.ToString() +
                 " Tháng " + DateTime.Now.Month.ToString() +
                 " Ngày " + DateTime.Now.Day.ToString();
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                 today =
                  "Năm " + DateTime.Now.Year.ToString() +
                  " Tháng " + DateTime.Now.Month.ToString() +
                  " Ngày " + DateTime.Now.Day.ToString();
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                 today =
                 "Year " + DateTime.Now.Year.ToString() +
                 " Month " + DateTime.Now.Month.ToString() +
                 " Day " + DateTime.Now.Day.ToString();
            }
            if (DataProvider.LG.rdChina == true)
            {
                 today =
                  "五 " + DateTime.Now.Year.ToString() +
                  " 月 " + DateTime.Now.Month.ToString() +
                  " 日 " + DateTime.Now.Day.ToString();
            }
            return today;
        }
        //Get Time
        public static string getTimeNow()
        {
            string timenow = "";
            if (DataProvider.LG.rdVietNam == false && DataProvider.LG.rdEnglish == false && DataProvider.LG.rdChina == false)
            {
                timenow = "Bây Giờ : " + DateTime.Now.Hour.ToString() + " Phút " + DateTime.Now.Minute.ToString() + " Giây " + DateTime.Now.Second.ToString();
            }
            if (DataProvider.LG.rdVietNam == true)
            {
                 timenow = "Bây Giờ : " + DateTime.Now.Hour.ToString() + " Phút " + DateTime.Now.Minute.ToString() + " Giây " + DateTime.Now.Second.ToString();
            }
            if (DataProvider.LG.rdEnglish == true)
            {
                 timenow = "Now Hour: " + DateTime.Now.Hour.ToString() + " Minute " + DateTime.Now.Minute.ToString() + " seconds " + DateTime.Now.Second.ToString();
            }
            if (DataProvider.LG.rdChina == true)
            {
                 timenow = "現在 : " + DateTime.Now.Hour.ToString() + " 分鐘 " + DateTime.Now.Minute.ToString() + " 第二 " + DateTime.Now.Second.ToString();
            }
            return timenow;
        }
    }

}
