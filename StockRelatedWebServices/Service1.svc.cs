using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Caching;
using HtmlAgilityPack;
using System.IO;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace StockRelatedWebServices
{
	public class Service1 : IService1
	{
		//MEMBER VARIABLES
		public struct Stock {
			string stockSymbol;
			decimal stockPrice;
			public Stock(string _stockSymbol, decimal _stockPrice)
			{
				stockSymbol = _stockSymbol;
				stockPrice = _stockPrice;
			}

			public string getStockSymbol()
			{
				return stockSymbol;
			}

			public decimal getStockPrice()
			{
				return stockPrice;
			}
		}
		Stock[] top10USIndices = null;
		const string DEFAULT_STOCK_EXCHANGE_URL = "https://www.marketwatch.com/tools/marketsummary/indices/indices.asp?indexid=1&groupid=37";

		//REQUIRED SERVICE #1
		public string GetTop10USIndices(string sourceURL)
		{
			//analyze data to obtain price of each stock symbol
			top10USIndices = parseWebContent(sourceURL); //parse the source URL and store in Stock[] data structure
			string stockStr = stocksToString(top10USIndices); //convert Stock[] data structure to string
			string fileName = storeAsTxtFile(stockStr); //store in text file on server
			
			return fileName; //return name of file 
		}
		//REQUIRED SERVICE #2
		public decimal GetStockQuote(string stockSymbol) {
			decimal stockPrice = 0.0m;
			if(top10USIndices == null) //if we haven't found the stock data yet
			{
				GetTop10USIndices(DEFAULT_STOCK_EXCHANGE_URL); //pull our own data
			}

			for(int i = 0; i < top10USIndices.Length; i++)
			{
				string tryThis = top10USIndices[i].getStockSymbol();
				if(stockSymbol == top10USIndices[i].getStockSymbol())
				{
					stockPrice = top10USIndices[i].getStockPrice();
				}
			}

			return stockPrice;
		}
		//ELECTIVE SERVICE #1
		public string SortIndicesLowHigh()
		{
			Stock[] top10Sorted = null;
			string indicesSorted = "";
			
			if (top10USIndices == null) //if we haven't found the stock data yet
			{
				GetTop10USIndices(DEFAULT_STOCK_EXCHANGE_URL); //pull our own data
			}

			top10Sorted = top10USIndices; //make a copy of the current top10USIndices

			quickSort(top10Sorted, 0, 9); //sort the top10USIndices and store in top10sorted array 
			indicesSorted = stocksToString(top10Sorted); //store the sortedArray as string

			return indicesSorted; //return the sorted string
		}
		//ELECTIVE SERVICE #2
		public decimal CalcTransactionPrice(string stockSymbol, int numShares)
		{
			decimal stockPrice = GetStockQuote(stockSymbol); //use other service to determine current stock price

			return stockPrice * numShares; //multiply price by number of shares to get the transaction price
		}

		//ELECTIVE SERVICE #4
		public double GetNumSharesWithDollarCostAvg(string stockSymbol, decimal monthlyInvestment, int numYears)
		{
			decimal stockPrice = GetStockQuote(stockSymbol); //find and store current stock price
			decimal totalInvestment = monthlyInvestment * 12 * numYears; // calculate total investment amount
			double numOwnedShares = Convert.ToDouble(totalInvestment / stockPrice); //calculate how many owned shares at current price

			return numOwnedShares; //return number of owned shares 
		}

		//HELPER FUNCTIONS
		private Stock[] parseWebContent(string _sourceURL)
		{
			Stock[] currentTop10USIndices = new Stock[10]; //create temp Stock[] array

			var web = new HtmlAgilityPack.HtmlWeb();
			HtmlAgilityPack.HtmlDocument doc = web.Load(_sourceURL); //downloads the web content

			//temp variables
			string stockSymbol = ""; 
			decimal stockPrice;

			for (int i = 1; i < 11; i++) //iterate through top 10 indices
			{
				stockSymbol = doc.DocumentNode.SelectNodes("//*[@id=\"intindices\"]/table/tbody/tr[" + i + "]/td[1]/a")[0].InnerText; //temp store the symbol
				stockPrice = Convert.ToDecimal(doc.DocumentNode.SelectNodes("//*[@id=\"intindices\"]/table/tbody/tr[" + i + "]/td[3]")[0].InnerText); //temp store the share price
				Stock newStock = new Stock(stockSymbol, stockPrice); //init a new stock
				currentTop10USIndices[i - 1] = newStock; //add new stock to Stock[] data structure
			}

			return currentTop10USIndices; 
		}
		private string stocksToString(Stock[] stocks)
		{
			string str = "";

			for(int i = 0; i < stocks.Length; i++)
			{
				str += stocks[i].getStockSymbol();
				str += "\t = \t";
				str += string.Format("{0:C}", stocks[i].getStockPrice());
				str += Environment.NewLine;
			}

			return str;
		}
		private string storeAsTxtFile(string stockStr)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory;
			path += "App_Data\\stocks.txt"; //store to App_Data folder on server?

			if (File.Exists(path))
			{
				File.Delete(path); //if it already exists, delete and re-write file
			}

			{
				FileStream fs = new FileStream(path, FileMode.OpenOrCreate); //open the file stream
				StreamWriter str = new StreamWriter(fs); //create the file writer
				str.BaseStream.Seek(0, SeekOrigin.End);
				str.Write(stockStr); //write stock symbol and price to file
				str.Flush(); //flush the buffer
				str.Close(); //close the writer
				fs.Close(); //close the file stream
			}
			//string readtext = File.ReadAllText(path);
			return path;
		}
		private void quickSort(Stock[] unsorted, int low, int high)
		{
			if(low < high)
			{
				int pivot = partition(unsorted, low, high);

				quickSort(unsorted, low, pivot - 1);//recursively quicksort elements before pivot
				quickSort(unsorted, pivot + 1, high);//recursively quicksort elements after pivot
			}
		}
		private int partition(Stock[] unsorted, int low, int high)
		{
			decimal pivot = unsorted[high].getStockPrice(); //store pivot as high index element

			int i = (low - 1);
			for(int j = low; j < high; j++)
			{
				//if stock price is lower than pivot's stock price
				if(unsorted[j].getStockPrice() < pivot)
				{
					i++; //increment the index

					//swap unsorted[i] and unsorted[j]
					Stock temp = unsorted[i];
					unsorted[i] = unsorted[j];
					unsorted[j] = temp;
				}
			}
			//swap unsorted[i + 1] and unsorted[high]
			Stock tempStock = unsorted[i + 1];
			unsorted[i + 1] = unsorted[high];
			unsorted[high] = tempStock;

			return i + 1;
		}

	}
}
