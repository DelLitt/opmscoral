<?php
//
// Customer object for table 'customer'.
//
class Customer
{
    public $customerId = ''; 		
    public $customerName = '';
    public $address = '';
    public $companyId = '';
    public $phone = '';
    public $fax = '';
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