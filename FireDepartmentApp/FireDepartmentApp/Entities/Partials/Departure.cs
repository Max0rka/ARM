using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireDepartmentApp.Entities
{
    public partial class Departure
    {
        [XmlIgnore]
        public Settlement Settlement { get; set; }
        [XmlIgnore]
        public string AddressName
        {
            
            get
            {
                //string addressName = $"{DepartureArea.Settlement.SettlementName}, р-н выезда {DepartureArea.DepartureAreaName}, {Street.StreetName}";
                string addressName = "";
                if (DepartureArea != null && DepartureArea.Settlement != null)
                    addressName += $"{DepartureArea.Settlement.SettlementName}, р-н выезда {DepartureArea.DepartureAreaName}";
                if (Street != null)
                    addressName += $", ул. {Street.StreetName}";
                if (NumHouse != null && NumHouse.Length > 0)
                    addressName += $", д.{NumHouse}";
                if (NumCorp != null && NumCorp.Length > 0)
                    addressName += $", корп.{NumCorp}";
                if (NumAppart != null && NumAppart.Length > 0)
                    addressName += $", кв.{NumAppart}";
                return addressName;
            }
        }
        [XmlIgnore]
        public string ListBurnTypes
        {
            get
            {
                string burnTypes = "";
                foreach (var i in DepartureBurns)
                    burnTypes += $"{i.BurnType.BurnTypeName}, ";
                if (burnTypes.Length > 2)
                    burnTypes = burnTypes.Remove(burnTypes.Length - 2);
                return burnTypes;
            }
        }
        [XmlIgnore]
        public string ApplicantInfo
        {
            get
            {
                string applicantInfo = "";
                if (FIOApplicant != null && FIOApplicant.Length > 0)
                    applicantInfo += FIOApplicant;
                if (ApplicantPhone != null && ApplicantPhone.Length > 0)
                    applicantInfo += $" {ApplicantPhone}";
                return applicantInfo;
            }
        }
        //public string SignInfo { get; set; }
        //public string SignAddInfo { get; set; }

        //public string ThreatPeople { get; set; }
        //public string ThreatCountPeople { get; set; }
        //public string AddThreatPeople { get; set; }

        //public string Affected { get; set; }
        //public string AffectedCount { get; set; }
        //public string AddAffected { get; set; }

        //public string StatePeople { get; set; }
        //public List<string> StatePeoples = new List<string>();
        //public string AddStatePeople { get; set; }

        //public string Location { get; set; }
        //public List<string> Locations = new List<string>();
        //public string AddLocation { get; set; }

        //public string ThreatFire { get; set; }
        //public string AddThreatFire { get; set; }

        //public string ObjectInfo { get;set; }
        //public List<string> Objects = new List<string>();
        //public string AddObjectInfo { get;set; }

        //public string Place { get; set; }
        //public string AddPlace { get; set; }

        //public string Barrier { get; set; }
        //public string AddBarrier { get; set; }

        //public string MeetMCS { get; set; }
        //public string AddMeetMCS { get; set; }

        //public string Why { get; set; }
        //public string AddWhy { get; set; }

        //public string FIO { get; set; }
        
    }
}
