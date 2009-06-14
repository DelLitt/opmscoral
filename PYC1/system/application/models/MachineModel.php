<?php

class MachineModel extends Model {

    function insert($Machine) {
		$sql = 'INSERT INTO machine(';
        
        $sql .= '    MACHINE_NAME, ';
        $sql .= '    SERIAL_NUMBER, ';
        $sql .= '    MODEL, ';
        $sql .= '    COUNTER_NO, ';
        $sql .= '    COLOR, ';
        $sql .= '    FAX_TX, ';
        $sql .= '    RECEIVE_RX, ';
        $sql .= '    PREPORT_MASTER, ';
        $sql .= '    COPY, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    Description ';
        $sql .= '    MACHINE_TYPE, ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($Machine['machineName']) ? $Machine['machineName'] : null;
        $paramArr[] = isset($Machine['serialNumber']) ? $Machine['serialNumber'] : null;
        $paramArr[] = isset($Machine['model']) ? $Machine['model'] : null;
        $paramArr[] = isset($Machine['counterNo']) ? $Machine['counterNo'] : null;
        $paramArr[] = isset($Machine['color']) ? $Machine['color'] : null;
        $paramArr[] = isset($Machine['faxTx']) ? $Machine['faxTx'] : null;
        $paramArr[] = isset($Machine['receiveRx']) ? $Machine['receiveRx'] : null;
        $paramArr[] = isset($Machine['preportMaster']) ? $Machine['preportMaster'] : null;
        $paramArr[] = isset($Machine['copy']) ? $Machine['copy'] : null;
        $paramArr[] = isset($Machine['createDate']) ? $Machine['createDate'] : null;
        $paramArr[] = isset($Machine['createUser']) ? $Machine['createUser'] : null;
        $paramArr[] = isset($Machine['updateDate']) ? $Machine['updateDate'] : null;
        $paramArr[] = isset($Machine['updateUser']) ? $Machine['updateUser'] : null;
        $paramArr[] = isset($Machine['description']) ? $Machine['description'] : null;
		if ($Machine->machineTypeMaster != null) {
        	$paramArr[] = isset($Machine['machineTypeMaster.typeId']) ? $Machine['machineTypeMaster.typeId'] : null;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Machine) {
		$sql = 'UPDATE machine SET ';
        $sql .= '    MACHINE_NAME = ? ';
        $sql .= '    ,SERIAL_NUMBER = ? ';
        $sql .= '    ,MODEL = ? ';
        $sql .= '    ,COUNTER_NO = ? ';
        $sql .= '    ,COLOR = ? ';
        $sql .= '    ,FAX_TX = ? ';
        $sql .= '    ,RECEIVE_RX = ? ';
        $sql .= '    ,PREPORT_MASTER = ? ';
        $sql .= '    ,COPY = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,Description = ? ';
        $sql .= '    ,MACHINE_TYPE = ? ';
		$sql .= ' WHERE ';
        $sql .= '    MACHINE_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($Machine['machineName']) ? $Machine['machineName'] : null;
        $paramArr[] = isset($Machine['serialNumber']) ? $Machine['serialNumber'] : null;
        $paramArr[] = isset($Machine['model']) ? $Machine['model'] : null;
        $paramArr[] = isset($Machine['counterNo']) ? $Machine['counterNo'] : null;
        $paramArr[] = isset($Machine['color']) ? $Machine['color'] : null;
        $paramArr[] = isset($Machine['faxTx']) ? $Machine['faxTx'] : null;
        $paramArr[] = isset($Machine['receiveRx']) ? $Machine['receiveRx'] : null;
        $paramArr[] = isset($Machine['preportMaster']) ? $Machine['preportMaster'] : null;
        $paramArr[] = isset($Machine['copy']) ? $Machine['copy'] : null;
        $paramArr[] = isset($Machine['createDate']) ? $Machine['createDate'] : null;
        $paramArr[] = isset($Machine['createUser']) ? $Machine['createUser'] : null;
        $paramArr[] = isset($Machine['updateDate']) ? $Machine['updateDate'] : null;
        $paramArr[] = isset($Machine['updateUser']) ? $Machine['updateUser'] : null;
        $paramArr[] = isset($Machine['description']) ? $Machine['description'] : null;
       	$paramArr[] = isset($Machine['machineTypeMaster.typeId']) ? $Machine['machineTypeMaster.typeId'] : null;
        $paramArr[] = isset($Machine['machineId']) ? $Machine['machineId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    machine.MACHINE_ID as machine_MACHINE_ID';
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
        $sql .= '    ,machine_type_master.type_id as machine_type_master_type_id';
        $sql .= '    ,machine_type_master.type_name as machine_type_master_type_name';
        $sql .= ' FROM machine';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
		$sql .= ' WHERE ';
        $sql .= '    machine.MACHINE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['machineId'] = $row[0]['machine_MACHINE_ID'];
            $result['machineName'] = $row[0]['machine_MACHINE_NAME'];
            $result['serialNumber'] = $row[0]['machine_SERIAL_NUMBER'];
            $result['model'] = $row[0]['machine_MODEL'];
            $result['counterNo'] = $row[0]['machine_COUNTER_NO'];
            $result['color'] = $row[0]['machine_COLOR'];
            $result['faxTx'] = $row[0]['machine_FAX_TX'];
            $result['receiveRx'] = $row[0]['machine_RECEIVE_RX'];
            $result['preportMaster'] = $row[0]['machine_PREPORT_MASTER'];
            $result['copy'] = $row[0]['machine_COPY'];
            $result['createDate'] = $row[0]['machine_CREATE_DATE'];
            $result['createUser'] = $row[0]['machine_CREATE_USER'];
            $result['updateDate'] = $row[0]['machine_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['machine_UPDATE_USER'];
            $result['description'] = $row[0]['machine_Description'];
        	$result['machineTypeMaster.typeId'] = $row[0]['machine_type_master_type_id'];
			$result['machineTypeMaster.typeName'] = $row[0]['machine_type_master_type_name'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    machine_MACHINE_ID as machine.MACHINE_ID ';
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
        $sql .= '    ,machine_type_master.type_id as machine_type_master_type_id ';
        $sql .= '    ,machine_type_master.type_name as machine_type_master_type_name ';
        $sql .= ' FROM machine';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
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
        	    $result['machineId'] = $row['machine_MACHINE_ID'];
                $result['machineName'] = $row['machine_MACHINE_NAME'];
                $result['serialNumber'] = $row['machine_SERIAL_NUMBER'];
                $result['model'] = $row['machine_MODEL'];
                $result['counterNo'] = $row['machine_COUNTER_NO'];
                $result['color'] = $row['machine_COLOR'];
                $result['faxTx'] = $row['machine_FAX_TX'];
                $result['receiveRx'] = $row['machine_RECEIVE_RX'];
                $result['preportMaster'] = $row['machine_PREPORT_MASTER'];
                $result['copy'] = $row['machine_COPY'];
                $result['createDate'] = $row['machine_CREATE_DATE'];
                $result['createUser'] = $row['machine_CREATE_USER'];
                $result['updateDate'] = $row['machine_UPDATE_DATE'];
                $result['updateUser'] = $row['machine_UPDATE_USER'];
                $result['description'] = $row['machine_Description'];
        	    $result['machineTypeMaster.typeId'] = $row['machine_type_master_type_id'];
			    $result['machineTypeMaster.typeName'] = $row['machine_type_master_type_name'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM machine ';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
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
        $sql .= '    machine.MACHINE_ID as machine_MACHINE_ID ';
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
        $sql .= '    ,machine_type_master.type_id as machine_type_master_type_id ';
        $sql .= '    ,machine_type_master.type_name as machine_type_master_type_name ';
        $sql .= ' FROM machine';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
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
        	    $result['machineId'] = $row['machine_MACHINE_ID'];
                $result['machineName'] = $row['machine_MACHINE_NAME'];
                $result['serialNumber'] = $row['machine_SERIAL_NUMBER'];
                $result['model'] = $row['machine_MODEL'];
                $result['counterNo'] = $row['machine_COUNTER_NO'];
                $result['color'] = $row['machine_COLOR'];
                $result['faxTx'] = $row['machine_FAX_TX'];
                $result['receiveRx'] = $row['machine_RECEIVE_RX'];
                $result['preportMaster'] = $row['machine_PREPORT_MASTER'];
                $result['copy'] = $row['machine_COPY'];
                $result['createDate'] = $row['machine_CREATE_DATE'];
                $result['createUser'] = $row['machine_CREATE_USER'];
                $result['updateDate'] = $row['machine_UPDATE_DATE'];
                $result['updateUser'] = $row['machine_UPDATE_USER'];
                $result['description'] = $row['machine_Description'];
        	    $result['machineTypeMaster.typeId'] = $row['machine_type_master_type_id'];
			    $result['machineTypeMaster.typeName'] = $row['machine_type_master_type_name'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>