<?php
//
// Company object for table 'company'.
//
class Company
{
    public $companyId = ''; 		
    public $companyName = '';
    public $address = '';
    public $phone = '';
    public $createDate = '';
    public $createUser = '';
    public $updateDate = '';
    public $updateUser = '';

        // Contract
    public $contracts = array();
        // Request
    public $requests = array();
}

?>