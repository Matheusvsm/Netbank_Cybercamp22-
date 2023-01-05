using System.Text.Json.Serialization;

namespace Osb.Core.Platform.Integration.Entity.FitBank.Models.Response
{
    public class FindInfoPixQRCodeResponse : BaseResponse
    {

        public long SearchProtocol { get; set; }
        public InfosPixQRCode Infos { get; set; }
    }
}