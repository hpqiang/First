using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

//namespace LNDLWcfService
//{
//    [ServiceContract]
//    public interface IWCFUploader
//    {
//        [OperationContract]
//        //[OperationContract(Name = "Upload")]
//        //[DataContractFormat]
//        //[WebInvoke(Method = "POST",
//        //            UriTemplate = "Upload/",
//        //            BodyStyle = WebMessageBodyStyle.Bare,
//        //            ResponseFormat = WebMessageFormat.Json)]
//        UploadedFile Upload(Stream Uploading);

//        [OperationContract]
//        //[OperationContract(Name = "Transform")]
//        //[DataContractFormat]
//        //[WebInvoke(Method = "POST",
//        //            UriTemplate = "Transform",
//        //    //BodyStyle = WebMessageBodyStyle.Bare,
//        //            BodyStyle = WebMessageBodyStyle.Wrapped,
//        //            ResponseFormat = WebMessageFormat.Json)]
//        UploadedFile Transform(UploadedFile Uploading, string FileName);
//    }
    
//    [DataContract]
//    public class UploadedFile
//    {
//        [DataMember]
//        public string FilePath { get; set; }

//        [DataMember]
//        public int FileLength { get; set; }

//        [DataMember]
//        public string FileName { get; set; }

//        //Other information. On upload only path and size are obvious.
//        //...
//    }

//    //[ServiceContract(Name = "IWCFUploader")]

//}
