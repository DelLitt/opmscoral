<?php
//
// Employee object for table 'employee'.
//
class Employee
{
    public $employeeId = ''; 		
    public $employeeName = '';
    public $roleId = '';
    public $address = '';
    public $phone = '';
    public $loginName = '';
    public $createDate = '';
    public $createUser = '';
    public $updateDate = '';
    public $updateUser = '';

    public $roleMaster = null;
        // EmployeeRequest
    public $employeeRequests = array();
}

?>