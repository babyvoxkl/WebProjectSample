using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    [DataContract]
    public class GetApproveListRequest
    {
        [DataMember]
        public string DoctorCode { get; set; }

        [DataMember]
        public string DoctorRole { get; set; }

        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public string EndTime { get; set; }

        [DataMember]
        public string ExamineStatus { get; set; }

        [DataMember]
        public string DeptName { get; set; }

        [DataMember]
        public string AdminNo { get; set; }

        [DataMember]
        public string ApproveStatus { get; set; }

        [DataMember]
        public string StartRow { get; set; }

        [DataMember]
        public string EndRow { get; set; }
    }
}
