using System;
using System.Data;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace My
{
    /// <summary>
    /// 有關到頁面使用的類別
    /// </summary>
    /// <remarks></remarks>
    public class WebForm
    {
        #region 輸出javaScript到網頁上


        /// <summary>
        /// 輸出javaScript到網頁上
        /// </summary>
        /// <param name="JavaScript">要輸出到頁面上的JavaScript，不用加 &lt;script&gt;與 &lt;/script&gt;</param>
        /// <param name="page">就傳入Page就對了</param>
        /// <remarks></remarks>
        static public void doJavaScript(string JavaScript)
        {
            string script = "";
            string key = Guid.NewGuid().ToString();
            script += JavaScript;
            ((Page)HttpContext.Current.CurrentHandler).ClientScript.RegisterStartupScript(typeof(string), key, script, true);
        }
        #endregion

        #region 輸入文字方塊的文字轉成HTML
        /// <summary>
        /// 輸入文字方塊的文字轉成HTML
        /// </summary>
        /// <param name="fstr">要轉換的文字</param>
        /// <returns>回傳HTML用的文字</returns>
        /// <remarks></remarks>

        static public string TXT2HTML(string fstr)
        {
            fstr = fstr.Replace(">", "&gt;");
            fstr = fstr.Replace(">", "&gt;");
            fstr = fstr.Replace("<", "&lt;");
            fstr = fstr.Replace("\"", "&quot;");
            fstr = fstr.Replace("\'", "&quot;");
            fstr = fstr.Replace("\n", "<br>");
            fstr = fstr.Replace("|", "&brvbar;");
            fstr = fstr.Replace(" ", "&nbsp;");
            fstr = fstr.Replace("[", "<");
            fstr = fstr.Replace("]", ">");
            fstr = fstr.Replace("url=", "a href=");
            fstr = fstr.Replace("/url", "/a");
            return fstr;
        }



        #endregion

        #region 限制字數的函式，適用於抓取資料庫資料，繫節時使用，會把NULL值換成空白顯示。
        /// <summary>
        /// 限制字數的函式，適用於抓取資料庫資料，繫節時使用，會把NULL值換成空白顯示。
        /// </summary>
        /// <param name="LongString">要被限制的字串</param>
        /// <param name="intLimitCount">要限制幾個字</param>
        /// <param name="exString">非必要選項，若傳入可更換超過的字數樣式，預設為...</param>
        /// <returns>回傳字串結果</returns>
        /// <remarks>繫節時使用，會把NULL值換成空白顯示。</remarks>
        static public string limitWord(object LongString, int intLimitCount)
        {
            if (LongString != null)
            {
                string strLongWord = (string)LongString;
                if (strLongWord.Length > intLimitCount)
                {
                    return ((string)(LongString)).Substring(0, intLimitCount) + "...";
                }
                else
                {
                    return strLongWord;
                }
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region "自訂分頁語法產生Function "
        /// <summary>
        ///自訂分頁語法產生Function 
        /// </summary>
        /// <param name="CurrentPage">目前第幾頁</param>
        /// <param name="PageCount">一頁有幾筆</param>
        /// <param name="PrimaryKey">PrimaryKey</param>
        /// <param name="SelectField">要回傳的欄位</param>
        /// <param name="JoinString">要查詢的資料表或是Join字串</param>
        /// <param name="whereString">要查詢的條件與排序方式</param>
        /// <returns>回傳分頁SQL語法</returns>
        /// <remarks></remarks>
        static public string CustomPageSQL(int CurrentPage, int PageCount, string PrimaryKey, string SelectField, string JoinString, string whereString)
        {

            int TopCount = (CurrentPage - 1) * PageCount;
            string TempSqlString = "SELECT top ##PageCount## ##SelectField## FROM  ##JoinString## where ##PrimaryKey## Not IN(SELECT top ##TopCount##  ##PrimaryKey## FROM  ##JoinString## where 1=1 ##whereString##) ##whereString##";
            string strPageCount = PageCount.ToString();
            string strTopCount = TopCount.ToString();
            TempSqlString = TempSqlString.Replace("##PageCount##", strPageCount);
            TempSqlString = TempSqlString.Replace("##SelectField##", SelectField);
            TempSqlString = TempSqlString.Replace("##JoinString##", JoinString);
            TempSqlString = TempSqlString.Replace("##PrimaryKey##", PrimaryKey);
            TempSqlString = TempSqlString.Replace("##TopCount##", strTopCount);
            if (whereString != "")
            {
                whereString = "and " + whereString;
            }

            TempSqlString = TempSqlString.Replace("##whereString##", whereString);
            return TempSqlString;
        }

        #endregion

        #region "取得自訂分頁的總筆數的SQL語法"
        /// <summary>
        /// 取得自訂分頁的總筆數的SQL語法
        /// </summary>
        /// <param name="PrimaryKey">PrimaryKey</param>
        /// <param name="JoinString">要查詢的資料表或是Join字串</param>
        /// <param name="whereString">要查詢的條件與排序方式</param>
        /// <returns>取得自訂分頁的總筆數的SQL語法</returns>
        /// <remarks></remarks>
        static public string CustomPageRecordCount(string PrimaryKey, string JoinString, string whereString)
        {
            string TempSqlString = "SELECT   COUNT(##PrimaryKey##) AS Number FROM ##JoinString## WHERE 1=1 ##whereString##";
            TempSqlString = TempSqlString.Replace("##JoinString##", JoinString);
            TempSqlString = TempSqlString.Replace("##PrimaryKey##", PrimaryKey);
            if (whereString != "")
            {
                whereString = "and " + whereString;
            }
            TempSqlString = TempSqlString.Replace("##whereString##", whereString);
            return TempSqlString;
        }

        #endregion


        #region "把該日期轉成民國年.月.日格式"
        /// <summary>
        /// 把該日期轉成民國年.月.日格式
        /// </summary>
        /// <param name="dat">要轉換的日期</param>
        /// <returns>回傳民國年.月.日格式</returns>
        static public string Date2ROCFormat(DateTime dat)
        {
            return (dat.Year - 1911).ToString("000") + "." + dat.Month.ToString("00") + "." + dat.Day.ToString("00");
        }
        #endregion

        #region "把該日期轉成民國XX年XX月XX日格式"
        /// <summary>
        /// 把該日期轉成民國XX年XX月XX日格式
        /// </summary>
        /// <param name="dat">要轉換的日期</param>
        /// <returns>回傳民國XX年XX月XX日格式</returns>
        /// <remarks></remarks>
        static public string Date2CROCFormat(DateTime dat)
        {
            return "民國" + (dat.Year - 1911).ToString() + "年" + dat.Month.ToString() + "月" + dat.Day.ToString() + "日";
        }
        #endregion

        #region "把該日期轉成民國XX年XX月XX日 星期X 格式"
        /// <summary>
        /// 把該日期轉成民國XX年XX月XX日 星期X 格式
        /// </summary>
        /// <param name="dat">要轉換的日期</param>
        /// <returns>回傳民國XX年XX月XX日 星期X</returns>
        /// <remarks></remarks>
        static public string Date2CrocWeekFormat(DateTime dat)
        {
            string Week = "";
            switch (dat.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    Week = "日";
                    break;
                case DayOfWeek.Monday:
                    Week = "一";
                    break;
                case DayOfWeek.Tuesday:
                    Week = "二";
                    break;
                case DayOfWeek.Wednesday:
                    Week = "三";
                    break;
                case DayOfWeek.Thursday:
                    Week = "四";
                    break;
                case DayOfWeek.Friday:
                    Week = "五";
                    break;
                case DayOfWeek.Saturday:
                    Week = "六";
                    break;
            }
            return String.Format("民國{0}年{1}月{2}日 星期{3}", dat.Year - 1911, dat.Month, dat.Day, Week);
        }
        #endregion


        #region "舉世無敵縮圖程式"
        /// <summary>
        /// 舉世無敵縮圖程式(多載)
        /// 1.會自動判斷是比較高還是比較寬，以比較大的那一方決定要縮的尺寸
        /// 2.指定寬度，等比例縮小
        /// 3.指定高度，等比例縮小
        /// </summary>
        /// <param name="name">原檔檔名</param>
        /// <param name="source">來源路徑</param>
        /// <param name="target">目的路徑</param>
        /// <param name="suffix">縮圖辯識符號</param>
        /// <param name="MaxWidth">指定要縮的寬度</param>
        /// <param name="MaxHight">指定要縮的高度</param>
        /// <remarks></remarks>
        static public void GenerateThumbnailImage(string name, string source, string target, string suffix, int MaxWidth, int MaxHight)
        {
            System.Drawing.Image baseImage = System.Drawing.Image.FromFile(source + "\\" + name);
            Single ratio = 0.0F; //存放縮圖比例
            Single h = baseImage.Height;//圖像原尺寸高度
            Single w = baseImage.Width;//圖像原尺寸寬度
            int ht;//圖像縮圖後高度
            int wt; //圖像縮圖後寬度
            if (w > h)
            {//圖像比較寬
                ratio = MaxWidth / w;//計算寬度縮圖比例
                if (MaxWidth < w)
                {
                    ht = Convert.ToInt32(ratio * h);
                    wt = MaxWidth;
                }
                else
                {
                    ht = Convert.ToInt32(baseImage.Height);
                    wt = Convert.ToInt32(baseImage.Width);
                }
            }
            else
            {//比較高
                ratio = MaxHight / h;//計算寬度縮圖比例
                if (MaxHight < h)
                {
                    ht = MaxHight;
                    wt = Convert.ToInt32(ratio * w);
                }
                else
                {
                    ht = Convert.ToInt32(baseImage.Height);
                    wt = Convert.ToInt32(baseImage.Width);
                }
            }
            string Newname = target + "\\" + suffix + name;
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
            System.Drawing.Graphics graphic = Graphics.FromImage(img);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.DrawImage(baseImage, 0, 0, wt, ht);
            img.Save(Newname);

            img.Dispose();
            graphic.Dispose();
            baseImage.Dispose();

        }

        /// <summary>
        /// 舉世無敵縮圖程式(多載)
        /// 1.會自動判斷是比較高還是比較寬，以比較大的那一方決定要縮的尺寸
        /// 2.指定寬度，等比例縮小
        /// 3.指定高度，等比例縮小
        /// </summary>
        /// <param name="name">原檔檔名</param>
        /// <param name="source">來源檔案的Stream,可接受上傳檔案</param>
        /// <param name="target">目的路徑</param>
        /// <param name="suffix">縮圖辯識符號</param>
        /// <param name="MaxWidth">指定要縮的寬度</param>
        /// <param name="MaxHight">指定要縮的高度</param>
        /// <remarks></remarks>
        static public void GenerateThumbnailImage(string name, System.IO.Stream source, string target, string suffix, int MaxWidth, int MaxHight)
        {
            System.Drawing.Image baseImage = System.Drawing.Image.FromStream(source);
            Single ratio = 0.0F; //存放縮圖比例
            Single h = baseImage.Height; //圖像原尺寸高度
            Single w = baseImage.Width;  //圖像原尺寸寬度
            int ht; //圖像縮圖後高度
            int wt;//圖像縮圖後寬度
            if (w > h)
            {
                ratio = MaxWidth / w; //計算寬度縮圖比例
                if (MaxWidth < w)
                {
                    ht = Convert.ToInt32(ratio * h);
                    wt = MaxWidth;

                }
                else
                {
                    ht = Convert.ToInt32(baseImage.Height);
                    wt = Convert.ToInt32(baseImage.Width);

                }
            }
            else
            {
                ratio = MaxHight / h; //計算寬度縮圖比例
                if (MaxHight < h)
                {
                    ht = MaxHight;
                    wt = Convert.ToInt32(ratio * w);
                }
                else
                {
                    ht = Convert.ToInt32(baseImage.Height);
                    wt = Convert.ToInt32(baseImage.Width);
                }
            }
            string Newname = target + "\\" + suffix + name;
            System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
            System.Drawing.Graphics graphic = Graphics.FromImage(img);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.DrawImage(baseImage, 0, 0, wt, ht);
            img.Save(Newname);

            img.Dispose();
            graphic.Dispose();
            baseImage.Dispose();

        }
        /// <summary>
        /// 舉世無敵縮圖程式(指定寬度，等比例縮小)
        /// </summary>
        /// <param name="name">原檔檔名</param>
        /// <param name="source">來源路徑</param>
        /// <param name="target">目的路徑</param>
        /// <param name="suffix">縮圖辯識符號</param>
        /// <param name="MaxWidth">指定要縮的寬度</param>
        /// <remarks></remarks>
        static public void GenerateThumbnailImage(int MaxWidth, string name, string source, string target, string suffix)
        {
            System.Drawing.Image baseImage = System.Drawing.Image.FromFile(source + "\\" + name);
            Single ratio = 0.0F; //存放縮圖比例
            Single h = baseImage.Height; //圖像原尺寸高度
            Single w = baseImage.Width; //圖像原尺寸寬度
            int ht; //圖像縮圖後高度
            int wt; //圖像縮圖後寬度
            ratio = MaxWidth / w;//計算寬度縮圖比例
            if (MaxWidth < w)
            {
                ht = Convert.ToInt32(ratio * h);
                wt = MaxWidth;
            }
            else
            {
                ht = Convert.ToInt32(baseImage.Height);
                wt = Convert.ToInt32(baseImage.Width);
            }
            string Newname = target + "\\" + suffix + name;

            System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
            System.Drawing.Graphics graphic = Graphics.FromImage(img);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.DrawImage(baseImage, 0, 0, wt, ht);
            img.Save(Newname, System.Drawing.Imaging.ImageFormat.Jpeg);

            img.Dispose();
            graphic.Dispose();
            baseImage.Dispose();
        }
        /// <summary>
        /// 舉世無敵縮圖程式(指定高度，等比例縮小)
        /// </summary>
        /// <param name="name">原檔檔名</param>
        /// <param name="source">來源路徑</param>
        /// <param name="target">目的路徑</param>
        /// <param name="suffix">縮圖辯識符號</param>
        /// <param name="MaxHight">指定要縮的高度</param>
        /// <remarks></remarks>
        static public void GenerateThumbnailImage(string name, string source, string target, string suffix, int MaxHight)
        {
            System.Drawing.Image baseImage = System.Drawing.Image.FromFile(source + "\\" + name);
            Single ratio = 0.0F;//存放縮圖比例
            Single h = baseImage.Height; //圖像原尺寸高度
            Single w = baseImage.Width;  //圖像原尺寸寬度
            int ht; //圖像縮圖後高度
            int wt; //圖像縮圖後寬度
            ratio = MaxHight / h; //計算寬度縮圖比例
            if (MaxHight < h)
            {
                ht = MaxHight;
                wt = Convert.ToInt32(ratio * w);

            }
            else
            {
                ht = Convert.ToInt32(baseImage.Height);
                wt = Convert.ToInt32(baseImage.Width);

            }
            string Newname = target + "\\" + suffix + name;

            System.Drawing.Bitmap img = new System.Drawing.Bitmap(wt, ht);
            System.Drawing.Graphics graphic = Graphics.FromImage(img);
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphic.DrawImage(baseImage, 0, 0, wt, ht);
            img.Save(Newname);

            img.Dispose();
            graphic.Dispose();
            baseImage.Dispose();

        }
        #endregion
        #region "加解密函式"
        /// <summary>
        /// TripleDES解密
        /// </summary>
        /// <param name="byteEncryption">要解密的Byte()</param>
        /// <returns>解密後的字串</returns>
        /// <remarks></remarks>
        static public string TripleDESDecoding(byte[] byteEncryption)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            byte[] IV = { 228, 7, 39, 133, 31, 159, 107, 181 };
            byte[] key = { 168, 159, 239, 4, 198, 215, 9, 253, 248, 56, 191, 68, 140, 68, 230, 130, 27, 162, 182, 240, 52, 116, 130, 18 };
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, TDES.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            byte[] strInput = byteEncryption;
            cs.Write(strInput, 0, strInput.Length);
            cs.FlushFinalBlock();
            return System.Text.Encoding.Unicode.GetString((byte[])ms.ToArray());

        }
        /// <summary>
        /// TripleDES加密
        /// </summary>
        /// <param name="noEncryptionString">要加密的字串</param>
        /// <returns>加密後的Byte()</returns>
        /// <remarks></remarks>
        static public byte[] TripleDESEncryption(string noEncryptionString)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            byte[] IV = { 228, 7, 39, 133, 31, 159, 107, 181 };
            byte[] key = { 168, 159, 239, 4, 198, 215, 9, 253, 248, 56, 191, 68, 140, 68, 230, 130, 27, 162, 182, 240, 52, 116, 130, 18 };
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, TDES.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            byte[] strInput = System.Text.Encoding.Unicode.GetBytes(noEncryptionString);
            cs.Write(strInput, 0, strInput.Length);
            cs.FlushFinalBlock();
            return ms.ToArray();

        }

        #region "加密函式"
        static public string Eecoding(string cryString)
        {
            string strReturn = "";
            char[] cryChar = cryString.ToCharArray();
            for (int i = 0; (i <= cryChar.Length - 1); i++)
            {
                strReturn += EncodingMyCode(Asc(cryChar[i]));
                Random RandomNumber = new Random();
                double x = (90 - 65) + RandomNumber.NextDouble() * 90;
                strReturn += ((char)(x));
            }
            return strReturn;
        }
        #endregion

        #region "加密字碼轉換對應表"
        private static char EncodingMyCode(byte bytChar)
        {
            switch (bytChar)
            {
                case 48:
                    return 'z';
                    
                case 49:
                    return 'B';
                    
                case 50:
                    return 'a';
                    
                case 51:
                    return 'U';
                    
                case 52:
                    return 'D';
                    
                case 53:
                    return 'e';
                    
                case 54:
                    return 'W';
                    
                case 55:
                    return 'A';
                    
                case 56:
                    return 'K';
                    
                case 57:
                    return '3';
                    
                case 65:
                    return 'L';
                    
                case 66:
                    return 'f';
                    
                case 67:
                    return 'T';
                    
                case 68:
                    return 'o';
                    
                case 69:
                    return '4';
                    
                case 70:
                    return 'n';
                    
                case 71:
                    return 'k';
                    
                case 72:
                    return 'C';
                    
                case 73:
                    return 'r';
                    
                case 74:
                    return 'b';
                    
                case 75:
                    return 'P';
                    
                case 76:
                    return 's';
                    
                case 77:
                    return 'V';
                    
                case 78:
                    return '2';
                    
                case 79:
                    return 'c';
                    
                case 80:
                    return 'Y';
                    
                case 81:
                    return 'u';
                    
                case 82:
                    return '9';
                    
                case 83:
                    return 'x';
                    
                case 84:
                    return 'N';
                    
                case 85:
                    return 'v';
                    
                case 86:
                    return '8';
                    
                case 87:
                    return 'l';
                    
                case 88:
                    return 'M';
                    
                case 89:
                    return 'g';
                    
                case 90:
                    return '0';
                    
                case 97:
                    return 'F';
                    
                case 98:
                    return 'q';
                    
                case 99:
                    return 'S';
                    
                case 100:
                    return '1';
                    
                case 101:
                    return 'd';
                    
                case 102:
                    return 'j';
                    
                case 103:
                    return 'G';
                    
                case 104:
                    return 'Q';
                    
                case 105:
                    return 'y';
                    
                case 106:
                    return 'Z';
                    
                case 107:
                    return '7';
                    
                case 108:
                    return 'w';
                    
                case 109:
                    return 'J';
                    
                case 110:
                    return 't';
                    
                case 111:
                    return 'X';
                    
                case 112:
                    return '6';
                    
                case 113:
                    return 'h';
                    
                case 114:
                    return 'R';
                    
                case 115:
                    return 'H';
                    
                case 116:
                    return 'm';
                    
                case 117:
                    return 'O';
                    
                case 118:
                    return '5';
                    
                case 119:
                    return 'p';
                    
                case 120:
                    return 'I';
                    
                case 121:
                    return 'i';
                    
                case 122:
                    return 'E';
                    
                default:
                    return ' ';
                    
            }
        }

        #endregion

        #region "解密函式"
        static public string Decoding(string EncryptionString)
        {
            char[] EcryChar = EncryptionString.ToCharArray();
            string newstring = "";
            for (int i = 0; (i <= EcryChar.Length - 1); i++)
            {
                if (((i % 2) != 0))
                {

                    newstring += Chr(DncodingMyCode(EcryChar[i - 1]));

                }
            }
            return newstring;
        }
        #endregion

        #region "解密字碼轉換對應表"
        private static byte DncodingMyCode(char bytChar)
        {
            switch (bytChar)
            {
                case 'z':
                    return 48;
                    
                case 'B':
                    return 49;
                    
                case 'a':
                    return 50;
                    
                case 'U':
                    return 51;
                    
                case 'D':
                    return 52;
                    
                case 'e':
                    return 53;
                    
                case 'W':
                    return 54;
                    
                case 'A':
                    return 55;
                    
                case 'K':
                    return 56;
                    
                case '3':
                    return 57;
                    // 'A~Z
                    
                case 'L':
                    return 65;
                    
                case 'f':
                    return 66;
                    
                case 'T':
                    return 67;
                    
                case 'o':
                    return 68;
                    
                case '4':
                    return 69;
                    
                case 'n':
                    return 70;
                    
                case 'k':
                    return 71;
                    
                case 'C':
                    return 72;
                    
                case 'r':
                    return 73;
                    
                case 'b':
                    return 74;
                    
                case 'P':
                    return 75;
                    
                case 's':
                    return 76;
                    
                case 'V':
                    return 77;
                    
                case '2':
                    return 78;
                    
                case 'c':
                    return 79;
                    
                case 'Y':
                    return 80;
                    
                case 'u':
                    return 81;
                    
                case '9':
                    return 82;
                    
                case 'x':
                    return 83;
                    
                case 'N':
                    return 84;
                    
                case 'v':
                    return 85;
                    
                case '8':
                    return 86;
                    
                case 'l':
                    return 87;
                    
                case 'M':
                    return 88;
                    
                case 'g':
                    return 89;
                    
                case '0':
                    return 90;
                    // a~z
                    
                case 'F':
                    return 97;
                    
                case 'q':
                    return 98;
                    
                case 'S':
                    return 99;
                    
                case '1':
                    return 100;
                    
                case 'd':
                    return 101;
                    
                case 'j':
                    return 102;
                    
                case 'G':
                    return 103;
                    
                case 'Q':
                    return 104;
                    
                case 'y':
                    return 105;
                    
                case 'Z':
                    return 106;
                    
                case '7':
                    return 107;
                    
                case 'w':
                    return 108;
                    
                case 'J':
                    return 109;
                    
                case 't':
                    return 110;
                    
                case 'X':
                    return 111;
                    
                case '6':
                    return 112;
                    
                case 'h':
                    return 113;
                    
                case 'R':
                    return 114;
                    
                case 'H':
                    return 115;
                    
                case 'm':
                    return 116;
                    
                case 'O':
                    return 117;
                    
                case '5':
                    return 118;
                    
                case 'p':
                    return 119;
                    
                case 'I':
                    return 120;
                    
                case 'i':
                    return 121;
                    
                case 'E':
                    return 122;
                    
                default:
                    return 0;
                    
            }
        }
        #endregion











        #endregion

        #region "Porting Common VB functions to C#: Asc()"
        public static byte Asc(char ch)
        {
            //Return the character value of the given character
            return Encoding.ASCII.GetBytes(new char[] { ch }, 0, 1)[0];
        }
        #endregion

        #region "Porting Common VB functions to C#: Chr()"
        public static Char Chr(int i)
        {
            //Return the character of the given character value
            return Convert.ToChar(i);
        }
        #endregion




        #region "判斷是否為數字"
        /// <summary>
        /// 判斷是否為數字
        /// </summary>
        /// <param name="inputData">輸入字串</param>
        /// <returns>bool</returns>
        public static bool IsNumber(string inputData)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(inputData, "^[0-9]+$");
        }
        #endregion

        #region "驗證E-mail格式"
        /// <summary>
        /// 驗證E-mail格式
        /// </summary>
        /// <param name="strIn">輸入E-mail</param>
        /// <returns></returns>
        public static bool IsValidEmail(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return System.Text.RegularExpressions.Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        #region "驗證手機格式"
        /// <summary>
        /// 驗證手機格式
        /// </summary>
        /// <param name="strIn">輸入手機</param>
        /// <returns></returns>
        public static bool IsValidCellPhone(string strIn)
        {
            // Return true if strIn is in valid e-mail format.
            return System.Text.RegularExpressions.Regex.IsMatch(strIn, @"^(09([0-9]){8})$");
        }
        #endregion

        #region "產生分頁控制項"
        /// <summary>
        /// 產生分頁控制項
        /// </summary>
        /// <param name="page">目前第幾頁</param>
        /// <param name="totalitems">共有幾筆</param>
        /// <param name="limit">一頁幾筆</param>
        /// <param name="adjacents">不知道，傳2~5都OK</param>
        /// <param name="targetpage">連結文字，例:pagination.aspx?foo=bar</param>
        /// <returns></returns>
        public static string getPaginationString(int page, int totalitems, int limit, int adjacents, string targetpage)
        {
            //defaults

            targetpage = targetpage.IndexOf('?') != -1 ? targetpage + "&" : targetpage + "?";
            string margin = "";
            string padding = "";
            //other vars
            int prev = page - 1;
            //previous page is page - 1
            int nextPage = page + 1;
            //nextPage page is page + 1
            Double value = Convert.ToDouble(totalitems / limit);
            int lastpage = Convert.ToInt16(Math.Ceiling(value));
            //lastpage is = total items / items per page, rounded up.
            int lpm1 = lastpage - 1;
            //last page minus 1
            int counter = 0;
            // Now we apply our rules and draw the pagination object. 
            // We're actually saving the code to a variable in case we want to draw it more than once.

            StringBuilder paginationBuilder = new StringBuilder();
            if (lastpage > 1)
            {

                paginationBuilder.Append("<div class=\"pagination\"");
                if (!string.IsNullOrEmpty(margin) | !string.IsNullOrEmpty(padding))
                {
                    paginationBuilder.Append(" style=\"");
                    if (!string.IsNullOrEmpty(margin))
                    {
                        paginationBuilder.Append("margin: margin");
                    }
                    if (!string.IsNullOrEmpty(padding))
                    {
                        paginationBuilder.Append("padding: padding");
                    }
                    paginationBuilder.Append("\"");
                }
                paginationBuilder.Append(">");

                //previous button
                paginationBuilder.Append(page > 1 ? string.Format("<a href=\"{0}page={1}\">上一頁</a>", targetpage, prev) : "<span class=\"disabled\">上一頁</span>");
                //pages 
                if (lastpage < 7 + (adjacents * 2))
                {
                    //not enough pages to bother breaking it up

                    for (counter = 1; counter <= lastpage; counter++)
                    {

                        paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
                    }
                }
                else if (lastpage >= 7 + (adjacents * 2))
                {
                    //enough pages to hide some
                    //close to beginning only hide later pages
                    if (page < 1 + (adjacents * 3))
                    {
                        for (counter = 1; counter <= (4 + (adjacents * 2)) - 1; counter++)
                        {
                            paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
                        }
                        paginationBuilder.Append("...");
                        paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lpm1));
                        paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lastpage));
                    }
                    //in middle hide some front and some back
                    else if (lastpage - (adjacents * 2) > page & page > (adjacents * 2))
                    {
                        paginationBuilder.Append(string.Format("<a href=\"{0}page=1\">1</a>", targetpage));
                        paginationBuilder.Append(string.Format("<a href=\"{0}page=2\">2</a>", targetpage));
                        paginationBuilder.Append("...");
                        for (counter = (page - adjacents); counter <= (page + adjacents); counter++)
                        {
                            paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
                        }
                        paginationBuilder.Append("...");
                        paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lpm1));
                        paginationBuilder.Append(string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, lastpage));
                    }
                    else
                    {
                        //close to end only hide early pages
                        paginationBuilder.Append(string.Format("<a href=\"{0}page=1\">1</a>", targetpage));
                        paginationBuilder.Append(string.Format("<a href=\"{0}page=2\">2</a>", targetpage));
                        paginationBuilder.Append("...");
                        for (counter = (lastpage - (1 + (adjacents * 3))); counter <= lastpage; counter++)
                        {
                            paginationBuilder.Append(counter == page ? string.Format("<span class=\"current\">{0}</span>", counter) : string.Format("<a href=\"{0}page={1}\">{1}</a>", targetpage, counter));
                        }
                    }
                }
                //nextPage button
                paginationBuilder.Append(page < counter - 1 ? string.Format("<a href=\"{0}page={1}\">下一頁</a>", targetpage, nextPage) : "<span class=\"disabled\">下一頁</span>");
                paginationBuilder.Append("</div>\r\n");
            }
            return paginationBuilder.ToString();
        }

        #endregion

        #region "內連結轉換"
        /// <summary>
        /// 內連結轉換
        /// </summary>
        /// <param name="link">使用連結</param>
        /// <param name="insidePath">要附加的路徑(例:~/UploadFiles/Files/) </param>
        /// <returns></returns>
        public static string ConverInsideLink(object link, string insidePath, bool useServerMap)
        {
            if (link.ToString().ToLower().IndexOf("http://") == -1)
            {
                if (useServerMap == true)
                {
                    return HttpContext.Current.Server.MapPath(insidePath) + link.ToString();
                }
                else
                {
                    return insidePath + link.ToString();
                }

            }
            return link.ToString();
        }

        #endregion


        public static void SystemSendMail(string fromAddress, string toAddress, string Subject, string MailBody)
        {

            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = MailBody;
            // SMTP Server
            SmtpClient mailSender = new SmtpClient(ConfigurationManager.AppSettings["MailServer"]);
            //System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("krtc7938888@krtc.com.tw", "8888");
            //mailSender.Credentials = basicAuthenticationInfo;
            try
            {

                mailSender.Send(mailMessage);
                mailMessage.Dispose();
            }
            catch
            {
                return;
            }
            mailSender = null;
        }

        public static void SystemSendMailCC(string fromAddress, string toAddress, string Subject, string MailBody)
        {
            //MailMessage mailMessage = new MailMessage("MyerSystem@myerstone.com.tw", "system@mail.lts.tw");
            //mailMessage.Bcc.Add(toAddress);
           

            //mailMessage.Subject = Subject;
            //mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            //mailMessage.IsBodyHtml = true;
            //mailMessage.Body = MailBody;

            //// SMTP Server
            //System.Net.Mail.SmtpClient client = new SmtpClient();
            //client.EnableSsl = false;
            //client.Send(mailMessage);
            //mailMessage.Dispose();
            //try
            //{

            //    client.Send(mailMessage);
            //    mailMessage.Dispose();
            //}
            //catch
            //{
            //    return;
            //}
            //client = null;




            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            //mailMessage.Bcc.Add(toAddress);


            mailMessage.Subject = Subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = MailBody;

            // SMTP Server
            System.Net.Mail.SmtpClient client = new SmtpClient();
client.EnableSsl = false;
                client.Send(mailMessage);
                mailMessage.Dispose();
            try
            {
                
            }
            catch (Exception e)
            {

                return;
            }
            client = null;
        }

        public static void SendGmailMail(string fromAddress, string toAddress, string Subject, string MailBody,string password)
        {

            MailMessage mailMessage = new MailMessage(fromAddress, toAddress);
            mailMessage.Subject = Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = MailBody;
            // SMTP Server
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(fromAddress, password);
            mailSender.Credentials = basicAuthenticationInfo;
            mailSender.Port = 587;
            mailSender.EnableSsl = true;

            try
            {

                mailSender.Send(mailMessage);
                mailMessage.Dispose();
            }
            catch
            {
                return;
            }
            mailSender = null;
        }

        public static void DownLoadFileByContent(string fileName, string FileContent, string ContentType)
        {
            //設定下載的內容是word檔案,若是不清楚可以不要設
            //application/msword -->Word檔
            //application/x-excel -->Excel檔
            //application/pdf -->pdf檔
            //application/zip -->zip檔
            //text/HTML -->HTML文件 預設值
            //image/gif --> gif檔
            //image/jpeg --> jpg檔
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.Buffer = true;   
            if (!string.IsNullOrEmpty(ContentType))
            {
                HttpContext.Current.Response.ContentType = "application/msword";
            }
            
            const char c = (char)34;
            fileName = c + HttpUtility.UrlEncode(fileName, System.Text.Encoding.ASCII) + c;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            //指定檔案的來源
            HttpContext.Current.Response.Write(FileContent);
            HttpContext.Current.Response.End();

        }

        public static void DownLoadFileByFile(string fileName, string outPutFile, string ContentType)
        {
            //設定下載的內容是word檔案,若是不清楚可以不要設
            //application/msword -->Word檔
            //application/x-excel -->Excel檔
            //application/pdf -->pdf檔
            //application/zip -->zip檔
            //text/HTML -->HTML文件 預設值
            //image/gif --> gif檔
            //image/jpeg --> jpg檔
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.Buffer = true;
            if (!string.IsNullOrEmpty(ContentType))
            {
                HttpContext.Current.Response.ContentType = "application/msword";
            }

            const char c = (char)34;
            fileName = c + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8) + c;
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            //指定檔案的來源
            HttpContext.Current.Response.WriteFile(outPutFile);
            HttpContext.Current.Response.End();

        }

        //public static void FTPUploadFile(string directory,string fileName,string filePath)
        //{
        //    //FTP 傳過去
        //    FtpWebRequest reg = (FtpWebRequest)WebRequest.Create("ftp://172.16.1.9/UploadFiles/" + directory + "/" + fileName);
        //    reg.Credentials = new NetworkCredential("kmph", "kmph1234");
        //    reg.Method = WebRequestMethods.Ftp.UploadFile;
        //    byte[] buf = new byte[2048];
        //    int iWork;
        //    Stream rs = reg.GetRequestStream();
        //    FileStream fs = File.Open(filePath, FileMode.Open);
        //    while ((iWork = fs.Read(buf, 0, buf.Length)) > 0)
        //        rs.Write(buf, 0, iWork);
        //    rs.Close();
        //    fs.Close();

        //    FtpWebResponse res = (FtpWebResponse)reg.GetResponse();
        //    res.Close();
        //}

        public static string DataTableToExcelCSV(DataTable dataTable,string sepChar)
        {
           if(dataTable.Rows.Count>0)
           {
               string sep = "";
               StringBuilder sb=new StringBuilder();
               StringBuilder builder = new StringBuilder();
               foreach (DataColumn col in dataTable.Columns)
               {
                   builder.Append(sep).Append(col.ColumnName);
                   sep = sepChar;
               }
               sb.Append(builder.ToString() + "\n");
               //then write all the rows
               foreach (DataRow row in dataTable.Rows)
               {
                   sep = "";
                   builder = new StringBuilder();
                   foreach (DataColumn col in dataTable.Columns)
                   {
                       string dat = "" + row[col.ColumnName];
                       dat = dat.Replace("\"","\"\"");
                       dat = "\"" + dat + "\"";
                       dat = dat.Replace("\n", "");
                       builder.Append(sep).Append(dat);

                       sep = sepChar;
                   }
                   sb.Append(builder.ToString() + "\n");
               }
               return sb.ToString();
           }
           else
           {
               return "";
           }


        }


    }

}



