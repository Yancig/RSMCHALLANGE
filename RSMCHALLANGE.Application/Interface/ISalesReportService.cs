﻿using RSMCHALLANGE.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMCHALLANGE.Application.Interface
{
    public interface ISalesReportService
    {
        Task<IEnumerable<GetAllSalesReportDTOs>> GetAllSalesReport();


    }
}
