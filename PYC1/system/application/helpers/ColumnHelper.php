<?php

class ColumnHelper {
	function mapContractColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'contractId': 
				$result = 'contract.CONTRACT_ID';
				break;
            case 'contractNumber': 
				$result = 'contract.CONTRACT_NUMBER';
				break;
            case 'contractDate': 
				$result = 'contract.CONTRACT_DATE';
				break;
            case 'createDate': 
				$result = 'contract.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'contract.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'contract.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'contract.UPDATE_USER';
				break;
		    case 'Customer.customerId':
			    $result = 'customer.CUSTOMER_ID';
				break;
		    case 'Customer.customerName':
			    $result = 'customer.CUSTOMER_NAME';
				break;
		    case 'Customer.address':
			    $result = 'customer.ADDRESS';
				break;
		    case 'Customer.companyId':
			    $result = 'customer.COMPANY_ID';
				break;
		    case 'Customer.phone':
			    $result = 'customer.PHONE';
				break;
		    case 'Customer.fax':
			    $result = 'customer.FAX';
				break;
		    case 'Customer.createDate':
			    $result = 'customer.CREATE_DATE';
				break;
		    case 'Customer.createUser':
			    $result = 'customer.CREATE_USER';
				break;
		    case 'Customer.updateDate':
			    $result = 'customer.UPDATE_DATE';
				break;
		    case 'Customer.updateUser':
			    $result = 'customer.UPDATE_USER';
				break;
		    case 'Company.companyId':
			    $result = 'company.COMPANY_ID';
				break;
		    case 'Company.companyName':
			    $result = 'company.COMPANY_NAME';
				break;
		    case 'Company.address':
			    $result = 'company.ADDRESS';
				break;
		    case 'Company.phone':
			    $result = 'company.PHONE';
				break;
		    case 'Company.createDate':
			    $result = 'company.CREATE_DATE';
				break;
		    case 'Company.createUser':
			    $result = 'company.CREATE_USER';
				break;
		    case 'Company.updateDate':
			    $result = 'company.UPDATE_DATE';
				break;
		    case 'Company.updateUser':
			    $result = 'company.UPDATE_USER';
				break;
		    case 'ContractTypeMaster.contractTypeId':
			    $result = 'contract_type_master.CONTRACT_TYPE_ID';
				break;
		    case 'ContractTypeMaster.contractTypeName':
			    $result = 'contract_type_master.CONTRACT_TYPE_NAME';
				break;
		endswitch;
		return $result;
	}
	
	function mapRequestActionTypeMasterColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'requestActionTypeId': 
				$result = 'request_action_type_master.REQUEST_ACTION_TYPE_ID';
				break;
            case 'requestActionTypeName': 
				$result = 'request_action_type_master.REQUEST_ACTION_TYPE_NAME';
				break;
		endswitch;
		return $result;
	}
	
	function mapStatusTypeMasterColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'statusType': 
				$result = 'status_type_master.STATUS_TYPE';
				break;
            case 'statusName': 
				$result = 'status_type_master.STATUS_NAME';
				break;
		endswitch;
		return $result;
	}
	
	function mapEmployeeRequestColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'requestId': 
				$result = 'employee_request.REQUEST_ID';
				break;
		    case 'employeeId': 
				$result = 'employee_request.EMPLOYEE_ID';
				break;
		    case 'requestActionTypeId': 
				$result = 'employee_request.REQUEST_ACTION_TYPE_ID';
				break;
		endswitch;
		return $result;
	}
	
	function mapMachineTypeMasterColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'typeId': 
				$result = 'machine_type_master.type_id';
				break;
            case 'typeName': 
				$result = 'machine_type_master.type_name';
				break;
		endswitch;
		return $result;
	}
	
	function mapRequestStatusColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'requestStatusId': 
				$result = 'request_status.REQUEST_STATUS_ID';
				break;
            case 'createDate': 
				$result = 'request_status.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'request_status.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'request_status.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'request_status.UPDATE_USER';
				break;
            case 'description': 
				$result = 'request_status.DESCRIPTION';
				break;
		    case 'StatusTypeMaster.statusType':
			    $result = 'status_type_master.STATUS_TYPE';
				break;
		    case 'StatusTypeMaster.statusName':
			    $result = 'status_type_master.STATUS_NAME';
				break;
		    case 'Request.requestId':
			    $result = 'request.REQUEST_ID';
				break;
		    case 'Request.machineId':
			    $result = 'request.MACHINE_ID';
				break;
		    case 'Request.followUpRequestId':
			    $result = 'request.FOLLOW_UP_REQUEST_ID';
				break;
		    case 'Request.customerCallDate':
			    $result = 'request.CUSTOMER_CALL_DATE';
				break;
		    case 'Request.reportDate':
			    $result = 'request.REPORT_DATE';
				break;
		    case 'Request.finishDate':
			    $result = 'request.FINISH_DATE';
				break;
		    case 'Request.serviceType':
			    $result = 'request.SERVICE_TYPE';
				break;
		    case 'Request.problemReport':
			    $result = 'request.PROBLEM_REPORT';
				break;
		    case 'Request.symptom':
			    $result = 'request.SYMPTOM';
				break;
		    case 'Request.cause':
			    $result = 'request.CAUSE';
				break;
		    case 'Request.action':
			    $result = 'request.ACTION';
				break;
		    case 'Request.customerOpinion':
			    $result = 'request.CUSTOMER_OPINION';
				break;
		    case 'Request.createDate':
			    $result = 'request.CREATE_DATE';
				break;
		    case 'Request.createUser':
			    $result = 'request.CREATE_USER';
				break;
		    case 'Request.updateDate':
			    $result = 'request.UPDATE_DATE';
				break;
		    case 'Request.updateUser':
			    $result = 'request.UPDATE_USER';
				break;
		    case 'Request.requestCost':
			    $result = 'request.REQUEST_COST';
				break;
		endswitch;
		return $result;
	}
	
	function mapCustomerColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'customerId': 
				$result = 'customer.CUSTOMER_ID';
				break;
            case 'customerName': 
				$result = 'customer.CUSTOMER_NAME';
				break;
            case 'address': 
				$result = 'customer.ADDRESS';
				break;
            case 'companyId': 
				$result = 'customer.COMPANY_ID';
				break;
            case 'phone': 
				$result = 'customer.PHONE';
				break;
            case 'fax': 
				$result = 'customer.FAX';
				break;
            case 'createDate': 
				$result = 'customer.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'customer.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'customer.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'customer.UPDATE_USER';
				break;
		endswitch;
		return $result;
	}
	
	function mapReplacePartColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'replacePartId': 
				$result = 'replace_part.REPLACE_PART_ID';
				break;
            case 'partNo': 
				$result = 'replace_part.PART_NO';
				break;
            case 'description': 
				$result = 'replace_part.DESCRIPTION';
				break;
            case 'quantity': 
				$result = 'replace_part.QUANTITY';
				break;
            case 'priceUsd': 
				$result = 'replace_part.PRICE_USD';
				break;
            case 'priceVnd': 
				$result = 'replace_part.PRICE_VND';
				break;
            case 'createDate': 
				$result = 'replace_part.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'replace_part.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'replace_part.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'replace_part.UPDATE_USER';
				break;
		    case 'Request.requestId':
			    $result = 'request.REQUEST_ID';
				break;
		    case 'Request.machineId':
			    $result = 'request.MACHINE_ID';
				break;
		    case 'Request.followUpRequestId':
			    $result = 'request.FOLLOW_UP_REQUEST_ID';
				break;
		    case 'Request.customerCallDate':
			    $result = 'request.CUSTOMER_CALL_DATE';
				break;
		    case 'Request.reportDate':
			    $result = 'request.REPORT_DATE';
				break;
		    case 'Request.finishDate':
			    $result = 'request.FINISH_DATE';
				break;
		    case 'Request.serviceType':
			    $result = 'request.SERVICE_TYPE';
				break;
		    case 'Request.problemReport':
			    $result = 'request.PROBLEM_REPORT';
				break;
		    case 'Request.symptom':
			    $result = 'request.SYMPTOM';
				break;
		    case 'Request.cause':
			    $result = 'request.CAUSE';
				break;
		    case 'Request.action':
			    $result = 'request.ACTION';
				break;
		    case 'Request.customerOpinion':
			    $result = 'request.CUSTOMER_OPINION';
				break;
		    case 'Request.createDate':
			    $result = 'request.CREATE_DATE';
				break;
		    case 'Request.createUser':
			    $result = 'request.CREATE_USER';
				break;
		    case 'Request.updateDate':
			    $result = 'request.UPDATE_DATE';
				break;
		    case 'Request.updateUser':
			    $result = 'request.UPDATE_USER';
				break;
		    case 'Request.requestCost':
			    $result = 'request.REQUEST_COST';
				break;
		endswitch;
		return $result;
	}
	
	function mapRoleMasterColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'roleId': 
				$result = 'role_master.ROLE_ID';
				break;
            case 'roleName': 
				$result = 'role_master.ROLE_NAME';
				break;
		endswitch;
		return $result;
	}
	
	function mapMachineColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'machineId': 
				$result = 'machine.MACHINE_ID';
				break;
            case 'machineName': 
				$result = 'machine.MACHINE_NAME';
				break;
            case 'serialNumber': 
				$result = 'machine.SERIAL_NUMBER';
				break;
            case 'model': 
				$result = 'machine.MODEL';
				break;
            case 'counterNo': 
				$result = 'machine.COUNTER_NO';
				break;
            case 'color': 
				$result = 'machine.COLOR';
				break;
            case 'faxTx': 
				$result = 'machine.FAX_TX';
				break;
            case 'receiveRx': 
				$result = 'machine.RECEIVE_RX';
				break;
            case 'preportMaster': 
				$result = 'machine.PREPORT_MASTER';
				break;
            case 'copy': 
				$result = 'machine.COPY';
				break;
            case 'createDate': 
				$result = 'machine.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'machine.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'machine.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'machine.UPDATE_USER';
				break;
		    case 'MachineTypeMaster.typeId':
			    $result = 'machine_type_master.type_id';
				break;
		    case 'MachineTypeMaster.typeName':
			    $result = 'machine_type_master.type_name';
				break;
		endswitch;
		return $result;
	}
	
	function mapCompanyColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'companyId': 
				$result = 'company.COMPANY_ID';
				break;
            case 'companyName': 
				$result = 'company.COMPANY_NAME';
				break;
            case 'address': 
				$result = 'company.ADDRESS';
				break;
            case 'phone': 
				$result = 'company.PHONE';
				break;
            case 'createDate': 
				$result = 'company.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'company.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'company.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'company.UPDATE_USER';
				break;
		endswitch;
		return $result;
	}
	
	function mapContractTypeMasterColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'contractTypeId': 
				$result = 'contract_type_master.CONTRACT_TYPE_ID';
				break;
            case 'contractTypeName': 
				$result = 'contract_type_master.CONTRACT_TYPE_NAME';
				break;
		endswitch;
		return $result;
	}
	
	function mapContractMachineColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'contractId': 
				$result = 'contract_machine.CONTRACT_ID';
				break;
		    case 'machineId': 
				$result = 'contract_machine.MACHINE_ID';
				break;
		endswitch;
		return $result;
	}
	
	function mapEmployeeColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'employeeId': 
				$result = 'employee.EMPLOYEE_ID';
				break;
            case 'employeeName': 
				$result = 'employee.EMPLOYEE_NAME';
				break;
            case 'roleId': 
				$result = 'employee.ROLE_ID';
				break;
            case 'address': 
				$result = 'employee.ADDRESS';
				break;
            case 'phone': 
				$result = 'employee.PHONE';
				break;
            case 'loginName': 
				$result = 'employee.LOGIN_NAME';
				break;
            case 'createDate': 
				$result = 'employee.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'employee.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'employee.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'employee.UPDATE_USER';
				break;
		    case 'RoleMaster.roleId':
			    $result = 'role_master.ROLE_ID';
				break;
		    case 'RoleMaster.roleName':
			    $result = 'role_master.ROLE_NAME';
				break;
		endswitch;
		return $result;
	}
	
	function mapRequestColumn($propertyName) {
		$result = null;
		switch ($propertyName):
		    case 'requestId': 
				$result = 'request.REQUEST_ID';
				break;
            case 'machineId': 
				$result = 'request.MACHINE_ID';
				break;
            case 'followUpRequestId': 
				$result = 'request.FOLLOW_UP_REQUEST_ID';
				break;
            case 'customerCallDate': 
				$result = 'request.CUSTOMER_CALL_DATE';
				break;
            case 'reportDate': 
				$result = 'request.REPORT_DATE';
				break;
            case 'finishDate': 
				$result = 'request.FINISH_DATE';
				break;
            case 'serviceType': 
				$result = 'request.SERVICE_TYPE';
				break;
            case 'problemReport': 
				$result = 'request.PROBLEM_REPORT';
				break;
            case 'symptom': 
				$result = 'request.SYMPTOM';
				break;
            case 'cause': 
				$result = 'request.CAUSE';
				break;
            case 'action': 
				$result = 'request.ACTION';
				break;
            case 'customerOpinion': 
				$result = 'request.CUSTOMER_OPINION';
				break;
            case 'createDate': 
				$result = 'request.CREATE_DATE';
				break;
            case 'createUser': 
				$result = 'request.CREATE_USER';
				break;
            case 'updateDate': 
				$result = 'request.UPDATE_DATE';
				break;
            case 'updateUser': 
				$result = 'request.UPDATE_USER';
				break;
            case 'requestCost': 
				$result = 'request.REQUEST_COST';
				break;
		    case 'Contract.contractId':
			    $result = 'contract.CONTRACT_ID';
				break;
		    case 'Contract.contractNumber':
			    $result = 'contract.CONTRACT_NUMBER';
				break;
		    case 'Contract.contractDate':
			    $result = 'contract.CONTRACT_DATE';
				break;
		    case 'Contract.createDate':
			    $result = 'contract.CREATE_DATE';
				break;
		    case 'Contract.createUser':
			    $result = 'contract.CREATE_USER';
				break;
		    case 'Contract.updateDate':
			    $result = 'contract.UPDATE_DATE';
				break;
		    case 'Contract.updateUser':
			    $result = 'contract.UPDATE_USER';
				break;
		    case 'Customer.customerId':
			    $result = 'customer.CUSTOMER_ID';
				break;
		    case 'Customer.customerName':
			    $result = 'customer.CUSTOMER_NAME';
				break;
		    case 'Customer.address':
			    $result = 'customer.ADDRESS';
				break;
		    case 'Customer.companyId':
			    $result = 'customer.COMPANY_ID';
				break;
		    case 'Customer.phone':
			    $result = 'customer.PHONE';
				break;
		    case 'Customer.fax':
			    $result = 'customer.FAX';
				break;
		    case 'Customer.createDate':
			    $result = 'customer.CREATE_DATE';
				break;
		    case 'Customer.createUser':
			    $result = 'customer.CREATE_USER';
				break;
		    case 'Customer.updateDate':
			    $result = 'customer.UPDATE_DATE';
				break;
		    case 'Customer.updateUser':
			    $result = 'customer.UPDATE_USER';
				break;
		    case 'Company.companyId':
			    $result = 'company.COMPANY_ID';
				break;
		    case 'Company.companyName':
			    $result = 'company.COMPANY_NAME';
				break;
		    case 'Company.address':
			    $result = 'company.ADDRESS';
				break;
		    case 'Company.phone':
			    $result = 'company.PHONE';
				break;
		    case 'Company.createDate':
			    $result = 'company.CREATE_DATE';
				break;
		    case 'Company.createUser':
			    $result = 'company.CREATE_USER';
				break;
		    case 'Company.updateDate':
			    $result = 'company.UPDATE_DATE';
				break;
		    case 'Company.updateUser':
			    $result = 'company.UPDATE_USER';
				break;
		endswitch;
		return $result;
	}
	
}
?>