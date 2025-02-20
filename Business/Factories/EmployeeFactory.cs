﻿using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static Employee CreateEmployee(EmployeeEntity employee)
    {
        return new Employee
        {
            EmployeeNumber = employee.EmployeeNumber,
            FirstName = employee.FirstName,
            LastName = employee.LastName
        };
    }
}
