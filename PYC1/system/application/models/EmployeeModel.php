<?php

class EmployeeModel extends Model {

    function insert($Employee) {
		$sql = 'INSERT INTO employee(';
        
        $sql .= '    EMPLOYEE_NAME, ';
        $sql .= '    ROLE_ID, ';
        $sql .= '    ADDRESS, ';
        $sql .= '    PHONE, ';
        $sql .= '    LOGIN_NAME, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    DESCRIPTION ';
        $sql .= '    ROLE_MASTER_ROLE_ID, ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($Employee['employeeName']) ? $Employee['employeeName'] : null;
        $paramArr[] = isset($Employee['roleId']) ? $Employee['roleId'] : null;
        $paramArr[] = isset($Employee['address']) ? $Employee['address'] : null;
        $paramArr[] = isset($Employee['phone']) ? $Employee['phone'] : null;
        $paramArr[] = isset($Employee['loginName']) ? $Employee['loginName'] : null;
        $paramArr[] = isset($Employee['createDate']) ? $Employee['createDate'] : null;
        $paramArr[] = isset($Employee['createUser']) ? $Employee['createUser'] : null;
        $paramArr[] = isset($Employee['updateDate']) ? $Employee['updateDate'] : null;
        $paramArr[] = isset($Employee['updateUser']) ? $Employee['updateUser'] : null;
        $paramArr[] = isset($Employee['description']) ? $Employee['description'] : null;
		if ($Employee->roleMaster != null) {
        	$paramArr[] = isset($Employee['roleMaster.roleId']) ? $Employee['roleMaster.roleId'] : null;
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
        $sql .= '    ,DESCRIPTION = ? ';
        $sql .= '    ,ROLE_MASTER_ROLE_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    EMPLOYEE_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($Employee['employeeName']) ? $Employee['employeeName'] : null;
        $paramArr[] = isset($Employee['roleId']) ? $Employee['roleId'] : null;
        $paramArr[] = isset($Employee['address']) ? $Employee['address'] : null;
        $paramArr[] = isset($Employee['phone']) ? $Employee['phone'] : null;
        $paramArr[] = isset($Employee['loginName']) ? $Employee['loginName'] : null;
        $paramArr[] = isset($Employee['createDate']) ? $Employee['createDate'] : null;
        $paramArr[] = isset($Employee['createUser']) ? $Employee['createUser'] : null;
        $paramArr[] = isset($Employee['updateDate']) ? $Employee['updateDate'] : null;
        $paramArr[] = isset($Employee['updateUser']) ? $Employee['updateUser'] : null;
        $paramArr[] = isset($Employee['description']) ? $Employee['description'] : null;
       	$paramArr[] = isset($Employee['roleMaster.roleId']) ? $Employee['roleMaster.roleId'] : null;
        $paramArr[] = isset($Employee['employeeId']) ? $Employee['employeeId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    employee.EMPLOYEE_ID as employee_EMPLOYEE_ID';
        $sql .= '    ,employee.EMPLOYEE_NAME as employee_EMPLOYEE_NAME';
        $sql .= '    ,employee.ROLE_ID as employee_ROLE_ID';
        $sql .= '    ,employee.ADDRESS as employee_ADDRESS';
        $sql .= '    ,employee.PHONE as employee_PHONE';
        $sql .= '    ,employee.LOGIN_NAME as employee_LOGIN_NAME';
        $sql .= '    ,employee.CREATE_DATE as employee_CREATE_DATE';
        $sql .= '    ,employee.CREATE_USER as employee_CREATE_USER';
        $sql .= '    ,employee.UPDATE_DATE as employee_UPDATE_DATE';
        $sql .= '    ,employee.UPDATE_USER as employee_UPDATE_USER';
        $sql .= '    ,employee.DESCRIPTION as employee_DESCRIPTION';
        $sql .= '    ,role_master.ROLE_ID as role_master_ROLE_ID';
        $sql .= '    ,role_master.ROLE_NAME as role_master_ROLE_NAME';
        $sql .= ' FROM employee';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
		$sql .= ' WHERE ';
        $sql .= '    employee.EMPLOYEE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['employeeId'] = $row[0]['employee_EMPLOYEE_ID'];
            $result['employeeName'] = $row[0]['employee_EMPLOYEE_NAME'];
            $result['roleId'] = $row[0]['employee_ROLE_ID'];
            $result['address'] = $row[0]['employee_ADDRESS'];
            $result['phone'] = $row[0]['employee_PHONE'];
            $result['loginName'] = $row[0]['employee_LOGIN_NAME'];
            $result['createDate'] = $row[0]['employee_CREATE_DATE'];
            $result['createUser'] = $row[0]['employee_CREATE_USER'];
            $result['updateDate'] = $row[0]['employee_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['employee_UPDATE_USER'];
            $result['description'] = $row[0]['employee_DESCRIPTION'];
        	$result['roleMaster.roleId'] = $row[0]['role_master_ROLE_ID'];
			$result['roleMaster.roleName'] = $row[0]['role_master_ROLE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    employee_EMPLOYEE_ID as employee.EMPLOYEE_ID ';
        $sql .= '    ,employee.EMPLOYEE_NAME as employee_EMPLOYEE_NAME ';
        $sql .= '    ,employee.ROLE_ID as employee_ROLE_ID ';
        $sql .= '    ,employee.ADDRESS as employee_ADDRESS ';
        $sql .= '    ,employee.PHONE as employee_PHONE ';
        $sql .= '    ,employee.LOGIN_NAME as employee_LOGIN_NAME ';
        $sql .= '    ,employee.CREATE_DATE as employee_CREATE_DATE ';
        $sql .= '    ,employee.CREATE_USER as employee_CREATE_USER ';
        $sql .= '    ,employee.UPDATE_DATE as employee_UPDATE_DATE ';
        $sql .= '    ,employee.UPDATE_USER as employee_UPDATE_USER ';
        $sql .= '    ,employee.DESCRIPTION as employee_DESCRIPTION ';
        $sql .= '    ,role_master.ROLE_ID as role_master_ROLE_ID ';
        $sql .= '    ,role_master.ROLE_NAME as role_master_ROLE_NAME ';
        $sql .= ' FROM employee';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
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
        	    $result['employeeId'] = $row['employee_EMPLOYEE_ID'];
                $result['employeeName'] = $row['employee_EMPLOYEE_NAME'];
                $result['roleId'] = $row['employee_ROLE_ID'];
                $result['address'] = $row['employee_ADDRESS'];
                $result['phone'] = $row['employee_PHONE'];
                $result['loginName'] = $row['employee_LOGIN_NAME'];
                $result['createDate'] = $row['employee_CREATE_DATE'];
                $result['createUser'] = $row['employee_CREATE_USER'];
                $result['updateDate'] = $row['employee_UPDATE_DATE'];
                $result['updateUser'] = $row['employee_UPDATE_USER'];
                $result['description'] = $row['employee_DESCRIPTION'];
        	    $result['roleMaster.roleId'] = $row['role_master_ROLE_ID'];
			    $result['roleMaster.roleName'] = $row['role_master_ROLE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM employee ';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
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
        $sql .= '    employee.EMPLOYEE_ID as employee_EMPLOYEE_ID ';
        $sql .= '    ,employee.EMPLOYEE_NAME as employee_EMPLOYEE_NAME ';
        $sql .= '    ,employee.ROLE_ID as employee_ROLE_ID ';
        $sql .= '    ,employee.ADDRESS as employee_ADDRESS ';
        $sql .= '    ,employee.PHONE as employee_PHONE ';
        $sql .= '    ,employee.LOGIN_NAME as employee_LOGIN_NAME ';
        $sql .= '    ,employee.CREATE_DATE as employee_CREATE_DATE ';
        $sql .= '    ,employee.CREATE_USER as employee_CREATE_USER ';
        $sql .= '    ,employee.UPDATE_DATE as employee_UPDATE_DATE ';
        $sql .= '    ,employee.UPDATE_USER as employee_UPDATE_USER ';
        $sql .= '    ,employee.DESCRIPTION as employee_DESCRIPTION ';
        $sql .= '    ,role_master.ROLE_ID as role_master_ROLE_ID ';
        $sql .= '    ,role_master.ROLE_NAME as role_master_ROLE_NAME ';
        $sql .= ' FROM employee';
		$sql .= '    LEFT OUTER JOIN role_master ON ';
        $sql .= '        role_master.ROLE_ID ';
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
        	    $result['employeeId'] = $row['employee_EMPLOYEE_ID'];
                $result['employeeName'] = $row['employee_EMPLOYEE_NAME'];
                $result['roleId'] = $row['employee_ROLE_ID'];
                $result['address'] = $row['employee_ADDRESS'];
                $result['phone'] = $row['employee_PHONE'];
                $result['loginName'] = $row['employee_LOGIN_NAME'];
                $result['createDate'] = $row['employee_CREATE_DATE'];
                $result['createUser'] = $row['employee_CREATE_USER'];
                $result['updateDate'] = $row['employee_UPDATE_DATE'];
                $result['updateUser'] = $row['employee_UPDATE_USER'];
                $result['description'] = $row['employee_DESCRIPTION'];
        	    $result['roleMaster.roleId'] = $row['role_master_ROLE_ID'];
			    $result['roleMaster.roleName'] = $row['role_master_ROLE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>