using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private readonly T[] _items;
        public int Capacity { get; }
        private int _count;

        public int Count => _count;

        public Garage(int capacity)
        {
            if (capacity <= 0) throw new ArgumentException("Capacity must be > 0", nameof(capacity));
            Capacity = capacity;
            _items = new T[capacity];
            _count = 0;
        }

        public bool Add(T vehicle, out string message)
        {
            if (vehicle == null)
            {
                message = "The vehicle is null.";
                return false;
            }

            if (_count >= Capacity)
            {
                message = "The garage is full..";
                return false;
            }

            if (FindByRegistration(vehicle.RegistrationNumber) != null)
            {
                message = $"A vehicle with a registration number {vehicle.RegistrationNumber} already exists.";
                return false;
            }

            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null)
                {
                    _items[i] = vehicle;
                    _count++;
                    message = $"Vehicle {vehicle.RegistrationNumber} parked.";
                    return true;
                }
            }

            message = "Could not add the vehicle for unknown reason.";
            return false;
        }

        private object FindByRegistration(object registrationNumber)
        {
            throw new NotImplementedException();
        }

        public T Remove(string registrationNumber, out string message)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                message = "Invalid registration number.";
                return default;
            }

            var idx = FindIndexByRegistration(registrationNumber);
            if (idx < 0)
            {
                message = $"No vehicle with registration number {registrationNumber} found.";
                return default;
            }

            var v = _items[idx];
            _items[idx] = default;
            _count--;
            message = $"Vehicle {v.RegistrationNumber} retrieved.";
            return v;
        }

        public T FindByRegistration(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber)) return default;
            var regUpper = registrationNumber.Trim().ToUpperInvariant();
            foreach (var item in _items)
            {
                if (item == null) continue;
                if (item.RegistrationNumber.ToUpperInvariant() == regUpper) return item;
            }
            return default;
        }

        private int FindIndexByRegistration(string registrationNumber)
        {
            if (string.IsNullOrWhiteSpace(registrationNumber)) return -1;
            var regUpper = registrationNumber.Trim().ToUpperInvariant();
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] == null) continue;
                if (_items[i].RegistrationNumber.ToUpperInvariant() == regUpper) return i;
            }
            return -1;
        }

        public IEnumerable<T> GetAll()
        {
            foreach (var item in _items)
                if (item != null) yield return item;
        }

        public Dictionary<string, int> CountByType()
        {
            var dict = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (var v in GetAll())
            {
                var key = v.VehicleType;
                if (dict.ContainsKey(key)) dict[key]++;
                else dict[key] = 1;
            }
            return dict;
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            if (predicate == null) yield break;
            foreach (var v in GetAll())
            {
                if (predicate(v)) yield return v;
            }
        }

        public void Populate(IEnumerable<T> vehicles)
        {
            if (vehicles == null) return;
            foreach (var v in vehicles)
            {
                if (_count >= Capacity) break;
                Add(v, out var _);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _items)
                if (item != null) yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
