using System.Collections.ObjectModel;
using AmisDeOutdoorApp.Models;

namespace AmisDeOutdoorApp.ViewModels
{
    /// <summary>
    /// ViewModel for managing a list of hiking equipment.
    /// </summary>
    public class EquipmentViewModel
    {
        /// <summary>
        /// Gets the list of equipment.
        /// </summary>
        public ObservableCollection<Equipment> EquipmentList { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipmentViewModel"/> class with sample data.
        /// </summary>
        public EquipmentViewModel()
        {
            EquipmentList = new ObservableCollection<Equipment>
            {
                new Equipment { Name = "Boots", Available = 1, Max = 4 },
                new Equipment { Name = "Backpack", Available = 2, Max = 5 },
                new Equipment { Name = "Tent", Available = 1, Max = 2 },
                new Equipment { Name = "Sleeping Bag", Available = 3, Max = 3 },
                new Equipment { Name = "Map", Available = 0, Max = 2 }
            };
        }
    }
}
