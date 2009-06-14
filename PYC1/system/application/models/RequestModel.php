<?php

class RequestModel extends Model {

    function insert($Request) {
		$sql = 'INSERT INTO request(';
        
        $sql .= '    FOLLOW_UP_REQUEST_ID, ';
        $sql .= '    CUSTOMER_CALL_DATE, ';
        $sql .= '    REPORT_DATE, ';
        $sql .= '    FINISH_DATE, ';
        $sql .= '    SERVICE_TYPE, ';
        $sql .= '    PROBLEM_REPORT, ';
        $sql .= '    SYMPTOM, ';
        $sql .= '    CAUSE, ';
        $sql .= '    ACTION, ';
        $sql .= '    CUSTOMER_OPINION, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    REQUEST_COST, ';
        $sql .= '    TEMP_CUSTOMER_NAME, ';
        $sql .= '    TEMP_COMPANY_NAME, ';
        $sql .= '    TEMP_ADDRESS, ';
        $sql .= '    TEMP_PHONE, ';
        $sql .= '    TEMP_FAX ';
        $sql .= '    CONTRACT_ID, ';
        $sql .= '    CUSTOMER_ID, ';
        $sql .= '    MACHINE_ID, ';
        $sql .= '    COMPANY_ID, ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($Request['followUpRequestId']) ? $Request['followUpRequestId'] : null;
        $paramArr[] = isset($Request['customerCallDate']) ? $Request['customerCallDate'] : null;
        $paramArr[] = isset($Request['reportDate']) ? $Request['reportDate'] : null;
        $paramArr[] = isset($Request['finishDate']) ? $Request['finishDate'] : null;
        $paramArr[] = isset($Request['serviceType']) ? $Request['serviceType'] : null;
        $paramArr[] = isset($Request['problemReport']) ? $Request['problemReport'] : null;
        $paramArr[] = isset($Request['symptom']) ? $Request['symptom'] : null;
        $paramArr[] = isset($Request['cause']) ? $Request['cause'] : null;
        $paramArr[] = isset($Request['action']) ? $Request['action'] : null;
        $paramArr[] = isset($Request['customerOpinion']) ? $Request['customerOpinion'] : null;
        $paramArr[] = isset($Request['createDate']) ? $Request['createDate'] : null;
        $paramArr[] = isset($Request['createUser']) ? $Request['createUser'] : null;
        $paramArr[] = isset($Request['updateDate']) ? $Request['updateDate'] : null;
        $paramArr[] = isset($Request['updateUser']) ? $Request['updateUser'] : null;
        $paramArr[] = isset($Request['requestCost']) ? $Request['requestCost'] : null;
        $paramArr[] = isset($Request['tempCustomerName']) ? $Request['tempCustomerName'] : null;
        $paramArr[] = isset($Request['tempCompanyName']) ? $Request['tempCompanyName'] : null;
        $paramArr[] = isset($Request['tempAddress']) ? $Request['tempAddress'] : null;
        $paramArr[] = isset($Request['tempPhone']) ? $Request['tempPhone'] : null;
        $paramArr[] = isset($Request['tempFax']) ? $Request['tempFax'] : null;
		if ($Request->contract != null) {
        	$paramArr[] = isset($Request['contract.contractId']) ? $Request['contract.contractId'] : null;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->customer != null) {
        	$paramArr[] = isset($Request['customer.customerId']) ? $Request['customer.customerId'] : null;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->machine != null) {
        	$paramArr[] = isset($Request['machine.machineId']) ? $Request['machine.machineId'] : null;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->company != null) {
        	$paramArr[] = isset($Request['company.companyId']) ? $Request['company.companyId'] : null;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Request) {
		$sql = 'UPDATE request SET ';
        $sql .= '    FOLLOW_UP_REQUEST_ID = ? ';
        $sql .= '    ,CUSTOMER_CALL_DATE = ? ';
        $sql .= '    ,REPORT_DATE = ? ';
        $sql .= '    ,FINISH_DATE = ? ';
        $sql .= '    ,SERVICE_TYPE = ? ';
        $sql .= '    ,PROBLEM_REPORT = ? ';
        $sql .= '    ,SYMPTOM = ? ';
        $sql .= '    ,CAUSE = ? ';
        $sql .= '    ,ACTION = ? ';
        $sql .= '    ,CUSTOMER_OPINION = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,REQUEST_COST = ? ';
        $sql .= '    ,TEMP_CUSTOMER_NAME = ? ';
        $sql .= '    ,TEMP_COMPANY_NAME = ? ';
        $sql .= '    ,TEMP_ADDRESS = ? ';
        $sql .= '    ,TEMP_PHONE = ? ';
        $sql .= '    ,TEMP_FAX = ? ';
        $sql .= '    ,CONTRACT_ID = ? ';
        $sql .= '    ,CUSTOMER_ID = ? ';
        $sql .= '    ,MACHINE_ID = ? ';
        $sql .= '    ,COMPANY_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    REQUEST_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($Request['followUpRequestId']) ? $Request['followUpRequestId'] : null;
        $paramArr[] = isset($Request['customerCallDate']) ? $Request['customerCallDate'] : null;
        $paramArr[] = isset($Request['reportDate']) ? $Request['reportDate'] : null;
        $paramArr[] = isset($Request['finishDate']) ? $Request['finishDate'] : null;
        $paramArr[] = isset($Request['serviceType']) ? $Request['serviceType'] : null;
        $paramArr[] = isset($Request['problemReport']) ? $Request['problemReport'] : null;
        $paramArr[] = isset($Request['symptom']) ? $Request['symptom'] : null;
        $paramArr[] = isset($Request['cause']) ? $Request['cause'] : null;
        $paramArr[] = isset($Request['action']) ? $Request['action'] : null;
        $paramArr[] = isset($Request['customerOpinion']) ? $Request['customerOpinion'] : null;
        $paramArr[] = isset($Request['createDate']) ? $Request['createDate'] : null;
        $paramArr[] = isset($Request['createUser']) ? $Request['createUser'] : null;
        $paramArr[] = isset($Request['updateDate']) ? $Request['updateDate'] : null;
        $paramArr[] = isset($Request['updateUser']) ? $Request['updateUser'] : null;
        $paramArr[] = isset($Request['requestCost']) ? $Request['requestCost'] : null;
        $paramArr[] = isset($Request['tempCustomerName']) ? $Request['tempCustomerName'] : null;
        $paramArr[] = isset($Request['tempCompanyName']) ? $Request['tempCompanyName'] : null;
        $paramArr[] = isset($Request['tempAddress']) ? $Request['tempAddress'] : null;
        $paramArr[] = isset($Request['tempPhone']) ? $Request['tempPhone'] : null;
        $paramArr[] = isset($Request['tempFax']) ? $Request['tempFax'] : null;
       	$paramArr[] = isset($Request['contract.contractId']) ? $Request['contract.contractId'] : null;
       	$paramArr[] = isset($Request['customer.customerId']) ? $Request['customer.customerId'] : null;
       	$paramArr[] = isset($Request['machine.machineId']) ? $Request['machine.machineId'] : null;
       	$paramArr[] = isset($Request['company.companyId']) ? $Request['company.companyId'] : null;
        $paramArr[] = isset($Request['requestId']) ? $Request['requestId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    request.REQUEST_ID as request_REQUEST_ID';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID as request_FOLLOW_UP_REQUEST_ID';
        $sql .= '    ,request.CUSTOMER_CALL_DATE as request_CUSTOMER_CALL_DATE';
        $sql .= '    ,request.REPORT_DATE as request_REPORT_DATE';
        $sql .= '    ,request.FINISH_DATE as request_FINISH_DATE';
        $sql .= '    ,request.SERVICE_TYPE as request_SERVICE_TYPE';
        $sql .= '    ,request.PROBLEM_REPORT as request_PROBLEM_REPORT';
        $sql .= '    ,request.SYMPTOM as request_SYMPTOM';
        $sql .= '    ,request.CAUSE as request_CAUSE';
        $sql .= '    ,request.ACTION as request_ACTION';
        $sql .= '    ,request.CUSTOMER_OPINION as request_CUSTOMER_OPINION';
        $sql .= '    ,request.CREATE_DATE as request_CREATE_DATE';
        $sql .= '    ,request.CREATE_USER as request_CREATE_USER';
        $sql .= '    ,request.UPDATE_DATE as request_UPDATE_DATE';
        $sql .= '    ,request.UPDATE_USER as request_UPDATE_USER';
        $sql .= '    ,request.REQUEST_COST as request_REQUEST_COST';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME as request_TEMP_CUSTOMER_NAME';
        $sql .= '    ,request.TEMP_COMPANY_NAME as request_TEMP_COMPANY_NAME';
        $sql .= '    ,request.TEMP_ADDRESS as request_TEMP_ADDRESS';
        $sql .= '    ,request.TEMP_PHONE as request_TEMP_PHONE';
        $sql .= '    ,request.TEMP_FAX as request_TEMP_FAX';
        $sql .= '    ,contract.CONTRACT_ID as contract_CONTRACT_ID';
        $sql .= '    ,contract.CONTRACT_NUMBER as contract_CONTRACT_NUMBER';
        $sql .= '    ,contract.CONTRACT_DATE as contract_CONTRACT_DATE';
        $sql .= '    ,contract.CREATE_DATE as contract_CREATE_DATE';
        $sql .= '    ,contract.CREATE_USER as contract_CREATE_USER';
        $sql .= '    ,contract.UPDATE_DATE as contract_UPDATE_DATE';
        $sql .= '    ,contract.UPDATE_USER as contract_UPDATE_USER';
        $sql .= '    ,contract.DESCRIPTION as contract_DESCRIPTION';
        $sql .= '    ,customer.CUSTOMER_ID as customer_CUSTOMER_ID';
        $sql .= '    ,customer.CUSTOMER_NAME as customer_CUSTOMER_NAME';
        $sql .= '    ,customer.ADDRESS as customer_ADDRESS';
        $sql .= '    ,customer.COMPANY_ID as customer_COMPANY_ID';
        $sql .= '    ,customer.PHONE as customer_PHONE';
        $sql .= '    ,customer.FAX as customer_FAX';
        $sql .= '    ,customer.CREATE_DATE as customer_CREATE_DATE';
        $sql .= '    ,customer.CREATE_USER as customer_CREATE_USER';
        $sql .= '    ,customer.UPDATE_DATE as customer_UPDATE_DATE';
        $sql .= '    ,customer.UPDATE_USER as customer_UPDATE_USER';
        $sql .= '    ,customer.DESCRIPTION as customer_DESCRIPTION';
        $sql .= '    ,machine.MACHINE_ID as machine_MACHINE_ID';
        $sql .= '    ,machine.MACHINE_NAME as machine_MACHINE_NAME';
        $sql .= '    ,machine.SERIAL_NUMBER as machine_SERIAL_NUMBER';
        $sql .= '    ,machine.MODEL as machine_MODEL';
        $sql .= '    ,machine.COUNTER_NO as machine_COUNTER_NO';
        $sql .= '    ,machine.COLOR as machine_COLOR';
        $sql .= '    ,machine.FAX_TX as machine_FAX_TX';
        $sql .= '    ,machine.RECEIVE_RX as machine_RECEIVE_RX';
        $sql .= '    ,machine.PREPORT_MASTER as machine_PREPORT_MASTER';
        $sql .= '    ,machine.COPY as machine_COPY';
        $sql .= '    ,machine.CREATE_DATE as machine_CREATE_DATE';
        $sql .= '    ,machine.CREATE_USER as machine_CREATE_USER';
        $sql .= '    ,machine.UPDATE_DATE as machine_UPDATE_DATE';
        $sql .= '    ,machine.UPDATE_USER as machine_UPDATE_USER';
        $sql .= '    ,machine.Description as machine_Description';
        $sql .= '    ,company.COMPANY_ID as company_COMPANY_ID';
        $sql .= '    ,company.COMPANY_NAME as company_COMPANY_NAME';
        $sql .= '    ,company.ADDRESS as company_ADDRESS';
        $sql .= '    ,company.PHONE as company_PHONE';
        $sql .= '    ,company.CREATE_DATE as company_CREATE_DATE';
        $sql .= '    ,company.CREATE_USER as company_CREATE_USER';
        $sql .= '    ,company.UPDATE_DATE as company_UPDATE_DATE';
        $sql .= '    ,company.UPDATE_USER as company_UPDATE_USER';
        $sql .= '    ,company.FAX as company_FAX';
        $sql .= '    ,company.REPRESENT_NAME as company_REPRESENT_NAME';
        $sql .= '    ,company.REPRESENT_PHONE as company_REPRESENT_PHONE';
        $sql .= '    ,company.REPRESENT_FAX as company_REPRESENT_FAX';
        $sql .= '    ,company.DESCRIPTION as company_DESCRIPTION';
        $sql .= ' FROM request';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN machine ON ';
        $sql .= '        machine.MACHINE_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$sql .= ' WHERE ';
        $sql .= '    request.REQUEST_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['requestId'] = $row[0]['request_REQUEST_ID'];
            $result['followUpRequestId'] = $row[0]['request_FOLLOW_UP_REQUEST_ID'];
            $result['customerCallDate'] = $row[0]['request_CUSTOMER_CALL_DATE'];
            $result['reportDate'] = $row[0]['request_REPORT_DATE'];
            $result['finishDate'] = $row[0]['request_FINISH_DATE'];
            $result['serviceType'] = $row[0]['request_SERVICE_TYPE'];
            $result['problemReport'] = $row[0]['request_PROBLEM_REPORT'];
            $result['symptom'] = $row[0]['request_SYMPTOM'];
            $result['cause'] = $row[0]['request_CAUSE'];
            $result['action'] = $row[0]['request_ACTION'];
            $result['customerOpinion'] = $row[0]['request_CUSTOMER_OPINION'];
            $result['createDate'] = $row[0]['request_CREATE_DATE'];
            $result['createUser'] = $row[0]['request_CREATE_USER'];
            $result['updateDate'] = $row[0]['request_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['request_UPDATE_USER'];
            $result['requestCost'] = $row[0]['request_REQUEST_COST'];
            $result['tempCustomerName'] = $row[0]['request_TEMP_CUSTOMER_NAME'];
            $result['tempCompanyName'] = $row[0]['request_TEMP_COMPANY_NAME'];
            $result['tempAddress'] = $row[0]['request_TEMP_ADDRESS'];
            $result['tempPhone'] = $row[0]['request_TEMP_PHONE'];
            $result['tempFax'] = $row[0]['request_TEMP_FAX'];
        	$result['contract.contractId'] = $row[0]['contract_CONTRACT_ID'];
			$result['contract.contractNumber'] = $row[0]['contract_CONTRACT_NUMBER'];
			$result['contract.contractDate'] = $row[0]['contract_CONTRACT_DATE'];
			$result['contract.createDate'] = $row[0]['contract_CREATE_DATE'];
			$result['contract.createUser'] = $row[0]['contract_CREATE_USER'];
			$result['contract.updateDate'] = $row[0]['contract_UPDATE_DATE'];
			$result['contract.updateUser'] = $row[0]['contract_UPDATE_USER'];
			$result['contract.description'] = $row[0]['contract_DESCRIPTION'];
        	$result['customer.customerId'] = $row[0]['customer_CUSTOMER_ID'];
			$result['customer.customerName'] = $row[0]['customer_CUSTOMER_NAME'];
			$result['customer.address'] = $row[0]['customer_ADDRESS'];
			$result['customer.companyId'] = $row[0]['customer_COMPANY_ID'];
			$result['customer.phone'] = $row[0]['customer_PHONE'];
			$result['customer.fax'] = $row[0]['customer_FAX'];
			$result['customer.createDate'] = $row[0]['customer_CREATE_DATE'];
			$result['customer.createUser'] = $row[0]['customer_CREATE_USER'];
			$result['customer.updateDate'] = $row[0]['customer_UPDATE_DATE'];
			$result['customer.updateUser'] = $row[0]['customer_UPDATE_USER'];
			$result['customer.description'] = $row[0]['customer_DESCRIPTION'];
        	$result['machine.machineId'] = $row[0]['machine_MACHINE_ID'];
			$result['machine.machineName'] = $row[0]['machine_MACHINE_NAME'];
			$result['machine.serialNumber'] = $row[0]['machine_SERIAL_NUMBER'];
			$result['machine.model'] = $row[0]['machine_MODEL'];
			$result['machine.counterNo'] = $row[0]['machine_COUNTER_NO'];
			$result['machine.color'] = $row[0]['machine_COLOR'];
			$result['machine.faxTx'] = $row[0]['machine_FAX_TX'];
			$result['machine.receiveRx'] = $row[0]['machine_RECEIVE_RX'];
			$result['machine.preportMaster'] = $row[0]['machine_PREPORT_MASTER'];
			$result['machine.copy'] = $row[0]['machine_COPY'];
			$result['machine.createDate'] = $row[0]['machine_CREATE_DATE'];
			$result['machine.createUser'] = $row[0]['machine_CREATE_USER'];
			$result['machine.updateDate'] = $row[0]['machine_UPDATE_DATE'];
			$result['machine.updateUser'] = $row[0]['machine_UPDATE_USER'];
			$result['machine.description'] = $row[0]['machine_Description'];
        	$result['company.companyId'] = $row[0]['company_COMPANY_ID'];
			$result['company.companyName'] = $row[0]['company_COMPANY_NAME'];
			$result['company.address'] = $row[0]['company_ADDRESS'];
			$result['company.phone'] = $row[0]['company_PHONE'];
			$result['company.createDate'] = $row[0]['company_CREATE_DATE'];
			$result['company.createUser'] = $row[0]['company_CREATE_USER'];
			$result['company.updateDate'] = $row[0]['company_UPDATE_DATE'];
			$result['company.updateUser'] = $row[0]['company_UPDATE_USER'];
			$result['company.fax'] = $row[0]['company_FAX'];
			$result['company.representName'] = $row[0]['company_REPRESENT_NAME'];
			$result['company.representPhone'] = $row[0]['company_REPRESENT_PHONE'];
			$result['company.representFax'] = $row[0]['company_REPRESENT_FAX'];
			$result['company.description'] = $row[0]['company_DESCRIPTION'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request_REQUEST_ID as request.REQUEST_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID as request_FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE as request_CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE as request_REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE as request_FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE as request_SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT as request_PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM as request_SYMPTOM ';
        $sql .= '    ,request.CAUSE as request_CAUSE ';
        $sql .= '    ,request.ACTION as request_ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION as request_CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE as request_CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER as request_CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE as request_UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER as request_UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST as request_REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME as request_TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME as request_TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS as request_TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE as request_TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX as request_TEMP_FAX ';
        $sql .= '    ,contract.CONTRACT_ID as contract_CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER as contract_CONTRACT_NUMBER ';
        $sql .= '    ,contract.CONTRACT_DATE as contract_CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE as contract_CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER as contract_CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE as contract_UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER as contract_UPDATE_USER ';
        $sql .= '    ,contract.DESCRIPTION as contract_DESCRIPTION ';
        $sql .= '    ,customer.CUSTOMER_ID as customer_CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME as customer_CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS as customer_ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID as customer_COMPANY_ID ';
        $sql .= '    ,customer.PHONE as customer_PHONE ';
        $sql .= '    ,customer.FAX as customer_FAX ';
        $sql .= '    ,customer.CREATE_DATE as customer_CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER as customer_CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE as customer_UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER as customer_UPDATE_USER ';
        $sql .= '    ,customer.DESCRIPTION as customer_DESCRIPTION ';
        $sql .= '    ,machine.MACHINE_ID as machine_MACHINE_ID ';
        $sql .= '    ,machine.MACHINE_NAME as machine_MACHINE_NAME ';
        $sql .= '    ,machine.SERIAL_NUMBER as machine_SERIAL_NUMBER ';
        $sql .= '    ,machine.MODEL as machine_MODEL ';
        $sql .= '    ,machine.COUNTER_NO as machine_COUNTER_NO ';
        $sql .= '    ,machine.COLOR as machine_COLOR ';
        $sql .= '    ,machine.FAX_TX as machine_FAX_TX ';
        $sql .= '    ,machine.RECEIVE_RX as machine_RECEIVE_RX ';
        $sql .= '    ,machine.PREPORT_MASTER as machine_PREPORT_MASTER ';
        $sql .= '    ,machine.COPY as machine_COPY ';
        $sql .= '    ,machine.CREATE_DATE as machine_CREATE_DATE ';
        $sql .= '    ,machine.CREATE_USER as machine_CREATE_USER ';
        $sql .= '    ,machine.UPDATE_DATE as machine_UPDATE_DATE ';
        $sql .= '    ,machine.UPDATE_USER as machine_UPDATE_USER ';
        $sql .= '    ,machine.Description as machine_Description ';
        $sql .= '    ,company.COMPANY_ID as company_COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME as company_COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS as company_ADDRESS ';
        $sql .= '    ,company.PHONE as company_PHONE ';
        $sql .= '    ,company.CREATE_DATE as company_CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER as company_CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE as company_UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER as company_UPDATE_USER ';
        $sql .= '    ,company.FAX as company_FAX ';
        $sql .= '    ,company.REPRESENT_NAME as company_REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE as company_REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX as company_REPRESENT_FAX ';
        $sql .= '    ,company.DESCRIPTION as company_DESCRIPTION ';
        $sql .= ' FROM request';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN machine ON ';
        $sql .= '        machine.MACHINE_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$paramArr = array();
	    if ($criteria != null && count($criteria) > 0) {
	    	if (count($criteria['where']) > 0) {
	    		$countCriteria = count($criteria['where']);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['where'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria['operator'][$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria['order']) > 0) {
				$countCriteria = count($criteria['order']);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['order'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' , ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $value . ' '.$concator;
		        }
		    }
	    }
    
    	$query = $this->db->query($sql, $paramArr);

        if ($query->num_rows() > 0)
        {
        	$resultList = array();
        	foreach ($query->result_array() as $row) {
                $result = array();
        	    $result['requestId'] = $row['request_REQUEST_ID'];
                $result['followUpRequestId'] = $row['request_FOLLOW_UP_REQUEST_ID'];
                $result['customerCallDate'] = $row['request_CUSTOMER_CALL_DATE'];
                $result['reportDate'] = $row['request_REPORT_DATE'];
                $result['finishDate'] = $row['request_FINISH_DATE'];
                $result['serviceType'] = $row['request_SERVICE_TYPE'];
                $result['problemReport'] = $row['request_PROBLEM_REPORT'];
                $result['symptom'] = $row['request_SYMPTOM'];
                $result['cause'] = $row['request_CAUSE'];
                $result['action'] = $row['request_ACTION'];
                $result['customerOpinion'] = $row['request_CUSTOMER_OPINION'];
                $result['createDate'] = $row['request_CREATE_DATE'];
                $result['createUser'] = $row['request_CREATE_USER'];
                $result['updateDate'] = $row['request_UPDATE_DATE'];
                $result['updateUser'] = $row['request_UPDATE_USER'];
                $result['requestCost'] = $row['request_REQUEST_COST'];
                $result['tempCustomerName'] = $row['request_TEMP_CUSTOMER_NAME'];
                $result['tempCompanyName'] = $row['request_TEMP_COMPANY_NAME'];
                $result['tempAddress'] = $row['request_TEMP_ADDRESS'];
                $result['tempPhone'] = $row['request_TEMP_PHONE'];
                $result['tempFax'] = $row['request_TEMP_FAX'];
        	    $result['contract.contractId'] = $row['contract_CONTRACT_ID'];
			    $result['contract.contractNumber'] = $row['contract_CONTRACT_NUMBER'];
			    $result['contract.contractDate'] = $row['contract_CONTRACT_DATE'];
			    $result['contract.createDate'] = $row['contract_CREATE_DATE'];
			    $result['contract.createUser'] = $row['contract_CREATE_USER'];
			    $result['contract.updateDate'] = $row['contract_UPDATE_DATE'];
			    $result['contract.updateUser'] = $row['contract_UPDATE_USER'];
			    $result['contract.description'] = $row['contract_DESCRIPTION'];
        	    $result['customer.customerId'] = $row['customer_CUSTOMER_ID'];
			    $result['customer.customerName'] = $row['customer_CUSTOMER_NAME'];
			    $result['customer.address'] = $row['customer_ADDRESS'];
			    $result['customer.companyId'] = $row['customer_COMPANY_ID'];
			    $result['customer.phone'] = $row['customer_PHONE'];
			    $result['customer.fax'] = $row['customer_FAX'];
			    $result['customer.createDate'] = $row['customer_CREATE_DATE'];
			    $result['customer.createUser'] = $row['customer_CREATE_USER'];
			    $result['customer.updateDate'] = $row['customer_UPDATE_DATE'];
			    $result['customer.updateUser'] = $row['customer_UPDATE_USER'];
			    $result['customer.description'] = $row['customer_DESCRIPTION'];
        	    $result['machine.machineId'] = $row['machine_MACHINE_ID'];
			    $result['machine.machineName'] = $row['machine_MACHINE_NAME'];
			    $result['machine.serialNumber'] = $row['machine_SERIAL_NUMBER'];
			    $result['machine.model'] = $row['machine_MODEL'];
			    $result['machine.counterNo'] = $row['machine_COUNTER_NO'];
			    $result['machine.color'] = $row['machine_COLOR'];
			    $result['machine.faxTx'] = $row['machine_FAX_TX'];
			    $result['machine.receiveRx'] = $row['machine_RECEIVE_RX'];
			    $result['machine.preportMaster'] = $row['machine_PREPORT_MASTER'];
			    $result['machine.copy'] = $row['machine_COPY'];
			    $result['machine.createDate'] = $row['machine_CREATE_DATE'];
			    $result['machine.createUser'] = $row['machine_CREATE_USER'];
			    $result['machine.updateDate'] = $row['machine_UPDATE_DATE'];
			    $result['machine.updateUser'] = $row['machine_UPDATE_USER'];
			    $result['machine.description'] = $row['machine_Description'];
        	    $result['company.companyId'] = $row['company_COMPANY_ID'];
			    $result['company.companyName'] = $row['company_COMPANY_NAME'];
			    $result['company.address'] = $row['company_ADDRESS'];
			    $result['company.phone'] = $row['company_PHONE'];
			    $result['company.createDate'] = $row['company_CREATE_DATE'];
			    $result['company.createUser'] = $row['company_CREATE_USER'];
			    $result['company.updateDate'] = $row['company_UPDATE_DATE'];
			    $result['company.updateUser'] = $row['company_UPDATE_USER'];
			    $result['company.fax'] = $row['company_FAX'];
			    $result['company.representName'] = $row['company_REPRESENT_NAME'];
			    $result['company.representPhone'] = $row['company_REPRESENT_PHONE'];
			    $result['company.representFax'] = $row['company_REPRESENT_FAX'];
			    $result['company.description'] = $row['company_DESCRIPTION'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM request ';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN machine ON ';
        $sql .= '        machine.MACHINE_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$paramArr = array();
	    if ($criteria != null && count($criteria) > 0) {
	    	if (count($criteria['where']) > 0) {
	    		$countCriteria = count($criteria['where']);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['where'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria['operator'][$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    }
    
    	$query = $this->db->query($sql, $paramArr);
        $row = $query->result_array();
		return $row[0]['COUNT_VALUE'];	
	}
	
	function findPaging($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request.REQUEST_ID as request_REQUEST_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID as request_FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE as request_CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE as request_REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE as request_FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE as request_SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT as request_PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM as request_SYMPTOM ';
        $sql .= '    ,request.CAUSE as request_CAUSE ';
        $sql .= '    ,request.ACTION as request_ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION as request_CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE as request_CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER as request_CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE as request_UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER as request_UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST as request_REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME as request_TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME as request_TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS as request_TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE as request_TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX as request_TEMP_FAX ';
        $sql .= '    ,contract.CONTRACT_ID as contract_CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER as contract_CONTRACT_NUMBER ';
        $sql .= '    ,contract.CONTRACT_DATE as contract_CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE as contract_CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER as contract_CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE as contract_UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER as contract_UPDATE_USER ';
        $sql .= '    ,contract.DESCRIPTION as contract_DESCRIPTION ';
        $sql .= '    ,customer.CUSTOMER_ID as customer_CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME as customer_CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS as customer_ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID as customer_COMPANY_ID ';
        $sql .= '    ,customer.PHONE as customer_PHONE ';
        $sql .= '    ,customer.FAX as customer_FAX ';
        $sql .= '    ,customer.CREATE_DATE as customer_CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER as customer_CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE as customer_UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER as customer_UPDATE_USER ';
        $sql .= '    ,customer.DESCRIPTION as customer_DESCRIPTION ';
        $sql .= '    ,machine.MACHINE_ID as machine_MACHINE_ID ';
        $sql .= '    ,machine.MACHINE_NAME as machine_MACHINE_NAME ';
        $sql .= '    ,machine.SERIAL_NUMBER as machine_SERIAL_NUMBER ';
        $sql .= '    ,machine.MODEL as machine_MODEL ';
        $sql .= '    ,machine.COUNTER_NO as machine_COUNTER_NO ';
        $sql .= '    ,machine.COLOR as machine_COLOR ';
        $sql .= '    ,machine.FAX_TX as machine_FAX_TX ';
        $sql .= '    ,machine.RECEIVE_RX as machine_RECEIVE_RX ';
        $sql .= '    ,machine.PREPORT_MASTER as machine_PREPORT_MASTER ';
        $sql .= '    ,machine.COPY as machine_COPY ';
        $sql .= '    ,machine.CREATE_DATE as machine_CREATE_DATE ';
        $sql .= '    ,machine.CREATE_USER as machine_CREATE_USER ';
        $sql .= '    ,machine.UPDATE_DATE as machine_UPDATE_DATE ';
        $sql .= '    ,machine.UPDATE_USER as machine_UPDATE_USER ';
        $sql .= '    ,machine.Description as machine_Description ';
        $sql .= '    ,company.COMPANY_ID as company_COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME as company_COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS as company_ADDRESS ';
        $sql .= '    ,company.PHONE as company_PHONE ';
        $sql .= '    ,company.CREATE_DATE as company_CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER as company_CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE as company_UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER as company_UPDATE_USER ';
        $sql .= '    ,company.FAX as company_FAX ';
        $sql .= '    ,company.REPRESENT_NAME as company_REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE as company_REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX as company_REPRESENT_FAX ';
        $sql .= '    ,company.DESCRIPTION as company_DESCRIPTION ';
        $sql .= ' FROM request';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN machine ON ';
        $sql .= '        machine.MACHINE_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$paramArr = array();
	    if ($criteria != null && count($criteria) > 0) {
	    	if (count($criteria['where']) > 0) {
	    		$countCriteria = count($criteria['where']);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['where'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria['operator'][$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria['order']) > 0) {
				$countCriteria = count($criteria['order']);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['order'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' , ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $value . ' '.$concator;
		        }
		    }
	    }

		$sql .= ' LIMIT ' . ($criteria['pageNumber']) . ', ' . ($criteria['recordPerPage']);

    	$query = $this->db->query($sql, $paramArr);

        if ($query->num_rows() > 0)
        {
        	$resultList = array();
        	foreach ($query->result_array() as $row) {
                $result = array();
        	    $result['requestId'] = $row['request_REQUEST_ID'];
                $result['followUpRequestId'] = $row['request_FOLLOW_UP_REQUEST_ID'];
                $result['customerCallDate'] = $row['request_CUSTOMER_CALL_DATE'];
                $result['reportDate'] = $row['request_REPORT_DATE'];
                $result['finishDate'] = $row['request_FINISH_DATE'];
                $result['serviceType'] = $row['request_SERVICE_TYPE'];
                $result['problemReport'] = $row['request_PROBLEM_REPORT'];
                $result['symptom'] = $row['request_SYMPTOM'];
                $result['cause'] = $row['request_CAUSE'];
                $result['action'] = $row['request_ACTION'];
                $result['customerOpinion'] = $row['request_CUSTOMER_OPINION'];
                $result['createDate'] = $row['request_CREATE_DATE'];
                $result['createUser'] = $row['request_CREATE_USER'];
                $result['updateDate'] = $row['request_UPDATE_DATE'];
                $result['updateUser'] = $row['request_UPDATE_USER'];
                $result['requestCost'] = $row['request_REQUEST_COST'];
                $result['tempCustomerName'] = $row['request_TEMP_CUSTOMER_NAME'];
                $result['tempCompanyName'] = $row['request_TEMP_COMPANY_NAME'];
                $result['tempAddress'] = $row['request_TEMP_ADDRESS'];
                $result['tempPhone'] = $row['request_TEMP_PHONE'];
                $result['tempFax'] = $row['request_TEMP_FAX'];
        	    $result['contract.contractId'] = $row['contract_CONTRACT_ID'];
			    $result['contract.contractNumber'] = $row['contract_CONTRACT_NUMBER'];
			    $result['contract.contractDate'] = $row['contract_CONTRACT_DATE'];
			    $result['contract.createDate'] = $row['contract_CREATE_DATE'];
			    $result['contract.createUser'] = $row['contract_CREATE_USER'];
			    $result['contract.updateDate'] = $row['contract_UPDATE_DATE'];
			    $result['contract.updateUser'] = $row['contract_UPDATE_USER'];
			    $result['contract.description'] = $row['contract_DESCRIPTION'];
        	    $result['customer.customerId'] = $row['customer_CUSTOMER_ID'];
			    $result['customer.customerName'] = $row['customer_CUSTOMER_NAME'];
			    $result['customer.address'] = $row['customer_ADDRESS'];
			    $result['customer.companyId'] = $row['customer_COMPANY_ID'];
			    $result['customer.phone'] = $row['customer_PHONE'];
			    $result['customer.fax'] = $row['customer_FAX'];
			    $result['customer.createDate'] = $row['customer_CREATE_DATE'];
			    $result['customer.createUser'] = $row['customer_CREATE_USER'];
			    $result['customer.updateDate'] = $row['customer_UPDATE_DATE'];
			    $result['customer.updateUser'] = $row['customer_UPDATE_USER'];
			    $result['customer.description'] = $row['customer_DESCRIPTION'];
        	    $result['machine.machineId'] = $row['machine_MACHINE_ID'];
			    $result['machine.machineName'] = $row['machine_MACHINE_NAME'];
			    $result['machine.serialNumber'] = $row['machine_SERIAL_NUMBER'];
			    $result['machine.model'] = $row['machine_MODEL'];
			    $result['machine.counterNo'] = $row['machine_COUNTER_NO'];
			    $result['machine.color'] = $row['machine_COLOR'];
			    $result['machine.faxTx'] = $row['machine_FAX_TX'];
			    $result['machine.receiveRx'] = $row['machine_RECEIVE_RX'];
			    $result['machine.preportMaster'] = $row['machine_PREPORT_MASTER'];
			    $result['machine.copy'] = $row['machine_COPY'];
			    $result['machine.createDate'] = $row['machine_CREATE_DATE'];
			    $result['machine.createUser'] = $row['machine_CREATE_USER'];
			    $result['machine.updateDate'] = $row['machine_UPDATE_DATE'];
			    $result['machine.updateUser'] = $row['machine_UPDATE_USER'];
			    $result['machine.description'] = $row['machine_Description'];
        	    $result['company.companyId'] = $row['company_COMPANY_ID'];
			    $result['company.companyName'] = $row['company_COMPANY_NAME'];
			    $result['company.address'] = $row['company_ADDRESS'];
			    $result['company.phone'] = $row['company_PHONE'];
			    $result['company.createDate'] = $row['company_CREATE_DATE'];
			    $result['company.createUser'] = $row['company_CREATE_USER'];
			    $result['company.updateDate'] = $row['company_UPDATE_DATE'];
			    $result['company.updateUser'] = $row['company_UPDATE_USER'];
			    $result['company.fax'] = $row['company_FAX'];
			    $result['company.representName'] = $row['company_REPRESENT_NAME'];
			    $result['company.representPhone'] = $row['company_REPRESENT_PHONE'];
			    $result['company.representFax'] = $row['company_REPRESENT_FAX'];
			    $result['company.description'] = $row['company_DESCRIPTION'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>