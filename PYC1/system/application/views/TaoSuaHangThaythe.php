<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
<form id="mainform">
<div id="divKhachHangCongTy" >
<h2>Thông tin mặt hàng thay thế</h2>
<table border="0" width="40%" cellspacing="0" cellpadding="0" id="table1">
	<tr>
		<td nowrap width="1%">Mã sản phẩm&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtReplacePartId" value="<?php echo $ReplacePart != null ? $ReplacePart->replacePartId : '' ?>"  maxlength="30" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Tên sản phẩm&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtPartNo" value="<?php echo $ReplacePart != null ? $ReplacePart->partNo : '' ?>" maxlength="100" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Số lượng&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtQuantity" value="<?php echo $ReplacePart != null ? $ReplacePart->quantity : '' ?>" maxlength="10" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Giá(USD)&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtPriceUsd" value="<?php echo $ReplacePart != null ? $ReplacePart->priceUsd : '' ?>" maxlength="10" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Giá(VND)&nbsp;</td>
		<td>
            <input type="text" class="input_text" name="txtPriceVnd" value="<?php echo $ReplacePart != null ? $ReplacePart->priceVnd : '' ?>" maxlength="10" size="20"/>
		</td>
	</tr>
	<tr>
		<td nowrap width="1%">Mô tả&nbsp;</td>
		<td>
            <textarea class="input_text" name="txtDescription" value="<?php echo $ReplacePart != null ? $ReplacePart->description : '' ?>" cols="70" rows="5"></textarea>
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


