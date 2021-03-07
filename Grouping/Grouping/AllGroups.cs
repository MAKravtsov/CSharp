using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouping
{
    class AllGroups
    {
        public List<UniqueGroup> uniqueGroups;
        public List<NonuniqueGroup> nonuniqueGroups;
        public Group[] groups;

        public AllGroups (Group[] gr)
        {
            groups = gr;
            uniqueGroups = new List<UniqueGroup>() ;
            nonuniqueGroups = new List<NonuniqueGroup>() ;
        }
   
    }
}
