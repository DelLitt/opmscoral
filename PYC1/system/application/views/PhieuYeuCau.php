<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<h2>Thông tin Phiếu yêu cầu</h2>
<table border="0" width="500px" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap><label>Mã phiếu&nbsp;</label></td>
		<td>
			<input type="text" class="input_text" name="txtRequestId" value="<?php echo $Request != null ? $Request->requestId : '' ?>" size="20px" maxlength="20" disabled="disabled">
		</td>
		<td nowrap><label>Ngày&nbsp;</label></td>
		<td>
			<input type="text" class="input_text" name="txtReportDate" value="<?php echo $Request != null ? $Request->reportDate : '' ?>" size="20px" maxlength="10" readonly="readonly">
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Mã công ty&nbsp;</label></td>
		<td>
			<input type="text" name="txtCompanyId" class="input_text" value="<?php echo $Request != null && $Request->company != null ? $Request->company->companyId : '' ?>" size="20px" maxlength="10"><input type="button" value="..." >&nbsp;
		</td>
		<td nowrap ><label>Mã khách hàng&nbsp;</label></td>
		<td>
			<input type="text" class="input_text" name="txtCustomerId" value="<?php echo $Request != null && $Request->customer != null ? $Request->customer->customerId : '' ?>" size="20px" maxlength="10"><input type="button" value="..." >
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Tên công ty&nbsp;</label></td>
		<td>
			<input type="text" name="txtCompanyName" class="input_text"  size="20px" maxlength="100" readonly="readonly">
		</td>
		<td nowrap ><label>Tên khách hàng&nbsp;</label></td>
		<td>
			<input type="text" name="txtCustomerName" class="input_text"  size="20px" maxlength="100" readonly="readonly">
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Địa chỉ&nbsp;</label></td>
		<td colspan="3">
			<input type="text" name="txtAddress" class="input_text" size="72px" maxlength="500" readonly="readonly">
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Điện thoại&nbsp;</label></td>
		<td>
			<input type="text" name="txtPhone" class="input_text" size="20px" maxlength="30" readonly="readonly">
		</td>
		<td nowrap ><label>Fax&nbsp;</label></td>
		<td>
			<input type="text" name="txtFax" class="input_text" size="20px" maxlength="30" readonly="readonly">
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Số hợp đồng&nbsp;</label></td>
		<td>
			<input type="text" name="txtContractNumber" class="input_text" size="20px" maxlength="10"><input type="button" value="..." >&nbsp;
		</td>
		<td nowrap ><label>Mã máy&nbsp;</label></td>
		<td>
			<input type="text" class="input_text" name="txtMachineId" value="<?php echo $Request != null ? $Request->machineId : '' ?>" size="20px" maxlength="10"><input type="button" value="..." >
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Loại máy&nbsp;</label></td>
		<td>
			<select name="cbbMachineType">
                <?php foreach ($MachineTypeList as $key => $value) {?>
				<option value="<?php echo $key ?>"><?php echo $value ?></option>
				<?php }?>
            </select>
		</td>
		<td nowrap ><label>Số máy&nbsp;</label></td>
		<td>
			<input type="text" name="txtFax" size="20px" maxlength="30">
		</td>
	</tr>
    <tr>
		<td nowrap ><label>Counter No&nbsp;</label></td>
		<td>
			<input type="text" name="txtCounterNo" size="20px" maxlength="30" >
		</td>
		<td nowrap ><label>Màu&nbsp;</label></td>
		<td>
			<input type="text" name="txtColor" size="20px" maxlength="30" >
		</td>
	</tr>
    <tr>
		<td nowrap ><label>Fax - Truyền(TX)&nbsp;</label></td>
		<td>
			<input type="text" name="txtFaxTx" size="20px" maxlength="30" >
		</td>
		<td nowrap ><label>Nhận(RX)&nbsp;</label></td>
		<td>
			<input type="text" name="txtReceiveRx" size="20px" maxlength="30" >
		</td>
	</tr>
    <tr>
		<td nowrap ><label>Preport - Master&nbsp;</label></td>
		<td>
			<input type="text" name="txtPreportMaster" size="20px" maxlength="30">
		</td>
		<td nowrap ><label>Copy&nbsp;</label></td>
		<td>
			<input type="text" name="txtCopy" size="20px" maxlength="30" >
		</td>
	</tr>
	<tr>
		<td nowrap ><label>Loại máy&nbsp;</label></td>
		<td colspan="3">
			<select name="cbbContractType">
                    <option value="UNIVERSAL_RECORD">Universal Record</option>
                    <option value="VEHICLE">Vehicle Reservation</option>
                    <option value="MCO">MCO Number</option>
                    <option value="ELECTRONIC_TICKET">Electronic Ticket</option>
            </select>
		</td>
	</tr>
	<tr>
		<td nowrap  valign="top"><label>Loại công tác&nbsp;</label></td>
		<td>
			<input type="checkbox" name="chkInstallation" />Lắp đặt
		</td>
		<td>
			<input type="checkbox" name="chkPM" />Bảo trì
		</td>
		<td>
			<input type="checkbox" name="chkFollowUp" />Làm tiếp
		</td>
	</tr>
	<tr>
		<td nowrap  valign="top"><label>&nbsp;</label></td>
		<td>
			<input type="checkbox" name="chkRemoval" />Di chuyển
		</td>
		<td>
			<input type="checkbox" name="chkEM" />Sửa chữa
		</td>
		<td>
			<input type="checkbox" name="chkDelivery" />Giao hàng
		</td>
	</tr>
	<tr>
		<td nowrap  valign="top"><label>Mô tả&nbsp;</label></td>
		<td colspan="3">
			<textarea name="txtDescription" rows="6" cols="60"></textarea>
		</td>
	</tr>
	<tr>
		<td colspan="4" align="center">
			<input type="button" value="Lưu" >
			<input type="button" value="Bỏ qua">
		</td>
	</tr>
</table>
</form>
</body>
</html>

