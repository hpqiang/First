using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LNDLWcfService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                 InstanceContextMode = InstanceContextMode.PerCall,
                 IgnoreExtensionDataObject = true,
                 IncludeExceptionDetailInFaults = true)]
    public class WcfUploader : IWCFUploader
    {
        #region IWCFUploader Members

        public UploadedFile Upload(Stream Uploading)
        {

            Console.WriteLine("In Upload...");
            UploadedFile upload = new UploadedFile
            {
                FilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
            };

            Console.WriteLine(upload.FilePath.ToString());
            int length = 0;
            using (FileStream writer = new FileStream(upload.FilePath, FileMode.Create))
            {
                int readCount;
                var buffer = new byte[8192];
                while ((readCount = Uploading.Read(buffer, 0, buffer.Length)) != 0)
                {
                    writer.Write(buffer, 0, readCount);
                    length += readCount;
                }
            }

            upload.FileLength = length;

            return upload;
        }

        public UploadedFile Transform(UploadedFile Uploading, string FileName)
        {
            Uploading.FileName = FileName;
            return Uploading;
        }

        #endregion
    }
}
