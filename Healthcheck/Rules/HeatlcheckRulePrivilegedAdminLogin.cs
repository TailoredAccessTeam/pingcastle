﻿//
// Copyright (c) Ping Castle. All rights reserved.
// https://www.pingcastle.com
//
// Licensed under the Non-Profit OSL. See LICENSE file in the project root for full license information.
//
using System;
using System.Collections.Generic;
using System.Text;
using PingCastle.Rules;

namespace PingCastle.Healthcheck.Rules
{
	[RuleModel("P-AdminLogin", RiskRuleCategory.PrivilegedAccounts, RiskModelCategory.AdminControl)]
	[RuleComputation(RuleComputationType.TriggerIfLessThan, 20, Threshold: 35)]
    public class HeatlcheckRulePrivilegedAdminLogin : RuleBase<HealthcheckData>
    {
		protected override int? AnalyzeDataNew(HealthcheckData healthcheckData)
        {
            if (healthcheckData.DomainCreation.AddDays(35) < healthcheckData.GenerationDate)
            {
				return 100;
            }
			return (int)(healthcheckData.GenerationDate - healthcheckData.AdminLastLoginDate).TotalDays;
        }
    }
}
