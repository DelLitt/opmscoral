<?php

class ObjectCriteria
{
    function clearAllCriteria(&$criteria)
    {
        $criteria['where'] = array();
    }

    function addEqCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value;
            $criteria['operator'][$propertyName] = ' = ';
        }
    }

    function addGreaterOrEqualsCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value;
            $criteria['operator'][$propertyName] = ' >= ';
        }
        return $this;
    }

	function addGreaterCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value;
            $criteria['operator'][$propertyName] = ' > ';
        }
    }

    function addLesserOrEqualsCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value;
            $criteria['operator'][$propertyName] = ' <= ';
        }
    }

	function addLesserCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value;
            $criteria['operator'][$propertyName] = ' < ';
        }
    }

	function addNotEqualCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value;
            $criteria['operator'][$propertyName] = ' <> ';
        }
    }

	function addLikeCriteria(&$criteria, $propertyName, $value)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = $value.'%';
            $criteria['operator'][$propertyName] = ' like ';
        }
    }

	function addIsNullCriteria(&$criteria, $propertyName)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = '';
            $criteria['operator'][$propertyName] = ' is null ';
        }
    }

	function addIsNotNullCriteria(&$criteria, $propertyName)
    {
        if ($value != FALSE)
        {
            $criteria['where'][$propertyName] = '';
            $criteria['operator'][$propertyName] = ' is not null ';
        }
        return $this;
    }

    function addOrder(&$criteria, $propertyName, $isAscending)
    {
        if ($isAscending == FALSE)
        {
            $criteria['order'][$propertyName] = ' ASC ';
        }
        else
        {
            $criteria['order'][$propertyName] = ' DESC ';
        }
    }

    function clearOrder(&$criteria)
    {
        $criteria['order'] = array();
    }
}

?>