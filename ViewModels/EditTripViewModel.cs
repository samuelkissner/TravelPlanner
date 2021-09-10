using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelPlanner.ViewModels
{
    public class EditTripViewModel : CreateTripViewModel
    {
        public int ID { get; set; }
        public string ExistingPhotoPath{ get; set; }
    }
}
