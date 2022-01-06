using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService_2Way_20190140029
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceCallback : IServiceCallback
    {
        Dictionary<IClientCallback,string> userList = new Dictionary<IClientCallback,string>(); // Menyimpan data ketika user online
        public void gabung(string userrname)
        {
            IClientCallback koneksiGabung = OperationContext.Current.GetCallbackChannel<IClientCallback>(); //Untuk menampung user ketika baru daftar/buat akun
            userList[koneksiGabung] = userrname;
        }

        public void kirimPesan(string pesan)
        {
            IClientCallback koneksiPesan = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            string user;
            if(!userList.TryGetValue(koneksiPesan, out user))
            {
                return;

            }
            foreach(IClientCallback other in userList.Keys)
            {
                other.pesanKirim(user, pesan);
            }
        }
    }
}
