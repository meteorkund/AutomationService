﻿using AutomationService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationService.Domain.Commands
{
    public interface ICreateCustomerCommand
    {
        Task Create(Customer customer);
    }
}
