using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krankenhausverwaltung
{
    public enum Branch
    {
        AUGEN = 0,
        INNERE = 1,
        HNO = 2,
        UNDIFINED = int.MaxValue
    }

    class BranchClass
    {
        public static string BranchToString(Branch branch)
        {
            switch (branch)
            {
                case Branch.AUGEN:
                    return "Augen";

                case Branch.HNO:
                    return "HNO";

                case Branch.INNERE:
                    return "Innere";

            }
            return "undifined";
        }
        public static Branch StringToBranch(string branch)
        {
            switch (branch.ToLower())
            {
                case "augen":
                    return Branch.AUGEN;

                case "hno":
                    return Branch.HNO;

                case "innere":
                    return Branch.INNERE;

            }
            return Branch.INNERE;
        }
    }
}
