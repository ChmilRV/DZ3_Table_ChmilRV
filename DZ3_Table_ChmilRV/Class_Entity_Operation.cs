using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3_Table_ChmilRV
{
	static class Class_Entity_Operation
	{
      public static async Task AddTableEntity(TableEntity entity)
      {
         // Add the newly created entity.
         try
         {
            await Program.tableClient.AddEntityAsync(entity);
            Console.WriteLine($"{entity.RowKey}: Продукт - {entity["Product"]} кол-во - {entity["Quantity"]}  цена ${entity.GetDouble("Price")}.");
         }
         catch
         {
         }
         return;
      }


      public static void QueryToTableEntity()
      {
         Pageable<EntityModel> queryResultsFilter = Program.tableClient.Query<EntityModel>(ent => ent.Price >= 6);

         Console.WriteLine($"\nЗапрос (Price >= 6) вернул {queryResultsFilter.Count()} записей.");
         Console.WriteLine("Список выбранных данных:");

         // Iterate the <see cref="Pageable"> to access all queried entities.
         foreach (EntityModel qEntity in queryResultsFilter)
         {
            Console.WriteLine($"Продукт - {qEntity.Product} кол-во - {qEntity.Quantity} цена - {qEntity.Price}");
         }
         return;
      }


      public static async Task DeleteTableEntity(string partitionKey, string rowKey)
      {
         // Delete the entity given the partition and row key.
         await Program.tableClient.DeleteEntityAsync(partitionKey, rowKey);
         Console.WriteLine($"Запись с partitionKey = {partitionKey} и rowKey = {rowKey} удалена!!!");
         return;
      }





   }
}
