using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiers.Core
{
    public enum UserRole
    {
        Public,
        Authenticated,
        Admin,
    };

    public static class Constants
    {
        public const int MinQueryLength = 2;
        public const int MaxQueryLength = 100;

        public const bool StripSpecialCharacters = true;
    }
}
