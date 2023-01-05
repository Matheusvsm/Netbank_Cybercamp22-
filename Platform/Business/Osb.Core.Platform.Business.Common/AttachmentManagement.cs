using System;
using System.IO;

namespace Osb.Core.Platform.Business.Common
{
    public class  AttachmentManagement
    {
        public void SaveAttachment(string attachmentFileName,  string content)
        {
            byte[] imageBytes = Convert.FromBase64String(content);
            File.WriteAllBytes(attachmentFileName, imageBytes);
        }

    }
}