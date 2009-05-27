<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Tạo/Chỉnh sửa máy</h2>
<table border="0" width="40%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã sản phẩm&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtMachineId" value="<?php echo $Machine != null ? $Machine->machineId : '' ?>"  maxlength="10" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Tên sản phẩm&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtMachineName" value="<?php echo $Machine != null ? $Machine->machineName : '' ?>" maxlength="30" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Loại sản phẩm&nbsp;</td>
		<td>
            <select name="cbbMachineType" style="border-style: solid; border-width: 1px; border-color: teal">
				<?php foreach ($MachineTypeList as $key => $value) {?>
				<option value="<?php echo $key ?>"><?php echo $value ?></option>
				<?php }?>
			</select>
		</td>
	</tr>
    <tr>
		<td nowrap width="1%">Số hiệu&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtSerialNumber" value="<?php echo $Machine != null ? $Machine->serialNumber : '' ?>" maxlength="30" size="20"/>
		</td>
	</tr>
    <tr>
		<td nowrap width="1%">Counter No&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCounterNo" value="<?php echo $Machine != null ? $Machine->counterNo : '' ?>" maxlength="30" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Màu&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtColor" value="<?php echo $Machine != null ? $Machine->color : '' ?>" maxlength="30" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Fax - Truyền(TX)&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtFaxTx" value="<?php echo $Machine != null ? $Machine->faxTx : '' ?>" maxlength="30" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Nhận(RX)&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtReceiveRx" value="<?php echo $Machine != null ? $Machine->receiveRx : '' ?>" maxlength="30" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Preport - Master&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtPreportMaster" value="<?php echo $Machine != null ? $Machine->preportMaster : '' ?>" maxlength="30" size="20"/>        
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Copy&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtCopy" value="<?php echo $Machine != null ? $Machine->copy : '' ?>" maxlength="30" size="20"/>                
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Mô tả&nbsp;</td>
		<td>
            <textarea class="input_text" name="txtDescription" value="<?php echo $Machine != null ? $Machine->description : '' ?>"
 rows="5" cols="70"></textarea>
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