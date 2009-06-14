<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<script type="text/javascript">
	function submitForm(action) {
		document.getElementById('action').value = action;
		document.forms['mainform'].submit();
	}
</script>
<body>

<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Tìm kiếm nhân viên</h2>
<table border="0" width="40%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã nhân viên&nbsp;</td>
		<td>
			<input type="text" name="txtEmployeeId" class="input_text" maxlength="10" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtEmployeeId']) : '')?>"/>
		</td>
		<td nowrap width="1%">&nbsp;Tên nhân viên&nbsp;</td>
		<td>
			<input type="text" name="txtEmployeeName" class="input_text" maxlength="30" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtEmployeeName']) : '')?>"/>
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
			<input type="text" name="txtEmail" Maxlength="500"/>
		</td>
	</tr>
	<tr>
		<td colspan="4" align="center">
            <input type="button" class="input_button" value="Tìm" id="btnSave" onclick="javascript:submitForm('search');">
            <input type="button" class="input_button" value="Tạo mới" id="btnAdd" onclick="javascript:submitForm('add_new_screen');">
			<input type="button" class="input_button" value="Bỏ qua" id="btnCancel">
		</td>
	</tr>
</table>
</div>
<br/>
<?php echo $searchResult?>
<input type="hidden" name="action" id="action" value="">
<input type="hidden" name="hidSortOrder" id="hidSortOrder" value="<?php echo ($criteria != null && count($criteria) > 0 ? $criteria['orderDirection'] : '')?>">
<input type="hidden" name="hidOrderBy" id="hidOrderBy" value="<?php echo ($criteria != null && count($criteria) > 0 ? $criteria['orderField'] : '')?>">
<input type="hidden" name="hidPageNum" id="hidPageNum" value="<?php echo ($criteria != null && count($criteria) > 0 ? $criteria['pageNumber'] : '')?>">
</form>
</body>
</html>

