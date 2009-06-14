<?php
//
// Machine object for table 'machine'.
//
class Machine
{
    public $machineId = ''; 		
    public $machineName = '';
    public $serialNumber = '';
    public $model = '';
    public $counterNo = '';
    public $color = '';
    public $faxTx = '';
    public $receiveRx = '';
    public $preportMaster = '';
    public $copy = '';
    public $createDate = '';
    public $createUser = '';
    public $updateDate = '';
    public $updateUser = '';

    public $machineTypeMaster = '';
        // ContractMachine
    public $contractMachines = array();
}

?>