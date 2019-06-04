﻿using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : GenericEditableViewModelBase<CompanyBasicsModel>
    {
        private ICompanyBasicsService _service;

        public CompanyBasicsViewModel(int companyId, ICompanyBasicsService service)
        {
            DisplayName = "Üldandmed";

            _service = service;
            Model = _service.GetCompanyBasicsModel(companyId);
        }
    }
}
