using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockRelatedWebServices
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IService1
	{
		//REQUIRED SERVICES
		[OperationContract]
		string GetTop10USIndices(string sourceURL); //scrapes the web page at sourceURL and saves stock indices to text file, then returns .txt file location
		[OperationContract]
		decimal GetStockQuote(string stockSymbol); //uses GetTop10USIndices to find share price of a specific stock given stockSymbol (ex: VOO)
		
		//ELECTIVE SERVICES
		[OperationContract]
		string SortIndicesLowHigh(); //uses GetTop10USIndices to sort top 10 US indices low to high using quickSort algorithm
		[OperationContract]
		decimal CalcTransactionPrice(string stockSymbol, int numShares); //returns the transaction price for a stock given number of shares to buy
		[OperationContract]
		double GetNumSharesWithDollarCostAvg(string stockSymbol, decimal monthlyInvestment, int numYears); //returns number of owned shares using dollar cost averaging after a specified time period
	}


	// Use a data contract as illustrated in the sample below to add composite types to service operations.
	[DataContract]
	public class CompositeType
	{
		bool boolValue = true;
		string stringValue = "Hello ";

		[DataMember]
		public bool BoolValue
		{
			get { return boolValue; }
			set { boolValue = value; }
		}

		[DataMember]
		public string StringValue
		{
			get { return stringValue; }
			set { stringValue = value; }
		}
	}
}
