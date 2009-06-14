<?php

class CustomerModel extends Model {

    function insert($Customer) {
		$sql = 'INSERT INTO customer(';
        
        $sql .= '    CUSTOMER_NAME, ';
        $sql .= '    ADDRESS, ';
        $sql .= '    COMPANY_ID, ';
        $sql .= '    PHONE, ';
        $sql .= '    FAX, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    DESCRIPTION ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($Customer['customerName']) ? $Customer['customerName'] : null;
        $paramArr[] = isset($Customer['address']) ? $Customer['address'] : null;
        $paramArr[] = isset($Customer['companyId']) ? $Customer['companyId'] : null;
        $paramArr[] = isset($Customer['phone']) ? $Customer['phone'] : null;
        $paramArr[] = isset($Customer['fax']) ? $Customer['fax'] : null;
        $paramArr[] = isset($Customer['createDate']) ? $Customer['createDate'] : null;
        $paramArr[] = isset($Customer['createUser']) ? $Customer['createUser'] : null;
        $paramArr[] = isset($Customer['updateDate']) ? $Customer['updateDate'] : null;
        $paramArr[] = isset($Customer['updateUser']) ? $Customer['updateUser'] : null;
        $paramArr[] = isset($Customer['description']) ? $Customer['description'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Customer) {
		$sql = 'UPDATE customer SET ';
        $sql .= '    CUSTOMER_NAME = ? ';
        $sql .= '    ,ADDRESS = ? ';
        $sql .= '    ,COMPANY_ID = ? ';
        $sql .= '    ,PHONE = ? ';
        $sql .= '    ,FAX = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,DESCRIPTION = ? ';
		$sql .= ' WHERE ';
        $sql .= '    CUSTOMER_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($Customer['customerName']) ? $Customer['customerName'] : null;
        $paramArr[] = isset($Customer['address']) ? $Customer['address'] : null;
        $paramArr[] = isset($Customer['companyId']) ? $Customer['companyId'] : null;
        $paramArr[] = isset($Customer['phone']) ? $Customer['phone'] : null;
        $paramArr[] = isset($Customer['fax']) ? $Customer['fax'] : null;
        $paramArr[] = isset($Customer['createDate']) ? $Customer['createDate'] : null;
        $paramArr[] = isset($Customer['createUser']) ? $Customer['createUser'] : null;
        $paramArr[] = isset($Customer['updateDate']) ? $Customer['updateDate'] : null;
        $paramArr[] = isset($Customer['updateUser']) ? $Customer['updateUser'] : null;
        $paramArr[] = isset($Customer['description']) ? $Customer['description'] : null;
        $paramArr[] = isset($Customer['customerId']) ? $Customer['customerId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    customer.CUSTOMER_ID as customer_CUSTOMER_ID';
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
        $sql .= ' FROM customer';
		$sql .= ' WHERE ';
        $sql .= '    customer.CUSTOMER_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['customerId'] = $row[0]['customer_CUSTOMER_ID'];
            $result['customerName'] = $row[0]['customer_CUSTOMER_NAME'];
            $result['address'] = $row[0]['customer_ADDRESS'];
            $result['companyId'] = $row[0]['customer_COMPANY_ID'];
            $result['phone'] = $row[0]['customer_PHONE'];
            $result['fax'] = $row[0]['customer_FAX'];
            $result['createDate'] = $row[0]['customer_CREATE_DATE'];
            $result['createUser'] = $row[0]['customer_CREATE_USER'];
            $result['updateDate'] = $row[0]['customer_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['customer_UPDATE_USER'];
            $result['description'] = $row[0]['customer_DESCRIPTION'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    customer_CUSTOMER_ID as customer.CUSTOMER_ID ';
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
        $sql .= ' FROM customer';
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
        	    $result['customerId'] = $row['customer_CUSTOMER_ID'];
                $result['customerName'] = $row['customer_CUSTOMER_NAME'];
                $result['address'] = $row['customer_ADDRESS'];
                $result['companyId'] = $row['customer_COMPANY_ID'];
                $result['phone'] = $row['customer_PHONE'];
                $result['fax'] = $row['customer_FAX'];
                $result['createDate'] = $row['customer_CREATE_DATE'];
                $result['createUser'] = $row['customer_CREATE_USER'];
                $result['updateDate'] = $row['customer_UPDATE_DATE'];
                $result['updateUser'] = $row['customer_UPDATE_USER'];
                $result['description'] = $row['customer_DESCRIPTION'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM customer ';
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
        $sql .= '    customer.CUSTOMER_ID as customer_CUSTOMER_ID ';
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
        $sql .= ' FROM customer';
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
        	    $result['customerId'] = $row['customer_CUSTOMER_ID'];
                $result['customerName'] = $row['customer_CUSTOMER_NAME'];
                $result['address'] = $row['customer_ADDRESS'];
                $result['companyId'] = $row['customer_COMPANY_ID'];
                $result['phone'] = $row['customer_PHONE'];
                $result['fax'] = $row['customer_FAX'];
                $result['createDate'] = $row['customer_CREATE_DATE'];
                $result['createUser'] = $row['customer_CREATE_USER'];
                $result['updateDate'] = $row['customer_UPDATE_DATE'];
                $result['updateUser'] = $row['customer_UPDATE_USER'];
                $result['description'] = $row['customer_DESCRIPTION'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>