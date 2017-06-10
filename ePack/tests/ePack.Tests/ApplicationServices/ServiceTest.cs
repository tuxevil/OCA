using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tests.ApplicationServices
{
    public abstract class ServiceTest
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            ServiceLocatorInitializer.Init();
        }

    }
}
