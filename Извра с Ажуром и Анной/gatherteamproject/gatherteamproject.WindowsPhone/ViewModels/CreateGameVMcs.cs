using System.Collections.ObjectModel;
using System.Linq;
using gatherteamproject;
using gatherteamproject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using gatherteamproject.Views;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace gatherteamproject.ViewModels
{
    public class CreateGameVM : BaseViewModel
    {

        public event OpenPageDelegate CreateEvent;
        private DelegateCommand _createCommand;

        private readonly ObservableCollection<string> _gameFormats = new ObservableCollection<string> { "5x5", "6x6", "другой" };

        public ObservableCollection<string> GameFormats { get { return _gameFormats; } }

        public ObservableCollection<string> ListOfAddresses
        {
            get
            {
//                UpdateDataBase();
                var list = new ObservableCollection<string>();
                if (items == null) return list;
                foreach (var todoItem in items)
                {
                    list.Add(todoItem.Text);
                }
                return list;
            }
        }

        private async void UpdateDataBase()
        {
            await RefreshTodoItems();
        }

        public DelegateCommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new DelegateCommand(o => Create());
                }

                return _createCommand;
            }
        }

        private MobileServiceCollection<TodoItem, TodoItem> items;
        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();

        private async Task InsertTodoItem(TodoItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);
        }

        private async Task RefreshTodoItems()
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                // This code refreshes the entries in the list view by querying the TodoItems table.
                // The query excludes completed TodoItems
                items = await todoTable
                    .Where(todoItem => todoItem.Complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                //ListItems.ItemsSource = items;
                //this._createComman.IsEnabled = true;
            }
        }

        private async Task UpdateCheckedTodoItem(TodoItem item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
           // ListItems.Focus(Windows.UI.Xaml.FocusState.Unfocused);
        }

        private async void Create()
        {

//            var todoItem = new TodoItem { Text = "Success2!" };
//            await InsertTodoItem(todoItem);
            
           if (CreateEvent != null) CreateEvent();
           /*  DataBase.LocalDB.InsertItem(new Models.GameModel
            {
                Id = "ololo",
                Format = GameModel.GameFormat.SixToSix,
                GameAddress = new GameAddress(),
                GameName = "thisis sparta!!!11!!",
                Time = "11:22",
                Version = "first"
            });
            DataBase.LocalDB.Push();*/
        }
    }
}
