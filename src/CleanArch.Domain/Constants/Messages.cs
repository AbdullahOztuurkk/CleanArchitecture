using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Constants
{
    public static class Messages
    {
        public const string CREATED_NOTE_SUCCESSFULLY = "Note has been added successfully";
        public const string DELETED_NOTE_PERMANENTLY = "Note has been deleted permanently";

        public const string CREATED_TAG_SUCCESSFULLY = "Tag has been added successfully";
        public const string DELETED_TAG_PERMANENTLY = "Tag has been deleted permanently";

        public const string ERROR_OCCURRED = "Error occurred. Please try again later!";
        public const string VALIDATION_ERROR = "Some values are not valid. Please try again.";

    }
}
