<?php

class ContractModel extends Model {

    function insert($Contract) {
		$sql = 'INSERT INTO contract(';
        $sql .= '    CONTRACT_ID, ';
        $sql .= '    CONTRACT_NUMBER, ';
        $sql .= '    CUSTOMER_ID, ';
        $sql .= '    COMPANY_ID, ';
        $sql .= '    CONTRACT_DATE, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER ';
        $sql .= '    CONTRACT_TYPE_ID) VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        $paramArr[] = $Contract->contractId;
        $paramArr[] = $Contract->contractNumber;
        $paramArr[] = $Contract->customerId;
        $paramArr[] = $Contract->companyId;
        $paramArr[] = $Contract->contractDate;
        $paramArr[] = $Contract->createDate;
        $paramArr[] = $Contract->createUser;
        $paramArr[] = $Contract->updateDate;
        $paramArr[] = $Contract->updateUser;
		if ($Contract->contractTypeMaster != null) {
        	$paramArr[] = $Contract->contractTypeMaster->contractTypeId;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Contract) {
		$sql = 'UPDATE contract SET ';
        $sql .= '    CONTRACT_NUMBER = ? ';
        $sql .= '    ,CUSTOMER_ID = ? ';
        $sql .= '    ,COMPANY_ID = ? ';
        $sql .= '    ,CONTRACT_DATE = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,CONTRACT_TYPE_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    CONTRACT_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = $Contract->contractNumber;
        $paramArr[] = $Contract->customerId;
        $paramArr[] = $Contract->companyId;
        $paramArr[] = $Contract->contractDate;
        $paramArr[] = $Contract->createDate;
        $paramArr[] = $Contract->createUser;
        $paramArr[] = $Contract->updateDate;
        $paramArr[] = $Contract->updateUser;
		if ($Contract->contractTypeMaster != null) {
        	$paramArr[] = $Contract->contractTypeMaster->contractTypeId;
        } else {
        	$paramArr[] = '';
        }
        $paramArr[] = $Contract->contractId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    contract.CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER ';
        $sql .= '    ,contract.CUSTOMER_ID ';
        $sql .= '    ,contract.COMPANY_ID ';
        $sql .= '    ,contract.CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
		$sql .= ' WHERE ';
        $sql .= '    contract.CONTRACT_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new Contract();
        	$result->contractId = $row['contract.CONTRACT_ID'];
            $result->contractNumber = $row['contract.CONTRACT_NUMBER'];
            $result->customerId = $row['contract.CUSTOMER_ID'];
            $result->companyId = $row['contract.COMPANY_ID'];
            $result->contractDate = $row['contract.CONTRACT_DATE'];
            $result->createDate = $row['contract.CREATE_DATE'];
            $result->createUser = $row['contract.CREATE_USER'];
            $result->updateDate = $row['contract.UPDATE_DATE'];
            $result->updateUser = $row['contract.UPDATE_USER'];
             $result->contractTypeMaster = new ContractTypeMaster();
        	$result->contractTypeMaster->contractTypeId = $row['contract_type_master.CONTRACT_TYPE_ID'];
			$result->contractTypeMaster->contractTypeName = $row['contract_type_master.CONTRACT_TYPE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    contract.CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER ';
        $sql .= '    ,contract.CUSTOMER_ID ';
        $sql .= '    ,contract.COMPANY_ID ';
        $sql .= '    ,contract.CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
		$paramArr = array();
	    if ($criteria != null) {
	    	if (count($criteria->where) > 0) {
	    		$countCriteria = count($criteria->where);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->where as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria->operator[$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria->order) > 0) {
				$countCriteria = count($criteria->order);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->order as $key => $value) {
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
        	foreach ($query->result() as $row) {
                $result = new Contract();
        	    $result->contractId = $row['contract.CONTRACT_ID'];
                $result->contractNumber = $row['contract.CONTRACT_NUMBER'];
                $result->customerId = $row['contract.CUSTOMER_ID'];
                $result->companyId = $row['contract.COMPANY_ID'];
                $result->contractDate = $row['contract.CONTRACT_DATE'];
                $result->createDate = $row['contract.CREATE_DATE'];
                $result->createUser = $row['contract.CREATE_USER'];
                $result->updateDate = $row['contract.UPDATE_DATE'];
                $result->updateUser = $row['contract.UPDATE_USER'];
                 $result->contractTypeMaster = new ContractTypeMaster();
        	    $result->contractTypeMaster->contractTypeId = $row['contract_type_master.CONTRACT_TYPE_ID'];
			    $result->contractTypeMaster->contractTypeName = $row['contract_type_master.CONTRACT_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM contract ';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
		$paramArr = array();
	    if ($criteria != null) {
	    	if (count($criteria->where) > 0) {
	    		$countCriteria = count($criteria->where);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->where as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria->operator[$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    }
    
    	$query = $this->db->query($sql, $paramArr);
        $row = $query->row();
		return $row->COUNTER;	
	}
	
	function findPaging($criteria, $pageNumber, $recordPerPage) {
		$sql = 'SELECT ';
        $sql .= '    contract.CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER ';
        $sql .= '    ,contract.CUSTOMER_ID ';
        $sql .= '    ,contract.COMPANY_ID ';
        $sql .= '    ,contract.CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract';
		$sql .= '    LEFT OUTER JOIN contract_type_master ON ';
        $sql .= '        contract_type_master.CONTRACT_TYPE_ID ';
		$paramArr = array();
	    if ($criteria != null) {
	    	if (count($criteria->where) > 0) {
	    		$countCriteria = count($criteria->where);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->where as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria->operator[$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria->order) > 0) {
				$countCriteria = count($criteria->order);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->order as $key => $value) {
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

		$sql .= ' LIMIT ' . ($pageNumber * $recordPerPage) . ' ' . $recordPerPage;

    	$query = $this->db->query($sql, $paramArr);

        if ($query->num_rows() > 0)
        {
        	$resultList = array();
        	foreach ($query->result() as $row) {
                $result = new Contract();
        	    $result->contractId = $row['contract.CONTRACT_ID'];
                $result->contractNumber = $row['contract.CONTRACT_NUMBER'];
                $result->customerId = $row['contract.CUSTOMER_ID'];
                $result->companyId = $row['contract.COMPANY_ID'];
                $result->contractDate = $row['contract.CONTRACT_DATE'];
                $result->createDate = $row['contract.CREATE_DATE'];
                $result->createUser = $row['contract.CREATE_USER'];
                $result->updateDate = $row['contract.UPDATE_DATE'];
                $result->updateUser = $row['contract.UPDATE_USER'];
                 $result->contractTypeMaster = new ContractTypeMaster();
        	    $result->contractTypeMaster->contractTypeId = $row['contract_type_master.CONTRACT_TYPE_ID'];
			    $result->contractTypeMaster->contractTypeName = $row['contract_type_master.CONTRACT_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>