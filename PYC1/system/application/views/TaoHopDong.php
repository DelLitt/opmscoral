<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Tạo/Chỉnh sửa hợp đồng</h2>
<table border="0" width="40%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã hợp đồng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtContractId" value="<?php echo $Contract != null ? $Contract->contractId : '' ?>"  maxlength="10" size="20" readonly/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Số hợp đồng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtContractNumber" value="<?php echo $Contract != null ? $Contract->contractNumber : '' ?>" maxlength="30" size="20" />
		</td>
	</tr>
    <tr>
		<td nowrap width="1%">Mã khách hàng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCustomerId" value="<?php echo $Contract != null ? $Contract->customerId : '' ?>" maxlength="30" size="20" /><input type="button" value="...">
		</td>
	</tr>
    <tr>
		<td nowrap width="1%">Mã công ty&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCompanyId" value="<?php echo $Contract != null ? $Contract->companyId : '' ?>" maxlength="30" size="20" /><input type="button" value="...">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Ngày tạo hợp đồng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtContractDate" value="<?php echo $Contract != null ? $Contract->contractDate : '' ?>" maxlength="10" size="20" /><input type="button" value="...">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Loại hợp đồng&nbsp;</td>
		<td>
            <select name="cbbContractType" style="border-style: solid; border-width: 1px; border-color: teal">
				<?php foreach (ContractTypeMasterList as $key => $value) {?>
				<option value="<?php echo $key ?>"><?php echo $value ?></option>
				<?php }?>
			</select>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Mô tả&nbsp;</td>
		<td>
            <textarea name="txtDescription" Rows="5" Cols="70"/>
		</td>
	</tr>
	<tr>
		<td colspan="2" align="center">
            <input type="button" value="Lưu" id="btnSave" >
			<input type="button" value="Bỏ qua" id="btnCancel">
		</td>
	</tr>
</table>
</div>
</form>
</body>
</html>
