using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace korner_noah_project3_tryIt_page
{
	public partial class _Default : Page
	{
		const string STOCK_EXCHANGE_URL = "https://www.marketwatch.com/tools/marketsummary/indices/indices.asp?indexid=1&groupid=37";
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//TRYIT FOR REQUIRED SERVICE #1
		protected void GetTop10IndicesBtn_Click(object sender, EventArgs e)
		{
			StockRelatedWebServices.Service1Client proxy = new StockRelatedWebServices.Service1Client();
			// Use the 'client' variable to call operations on the service.
			Top10IndicesTextBox.Text = "Filename : " + proxy.GetTop10USIndices(STOCK_EXCHANGE_URL);
			// Always close the client.
			proxy.Close();
		}
		//TRYIT FOR REQUIRED SERVICE #2
		protected void GetStockQuoteBtn_Click(object sender, EventArgs e)
		{
			StockRelatedWebServices.Service1Client proxy = new StockRelatedWebServices.Service1Client();
			string stockSymbol = StockSymbolTextInput.Value;

			// Use the 'client' variable to call operations on the service.
			DisplayStockPriceLbl.Text = String.Format("{0:C}", proxy.GetStockQuote(stockSymbol));
			// Always close the client.
			proxy.Close();
		}
		//TRYIT FOR ELECTIVE SERVICE #1
		protected void SortTop10LowHighBtn_Click(object sender, EventArgs e)
		{
			//open the proxy
			StockRelatedWebServices.Service1Client proxy = new StockRelatedWebServices.Service1Client();
			SortedIndicesTextBox.Text = proxy.SortIndicesLowHigh();

			//close the client
			proxy.Close();
		}
		//TRYIT FOR ELECTIVE SERVICE #2
		protected void GetTransactionPriceBtn_Click(object sender, EventArgs e)
		{
			//open the proxy
			StockRelatedWebServices.Service1Client proxy = new StockRelatedWebServices.Service1Client();
			//store variables
			string stockSymbol = TransactionInput1.Value;
			int numShares = Convert.ToInt32(TransactionInput2.Value);
			//calculate transaction price
			decimal transactionPrice = proxy.CalcTransactionPrice(stockSymbol, numShares);
			//display transaction price
			TransactionPriceTextBox.Text = string.Format("{0:C}", transactionPrice);
			//close the client
			proxy.Close();
		}
		//TRYIT FOR ELECTIVE SERVICE #3 (CONSUMING A RESTful SERVICE)
		protected void CalcROIBtn_Click(object sender, EventArgs e)
		{
			//store cost and gain inputs			
			string costOfInvestment = ROICostInput.Value;
			string gainOnInvestment = ROIGainInput.Value;
		    //create base and complete URL's 
			string baseURL = "http://webstrar39.fulton.asu.edu/page2/Service1.svc/"; //NEED TO CHANGE ONCE DEPLOYED
			string completeURL = baseURL + "GetROI?c=" + costOfInvestment + "&g=" + gainOnInvestment;
			ROITextBox.Text = completeURL;
			//create base address NEED TO CHANGE ONCE DEPLOYED
			Uri completeURI = new Uri(completeURL);
			//open client 
			WebClient proxy = new WebClient();
			string bytes = proxy.DownloadString(completeURI);
			//store ROI 
			double ROI = Convert.ToDouble(bytes);
			//display as percentage
			ROITextBox.Text =  ROI.ToString("P");
		}
		//TRYIT FOR ELECTIVE SERVICE #4
		protected void CalcNumSharesBtn_Click(object sender, EventArgs e)
		{
			//store variables for stockSymbol, monthlyInvestment, and numYears
			string stockSymbol = OwnedSharesInput1.Value;
			decimal monthlyInvestment = Convert.ToDecimal(OwnedSharesInput2.Value);
			int numYears = Convert.ToInt32(OwnedSharesInput3.Value);
			//open the proxy
			StockRelatedWebServices.Service1Client proxy = new StockRelatedWebServices.Service1Client();
			//calculate number of shares owned
			double numOwnedShares = proxy.GetNumSharesWithDollarCostAvg(stockSymbol, monthlyInvestment, numYears);

			//display result
			OwnedSharesTextBox.Text = string.Format("{0:f2}", numOwnedShares);

			proxy.Close();
		}
	}
}