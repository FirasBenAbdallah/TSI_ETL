using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSI_ERP_ETL.Models.GetAllPaged
{
    public enum OperatorType
    {
        EQUAL,
        LESSOREQUAL,
        GREATEROREQUAL,
        LESS,
        GREATER,
        NOTEQUAL,
        CONTAINS,
        STARTSWITH,
        ENDSWITH,
        DATEIS,
        DATEISNOT,
        DATEISBEFORE,
        DATEISAFTER,
        NOTCONTAINS
    }
}

