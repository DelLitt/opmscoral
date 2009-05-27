<?php

class ObjectCriteria
{
    public $where = array();
    public $operator = array();
    public $order = array();

    function clearAllCriteria()
    {
        $where = array();
    }

    function addEqCriteria($propertyName, $value)
    {
        if ($value != FALSE)
        {
            $where[$propertyName] = $value;
            $operator[$propertyName] = ' = ';
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
            $order[$propertyName] = ' ASC ';
        }
        else
        {
            $order[$propertyName] = ' DESC ';
        }
        return $this;
    }

    function clearOrder()
    {
        $order = array();
    }
}

?>