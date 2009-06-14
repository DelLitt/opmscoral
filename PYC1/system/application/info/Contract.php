<?php
//
// Contract object for table 'contract'.
//
class Contract
{
    public $contractId = ''; 		
    public $contractNumber = '';
    public $contractDate = '';
    public $createDate = '';
    public $createUser = '';
    public $updateDate = '';
    public $updateUser = '';

        // ContractMachine
    public $contractMachines = array();
        // Request
    public $requests = array();
    public $customer = '';
    public $company = '';
    public $contractTypeMaster = '';
}

?>