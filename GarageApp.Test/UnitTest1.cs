using GarageApp.Vehicles;
using System.Diagnostics.Metrics;
using Xunit;

namespace GarageApp.Test
{
    public class GarageTests
    {
        [Fact]
        public void AddVehicle_WhenGarageHasSpace_ShouldIncreaseCount()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            var car = new Car("TST001", "Red", 4, 5, 5, "Gasoline");

            // Act
            var added = garage.Add(car, out var message);

            // Assert
            Assert.True(added, "Vehicle should be added.");
            Assert.Equal(1, garage.Count);
            Assert.NotNull(garage.FindByRegistration("TST001"));
            Assert.Equal("Vehicle TST001 parked.", message);
        }
        [Fact]
        public void AddVehicle_WhenGarageIsFull_ShouldNotIncreaseCount()
        {
            // Arrange
            var garage = new Garage<IVehicle>(1);
            var car1 = new Car("TST001", "Red", 4, 5, 5, "Gasoline");
            var car2 = new Car("TST002", "Blue", 4, 5, 5, "Diesel");
            // Act
            garage.Add(car1, out _);
            var added = garage.Add(car2, out var message);
            // Assert
            Assert.False(added, "Vehicle should not be added.");
            Assert.Equal(1, garage.Count);
            Assert.Null(garage.FindByRegistration("TST002"));
            Assert.Equal("The garage is full..", message);
        }
        [Fact]
        public void RemoveVehicle_WhenVehicleExists_ShouldDecreaseCount()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            var car = new Car("TST001", "Red", 4, 5, 5, "Gasoline");
            garage.Add(car, out _);
            // Act
            var removed = garage.Remove("TST001", out var message);
            // Assert
            Assert.True(removed != null, "Vehicle should be removed.");
            Assert.Equal(0, garage.Count);
            Assert.Null(garage.FindByRegistration("TST001"));
            Assert.Equal("Vehicle TST001 retrieved.", message);
        }
        [Fact]
        public void RemoveVehicle_WhenVehicleDoesNotExist_ShouldNotDecreaseCount()
        {
            // Arrange
            var garage = new Garage<IVehicle>(2);
            var car = new Car("TST001", "Red", 4, 5, 5, "Gasoline");
            garage.Add(car, out _);
            // Act
            var removed = garage.Remove("TST002", out var message);
            // Assert
            Assert.Equal(1, garage.Count);
            Assert.NotNull(garage.FindByRegistration("TST001"));
            Assert.Equal("No vehicle with registration number TST002 found.", message);
        }
        [Fact]
        public void SearchByCriteria_ShouldReturnMatchingVehicles()
        {
            var garage = new Garage<IVehicle>(10);
            garage.Add(new Car("A1", "Black", 4, 5, 5, "Gasoline"), out _);
            garage.Add(new Motorcycle("M1", "Pink", 3, 250), out _);

            var black = garage.Search(v => v.Color.Equals("black", System.StringComparison.OrdinalIgnoreCase)).ToList();
            Assert.Equal(1, black.Count);
        }
    }
}
