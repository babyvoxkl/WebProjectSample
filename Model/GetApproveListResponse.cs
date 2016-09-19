using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    [DataContract]
    public class GetApproveListResponse
    {
        [DataMember]
        public int ResultCode { get; set; }

        [DataMember]
        public string ResultMessage { get; set; }

        [DataMember]
        public int TotalRow { get; set; }
        [DataMember]
        public List<KssApply> Apply { get; set; }
    }

    [Serializable]
    [DataContract]
    public class KssApply
    {
        [DataMember]
        public string ApplyNo { get; set; }

        [DataMember]
        public string PaientNo { get; set; }

        [DataMember]
        public string PaientName { get; set; }

        [DataMember]
        public string PaientBedNo { get; set; }

        [DataMember]
        public string PaientAreaName { get; set; }

        [DataMember]
        public string SpecialDrugName { get; set; }

        [DataMember]
        public string ApplyTime { get; set; }

        [DataMember]
        public string ApplyOperate { get; set; }

        [DataMember]
        public string ExamineTime { get; set; }

        [DataMember]
        public string ExpertNo { get; set; }

        [DataMember]
        public string ExpertName { get; set; }

        [DataMember]
        public string DrugNo { get; set; }

        [DataMember]
        public string ApplyState { get; set; }

        [DataMember]
        public string PaientAreaCode { get; set; }

        [DataMember]
        public string Detail { get; set; }

        [DataMember]
        public string Bak1 { get; set; }

        [DataMember]
        public string Bak2 { get; set; }

        [DataMember]
        public string KssPurpose { get; set; }
    }
}
