using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GatherTeam.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;    


namespace GatherTeam.DataBase
{
    public static class LocalDB
    {
        public static async void InitSQLiteStore()
        {
            
              if (!App.GatherTeamBackendClient.SyncContext.IsInitialized)
              {
                    var store = new MobileServiceSQLiteStore("UserGames.db");
                    store.DefineTable<Models.GameModel>();
                    await App.GatherTeamBackendClient.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
                }
        }
        

        public static async void InsertItem(Models.GameModel item)
        {
            IMobileServiceSyncTable<Models.GameModel> table = App.GatherTeamBackendClient.GetSyncTable<Models.GameModel>();
            await table.InsertAsync(item);
        }

        public static async void Push() {
            string errorString = null;
            try {
                CancellationToken token = new CancellationToken();
                await App.GatherTeamBackendClient.SyncContext.PushAsync(token);
            } 
            catch (MobileServicePushFailedException ex) {
                errorString = "Push failed because of sync errors: " + 
                    ex.PushResult.Errors.Count() + ", message: " + ex.Message;
            } 
            catch (Exception ex) {
                errorString = "Push failed: " + ex.Message;
            }
        }
    }
}
