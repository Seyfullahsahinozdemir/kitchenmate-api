using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class FoodImageFile: File
    {
        public Food Food { get; set; }
    }
}
