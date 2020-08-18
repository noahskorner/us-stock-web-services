<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="korner_noah_project3_tryIt_page._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
	<a href ="http://webstrar39.fulton.asu.edu/index.html">Back To Main Page</a>
	<strong><br />
	Retreive and Store Top 10 US Indices as .txt file<br />
	</strong>
	<div style="height: 58px">
		<asp:Button ID="GetTop10IndicesBtn" runat="server" Text="Get Top 10 US Indices" Height="24px" Width="181px" OnClick="GetTop10IndicesBtn_Click" />
		<asp:TextBox ID="Top10IndicesTextBox" runat="server" Height="22px" Width="667px" ReadOnly="True"></asp:TextBox>
	</div>
	<strong>Get Stock Quote (For Top 10 US Indices Only)</strong><br />
	<div style="height: 40px">
		Stock Symbol:
		<input id="StockSymbolTextInput" type="text" runat="server"/><asp:Button ID="GetStockQuoteBtn" runat="server" Height="24px" Text="Get Stock Quote" Width="275px" OnClick="GetStockQuoteBtn_Click" />
		<asp:Label ID="DisplayStockPriceLbl" runat="server" Text="$0.00"></asp:Label>
		<br />
	</div>
	<strong>Sort Top 10 US Indices ($ - $$$)</strong><br />
	<asp:Button ID="SortTop10LowHighBtn" runat="server" OnClick="SortTop10LowHighBtn_Click" Text="Sort US Indices Low to High" Width="289px" />
	<asp:TextBox ID="SortedIndicesTextBox" runat="server" Height="194px" TextMode="MultiLine" Width="273px"></asp:TextBox>
	<br />
	<strong>Transaction Price Calculator: </strong>
	<br />
	Stock Symbol:
	<input id="TransactionInput1" type="text" runat="server"/>Number of Shares to purchase:
	<input id="TransactionInput2" type="text" runat="server"/><asp:Button ID="GetTransactionPriceBtn" runat="server" OnClick="GetTransactionPriceBtn_Click" Text="Get Transaction Price" />
&nbsp;Transaction Price:
	<asp:TextBox ID="TransactionPriceTextBox" runat="server"></asp:TextBox>
	<br />
	<br />

		
	<strong>Return on Investment (ROI) Calculator:</strong><br />
	Cost of Investment:
	<input id="ROICostInput" type="text"  runat="server"/>Gain on Investment:
	<input id="ROIGainInput" type="text"  runat="server"/><asp:Button ID="CalcROIBtn" runat="server" OnClick="CalcROIBtn_Click" Text="Calculate ROI" />
	Calculated ROI:
	<asp:TextBox ID="ROITextBox" runat="server"></asp:TextBox>
	<br />
	<br />
	<strong>Calculate Number of Shares Owned Using Dollar Cost Averaging:</strong><br />
	Stock Symbol:
	<input id="OwnedSharesInput1" type="text" runat="server"/>Monthly Investment Amount:
	<input id="OwnedSharesInput2" type="text" runat="server"/>Number of Years:
	<input id="OwnedSharesInput3" type="text" runat="server"/>
	<asp:Button ID="CalcNumSharesBtn" runat="server" OnClick="CalcNumSharesBtn_Click" Text="Calculate" />
	Number of Owned Shares:
	<asp:TextBox ID="OwnedSharesTextBox" runat="server"></asp:TextBox>
	<br />
		
	</asp:Content>
