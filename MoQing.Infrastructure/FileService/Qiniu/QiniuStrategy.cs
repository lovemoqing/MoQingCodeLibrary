using MoQing.Domain;
using MoQing.Infrastructure.Config;
using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Infrastructure.FileService
{
    /// <summary>
    /// 七牛云OSS文件操作策略基类，具体的实现
    /// </summary>
    public class QiniuStrategy : AbstractFileStrategy
    {
        public override ApiResult Upload(string bucket, string saveKey, byte[] data)
        {
            var AK = ConfigExtensions.Configuration["Qiniu:AK"];
            var SK = ConfigExtensions.Configuration["Qiniu:SK"];
            // 生成(上传)凭证时需要使用此Mac
            // 这个示例单独使用了一个Settings类，其中包含AccessKey和SecretKey
            // 实际应用中，请自行设置您的AccessKey和SecretKey
            Mac mac = new Mac(AK, SK);
            // 上传策略，参见 
            // https://developer.qiniu.com/kodo/manual/put-policy
            PutPolicy putPolicy = new PutPolicy();
            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            // putPolicy.Scope = bucket + ":" + saveKey;
            putPolicy.Scope = bucket;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            // 上传到云端多少天后自动删除该文件，如果不设置（即保持默认默认）则不删除
            putPolicy.DeleteAfterDays = 1;
            // 生成上传凭证，参见
            // https://developer.qiniu.com/kodo/manual/upload-token
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);
            FormUploader fu = new FormUploader();
            HttpResult result = fu.UploadData(data, saveKey, token);
            return new ApiResult() { Code = result.Code };
        }
        public override ApiResult DownLoad(string onlineUrl, string savaPath)
        {
            HttpResult result = DownloadManager.Download(onlineUrl, savaPath);
            return new ApiResult() { Code = result.Code };
        }
    }
}
