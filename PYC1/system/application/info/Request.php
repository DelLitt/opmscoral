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

    public $contract = '';
    public $customer = '';
    public $company = '';
        // EmployeeRequest
    public $employeeRequests = array();
        // RequestStatus
    public $requestStatuses = array();
        // ReplacePart
    public $replaceParts = array();
}

?>