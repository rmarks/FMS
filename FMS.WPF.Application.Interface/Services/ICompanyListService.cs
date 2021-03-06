﻿using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ICompanyListService
    {
        IList<CompanyListModel> GetCompanyListModels(string query);
    }
}