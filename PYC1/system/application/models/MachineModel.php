<?php

class MachineModel extends Model {

    function insert($Machine) {
		$sql = 'INSERT INTO machine(';
        $sql .= '    MACHINE_ID, ';
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
        $paramArr[] = $Machine->machineId;
        $paramArr[] = $Machine->machineName;
        $paramArr[] = $Machine->serialNumber;
        $paramArr[] = $Machine->model;
        $paramArr[] = $Machine->counterNo;
        $paramArr[] = $Machine->color;
        $paramArr[] = $Machine->faxTx;
        $paramArr[] = $Machine->receiveRx;
        $paramArr[] = $Machine->preportMaster;
        $paramArr[] = $Machine->copy;
        $paramArr[] = $Machine->createDate;
        $paramArr[] = $Machine->createUser;
        $paramArr[] = $Machine->updateDate;
        $paramArr[] = $Machine->updateUser;
        $paramArr[] = $Machine->description;
		if ($Machine->machineTypeMaster != null) {
        	$paramArr[] = $Machine->machineTypeMaster->typeId;
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
        $paramArr[] = $Machine->machineName;
        $paramArr[] = $Machine->serialNumber;
        $paramArr[] = $Machine->model;
        $paramArr[] = $Machine->counterNo;
        $paramArr[] = $Machine->color;
        $paramArr[] = $Machine->faxTx;
        $paramArr[] = $Machine->receiveRx;
        $paramArr[] = $Machine->preportMaster;
        $paramArr[] = $Machine->copy;
        $paramArr[] = $Machine->createDate;
        $paramArr[] = $Machine->createUser;
        $paramArr[] = $Machine->updateDate;
        $paramArr[] = $Machine->updateUser;
        $paramArr[] = $Machine->description;
		if ($Machine->machineTypeMaster != null) {
        	$paramArr[] = $Machine->machineTypeMaster->typeId;
        } else {
        	$paramArr[] = '';
        }
        $paramArr[] = $Machine->machineId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    machine.MACHINE_ID ';
        $sql .= '    ,machine.MACHINE_NAME ';
        $sql .= '    ,machine.SERIAL_NUMBER ';
        $sql .= '    ,machine.MODEL ';
        $sql .= '    ,machine.COUNTER_NO ';
        $sql .= '    ,machine.COLOR ';
        $sql .= '    ,machine.FAX_TX ';
        $sql .= '    ,machine.RECEIVE_RX ';
        $sql .= '    ,machine.PREPORT_MASTER ';
        $sql .= '    ,machine.COPY ';
        $sql .= '    ,machine.CREATE_DATE ';
        $sql .= '    ,machine.CREATE_USER ';
        $sql .= '    ,machine.UPDATE_DATE ';
        $sql .= '    ,machine.UPDATE_USER ';
        $sql .= '    ,machine.Description ';
        $sql .= '    ,machine_type_master.type_id ';
        $sql .= '    ,machine_type_master.type_name ';
        $sql .= ' FROM machine';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
		$sql .= ' WHERE ';
        $sql .= '    machine.MACHINE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new Machine();
        	$result->machineId = $row['machine.MACHINE_ID'];
            $result->machineName = $row['machine.MACHINE_NAME'];
            $result->serialNumber = $row['machine.SERIAL_NUMBER'];
            $result->model = $row['machine.MODEL'];
            $result->counterNo = $row['machine.COUNTER_NO'];
            $result->color = $row['machine.COLOR'];
            $result->faxTx = $row['machine.FAX_TX'];
            $result->receiveRx = $row['machine.RECEIVE_RX'];
            $result->preportMaster = $row['machine.PREPORT_MASTER'];
            $result->copy = $row['machine.COPY'];
            $result->createDate = $row['machine.CREATE_DATE'];
            $result->createUser = $row['machine.CREATE_USER'];
            $result->updateDate = $row['machine.UPDATE_DATE'];
            $result->updateUser = $row['machine.UPDATE_USER'];
            $result->description = $row['machine.Description'];
             $result->machineTypeMaster = new MachineTypeMaster();
        	$result->machineTypeMaster->typeId = $row['machine_type_master.type_id'];
			$result->machineTypeMaster->typeName = $row['machine_type_master.type_name'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    machine.MACHINE_ID ';
        $sql .= '    ,machine.MACHINE_NAME ';
        $sql .= '    ,machine.SERIAL_NUMBER ';
        $sql .= '    ,machine.MODEL ';
        $sql .= '    ,machine.COUNTER_NO ';
        $sql .= '    ,machine.COLOR ';
        $sql .= '    ,machine.FAX_TX ';
        $sql .= '    ,machine.RECEIVE_RX ';
        $sql .= '    ,machine.PREPORT_MASTER ';
        $sql .= '    ,machine.COPY ';
        $sql .= '    ,machine.CREATE_DATE ';
        $sql .= '    ,machine.CREATE_USER ';
        $sql .= '    ,machine.UPDATE_DATE ';
        $sql .= '    ,machine.UPDATE_USER ';
        $sql .= '    ,machine.Description ';
        $sql .= '    ,machine_type_master.type_id ';
        $sql .= '    ,machine_type_master.type_name ';
        $sql .= ' FROM machine';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
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
                $result = new Machine();
        	    $result->machineId = $row['machine.MACHINE_ID'];
                $result->machineName = $row['machine.MACHINE_NAME'];
                $result->serialNumber = $row['machine.SERIAL_NUMBER'];
                $result->model = $row['machine.MODEL'];
                $result->counterNo = $row['machine.COUNTER_NO'];
                $result->color = $row['machine.COLOR'];
                $result->faxTx = $row['machine.FAX_TX'];
                $result->receiveRx = $row['machine.RECEIVE_RX'];
                $result->preportMaster = $row['machine.PREPORT_MASTER'];
                $result->copy = $row['machine.COPY'];
                $result->createDate = $row['machine.CREATE_DATE'];
                $result->createUser = $row['machine.CREATE_USER'];
                $result->updateDate = $row['machine.UPDATE_DATE'];
                $result->updateUser = $row['machine.UPDATE_USER'];
                $result->description = $row['machine.Description'];
                 $result->machineTypeMaster = new MachineTypeMaster();
        	    $result->machineTypeMaster->typeId = $row['machine_type_master.type_id'];
			    $result->machineTypeMaster->typeName = $row['machine_type_master.type_name'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM machine ';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
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
        $sql .= '    machine.MACHINE_ID ';
        $sql .= '    ,machine.MACHINE_NAME ';
        $sql .= '    ,machine.SERIAL_NUMBER ';
        $sql .= '    ,machine.MODEL ';
        $sql .= '    ,machine.COUNTER_NO ';
        $sql .= '    ,machine.COLOR ';
        $sql .= '    ,machine.FAX_TX ';
        $sql .= '    ,machine.RECEIVE_RX ';
        $sql .= '    ,machine.PREPORT_MASTER ';
        $sql .= '    ,machine.COPY ';
        $sql .= '    ,machine.CREATE_DATE ';
        $sql .= '    ,machine.CREATE_USER ';
        $sql .= '    ,machine.UPDATE_DATE ';
        $sql .= '    ,machine.UPDATE_USER ';
        $sql .= '    ,machine.Description ';
        $sql .= '    ,machine_type_master.type_id ';
        $sql .= '    ,machine_type_master.type_name ';
        $sql .= ' FROM machine';
		$sql .= '    LEFT OUTER JOIN machine_type_master ON ';
        $sql .= '        machine_type_master.type_id ';
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
                $result = new Machine();
        	    $result->machineId = $row['machine.MACHINE_ID'];
                $result->machineName = $row['machine.MACHINE_NAME'];
                $result->serialNumber = $row['machine.SERIAL_NUMBER'];
                $result->model = $row['machine.MODEL'];
                $result->counterNo = $row['machine.COUNTER_NO'];
                $result->color = $row['machine.COLOR'];
                $result->faxTx = $row['machine.FAX_TX'];
                $result->receiveRx = $row['machine.RECEIVE_RX'];
                $result->preportMaster = $row['machine.PREPORT_MASTER'];
                $result->copy = $row['machine.COPY'];
                $result->createDate = $row['machine.CREATE_DATE'];
                $result->createUser = $row['machine.CREATE_USER'];
                $result->updateDate = $row['machine.UPDATE_DATE'];
                $result->updateUser = $row['machine.UPDATE_USER'];
                $result->description = $row['machine.Description'];
                 $result->machineTypeMaster = new MachineTypeMaster();
        	    $result->machineTypeMaster->typeId = $row['machine_type_master.type_id'];
			    $result->machineTypeMaster->typeName = $row['machine_type_master.type_name'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>