using System;
using System.Collections.Generic;

namespace Jetso.AuctionAgent
{
	/// <summary>
	/// <para>　</para>
	/// 　常用工具类——日期时间类
	/// </summary>
	public class DateTimeHelper
	{
		#region -- 格式化 --

		/// <summary>返回标准时间</summary>
		public static String GetStandardDateTime(String fDateTime, String formatStr)
		{
			if (fDateTime == "0000-0-0 0:00:00")
			{
				return fDateTime;
			}
			DateTime time = new DateTime(1900, 1, 1, 0, 0, 0, 0);
			if (DateTime.TryParse(fDateTime, out time))
			{
				return time.ToString(formatStr);
			}
			else
			{
				return "N/A";
			}
		}

		/// <summary>
		/// 返回标准时间 yyyy-MM-dd HH:mm:ss
		/// </sumary>
		public static String GetStandardDateTime(String fDateTime)
		{
			return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
		}

		/// <summary>
		/// 返回当天标准时间 yyyy-MM-dd HH:mm:ss
		/// </sumary>
		public static String GetStandardDateTime()
		{
			return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}

		/// <summary>返回标准时间 yyyy-MM-dd</summary>
		/// <param name="fDate"></param>
		/// <returns></returns>
		public static String GetStandardDate(String fDate)
		{
			return GetStandardDateTime(fDate, "yyyy-MM-dd");
		}

		/// <summary>返回当天标准时间 yyyy-MM-dd</summary>
		/// <param name="fDate"></param>
		/// <returns></returns>
		public static String GetStandardDate()
		{
			return DateTime.Now.ToString("yyyy-MM-dd");
		}

		#endregion

		#region -- 生成年月日时分秒字符串 --

		/// <summary>工具方法:生成年月日时分秒字符串</summary>
		/// <param name="link">年月日时分秒之间的连接字符</param>
		/// <param name="RanLength">最后生成随机数的位数</param>
		/// <returns>返回年月日时分秒毫秒四位随机数字的字符串</returns>
		public static String FileNameStr(String link, Int32 RanLength)
		{
			if (link.IsNullOrWhiteSpace())
			{
				link = "";
			}
			Int32 Year = DateTime.Now.Year;            //年
			Int32 Month = DateTime.Now.Month;          //月份
			Int32 Day = DateTime.Now.Day;              //日期
			Int32 Hour = DateTime.Now.Hour;            //小时
			Int32 Minute = DateTime.Now.Minute;        //分钟
			Int32 Second = DateTime.Now.Second;        //秒
			Int32 Milli = DateTime.Now.Millisecond;    //毫秒

			//生成随机数字
			String DataString = "0123456789";
			Random rnd = new Random();
			String rndstring = "";
			Int32 i = 1;

			while (i <= RanLength)
			{
				rndstring += DataString[rnd.Next(DataString.Length)];
				i++;
			}
			String FileNameStr = (Year + link + Month + link + Day + link + Hour + link + Minute + link + Second + link + Milli + link + rndstring).ToString();
			return FileNameStr;
		}

		#endregion

		#region -- 把秒转换成分钟 --

		/// <summary>把秒转换成分钟</summary>
		/// <param name="Second">秒</param>
		/// <returns>分钟</returns>
		public static Int32 SecondToMinute(Int32 Second)
		{
			decimal mm = (decimal)((decimal)Second / (decimal)60);
			return Convert.ToInt32(Math.Ceiling(mm));
		}

		#endregion

		#region -- 返回某年某月最后一天 --

		/// <summary>返回某年某月最后一天</summary>
		/// <param name="year">年份</param>
		/// <param name="month">月份</param>
		/// <returns>日</returns>
		public static Int32 GetMonthLastDate(Int32 year, Int32 month)
		{
			DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
			Int32 Day = lastDay.Day;
			return Day;
		}

		#endregion

		#region -- 生成两个日期中的月份数组 --

		/// <summary>生成两个日期中的月份数组</summary>
		/// <param name="StartDate">开始日期</param>
		/// <param name="EndDate">结束日期</param>
		/// <returns></returns>
		public static IList<Int32[]> GetYearDateList(DateTime StartDate, DateTime EndDate)
		{
			List<Int32[]> YearMonthList = new List<Int32[]>();
			Int32 SYear = StartDate.Year;
			Int32 SMonth = StartDate.Month;
			Int32 EYear = EndDate.Year;
			Int32 EMonth = EndDate.Month;

			//HttpContext.Current.Response.Write(SMonth + "   " + EMonth+"<br><hr>");
			if (SYear == EYear)
			{
				for (Int32 i = SMonth; i <= EMonth; i++)
				{
					Int32[] arrs = new Int32[2];
					arrs[0] = SYear;
					arrs[1] = i;
					YearMonthList.Add(arrs);

					//HttpContext.Current.Response.Write(arrs[0].ToString() + "年" + arrs[1] + "月<br><hr>");
				}
			}
			else if (SYear < EYear)
			{
				for (Int32 i = SYear; i <= EYear; i++)
				{
					if (i == SYear)
					{
						for (Int32 j = SMonth; j <= 12; j++)
						{
							Int32[] arrs = new Int32[2];
							arrs[0] = i;
							arrs[1] = j;
							YearMonthList.Add(arrs);

							// HttpContext.Current.Response.Write(arrs[0].ToString() + "年" + arrs[1] + "月<br><hr>");
						}
					}
					else if (i > SYear && i < EYear)
					{
						for (Int32 j = 1; j <= 12; j++)
						{
							Int32[] arrs = new Int32[2];
							arrs[0] = i;
							arrs[1] = j;
							YearMonthList.Add(arrs);

							//HttpContext.Current.Response.Write(arrs[0].ToString() + "年" + arrs[1] + "月<br><hr>");
						}
					}
					else if (i == EYear)
					{
						for (Int32 j = 1; j <= EMonth; j++)
						{
							Int32[] arrs = new Int32[2];
							arrs[0] = i;
							arrs[1] = j;
							YearMonthList.Add(arrs);

							//HttpContext.Current.Response.Write(arrs[0].ToString() + "年" + arrs[1] + "月<br><hr>");
						}
					}
				}
			}
			return YearMonthList;
		}

		#endregion

		#region - 中文星期数 -

		/// <summary>获取指定日期的星期数，如星期一</summary>
		/// <param name="T">当前日期时间</param>
		/// <returns>星期一、星期二……</returns>
		public static String GetFullWeekCN(DateTime T)
		{
			String Week = "";

			switch (T.DayOfWeek)
			{
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

				case DayOfWeek.Sunday:
					Week = "日";
					break;
			}
			return Week.IsNullOrWhiteSpace() ? "" : "星期" + Week;
		}

		/// <summary>获取当前日期的星期数，如星期一</summary>
		/// <returns>星期一、星期二……</returns>
		public static String GetFullWeekCN()
		{
			return GetFullWeekCN(DateTime.Now);
		}

		#endregion

		#region -- 时间差 --

		#region 计算两个日期的时间差

		/// <summary>返回类型</summary>
		public enum BackType
		{
			/// <summary>返回间隔天数</summary>
			GetDays,

			/// <summary>返回间隔小时数</summary>
			GetHours,

			/// <summary>返回间隔分钟数</summary>
			GetMinutes,

			/// <summary>返回间隔秒数</summary>
			GetSeconds,

			/// <summary>返回间隔整毫秒数</summary>
			GetMilliseconds,

			/// <summary>返回X月X日或X小时前或X分钟前</summary>
			GetString,
		}

		/// <summary>计算两个日期的时间差</summary>
		/// <param name="DateTime1">原日期</param>
		/// <param name="DateTime2">新日期</param>
		/// <param name="BackTypes">返回类型：天，小时，分钟，秒，毫秒，（X天或X小时或X分钟）</param>
		/// <returns>null或一个具体类型</returns>
		public static Object DateDiff(DateTime DateTime1, DateTime DateTime2, BackType BackTypes)
		{
			Object Diff = null;
			TimeSpan ts = DateTime2 - DateTime1;

			switch (BackTypes)
			{
				default:
					Diff = ts.TotalDays;
					break;

				case BackType.GetDays:
					Diff = ts.TotalDays;
					break;

				case BackType.GetHours:
					Diff = ts.TotalHours;
					break;

				case BackType.GetMinutes:
					Diff = ts.TotalMinutes;
					break;

				case BackType.GetSeconds:
					Diff = ts.TotalSeconds;
					break;

				case BackType.GetMilliseconds:
					Diff = ts.TotalMilliseconds;
					break;

				case BackType.GetString:
					String OutDiff = null;
					if (ts.Days >= 1)
					{
						OutDiff = ts.TotalDays + "天";
					}
					else
					{
						if (ts.Hours >= 1)
						{
							OutDiff = ts.TotalHours + "小时";
						}
						else
						{
							OutDiff = ts.TotalMinutes + "分钟";
						}
					}
					Diff = OutDiff;
					break;
			}
			return Diff;
		}

		#endregion

		/// <summary>返回相差的秒数</summary>
		/// <param name="Time"></param>
		/// <param name="Sec"></param>
		/// <returns></returns>
		public static Int32 StrDateDiffSeconds(String Time, Int32 Sec)
		{
			TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
			if (ts.TotalSeconds > Int32.MaxValue)
			{
				return Int32.MaxValue;
			}
			else if (ts.TotalSeconds < Int32.MinValue)
			{
				return Int32.MinValue;
			}
			return (Int32)ts.TotalSeconds;
		}

		/// <summary>返回相差的分钟数</summary>
		/// <param name="time"></param>
		/// <param name="minutes"></param>
		/// <returns></returns>
		public static Int32 StrDateDiffMinutes(String time, Int32 minutes)
		{
			if (time.IsNullOrWhiteSpace())
			{
				return 1;
			}
			TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
			if (ts.TotalMinutes > Int32.MaxValue)
			{
				return Int32.MaxValue;
			}
			else if (ts.TotalMinutes < Int32.MinValue)
			{
				return Int32.MinValue;
			}
			return (Int32)ts.TotalMinutes;
		}

		/// <summary>返回相差的小时数</summary>
		/// <param name="time"></param>
		/// <param name="hours"></param>
		/// <returns></returns>
		public static Int32 StrDateDiffHours(String time, Int32 hours)
		{
			if (time.IsNullOrWhiteSpace())
			{
				return 1;
			}
			TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
			if (ts.TotalHours > Int32.MaxValue)
			{
				return Int32.MaxValue;
			}
			else if (ts.TotalHours < Int32.MinValue)
			{
				return Int32.MinValue;
			}
			return (Int32)ts.TotalHours;
		}

		#endregion

		/// <summary>转换时间为unix时间戳</summary>
		/// <param name="date">需要传递UTC时间,避免时区误差,例:DataTime.UTCNow</param>
		/// <returns></returns>
		public static double ConvertToUnixTimestamp(DateTime date)
		{
			DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			TimeSpan diff = date - origin;
			return Math.Floor(diff.TotalSeconds);
		}
	}
}