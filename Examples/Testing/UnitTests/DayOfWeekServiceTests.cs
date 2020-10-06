using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayOfWeekServiceTests
    {
        [Test]
        public void IsWeekend_RealLogic_Saturday_True()
        {
            var service = new DayOfWeekService();
            var saturday = new DateTime(2020, 10, 03);
            
            var actual = service.IsWeekend(saturday);

            actual.Should().Be(true);
        }
        
        [Test]
        public void IsWeekend_RealLogic_Friday_False()
        {
            var service = new DayOfWeekService();
            var friday = new DateTime(2020, 10, 02);
            
            var actual = service.IsWeekend(friday);

            actual.Should().Be(false);
        }
        
    }
}