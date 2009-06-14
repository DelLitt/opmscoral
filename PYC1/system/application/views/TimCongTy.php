
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="<?php echo base_url(); ?>css/mystyle.css"/>
<script type="text/javascript">
function submitForm(action) {
	document.getElementById('action').value = action;
	document.forms['mainform'].submit();
}
</script>
</head>
<body>
<form id="mainform" method="post">
<div id="divKhachHangCongTy" >
<h2>Tìm khách hàng công ty</h2>
<table border="0" width="60%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã công ty </td>
		<td>
            <input type="text" name="txtCompanyId" MaxLength="10"  class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtCompanyId']) : '')?>"/>
		</td>
		<td nowrap width="1%">Tên công ty </td>
		<td>
            <input type="text" name="txtCompanyName" MaxLength="100" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtCompanyName']) : '')?>"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Địa chỉ </td>
		<td>
            <input type="text" name="txtAddress" MaxLength="500" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtAddress']) : '')?>"/>
		</td>
		<td nowrap width="1%">Điện thoại </td>
		<td>
            <input type="text" name="txtPhone" MaxLength="30" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtPhone']) : '')?>"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Fax </td>
		<td>
            <input type="text" name="txtFax" MaxLength="30" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtFax']) : '')?>"/>
		</td>
		<td nowrap width="1%">Tên người đại diện </td>
		<td>
            <input type="text" name="txtRepresentName" MaxLength="100" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtRepresentName']) : '')?>"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Điện thoại người đại diện </td>
		<td>
            <input type="text" name="txtRepresentPhone" MaxLength="30" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtRepresentHome']) : '')?>"/>
		</td>
		<td nowrap width="1%">Fax người đại diện</td>
		<td>
            <input type="text" name="txtRepresentFax" MaxLength="30" class="input_text" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtRepresentFax']) : '')?>"/>
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
