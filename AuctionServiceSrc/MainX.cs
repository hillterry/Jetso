
using System;
using System.Configuration;
using DmFramework.Log;
using DmFramework.IO;

namespace Jetso.AuctionAgent
{

	/// <summary>
	/// Application main class.
	/// </summary>
	public class MainX
	{

		/// <summary>
		/// Application main entry point.
		/// </summary>
		/// <param name="args">Command line argumnets.</param>
		public static void Main(String[] args)
		{
			try
			{
				HmTrace.UseService();

				AuctionAgent.ServiceMain();
			}
			catch (Exception ex)
			{
				HmTrace.WriteException(ex);
			}
		}
	}
}
