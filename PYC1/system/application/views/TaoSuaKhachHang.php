<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel='stylesheet' type='text/css' href='/index.php/mystyle.css' />
<title>Mã khách hàng</title>
<script type="text/javascript">
	function ShowDiv(idShow, idHide) 
	{
		var divShowArea = document.getElementById(idShow);
		var divHideArea = document.getElementById(idHide);
		if (divShowArea != null && divHideArea != null) 
		{
			divShowArea.style.display = 'block';
			divHideArea.style.display = 'none';
		}
	}
</script>
</head>

<body>
<center>
<form id="mainform" action="companycontroller/action/save">
<table border="0" width="40%" cellspacing="0" cellpadding="0" id="table1">
	<tr>
		<td nowrap width="1%">
			<input type="radio" value="1" checked name="rbCompany" onclick="ShowDiv('divKhachHangCongTy', 'divKhachHangCaNhan')">Khách hàng công ty
		</td>
		<td>
			<input type="radio" value="0" name="rbCompany" onclick="ShowDiv('divKhachHangCaNhan', 'divKhachHangCongTy')">Khách hàng cá nhân
		</td>
	</tr>
</table>
<br/>
<div id="divKhachHangCaNhan" style="display:none">
<h2>Thông tin khách hàng cá nhân</h2>
<table border="0" width="40%" cellspacing="0" cellpadding="0" id="table1">
	<tr>
		<td nowrap width="1%">Mã khách hàng </td>
		<td>
			<input type="text" class="input_text" name="txtCustomerId" value="<?php echo $Customer != null ? $Customer->customerId : '' ?>" maxlength="10" disabled="disabled">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Tên khách hàng </td>
		<td>
			<input type="text" class="input_text" name="txtCustomerName" value="<?php echo $Customer != null ? $Customer->customerName : '' ?>" maxlength="100">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Địa chỉ </td>
		<td>
			<input type="text" class="input_text" name="txtAddress" value="<?php echo $Customer != null ? $Customer->address : '' ?>" size="40" maxlength="500">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Điện thoại </td>
		<td>
			<input type="text" class="input_text" name="txtPhone" value="<?php echo $Customer != null ? $Customer->phone : '' ?>" size="20" maxlength="30">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Fax </td>
		<td>
			<input type="text" class="input_text" name="txtFax" value="<?php echo $Customer != null ? $Customer->fax : '' ?>" size="20" maxlength="30">
		</td>
	</tr>
	<tr>
		<td colspan="2" align="left">
			<input type="submit" value="Lưu" >
			<input type="button" value="Bỏ qua">
		</td>
	</tr>
</table>
</div>

<div id="divKhachHangCongTy" >
<h2>Thông tin khách hàng công ty</h2>
<table border="0" width="40%" cellspacing="0" cellpadding="0" id="table1">
	<tr>
		<td nowrap width="1%">Mã công ty </td>
		<td>
			<input type="text" class="input_text" name="txtCompanyId" value="<?php echo $Customer != null ? $Customer->companyId : '' ?>" maxlength="10" disabled="disabled">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Tên công ty </td>
		<td>
			<input type="text" class="input_text" name="txtCompanyName" value="<?php echo $Company != null ? $Company->companyName : '' ?>" maxlength="100">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Địa chỉ </td>
		<td>
			<input type="text" class="input_text" name="txtCompanyAddress" value="<?php echo $Company != null ? $Company->address : '' ?>" size="40" maxlength="500">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Điện thoại </td>
		<td>
			<input type="text" class="input_text" name="txtCompanyPhone" value="<?php echo $Company != null ? $Company->phone : '' ?>" size="20" maxlength="30">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Fax </td>
		<td>
			<input type="text" class="input_text" name="txtCompanyFax" value="<?php echo $Company != null ? $Company->fax : '' ?>" size="20" maxlength="30">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Tên người đại diện </td>
		<td>
			<input type="text" class="input_text" name="txtRepresentName" value="<?php echo $Company != null ? $Company->representName : '' ?>" maxlength="100">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Điện thoại người đại diện </td>
		<td>
			<input type="text" class="input_text" name="txtRepresentPhone" value="<?php echo $Company != null ? $Company->representPhone : '' ?>" size="20" maxlength="30">
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Fax </td>
		<td>
			<input type="text" class="input_text" name="txtRepresentFax" value="<?php echo $Company != null ? $Company->representFax : '' ?>" size="20" maxlength="30">
		</td>
	</tr>

	<tr>
		<td colspan="2" align="left">
			<input type="button" value="Lưu" >
			<input type="button" value="Bỏ qua">
		</td>
	</tr>
</table>
</div>
</form>
</center>
</body>
</html>
