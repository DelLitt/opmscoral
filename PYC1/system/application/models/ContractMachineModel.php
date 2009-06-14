<?php

class ContractMachineModel extends Model {

    function insert($ContractMachine) {
		$sql = 'INSERT INTO contract_machine(';
        
        
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?)';
		
        $paramArr = array();
        
        
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($ContractMachine) {
		$sql = 'UPDATE contract_machine SET ';
		$sql .= ' WHERE ';
        $sql .= '    CONTRACT_ID = ? ' ;
        $sql .= '    MACHINE_ID = ? AND' ;
		
        $paramArr = array();
        $paramArr[] = isset($ContractMachine['contractId']) ? $ContractMachine['contractId'] : null;
        $paramArr[] = isset($ContractMachine['machineId']) ? $ContractMachine['machineId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    contract_machine.CONTRACT_ID as contract_machine_CONTRACT_ID';
        $sql .= '    contract_machine.MACHINE_ID as contract_machine_MACHINE_ID';
        $sql .= ' FROM contract_machine ';
		$sql .= ' WHERE ';
        $sql .= '    contract_machine.CONTRACT_ID = ? ';
        $sql .= '    contract_machine.MACHINE_ID = ? ';
		$query = $this->db->query($sql, $id);
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['contractId'] = $row[0]['contract_machine_CONTRACT_ID'];
        	$result['machineId'] = $row[0]['contract_machine_MACHINE_ID'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    contract_machine_CONTRACT_ID as contract_machine.CONTRACT_ID ';
        $sql .= '    contract_machine_MACHINE_ID as contract_machine.MACHINE_ID ';
        $sql .= ' FROM contract_machine ';
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
        	    $result['contractId'] = $row['contract_machine_CONTRACT_ID'];
        	    $result['machineId'] = $row['contract_machine_MACHINE_ID'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM contract_machine ';
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
        $sql .= '    contract_machine.CONTRACT_ID as contract_machine_CONTRACT_ID ';
        $sql .= '    contract_machine.MACHINE_ID as contract_machine_MACHINE_ID ';
        $sql .= ' FROM contract_machine ';
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
        	    $result['contractId'] = $row['contract_machine_CONTRACT_ID'];
        	    $result['machineId'] = $row['contract_machine_MACHINE_ID'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>