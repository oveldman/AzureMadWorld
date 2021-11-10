﻿using System;
using AutoFixture.Xunit2;

namespace MadWorld.Tests.Setup
{
    public class AutoDomainInlineDataAttribute : InlineAutoDataAttribute
    {
        public AutoDomainInlineDataAttribute(params object[] objects) : base(new AutoDomainDataAttribute(), objects) { }
    }
}

