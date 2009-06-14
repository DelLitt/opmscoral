<?php

class CompanyModel extends Model {

    function insert($Company) {
		$sql = 'INSERT INTO company(';
        
        $sql .= '    COMPANY_NAME, ';
        $sql .= '    ADDRESS, ';
        $sql .= '    PHONE, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    FAX, ';
        $sql .= '    REPRESENT_NAME, ';
        $sql .= '    REPRESENT_PHONE, ';
        $sql .= '    REPRESENT_FAX, ';
        $sql .= '    DESCRIPTION ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($Company['companyName']) ? $Company['companyName'] : null;
        $paramArr[] = isset($Company['address']) ? $Company['address'] : null;
        $paramArr[] = isset($Company['phone']) ? $Company['phone'] : null;
        $paramArr[] = isset($Company['createDate']) ? $Company['createDate'] : null;
        $paramArr[] = isset($Company['createUser']) ? $Company['createUser'] : null;
        $paramArr[] = isset($Company['updateDate']) ? $Company['updateDate'] : null;
        $paramArr[] = isset($Company['updateUser']) ? $Company['updateUser'] : null;
        $paramArr[] = isset($Company['fax']) ? $Company['fax'] : null;
        $paramArr[] = isset($Company['representName']) ? $Company['representName'] : null;
        $paramArr[] = isset($Company['representPhone']) ? $Company['representPhone'] : null;
        $paramArr[] = isset($Company['representFax']) ? $Company['representFax'] : null;
        $paramArr[] = isset($Company['description']) ? $Company['description'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Company) {
		$sql = 'UPDATE company SET ';
        $sql .= '    COMPANY_NAME = ? ';
        $sql .= '    ,ADDRESS = ? ';
        $sql .= '    ,PHONE = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,FAX = ? ';
        $sql .= '    ,REPRESENT_NAME = ? ';
        $sql .= '    ,REPRESENT_PHONE = ? ';
        $sql .= '    ,REPRESENT_FAX = ? ';
        $sql .= '    ,DESCRIPTION = ? ';
		$sql .= ' WHERE ';
        $sql .= '    COMPANY_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($Company['companyName']) ? $Company['companyName'] : null;
        $paramArr[] = isset($Company['address']) ? $Company['address'] : null;
        $paramArr[] = isset($Company['phone']) ? $Company['phone'] : null;
        $paramArr[] = isset($Company['createDate']) ? $Company['createDate'] : null;
        $paramArr[] = isset($Company['createUser']) ? $Company['createUser'] : null;
        $paramArr[] = isset($Company['updateDate']) ? $Company['updateDate'] : null;
        $paramArr[] = isset($Company['updateUser']) ? $Company['updateUser'] : null;
        $paramArr[] = isset($Company['fax']) ? $Company['fax'] : null;
        $paramArr[] = isset($Company['representName']) ? $Company['representName'] : null;
        $paramArr[] = isset($Company['representPhone']) ? $Company['representPhone'] : null;
        $paramArr[] = isset($Company['representFax']) ? $Company['representFax'] : null;
        $paramArr[] = isset($Company['description']) ? $Company['description'] : null;
        $paramArr[] = isset($Company['companyId']) ? $Company['companyId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    company.COMPANY_ID as company_COMPANY_ID';
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
        $sql .= ' FROM company';
		$sql .= ' WHERE ';
        $sql .= '    company.COMPANY_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['companyId'] = $row[0]['company_COMPANY_ID'];
            $result['companyName'] = $row[0]['company_COMPANY_NAME'];
            $result['address'] = $row[0]['company_ADDRESS'];
            $result['phone'] = $row[0]['company_PHONE'];
            $result['createDate'] = $row[0]['company_CREATE_DATE'];
            $result['createUser'] = $row[0]['company_CREATE_USER'];
            $result['updateDate'] = $row[0]['company_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['company_UPDATE_USER'];
            $result['fax'] = $row[0]['company_FAX'];
            $result['representName'] = $row[0]['company_REPRESENT_NAME'];
            $result['representPhone'] = $row[0]['company_REPRESENT_PHONE'];
            $result['representFax'] = $row[0]['company_REPRESENT_FAX'];
            $result['description'] = $row[0]['company_DESCRIPTION'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    company_COMPANY_ID as company.COMPANY_ID ';
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
        $sql .= ' FROM company';
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
        	    $result['companyId'] = $row['company_COMPANY_ID'];
                $result['companyName'] = $row['company_COMPANY_NAME'];
                $result['address'] = $row['company_ADDRESS'];
                $result['phone'] = $row['company_PHONE'];
                $result['createDate'] = $row['company_CREATE_DATE'];
                $result['createUser'] = $row['company_CREATE_USER'];
                $result['updateDate'] = $row['company_UPDATE_DATE'];
                $result['updateUser'] = $row['company_UPDATE_USER'];
                $result['fax'] = $row['company_FAX'];
                $result['representName'] = $row['company_REPRESENT_NAME'];
                $result['representPhone'] = $row['company_REPRESENT_PHONE'];
                $result['representFax'] = $row['company_REPRESENT_FAX'];
                $result['description'] = $row['company_DESCRIPTION'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM company ';
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
        $sql .= '    company.COMPANY_ID as company_COMPANY_ID ';
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
        $sql .= ' FROM company';
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
        	    $result['companyId'] = $row['company_COMPANY_ID'];
                $result['companyName'] = $row['company_COMPANY_NAME'];
                $result['address'] = $row['company_ADDRESS'];
                $result['phone'] = $row['company_PHONE'];
                $result['createDate'] = $row['company_CREATE_DATE'];
                $result['createUser'] = $row['company_CREATE_USER'];
                $result['updateDate'] = $row['company_UPDATE_DATE'];
                $result['updateUser'] = $row['company_UPDATE_USER'];
                $result['fax'] = $row['company_FAX'];
                $result['representName'] = $row['company_REPRESENT_NAME'];
                $result['representPhone'] = $row['company_REPRESENT_PHONE'];
                $result['representFax'] = $row['company_REPRESENT_FAX'];
                $result['description'] = $row['company_DESCRIPTION'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>