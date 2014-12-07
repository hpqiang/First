using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfProductService.EFDAL;

namespace WcfProductService
{
    [ServiceContract]
    public interface IProductService
    {

        [OperationContract]
        List<tblProduct> GetProductEntities();
        [OperationContract]
        List<tblCurtain> GetCurtainEntities();
        [OperationContract]
        List<tblFabric> GetFabricEntities();
        [OperationContract]
        List<tblBed> GetBedEntities();
        [OperationContract]
        string GetMessage(string name);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

    }


    //// 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}
}
