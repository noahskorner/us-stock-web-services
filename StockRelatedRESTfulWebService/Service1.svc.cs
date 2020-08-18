using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace StockRelatedRESTfulWebService
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class Service1 : IService1
	{
		//ELECTIVE SERVICE #3 (RESTFUL SERVICE)
		public double GetROI(string c, string g)
		{
			double returnOnInvestment = calcROI(Convert.ToDecimal(c), Convert.ToDecimal(g));
			return returnOnInvestment;
		}

		//HELPER FUNCTIONS
		private double calcROI(decimal costOfInvestment, decimal gainOnInvestment)
		{
			//ROI Formula is (G - C) / C
			double ROI = Convert.ToDouble((gainOnInvestment - costOfInvestment) / costOfInvestment);
			return ROI;
		}
	}
}
