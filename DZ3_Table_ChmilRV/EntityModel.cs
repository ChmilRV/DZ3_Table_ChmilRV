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

      public string Product { get; set; }

      public double Price { get; set; }

      public int Quantity { get; set; }
      public DateTimeOffset? Timestamp { get; set; }
      public ETag ETag { get; set; }


   }
}
