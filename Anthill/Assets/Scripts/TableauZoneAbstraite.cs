using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntSimulator
{
    public class TableauZoneAbstraite
    {
        public  ZoneAbstraite[] zoneAbstraiteList { get; set; }

        public TableauZoneAbstraite()
        {
            zoneAbstraiteList = new ZoneAbstraite[FourmiliereConstante.NbCase];
        }
    }
}
