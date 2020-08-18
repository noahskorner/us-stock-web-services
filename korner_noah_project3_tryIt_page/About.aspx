<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="korner_noah_project3_tryIt_page.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<h2><%: Title %></h2>
    <h3>ASU CSE445 Project 3 TryIt Page</h3>
    <p>This is a TryIt page for both required and elective services implemented by Noah Korner</p>
	<p>
		<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; mso-table-layout-alt: fixed; border: 1.0pt solid windowtext; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 5.4pt 0in 5.4pt; font-size: 11.0pt; font-family: Calibri, sans-serif;">
			<tr>
				<td class="modal-lg" style="width: 1051px" valign="top">
					<p class="MsoNormal">
						<i><span>GetTop10UsIndices<o:p></o:p></span></i></p>
					<p class="MsoNormal">
						<o:p>URL: </o:p>
						<span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page1/Service1.svc</a></span></p>
					<p class="MsoNormal">
						<span>Pull top 10 US indices current stock information including share price.<o:p></o:p></span></p>
					<p class="MsoNormal">
						<span><strong>Input:</strong><o:p></o:p></span></p>
					<p class="MsoNormal">
						<span>string sourceURL<o:p></o:p></span></p>
					<p class="MsoNormal">
						<span><strong>Output:</strong><o:p></o:p></span></p>
					<p class="MsoNormal">
						<span>string fileName<o:p></o:p></span></p>
				</td>
			</tr>
			<tr>
				<td class="modal-lg" style="width: 1051px" valign="top">
					<p class="MsoNormal">
						<i><span>GetStockQuote<o:p> </o:p>
						</span></i>
					</p>
					<p class="MsoNormal">
						<o:p>URL:</o:p><span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page1/Service1.svc</a></span></p>
					<p class="MsoNormal">
						<span>Given a specific stock symbol, the web service will return the current share price of that stock.<o:p></o:p></span></p>
					<p class="MsoNormal">
						<span><strong>Input:</strong><o:p></o:p></span></p>
					<p class="MsoNormal">
						<span>string stockSymbol<o:p></o:p></span></p>
					<p class="MsoNormal">
						<span><strong>Output:</strong><o:p></o:p></span></p>
					<p class="MsoNormal">
						<span>decimal currentSharePrice<o:p></o:p></span></p>
					<p class="MsoNormal">
						<table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; mso-table-layout-alt: fixed; border: 1.0pt solid windowtext; mso-border-alt: solid windowtext .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0in 5.4pt 0in 5.4pt; font-size: 11.0pt; font-family: Calibri, sans-serif;">
							<tr>
								<td style="width: 1081px" valign="top">
									<p class="MsoNormal">
										<i><span>SortIndicesLowToHigh<o:p></o:p></span></i></p>
									<p class="MsoNormal">
										<o:p>
						<o:p>URL: </o:p>
										</o:p>
										<span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page1/Service1.svc</a></span></p>
									<p class="MsoNormal">
										<b><span>Input:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>void<o:p></o:p></span></p>
									<p class="MsoNormal">
										<b><span>Output:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>String indicesSorted<i><o:p></o:p></i></span></p>
								</td>
							</tr>
							<tr>
								<td style="width: 1081px" valign="top">
									<p class="MsoNormal">
										<i><span>CalcTransactionPrice<o:p></o:p></span></i></p>
									<p class="MsoNormal">
										<o:p>
						<o:p>URL: </o:p>
										</o:p>
										<span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page1/Service1.svc</a></span></p>
									<p class="MsoNormal">
										<b><span>Input:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>String stockSymbol<o:p></o:p></span></p>
									<p class="MsoNormal">
										<span>Int numShares<o:p></o:p></span></p>
									<p class="MsoNormal">
										<b><span>Output:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>Decimal transactionPrice<o:p></o:p></span></p>
								</td>
							</tr>
							<tr>
								<td style="width: 1081px" valign="top">
									<p class="MsoNormal">
										<i><span>getROI<o:p></o:p></span></i></p>
									<p class="MsoNormal">
										<o:p>
						<o:p>URL:
						<span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page2/Service1.svc</a></span></o:p></o:p></p>
									<p class="MsoNormal">
										<o:p>
										<o:p>Usage:
						<span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page1/Service1.svc</a>/GetROI?c={costOfInvestment}&amp;g={gainOnInvestment} </span></o:p>
										</o:p>
									</p>
									<p class="MsoNormal">
										<b><span>Input:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>decimal gain<o:p></o:p></span></p>
									<p class="MsoNormal">
										<span>decimal cost<o:p></o:p></span></p>
									<p class="MsoNormal">
										<b><span>Output:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>Double ROI<o:p></o:p></span></p>
								</td>
							</tr>
							<tr>
								<td style="width: 1081px" valign="top">
									<p class="MsoNormal">
										<i><span>GetNumSharesWithDollarCostAvg<o:p></o:p></span></i></p>
									<p class="MsoNormal">
										<o:p>
						<o:p>URL: </o:p>
										</o:p>
										<span><a href="http://webstrar39.fulton.asu.edu/page1/Service1.svc">http://webstrar39.fulton.asu.edu/page1/Service1.svc</a></span></p>
									<p class="MsoNormal">
										<b><span>Input:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>String stockSymbol<o:p></o:p></span></p>
									<p class="MsoNormal">
										<span>decimal monthlyInvestment<o:p></o:p></span></p>
									<p class="MsoNormal">
										<span>int numYears<o:p></o:p></span></p>
									<p class="MsoNormal">
										<b><span>Output:<o:p></o:p></span></b></p>
									<p class="MsoNormal">
										<span>double numOwnedShares<o:p></o:p></span></p>
								</td>
							</tr>
						</table>
						<o:p></o:p></p>
				</td>
			</tr>
		</table>
	</p>
</asp:Content>
