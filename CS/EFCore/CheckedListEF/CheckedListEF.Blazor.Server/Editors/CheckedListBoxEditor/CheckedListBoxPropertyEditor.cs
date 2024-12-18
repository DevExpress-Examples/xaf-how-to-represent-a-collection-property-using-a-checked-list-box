using DevExpress.Blazor;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace CheckedListEF.Blazor.Server.Editors {

    [PropertyEditor(typeof(IList<object>), false)]
    public class CheckedListBoxPropertyEditor : BlazorPropertyEditorBase, IComplexViewItem {
        private static readonly ConcurrentDictionary<Type, Func<CheckedListBoxPropertyEditor, IComponentModel>> createComponentModelDelegateByType = new ConcurrentDictionary<Type, Func<CheckedListBoxPropertyEditor, IComponentModel>>();
        private static Func<CheckedListBoxPropertyEditor, IComponentModel> CreateCreateComponentModelDelegate(Type listElementType) {
            ParameterExpression propertyEditor = Expression.Parameter(typeof(CheckedListBoxPropertyEditor), nameof(propertyEditor));
            Expression createComponentAdapterCall = Expression.Call(propertyEditor, nameof(CreateComponentModel), new Type[] { listElementType });
            return Expression.Lambda<Func<CheckedListBoxPropertyEditor, IComponentModel>>(createComponentAdapterCall, propertyEditor).Compile();
        }
        private XafApplication application;
        private IObjectSpace objectSpace;
        public override DxListBoxModel ComponentModel => (DxListBoxModel)base.ComponentModel;
        public CheckedListBoxPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentModel CreateComponentModel() => createComponentModelDelegateByType.GetOrAdd(MemberInfo.ListElementType, CreateCreateComponentModelDelegate)(this);
        private IComponentModel CreateComponentModel<T>() {
            var componentModel = new DxListBoxModel<T, T>();
            componentModel.TextFieldName = application.Model.BOModel.GetClass(MemberInfo.ListElementTypeInfo.Type).DefaultProperty;
            componentModel.SelectionMode = ListBoxSelectionMode.Multiple;
            componentModel.ShowCheckboxes = true;
            componentModel.ValuesChanged = EventCallback.Factory.Create<IEnumerable<T>>(this, values => {
                componentModel.Values = values;
                OnControlValueChanged();
                WriteValue();
            });
            SetDataSource = (model, data) => ((DxListBoxModel<T, T>)model).Data = ((IEnumerable)data)?.Cast<T>();
            GetControlValue = (model) => ((DxListBoxModel<T, T>)model).Values;
            SetControlValue = (model, value) => ((DxListBoxModel<T, T>)model).Values = (IEnumerable<T>)value;
            SetDataSource(componentModel, GetDataSource());
            return componentModel;
        }
        protected override void ApplyReadOnly() {
            base.ApplyReadOnly();
            if(ComponentModel is not null) {
                ComponentModel.ReadOnly = !AllowEdit;
            }
        }
        private object GetDataSource() => objectSpace.GetObjects(MemberInfo.ListElementType);
        protected override object GetControlValueCore() => GetControlValue(ComponentModel);
        protected override void ReadValueCore() {
            base.ReadValueCore();
            SetControlValue(ComponentModel, PropertyValue);
        }
        protected override void WriteValueCore() {
            var propertyList = (IList)PropertyValue;
            var actualObjects = (IEnumerable<object>)ControlValue;

            var objectsToLink = new HashSet<object>(actualObjects);
            var objectsToUnlink = new HashSet<object>();

            foreach(var obj in propertyList) {
                objectsToLink.Remove(obj);
                if(!actualObjects.Contains(obj)) {
                    objectsToUnlink.Add(obj);
                }
            }
            foreach(var obj in objectsToUnlink) {
                propertyList.Remove(obj);
            }
            foreach(var obj in objectsToLink) {
                propertyList.Add(obj);
            }

            objectSpace.SetModified(CurrentObject);
        }
        protected override void OnCurrentObjectChanged() {
            if(ComponentModel is not null) {
                SetDataSource(ComponentModel, GetDataSource());
            }
            base.OnCurrentObjectChanged();
        }
        protected override bool IsMemberSetterRequired() => false;
        private Action<IComponentModel, object> SetDataSource { get; set; }
        private Action<IComponentModel, object> SetControlValue { get; set; }
        private Func<IComponentModel, object> GetControlValue { get; set; }
        public override void BreakLinksToControl(bool unwireEventsOnly) {
            SetDataSource = null;
            base.BreakLinksToControl(unwireEventsOnly);
        }
        #region IComplexPropertyEditor Members
        public void Setup(IObjectSpace objectSpace, XafApplication application) {
            this.objectSpace = objectSpace;
            this.application = application;
        }
        #endregion
    }
}
