<?php

class CustomerModel extends Model {

    function insert($Customer) {
		$sql = 'INSERT INTO customer(';
        $sql .= '    CUSTOMER_ID, ';
        $sql .= '    CUSTOMER_NAME, ';
        $sql .= '    ADDRESS, ';
        $sql .= '    COMPANY_ID, ';
        $sql .= '    PHONE, ';
        $sql .= '    FAX, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        $paramArr[] = $Customer->customerId;
        $paramArr[] = $Customer->customerName;
        $paramArr[] = $Customer->address;
        $paramArr[] = $Customer->companyId;
        $paramArr[] = $Customer->phone;
        $paramArr[] = $Customer->fax;
        $paramArr[] = $Customer->createDate;
        $paramArr[] = $Customer->createUser;
        $paramArr[] = $Customer->updateDate;
        $paramArr[] = $Customer->updateUser;
    
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
		$sql .= ' WHERE ';
        $sql .= '    CUSTOMER_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = $Customer->customerName;
        $paramArr[] = $Customer->address;
        $paramArr[] = $Customer->companyId;
        $paramArr[] = $Customer->phone;
        $paramArr[] = $Customer->fax;
        $paramArr[] = $Customer->createDate;
        $paramArr[] = $Customer->createUser;
        $paramArr[] = $Customer->updateDate;
        $paramArr[] = $Customer->updateUser;
        $paramArr[] = $Customer->customerId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    customer.CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID ';
        $sql .= '    ,customer.PHONE ';
        $sql .= '    ,customer.FAX ';
        $sql .= '    ,customer.CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER ';
        $sql .= ' FROM customer';
		$sql .= ' WHERE ';
        $sql .= '    customer.CUSTOMER_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new Customer();
        	$result->customerId = $row['customer.CUSTOMER_ID'];
            $result->customerName = $row['customer.CUSTOMER_NAME'];
            $result->address = $row['customer.ADDRESS'];
            $result->companyId = $row['customer.COMPANY_ID'];
            $result->phone = $row['customer.PHONE'];
            $result->fax = $row['customer.FAX'];
            $result->createDate = $row['customer.CREATE_DATE'];
            $result->createUser = $row['customer.CREATE_USER'];
            $result->updateDate = $row['customer.UPDATE_DATE'];
            $result->updateUser = $row['customer.UPDATE_USER'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    customer.CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID ';
        $sql .= '    ,customer.PHONE ';
        $sql .= '    ,customer.FAX ';
        $sql .= '    ,customer.CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER ';
        $sql .= ' FROM customer';
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
                $result = new Customer();
        	    $result->customerId = $row['customer.CUSTOMER_ID'];
                $result->customerName = $row['customer.CUSTOMER_NAME'];
                $result->address = $row['customer.ADDRESS'];
                $result->companyId = $row['customer.COMPANY_ID'];
                $result->phone = $row['customer.PHONE'];
                $result->fax = $row['customer.FAX'];
                $result->createDate = $row['customer.CREATE_DATE'];
                $result->createUser = $row['customer.CREATE_USER'];
                $result->updateDate = $row['customer.UPDATE_DATE'];
                $result->updateUser = $row['customer.UPDATE_USER'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM customer ';
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
        $sql .= '    customer.CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID ';
        $sql .= '    ,customer.PHONE ';
        $sql .= '    ,customer.FAX ';
        $sql .= '    ,customer.CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER ';
        $sql .= ' FROM customer';
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
                $result = new Customer();
        	    $result->customerId = $row['customer.CUSTOMER_ID'];
                $result->customerName = $row['customer.CUSTOMER_NAME'];
                $result->address = $row['customer.ADDRESS'];
                $result->companyId = $row['customer.COMPANY_ID'];
                $result->phone = $row['customer.PHONE'];
                $result->fax = $row['customer.FAX'];
                $result->createDate = $row['customer.CREATE_DATE'];
                $result->createUser = $row['customer.CREATE_USER'];
                $result->updateDate = $row['customer.UPDATE_DATE'];
                $result->updateUser = $row['customer.UPDATE_USER'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>