using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBillsv2
{
    class StudentType
    {
        public bool IsBak;
        public bool IsMast;
        public bool IsSpec;
        public bool Is15F;

        public StudentType()
        {

        }

        public bool IsEqual ( StudentType st)
        {
            return (IsBak == st.IsBak && IsBak) || (IsSpec == st.IsSpec && IsSpec) || (IsMast == st.IsMast && IsMast);
        }
    }
}
