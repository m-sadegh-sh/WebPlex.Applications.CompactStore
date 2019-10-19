namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Models;

    public static class TempDateHelpers {
        private const string MESSAGES_KEY = "__Messages__";

        public static void AddResult(TempDataDictionary tempData, OperationModel result) {
            var results = GetMessages(tempData);

            results.Add(result);
        }

        public static ICollection<OperationModel> GetMessages(TempDataDictionary tempData) {
            var results = tempData[MESSAGES_KEY] as ICollection<OperationModel>;
            if (results == null)
                tempData[MESSAGES_KEY] = results = new Collection<OperationModel>();

            return results;
        }
    }
}
