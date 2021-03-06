﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sheperd.Core.Monitoring;
using System.Management;
using System.Collections.Generic;


namespace Sheperd.UnitTests.Providers
{
    [TestClass]
    public class WmiTest
    {
        [TestMethod]
        public void GetAnyData()
        {
            var data = WmiHelper.Query<string>(Environment.MachineName,
                "SELECT * FROM Win32_ComputerSystem",
                results => results.Select(mo => mo.GetText(TextFormat.Mof)));
        }
    }
}
