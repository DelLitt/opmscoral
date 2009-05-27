<?php
//
// Contract object for table 'contract'.
//
class Contract
{
    public $contractId = ''; 		
    public $contractNumber = '';
    public $customerId = '';
    public $companyId = '';
    public $contractDate = '';
    public $createDate = '';
    public $createUser = '';
    public $updateDate = '';
    public $updateUser = '';

        // Request
    public $requests = array();
        // ContractMachine
    public $contractMachines = array();
    public $contractTypeMaster = null;
}

?>