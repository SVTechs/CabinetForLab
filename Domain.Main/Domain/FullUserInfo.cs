using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class FullUserInfo
    {
        public virtual string ID { get; set; }

        public virtual long TemplateId { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Sex { get; set; }

        public virtual int Age { get; set; }

        public virtual string Tel { get; set; }

        public virtual string Address { get; set; }

        public virtual int UserState { get; set; }

        public virtual DateTime Createtime { get; set; }

        public virtual string CreateUser { get; set; }

        public virtual DateTime Updatetime { get; set; }

        public virtual string UpdateUser { get; set; }

        public virtual string CardNum { get; set; }

        public virtual string Image { get; set; }

        public virtual byte[] FaceFeature { get; set; }

        public virtual byte[] FingerFeature { get; set; }

        public virtual int IsProtected { get; set; }

        public virtual object BDFaceFeature { get; set; }

        public virtual string UserStateResult { get => UserState == 1 ? "启用" : "禁用"; }

        public virtual bool HasImage { get => FaceFeature != null; }

        public virtual bool HasFingerFeature { get => FingerFeature != null; }
    }
}
