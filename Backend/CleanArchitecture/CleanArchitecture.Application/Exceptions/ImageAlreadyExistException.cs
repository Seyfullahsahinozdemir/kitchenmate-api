using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Exceptions
{
    public class ImageAlreadyExistException: Exception
    {
        public ImageAlreadyExistException() : base("Image already exist") { }
    }
}
