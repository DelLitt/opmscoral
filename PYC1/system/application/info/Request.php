<?php
//
// Request object for table 'request'.
//
class Request
{
    public $requestId = ''; 		
    public $machineId = '';
    public $followUpRequestId = '';
    public $customerCallDate = '';
    public $reportDate = '';
    public $finishDate = '';
    public $serviceType = '';
    public $problemReport = '';
    public $symptom = '';
    public $cause = '';
    public $action = '';
    public $customerOpinion = '';
    public $createDate = '';
    public $createUser = '';
    public $updateDate = '';
    public $updateUser = '';
    public $requestCost = '';
    public $tempCustomerName = '';
    public $tempCompanyName = '';
    public $tempAddress = '';
    public $tempPhone = '';
    public $tempFax = '';

    public $contract = null;
    public $customer = null;
    public $company = null;
        // EmployeeRequest
    public $employeeRequests = array();
        // RequestStatus
    public $requestStatuses = array();
        // ReplacePart
    public $replaceParts = array();
}

?>