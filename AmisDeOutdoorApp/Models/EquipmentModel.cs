using System;

namespace AmisDeOutdoorApp.Models
{
    /// <summary>
    /// Represents a piece of equipment for a hike.
    /// </summary>
    public class Equipment
    {
        private string name;
        private int available;
        private int max;

        /// <summary>
        /// Gets or sets the name of the equipment.
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.", nameof(value));
                }
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of available items.
        /// </summary>
        public int Available
        {
            get => available;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Available items cannot be negative.");
                }
                available = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of items.
        /// </summary>
        public int Max
        {
            get => max;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Max items cannot be negative.");
                }
                if (value < Available)
                {
                    throw new ArgumentException("Max items cannot be less than available items.", nameof(value));
                }
                max = value;
            }
        }
    }
}
