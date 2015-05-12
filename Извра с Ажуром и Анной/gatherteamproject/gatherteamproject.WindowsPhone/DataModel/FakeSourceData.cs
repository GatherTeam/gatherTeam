using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using gatherteamproject.DataModel;
using gatherteamproject.Views;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

namespace gatherteamproject
{
   public class FakeSourceData
    {
        private readonly IMobileServiceTable<FieldAddress> _fieldTable = App.MobileService.GetTable<FieldAddress>();
        private readonly IMobileServiceTable<GameAddress> _gameTable = App.MobileService.GetTable<GameAddress>();

        public string Date { get; set; }

        public DateTime Date2 { get; set; }

        public string Time { get; set; }    

        public string Address { get; set; }

        public static IEnumerable<FakeSourceData> GetData()
        {
            var handMadeData = new[]
            {
                new FakeSourceData { Date = "Today", Time = "15.00", Address = "221b Baker Street" },
                new FakeSourceData { Date = "Today", Time = "15.00", Address = "32 Windsor Gardens" },
                new FakeSourceData { Date = "Today", Time = "15.00", Address = "Buckingham Palace" },
                new FakeSourceData { Date = "Today", Time = "15.00", Address = "29 Acacia Road" },

                new FakeSourceData { Date = "Tomorrow", Time = "16.00", Address = "15 Jubilee Terrace" },
                new FakeSourceData { Date = "Tomorrow", Time = "16.30", Address = "13 Coronation Street" },

                new FakeSourceData { Date = "25th october", Time = "16.00", Address = "890 Fifth Avenue" },
                new FakeSourceData { Date = "25th october", Time = "16.40", Address = "Apartment 5E, 129 West 81st Street" },
               
            };

            var r = new Random(1);
            var generatedData =
                from i in Enumerable.Range(0, 1000)
                select new FakeSourceData
                {
                    Date= "Data " + r.Next(1, 9),
                    Time = "Time " + r.Next(1, 9),
                    Address = "Address " + i
                };

            return handMadeData.Concat(generatedData);
        }


       /* private async void GetDate()
        {
            // Этот код обновляет записи в списке, выполняя запрос к таблице TodoItems.
            // Благодаря запросу "завершенные" дела не выводятся
            try
            {
                //Получаем из таблицы записи с флагом Complete, установленным в значение false
                Date2 = await _gameTable
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                //Сообщение, выводимое при возникновении в ходе загрузки ошибки
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            ListItems.ItemsSource = items;
        }*/
    }
}
