using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class DayShiftServiceTests
    {

        [Test]
        public void GetShiftBusinessDay_RealLogic_TuesdayToMonday()
        {
            var service = new DayShiftService(new DayOfWeekService());
            var monday = new DateTime(2020, 10, 05);
            var tuesday = new DateTime(2020, 10, 06);
            
            var actual = service.GetShiftBusinessDay(tuesday, -1);

            actual.Should().Be(monday);
        }
        
        [Test]
        public void GetShiftBusinessDay_RealLogic_FridayToMonday()
        {
            var service = new DayShiftService(new DayOfWeekService());
            var monday = new DateTime(2020, 10, 05);
            var friday = new DateTime(2020, 10, 02);
            
            var actual = service.GetShiftBusinessDay(friday, 1);

            actual.Should().Be(monday);
        }
        
    }
}