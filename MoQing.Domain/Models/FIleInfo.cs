using MoQing.Domain;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoQing.Domain
{
    [SugarTable("TB_FileInfo")]
    public class FileInfo: IEntity
    {
        public int ID { get; set; }
        public string id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get; set; }
        /// <summary>
        /// 文件类型：图片、视频、音频等
        /// </summary>
        public string Type { get; set; }
        public double Size { get; set; }
        public DateTime CreateTime { get; set; }
        public int IsDelete { get; set; }
        public string Remarks { get; set; }
    }
}
