<?php

class ContractModel extends Model {

    function insert($Contract) {
		$sql = 'INSERT INTO contract(';
        
        $sql .= '    CONTRACT_NUMBER, ';
        $sql .= '    CONTRACT_DATE, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    DESCRIPTION ';
        $sql .= '    CUSTOMER_ID, ';
        $sql .= '    COMPANY_ID, ';
        $sql .= '    CONTRACT_TYPE_ID) VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($Contract['contractNumber']) ? $Contract['contractNumber'] : null;
        $paramArr[] = isset($Contract['contractDate']) ? $Contract['contractDate'] : null;
        $paramArr[] = isset($Contract['createDate']) ? $Contract['createDate'] : null;
        $paramArr[] = isset($Contract['createUser']) ? $Contract['createUser'] : null;
        $paramArr[] = isset($Contract['updateDate']) ? $Contract['updateDate'] : null;
        $paramArr[] = isset($Contract['updateUser']) ? $Contract['updateUser'] : null;
        $paramArr[] = isset($Contract['description']) ? $Contract['description'] : null;
		if ($Contract->customer != null) {
        	$paramArr[] = isset($Contract['customer.customerId']) ? $Contract['customer.customerId'] : null;
        } else {
        	$paramArr[] = '';
        }
		if ($Contract->company != null) {
        	$paramArr[] = isset($Contract['company.companyId']) ? $Contract['company.companyId'] : null;
        } else {
        	$paramArr[] = '';
        }
		if ($Contract->contractTypeMaster != null) {
        	$paramArr[] = isset($Contract['contractTypeMaster.contractTypeId']) ? $Contract['contractTypeMaster.contractTypeId'] : null;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Contract) {
		$sql = 'UPDATE contract SET ';
        $sql .= '    CONTRACT_NUMBER = ? ';
        $sql .= '    ,CONTRACT_DATE = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,DESCRIPTION = ? ';
        $sql .= '    ,CUSTOMER_ID = ? ';
        $sql .= '    ,COMPANY_ID = ? ';
        $sql .= '    ,CONTRACT_TYPE_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    CONTRACT_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($Contract['contractNumber']) ? $Contract['contractNumber'] : null;
        $paramArr[] = isset($Contract['contractDate']) ? $Contract['contractDate'] : null;
        $paramArr[] = isset($Contract['createDate']) ? $Contract['createDate'] : null;
        $paramArr[] = isset($Contract['createUser']) ? $Contract['createUser'] : null;
        $paramArr[] = isset($Contract['updateDate']) ? $Contract['updateDate'] : null;
        $paramArr[] = isset($Contract['updateUser']) ? $Contract['updateUser'] : null;
        $paramArr[] = isset($Contract['description']) ? $Contract['description'] : null;
       	$paramArr[] = isset($Contract['customer.customerId']) ? $Contract['customer.customerId'] : null;
       	$paramArr[] = isset($Contract['company.companyId']) ? $Contract['company.companyId'] : null;
       	$paramArr[] = isset($Contract['contractTypeMaster.contractTypeId']) ? $Contract['contractTypeMaster.contractTypeId'] : null;
        $paramArr[] = isset($Contract['contractId']) ? $Contract['contractId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    contract.CONTRACT_ID as contract_CONTRACT_ID';
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
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_ID as contract_type_master_CONTRACT_TYPE_ID';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME as contract_type_master_CONTRACT_TYPE_NAME';
        $sql .= ' FROM contract';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
		$sql .= ' WHERE ';
        $sql .= '    contract.CONTRACT_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['contractId'] = $row[0]['contract_CONTRACT_ID'];
            $result['contractNumber'] = $row[0]['contract_CONTRACT_NUMBER'];
            $result['contractDate'] = $row[0]['contract_CONTRACT_DATE'];
            $result['createDate'] = $row[0]['contract_CREATE_DATE'];
            $result['createUser'] = $row[0]['contract_CREATE_USER'];
            $result['updateDate'] = $row[0]['contract_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['contract_UPDATE_USER'];
            $result['description'] = $row[0]['contract_DESCRIPTION'];
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
        	$result['contractTypeMaster.contractTypeId'] = $row[0]['contract_type_master_CONTRACT_TYPE_ID'];
			$result['contractTypeMaster.contractTypeName'] = $row[0]['contract_type_master_CONTRACT_TYPE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    contract_CONTRACT_ID as contract.CONTRACT_ID ';
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
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_ID as contract_type_master_CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME as contract_type_master_CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
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
        	    $result['contractId'] = $row['contract_CONTRACT_ID'];
                $result['contractNumber'] = $row['contract_CONTRACT_NUMBER'];
                $result['contractDate'] = $row['contract_CONTRACT_DATE'];
                $result['createDate'] = $row['contract_CREATE_DATE'];
                $result['createUser'] = $row['contract_CREATE_USER'];
                $result['updateDate'] = $row['contract_UPDATE_DATE'];
                $result['updateUser'] = $row['contract_UPDATE_USER'];
                $result['description'] = $row['contract_DESCRIPTION'];
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
        	    $result['contractTypeMaster.contractTypeId'] = $row['contract_type_master_CONTRACT_TYPE_ID'];
			    $result['contractTypeMaster.contractTypeName'] = $row['contract_type_master_CONTRACT_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM contract ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
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
        $sql .= '    contract.CONTRACT_ID as contract_CONTRACT_ID ';
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
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_ID as contract_type_master_CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME as contract_type_master_CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
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
        	    $result['contractId'] = $row['contract_CONTRACT_ID'];
                $result['contractNumber'] = $row['contract_CONTRACT_NUMBER'];
                $result['contractDate'] = $row['contract_CONTRACT_DATE'];
                $result['createDate'] = $row['contract_CREATE_DATE'];
                $result['createUser'] = $row['contract_CREATE_USER'];
                $result['updateDate'] = $row['contract_UPDATE_DATE'];
                $result['updateUser'] = $row['contract_UPDATE_USER'];
                $result['description'] = $row['contract_DESCRIPTION'];
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
        	    $result['contractTypeMaster.contractTypeId'] = $row['contract_type_master_CONTRACT_TYPE_ID'];
			    $result['contractTypeMaster.contractTypeName'] = $row['contract_type_master_CONTRACT_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>