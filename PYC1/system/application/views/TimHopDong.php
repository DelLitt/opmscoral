<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<link rel="stylesheet" type="text/css" href="<?php echo base_url(); ?>css/mystyle.css"/>
</head>
<body>
<script type="text/javascript">
	function submitForm(action) {
		document.getElementById('action').value = action;
		document.forms['mainform'].submit();
	}
</script>
<form id="mainform" method="post">
<div id="divKhachHangCongTy" >
<h2>Tìm hợp đồng</h2>
<?php echo validation_errors(); ?>
<table border="0" width="75%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã hợp đồng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtContractId" maxlength="10" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtContractId']) : '')?>"/>
		</td>
		<td nowrap width="1%">&nbsp;Số hợp đồng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtContractNumber" maxlength="30" size="20" value="<?php echo ($criteria != null && count($criteria) > 0 ? htmlentities($criteria['input_value']['txtContractNumber']) : '')?>"/>
		</td>
	</tr>
    <tr>
		<td nowrap width="1%">Mã khách hàng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCustomerId" maxlength="30" size="20" />
		</td>
		<td nowrap width="1%">&nbsp;Tên khách hàng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCustomerName" maxlength="30" size="20" />
		</td>
	</tr>
    <tr>
		<td nowrap width="1%">Mã công ty&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCompanyId" maxlength="30" size="20" />
		</td>
		<td nowrap width="1%">&nbsp;Tên công ty&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCompanyName" maxlength="30" size="20" />
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Ngày tạo hợp đồng Từ ngày&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCreateDateFrom" maxlength="10" size="20" /><input class="input_button" type="button" value="...">
		</td>
		<td nowrap width="1%">&nbsp;Đến ngày&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCreateDateTo" maxlength="10" size="20" /><input class="input_button" type="button" value="...">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Loại hợp đồng&nbsp;</td>
		<td colspan="3">
            <select name="cbbContractType" style="border-style: solid; border-width: 1px; border-color: teal">
				<option value="1">hahahaha</option>
			</select>
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
<br/>
<?php echo $searchResult?>
<input type="hidden" name="action" id="action" value="">
<input type="hidden" name="hidSortOrder" id="hidSortOrder" value="<?php echo ($criteria != null && count($criteria) > 0 ? $criteria['orderDirection'] : '')?>">
<input type="hidden" name="hidOrderBy" id="hidOrderBy" value="<?php echo ($criteria != null && count($criteria) > 0 ? $criteria['orderField'] : '')?>">
<input type="hidden" name="hidPageNum" id="hidPageNum" value="<?php echo ($criteria != null && count($criteria) > 0 ? $criteria['pageNumber'] : '')?>">
</div>
</form>
</body>
</html>
