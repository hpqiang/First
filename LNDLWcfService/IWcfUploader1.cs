﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace LNDLWcfService
{
    [DataContract]
    public class UploadedFile
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public int FileLength { get; set; }

        [DataMember]
        public string FileName { get; set; }

        //Other information. On upload only path and size are obvious.
        //...
    }

    [ServiceContract(Name = "IWCFUploader")]
    public interface IWCFUploader
    {
        [OperationContract(Name = "Upload")]
        [DataContractFormat]
        [WebInvoke(Method = "POST",
                    UriTemplate = "Upload/",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Upload(Stream Uploading);

        [OperationContract(Name = "Transform")]
        [DataContractFormat]
        [WebInvoke(Method = "POST",
                    UriTemplate = "Transform",
                    BodyStyle = WebMessageBodyStyle.Bare,
                    ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Transform(UploadedFile Uploading, string FileName);
    } 

}