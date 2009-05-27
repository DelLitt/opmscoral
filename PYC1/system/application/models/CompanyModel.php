<?php

class CompanyModel extends Model {

    function insert($Company) {
		$sql = 'INSERT INTO company(';
        $sql .= '    COMPANY_ID, ';
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
        $sql .= '    REPRESENT_FAX ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        $paramArr[] = $Company->companyId;
        $paramArr[] = $Company->companyName;
        $paramArr[] = $Company->address;
        $paramArr[] = $Company->phone;
        $paramArr[] = $Company->createDate;
        $paramArr[] = $Company->createUser;
        $paramArr[] = $Company->updateDate;
        $paramArr[] = $Company->updateUser;
        $paramArr[] = $Company->fax;
        $paramArr[] = $Company->representName;
        $paramArr[] = $Company->representPhone;
        $paramArr[] = $Company->representFax;
    
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
		$sql .= ' WHERE ';
        $sql .= '    COMPANY_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = $Company->companyName;
        $paramArr[] = $Company->address;
        $paramArr[] = $Company->phone;
        $paramArr[] = $Company->createDate;
        $paramArr[] = $Company->createUser;
        $paramArr[] = $Company->updateDate;
        $paramArr[] = $Company->updateUser;
        $paramArr[] = $Company->fax;
        $paramArr[] = $Company->representName;
        $paramArr[] = $Company->representPhone;
        $paramArr[] = $Company->representFax;
        $paramArr[] = $Company->companyId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    company.COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS ';
        $sql .= '    ,company.PHONE ';
        $sql .= '    ,company.CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER ';
        $sql .= '    ,company.FAX ';
        $sql .= '    ,company.REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX ';
        $sql .= ' FROM company';
		$sql .= ' WHERE ';
        $sql .= '    company.COMPANY_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new Company();
        	$result->companyId = $row['company.COMPANY_ID'];
            $result->companyName = $row['company.COMPANY_NAME'];
            $result->address = $row['company.ADDRESS'];
            $result->phone = $row['company.PHONE'];
            $result->createDate = $row['company.CREATE_DATE'];
            $result->createUser = $row['company.CREATE_USER'];
            $result->updateDate = $row['company.UPDATE_DATE'];
            $result->updateUser = $row['company.UPDATE_USER'];
            $result->fax = $row['company.FAX'];
            $result->representName = $row['company.REPRESENT_NAME'];
            $result->representPhone = $row['company.REPRESENT_PHONE'];
            $result->representFax = $row['company.REPRESENT_FAX'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    company.COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS ';
        $sql .= '    ,company.PHONE ';
        $sql .= '    ,company.CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER ';
        $sql .= '    ,company.FAX ';
        $sql .= '    ,company.REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX ';
        $sql .= ' FROM company';
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
                $result = new Company();
        	    $result->companyId = $row['company.COMPANY_ID'];
                $result->companyName = $row['company.COMPANY_NAME'];
                $result->address = $row['company.ADDRESS'];
                $result->phone = $row['company.PHONE'];
                $result->createDate = $row['company.CREATE_DATE'];
                $result->createUser = $row['company.CREATE_USER'];
                $result->updateDate = $row['company.UPDATE_DATE'];
                $result->updateUser = $row['company.UPDATE_USER'];
                $result->fax = $row['company.FAX'];
                $result->representName = $row['company.REPRESENT_NAME'];
                $result->representPhone = $row['company.REPRESENT_PHONE'];
                $result->representFax = $row['company.REPRESENT_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM company ';
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
        $sql .= '    company.COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS ';
        $sql .= '    ,company.PHONE ';
        $sql .= '    ,company.CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER ';
        $sql .= '    ,company.FAX ';
        $sql .= '    ,company.REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX ';
        $sql .= ' FROM company';
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
                $result = new Company();
        	    $result->companyId = $row['company.COMPANY_ID'];
                $result->companyName = $row['company.COMPANY_NAME'];
                $result->address = $row['company.ADDRESS'];
                $result->phone = $row['company.PHONE'];
                $result->createDate = $row['company.CREATE_DATE'];
                $result->createUser = $row['company.CREATE_USER'];
                $result->updateDate = $row['company.UPDATE_DATE'];
                $result->updateUser = $row['company.UPDATE_USER'];
                $result->fax = $row['company.FAX'];
                $result->representName = $row['company.REPRESENT_NAME'];
                $result->representPhone = $row['company.REPRESENT_PHONE'];
                $result->representFax = $row['company.REPRESENT_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>