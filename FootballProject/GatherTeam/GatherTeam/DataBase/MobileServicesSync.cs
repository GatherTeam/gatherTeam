using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GatherTeam.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;

namespace GatherTeam.DataBase
{
    public static class MobileServicesSync
    {

        public static async void InitSQLiteStore()
        {

            if (!App.MobileService.SyncContext.IsInitialized)
            {

                var store = new MobileServiceSQLiteStore("Games.db");

                store.DefineTable("GamesTable", new JObject());

                await App.MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            }

        }

        public static async void InsertItem(GameModel item)
        {

            IMobileServiceSyncTable table = App.MobileService.GetSyncTable("GamesTable");
            JObject jsonObject = JObject.FromObject(item);
            JObject obj = new JObject();
            await table.InsertAsync(obj);

        }

        public static async void Push()
        {

            string errorString = null;

            try
            {

                CancellationToken token = new CancellationToken();

                await App.MobileService.SyncContext.PushAsync(token);

            }
            catch (MobileServicePushFailedException ex)
            {

                errorString = "Push failed because of sync errors: " + ex.PushResult.Errors.Count() + ", message: " + ex.Message;

            }
            catch (Exception ex)
            {

                errorString = "Push failed: " + ex.Message;

            }

        }

    }
}
