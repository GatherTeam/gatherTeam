using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using gatherteamproject.DataModel;
using gatherteamproject.Views;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

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
//                    list.Add(todoItem.Text);
                }
                return list;
            }
        }

        public string GameMode
        {
            get { return _gameMode; }
            set
            {
                _gameMode = value;
                NotifyPropertyChanged("GameMode");
            }
        }

        public string SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;
                NotifyPropertyChanged("SelectedAddress");
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

        private MobileServiceCollection<GameAddress, GameAddress> items;
        private IMobileServiceTable<GameAddress> todoTable = App.gathertearmserviceClient.GetTable<GameAddress>();
        private string _selectedAddress;
        private string _gameMode;
        private async Task InsertTodoItem(GameAddress todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an id, the item is added to the CollectionView

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
//                items = await todoTable
//                    .Where(todoItem => todoItem.GameFieldX == 10.4)
//                    .ToCollectionAsync();
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

        private async Task UpdateCheckedTodoItem(GameAddress item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the gathertearmserviceClient 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
        }

     

        private async void Create()
        {
            var newGame = new GameAddress();
            newGame.Id = Guid.NewGuid().ToString();
            newGame.GameFieldAddressString = "AddressString";
            newGame.GameFieldX = 10f;
            newGame.GameFieldY = 11f;
            try
            {
                await InsertTodoItem(newGame);
            }
            catch (Exception e)
            {
            }
           if (CreateEvent != null) CreateEvent();
        }
    }
}
