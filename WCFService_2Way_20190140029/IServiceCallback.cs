using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService_2Way_20190140029
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void gabung(string userrname);

        [OperationContract(IsOneWay = true)]
        void kirimPesan(string pesan);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFService_2Way_20190140029.ContractType".
}
