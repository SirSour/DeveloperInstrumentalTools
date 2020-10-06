using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using UnitTestsTarget;

namespace UnitTests
{
    public class Tests
    {
        [Test]
        public void GetWorkingToday_RealLogic_Friday_ReturnsMonday()
        {
            // Arrange
            var today = new DateTime(2020, 10, 02);

            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));
            
            // Act
            var result = service.GetWorkingTomorrow(today);
            
            // Assert
            result.Should().Be(new DateTime(2020, 10, 05));
        }
        
        [Test]
        public void GetWorkingTomorrow_AllDatesWorking_ReturnsTomorrow()
        {
            // Arrange
            var today = new DateTime(2020, 10, 02);

            var dayOfWeekService = new Mock<IDayOfWeekService>();
            dayOfWeekService
                .Setup(x => x.IsWeekend(It.IsAny<DateTime>()))
                .Returns(false);

            var service = new CalendarService(new DayShiftService(dayOfWeekService.Object));
            
            // Act
            var result = service.GetWorkingTomorrow(today);
            
            // Assert
            result.Should().Be(new DateTime(2020, 10, 03));
        }
        
        [Test]
        public void GetWorkingToday_Saturday_ReturnsMonday()
        {
            var saturday = new DateTime(2020, 10, 03);
            var service = new CalendarService(new DayShiftService(new DayOfWeekService()));
            
            var result = service.GetWorkingToday(saturday);
            
            result.Should().Be(new DateTime(2020, 10, 05));
        }

        [Test] public void GetWorkingYesterday_AllDatesWorking_ReturnsWednesday()
        {
            var thursday = new DateTime(2020, 10, 08);
            
            var dayOfWeekService = new Mock<IDayOfWeekService>();
            dayOfWeekService
                .Setup(x => x.IsWeekend(It.IsAny<DateTime>()))
                .Returns(false);
            
            var service = new CalendarService(new DayShiftService(dayOfWeekService.Object));
            
            var result = service.GetWorkingYesterday(thursday);
            
            result.Should().Be(new DateTime(2020, 10, 07));
        }
    }
}