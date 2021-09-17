using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DZ3_Table_ChmilRV
{
	public class AppSettings
	{

		public string StorageConnectionString { get; set; }
		public string TableName { get; set; }

		public AppSettings()
		{
			var json = File.ReadAllText("AppSetting.json");
			var appSettings = JsonDocument.Parse(json, new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip });
			StorageConnectionString = appSettings.RootElement.GetProperty("StorageConnectionString").GetString();
			TableName = appSettings.RootElement.GetProperty("TableName").GetString();
		}




	}
}
