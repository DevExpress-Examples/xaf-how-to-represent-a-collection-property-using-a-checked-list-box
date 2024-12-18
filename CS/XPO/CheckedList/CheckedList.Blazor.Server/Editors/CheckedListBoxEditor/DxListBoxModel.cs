using DevExpress.Blazor;
using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace CheckedList.Blazor.Server.Editors {
    public class DxListBoxModel : ComponentModelBase {
        public bool ReadOnly {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
        public string TextFieldName {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }
        public ListBoxSelectionMode SelectionMode {
            get => GetPropertyValue<ListBoxSelectionMode>();
            set => SetPropertyValue(value);
        }
        public bool ShowCheckboxes {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
    }
    public class DxListBoxModel<TData, TValue> : DxListBoxModel {
        public IEnumerable<TData> Data {
            get => GetPropertyValue<IEnumerable<TData>>();
            set => SetPropertyValue(value);
        }
        public IEnumerable<TValue> Values {
            get => GetPropertyValue<IEnumerable<TValue>>();
            set => SetPropertyValue(value);
        }
        public EventCallback<IEnumerable<TValue>> ValuesChanged {
            get => GetPropertyValue<EventCallback<IEnumerable<TValue>>>();
            set => SetPropertyValue(value);
        }
        public override Type ComponentType => typeof(DxListBox<TData, TValue>);
    }
}
