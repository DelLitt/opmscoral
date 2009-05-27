<?php

class EmployeeModel extends Model {

    function insert($Employee) {
		$sql = 'INSERT INTO employee(';
        $sql .= '    EMPLOYEE_ID, ';
        $sql .= '    EMPLOYEE_NAME, ';
        $sql .= '    ROLE_ID, ';
        $sql .= '    ADDRESS, ';
        $sql .= '    PHONE, ';
        $sql .= '    LOGIN_NAME, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER ';
        $sql .= '    ROLE_MASTER_ROLE_ID, ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        $paramArr[] = $Employee->employeeId;
        $paramArr[] = $Employee->employeeName;
        $paramArr[] = $Employee->roleId;
        $paramArr[] = $Employee->address;
        $paramArr[] = $Employee->phone;
        $paramArr[] = $Employee->loginName;
        $paramArr[] = $Employee->createDate;
        $paramArr[] = $Employee->createUser;
        $paramArr[] = $Employee->updateDate;
        $paramArr[] = $Employee->updateUser;
		if ($Employee->roleMaster != null) {
        	$paramArr[] = $Employee->roleMaster->roleId;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Employee) {
		$sql = 'UPDATE employee SET ';
        $sql .= '    EMPLOYEE_NAME = ? ';
        $sql .= '    ,ROLE_ID = ? ';
        $sql .= '    ,ADDRESS = ? ';
        $sql .= '    ,PHONE = ? ';
        $sql .= '    ,LOGIN_NAME = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,ROLE_MASTER_ROLE_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    EMPLOYEE_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = $Employee->employeeName;
        $paramArr[] = $Employee->roleId;
        $paramArr[] = $Employee->address;
        $paramArr[] = $Employee->phone;
        $paramArr[] = $Employee->loginName;
        $paramArr[] = $Employee->createDate;
        $paramArr[] = $Employee->createUser;
        $paramArr[] = $Employee->updateDate;
        $paramArr[] = $Employee->updateUser;
		if ($Employee->roleMaster != null) {
        	$paramArr[] = $Employee->roleMaster->roleId;
        } else {
        	$paramArr[] = '';
        }
        $paramArr[] = $Employee->employeeId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    employee.EMPLOYEE_ID ';
        $sql .= '    ,employee.EMPLOYEE_NAME ';
        $sql .= '    ,employee.ROLE_ID ';
        $sql .= '    ,employee.ADDRESS ';
        $sql .= '    ,employee.PHONE ';
        $sql .= '    ,employee.LOGIN_NAME ';
        $sql .= '    ,employee.CREATE_DATE ';
        $sql .= '    ,employee.CREATE_USER ';
        $sql .= '    ,employee.UPDATE_DATE ';
        $sql .= '    ,employee.UPDATE_USER ';
        $sql .= '    ,role_master.ROLE_ID ';
        $sql .= '    ,role_master.ROLE_NAME ';
        $sql .= ' FROM employee';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
		$sql .= ' WHERE ';
        $sql .= '    employee.EMPLOYEE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new Employee();
        	$result->employeeId = $row['employee.EMPLOYEE_ID'];
            $result->employeeName = $row['employee.EMPLOYEE_NAME'];
            $result->roleId = $row['employee.ROLE_ID'];
            $result->address = $row['employee.ADDRESS'];
            $result->phone = $row['employee.PHONE'];
            $result->loginName = $row['employee.LOGIN_NAME'];
            $result->createDate = $row['employee.CREATE_DATE'];
            $result->createUser = $row['employee.CREATE_USER'];
            $result->updateDate = $row['employee.UPDATE_DATE'];
            $result->updateUser = $row['employee.UPDATE_USER'];
             $result->roleMaster = new RoleMaster();
        	$result->roleMaster->roleId = $row['role_master.ROLE_ID'];
			$result->roleMaster->roleName = $row['role_master.ROLE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    employee.EMPLOYEE_ID ';
        $sql .= '    ,employee.EMPLOYEE_NAME ';
        $sql .= '    ,employee.ROLE_ID ';
        $sql .= '    ,employee.ADDRESS ';
        $sql .= '    ,employee.PHONE ';
        $sql .= '    ,employee.LOGIN_NAME ';
        $sql .= '    ,employee.CREATE_DATE ';
        $sql .= '    ,employee.CREATE_USER ';
        $sql .= '    ,employee.UPDATE_DATE ';
        $sql .= '    ,employee.UPDATE_USER ';
        $sql .= '    ,role_master.ROLE_ID ';
        $sql .= '    ,role_master.ROLE_NAME ';
        $sql .= ' FROM employee';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
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
                $result = new Employee();
        	    $result->employeeId = $row['employee.EMPLOYEE_ID'];
                $result->employeeName = $row['employee.EMPLOYEE_NAME'];
                $result->roleId = $row['employee.ROLE_ID'];
                $result->address = $row['employee.ADDRESS'];
                $result->phone = $row['employee.PHONE'];
                $result->loginName = $row['employee.LOGIN_NAME'];
                $result->createDate = $row['employee.CREATE_DATE'];
                $result->createUser = $row['employee.CREATE_USER'];
                $result->updateDate = $row['employee.UPDATE_DATE'];
                $result->updateUser = $row['employee.UPDATE_USER'];
                 $result->roleMaster = new RoleMaster();
        	    $result->roleMaster->roleId = $row['role_master.ROLE_ID'];
			    $result->roleMaster->roleName = $row['role_master.ROLE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM employee ';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
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
        $sql .= '    employee.EMPLOYEE_ID ';
        $sql .= '    ,employee.EMPLOYEE_NAME ';
        $sql .= '    ,employee.ROLE_ID ';
        $sql .= '    ,employee.ADDRESS ';
        $sql .= '    ,employee.PHONE ';
        $sql .= '    ,employee.LOGIN_NAME ';
        $sql .= '    ,employee.CREATE_DATE ';
        $sql .= '    ,employee.CREATE_USER ';
        $sql .= '    ,employee.UPDATE_DATE ';
        $sql .= '    ,employee.UPDATE_USER ';
        $sql .= '    ,role_master.ROLE_ID ';
        $sql .= '    ,role_master.ROLE_NAME ';
        $sql .= ' FROM employee';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
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
                $result = new Employee();
        	    $result->employeeId = $row['employee.EMPLOYEE_ID'];
                $result->employeeName = $row['employee.EMPLOYEE_NAME'];
                $result->roleId = $row['employee.ROLE_ID'];
                $result->address = $row['employee.ADDRESS'];
                $result->phone = $row['employee.PHONE'];
                $result->loginName = $row['employee.LOGIN_NAME'];
                $result->createDate = $row['employee.CREATE_DATE'];
                $result->createUser = $row['employee.CREATE_USER'];
                $result->updateDate = $row['employee.UPDATE_DATE'];
                $result->updateUser = $row['employee.UPDATE_USER'];
                 $result->roleMaster = new RoleMaster();
        	    $result->roleMaster->roleId = $row['role_master.ROLE_ID'];
			    $result->roleMaster->roleName = $row['role_master.ROLE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>