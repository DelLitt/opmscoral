<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Tìm kiếm nhân viên</h2>
<table border="0" width="40%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã nhân viên&nbsp;</td>
		<td>
			<input type="text" name="txtEmployeeId" MaxLength="10"/>
		</td>
		<td nowrap width="1%">&nbsp;Tên nhân viên&nbsp;</td>
		<td>
			<input type="text" name="txtEmployeeName" MaxLength="10"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Vị trí&nbsp;</td>
		<td>
			<asp:DropDownList id="cbbRoles" runat="server">
				<asp:ListItem>Tất cả</asp:ListItem>
			</asp:DropDownList>
		</td>
		<td nowrap width="1%">&nbsp;Email&nbsp;</td>
		<td>
			<input type="text" name="txtEmail" MaxLength="500"/>
		</td>
	</tr>
	<tr>
		<td colspan="4" align="center">
			<asp:Button id="btnSearch" Text="Tìm" />
			<asp:Button id="btnCancel" Text="Bỏ qua" />
		</td>
	</tr>
</table>
</div>
</form>
</body>
</html>

