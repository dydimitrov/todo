using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace TodoListApp
{
    partial class TodoListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TodoItem> TodoItems { get; set; }

        public TodoListViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>();
        }

        public ICommand AddTodoCommand => new Command(AddTodoItem);

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _newTodoInputValue;
        public string NewTodoInputValue
        {
            get
            {
                return _newTodoInputValue;
            }
            set
            {
                if (value != this._newTodoInputValue)
                {
                    _newTodoInputValue = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public ICommand RemoveTodoCommand => new Command(RemoveTodoItem);

        public ICommand RemoveAllCommand => new Command(RemoveAllItem);
        public ICommand MarkAllDoneCommand => new Command(MarkAllDone);

        void AddTodoItem()
        {
            TodoItems.Add(new TodoItem(NewTodoInputValue, false));
            NewTodoInputValue = String.Empty;
        }

        void RemoveTodoItem(object o)
        {
            TodoItem todoItemBeingRemoved = o as TodoItem;
            TodoItems.Remove(todoItemBeingRemoved);
        }

        void RemoveAllItem(object o)
        {
            TodoItems.Clear();
        }
        void MarkAllDone(object o)
        {            
            foreach (var item in TodoItems)
            {
                item.Complete = true;
            }
        }
    }
}
