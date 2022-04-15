using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TodoListApp
{
    public class TodoItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private bool complete;
        public string TodoText { get; set; }

        public bool Complete
        {
            get { return complete; }
            set
            {
                complete = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Complete"));
            }
        }
        public TodoItem(string TodoText, bool Complete)
        {
            this.TodoText = TodoText;
            this.Complete = Complete;
        }
    }
}
