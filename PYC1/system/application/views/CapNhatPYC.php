<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Cập nhật trạng thái phiếu yêu cầu</h2>
<table border="0" width="40%" cellspacing="1" cellpadding="1" id="table1">
	<tr>
		<td nowrap width="1%">Mã phiếu yêu cầu&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtRequestId" value="<?php echo $Request != null ? $Request->requestId : '' ?>"  maxlength="10" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Trạng thái&nbsp;</td>
		<td>
			<select name="cbbStatus">
                <?php foreach ($StatusList as $key => $value) {?>
				<option value="<?php echo $key ?>"><?php echo $value ?></option>
				<?php }?>
            </select>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Ngày nhận phiếu&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtFinishDate" value="<?php echo $Request != null ? $Request->finishDate : '' ?>" maxlength="10" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Nhân viên kĩ thuật&nbsp;</td>
		<td>
			<select name="cbbEmployee" style="border-style: solid; border-width: 1px; border-color: teal">
                <?php foreach ($CompanyList as $key => $value) {?>
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

