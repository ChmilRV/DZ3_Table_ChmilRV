using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3_Table_ChmilRV
{
	public class EntityModel : ITableEntity
	{

      public EntityModel()
      {
      }

      public EntityModel(string lastName, string firstName)
      {
         PartitionKey = lastName;
         RowKey = firstName;
      }

      public string PartitionKey { get; set; }
      public string RowKey { get; set; }

		public int Id { get; set; }
      public string Name { get; set; }
      public double Price { get; set; }
      public string Remark { get; set; }
      public string Note { get; set; }

      public ETag ETag { get; set; }
      public DateTimeOffset? Timestamp { get; set; }
   }
}
