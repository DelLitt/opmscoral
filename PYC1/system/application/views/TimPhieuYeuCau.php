<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Tìm kiếm phiếu yêu cầu</h2>
<table border="0" width="80%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã phiếu yêu cầu&nbsp;</td>
		<td>
			<input type="text" name="txtRequestId" MaxLength="10"/>
		</td>
		<td nowrap width="1%">&nbsp;Trạng thái&nbsp;</td>
		<td>
			<asp:DropDownList id="cbbStatus" runat="server">
				<asp:ListItem>Tất cả</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Mã khách hàng&nbsp;</td>
		<td>
			<input type="text" name="txtCustomerId" MaxLength="20" />		
		</td>
		<td nowrap width="1%">&nbsp;Tên khách hàng&nbsp;</td>
		<td>
            <input type="text" name="txtCustomerName" MaxLength="500" />
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Mã công ty&nbsp;</td>
		<td>
            <input type="text" name="txtCompanyId" MaxLength="20" />        
		</td>
		<td nowrap width="1%">&nbsp;Tên công ty&nbsp;</td>
		<td>
            <input type="text" name="txtCompanyName" MaxLength="500" />
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Ngày nhận phiếu Từ ngày&nbsp;</td>
		<td>
            <input type="text" name="txtDateFrom" MaxLength="500" /><input type="button" value="...">
		</td>
		<td nowrap width="1%">&nbsp;Đến ngày&nbsp;</td>
		<td>
            <input type="text" name="txtDateTo" MaxLength="500" /><input type="button" value="...">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Nhân viên kĩ thuật&nbsp;</td>
		<td colspan="3">
            <asp:DropDownList id="cbbEmployee" runat="server">
				<asp:ListItem>Tất cả</asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td colspan="4" align="center">
			<asp:Button id="btnSearch" Text="Tìm" />&nbsp;
			<asp:Button id="btnCancel" Text="Bỏ qua" />
		</td>
	</tr>
</table>
</div>
</form>
</body>
</html>

