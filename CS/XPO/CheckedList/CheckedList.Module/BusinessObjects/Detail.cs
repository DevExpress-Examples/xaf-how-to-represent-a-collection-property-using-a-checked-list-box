using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace CheckedList.Module {
    [DefaultClassOptions]
    public class Detail : BaseObject {
        public Detail(Session session) : base(session) { }
        private string _DetailName;
        public string DetailName {
            get { return _DetailName; }
            set { SetPropertyValue("DetailName", ref _DetailName, value); }
        }
        private Master _Master;
        [Association("Master-Details")]
        public Master Master {
            get { return _Master; }
            set { SetPropertyValue("Master", ref _Master, value); }
        }
    }
}