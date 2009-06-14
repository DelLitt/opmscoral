<?php //if ( ! defined('BASEPATH')) exit('No direct script access allowed'); 

class ObjectCriteria
{
    public $where = array();
    public $operator = array();
    public $order = array();
    public $orderField = '';
    public $orderDirection = TRUE;
    public $pageNumber = 0;
    public $recordPerPage = 2;
    
    function clearAllCriteria()
    {
        $where = array();
    }

    function addEqCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $this->where[$propertyName] = $value;
            $this->operator[$propertyName] = ' = ';
        }
        return $this;
    }

    function addGreaterOrEqualsCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' >= ';
        }
        return $this;
    }

	function addGreaterCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' > ';
        }
        return $this;
    }

    function addLesserOrEqualsCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' <= ';
        }
        return $this;
    }

	function addLesserCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' < ';
        }
        return $this;
    }

	function addNotEqualCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' <> ';
        }
        return $this;
    }

	function addLikeCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' like ';
        }
        return $this;
    }

	function addIsNullCriteria($propertyName)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = '';
            $operator[$propertyName] = ' is null ';
        }
        return $this;
    }

	function addIsNotNullCriteria($propertyName)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = '';
            $operator[$propertyName] = ' is not null ';
        }
        return $this;
    }

    function addOrder($propertyName, $isAscending)
    {
        if ($isAscending == FALSE)
        {
            $this->order[$propertyName] = ' ASC ';
        }
        else
        {
            $this->order[$propertyName] = ' DESC ';
        }
        return $this;
    }

    function clearOrder()
    {
        //$this->order = array();
    }
}

?>